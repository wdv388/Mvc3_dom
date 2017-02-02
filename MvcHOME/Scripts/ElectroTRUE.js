//ver 1.0
$(document).ready(function () {

    var benefit = $('#benefit').val();  //true or false
    var benefitPerson = $('#benefitPerson').val(); // 2 or 0
    var lim1 = parseInt($('#lim1').val()); // 100
    var lim2 = parseInt($('#lim2').val()); //600
    var lim3 = parseInt($('#lim3').val()); //75
    var TEL1 = parseFloat($('#TEL1').val()) / 100;//36.6
    var TEL2 = parseFloat($('#TEL2').val()) / 100;//63
    var TEL3 = parseFloat($('#TEL3').val()) / 100;//1.407
    var TEB = (TEL1 * 25) / 100;//tarif po pilge 75%

    $('#ED').focus(function () { 
        var ec = parseInt($('#EC').val());
        var ep = parseInt($('#EP').val());
        var ed = ec - ep;
        $('#ED').val(ed);
        $('#Privelege').val(0);
        $('#SumP').val(0);
        if (ed>=lim2) {
            var ed1 = ed - lim1;//900-100=800
            var ed2 = ed1 - lim2;//800-600=200
            $('#toLim').val(lim1);
            $('#fromLim').val(lim2);
            $('#overLim').val(ed2);
            var pr1 = lim1 * TEL1;
            var pr2 = lim2 * TEL2;
            var pr3 = ed2 * TEL3;
            $('#SumT').val(pr1);
            $('#SumF').val(pr2);
            $('#SumO').val(pr3);
            var sum = pr1 + pr2 + pr3;
            $('#Sum').val(sum);
            console.log(ed1,ed2,lim1,lim2);

        } else if (ed >= lim1) {
            var ed1 = ed - lim1;//500-100=400
            $('#toLim').val(lim1);
            $('#fromLim').val(ed1);
            $('#overLim').val(0);
            var pr1 = lim1 * TEL1;
            var pr2 = ed1 * TEL2;
            $('#SumT').val(pr1);
            $('#SumF').val(pr2);
            $('#SumO').val(0);
            var sum = pr1 + pr2;
            $('#Sum').val(sum);



        } else {
            $('#toLim').val(ed);
            $('#fromLim').val(0);
            $('#overLim').val(0);
            var pr1 = ed * TEL1;//50*0.36
            $('#SumT').val(pr1);
            $('#SumF').val(0);
            $('#SumO').val(0);
            var sum = pr1 ;
            $('#Sum').val(sum);

        }
       
        });

       


      



       


});