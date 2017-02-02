//to do: need to rewrite in switch case
//ver 2.0 benefit
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
        var ec = parseInt($('#EC').val());//potochni
        var ep = parseInt($('#EP').val());//poperedni
        var ed = ec - ep;//cposhito
        $('#ED').val(ed);

        console.log("споживання", ec, ep, ed);


    });
    $('#Privelege').focus(function () {
       var ed = $('#ED').val();
        if (ed>= lim2  ) {
           var ed1 = ed - lim1;//900-100=800
           var ed2 = lim1 - lim3;//100-75=25
           var ed3 = ed1 - lim2;//800-600=200
           $('#Privelege').val(lim3);
           $('#toLim').val(ed2);
           $('#fromLim').val(lim2);
           $('#overLim').val(ed3);
           var pr1 = lim3 * TEB;//75*0.09
           var pr2 = ed2 * TEL1;//25*36.6
           var pr3 = lim2 * TEL2;//600*63
           var pr4 = ed3 * TEL3;//200*1.407
           $('#SumP').val(pr1);
           $('#SumT').val(pr2);
           $('#SumF').val(pr3);
           $('#SumO').val(pr4);
           var sum = pr1 + pr2 + pr3 + pr4;
           $('#Sum').val(sum);
        } else if (ed>=lim1) {
            var ed1 = ed - lim1;//120-100=20
            var ed2 = lim1 - lim3;//100-75=25
            $('#Privelege').val(lim3);//75
            $('#toLim').val(ed2);//25
            $('#fromLim').val(ed1);//20
            $('#overLim').val(0);
            var pr1 = lim3 * TEB;
            var pr2 = ed2 * TEL1;
            var pr3 = ed1 * TEL2;
            $('#SumP').val(pr1);
            $('#SumT').val(pr2);
            $('#SumF').val(pr3);
            $('#SumO').val(0);
            var sum = pr1 + pr2 + pr3;
            $('#Sum').val(sum);

        } else if(ed >= lim3) {
            var ed1=ed - lim3//90-75=15
            $('#Privelege').val(lim3);//75
            $('#toLim').val(ed1);//15
            $('#fromLim').val(0);
            $('#overLim').val(0);
            var pr1 = lim3 * TEB;
            var pr2 = ed1 * TEL1;
            $('#SumP').val(pr1);
            $('#SumT').val(pr2);
            $('#SumF').val(0);
            $('#SumO').val(0);
            var sum = pr1 + pr2;
            $('#Sum').val(sum);

        }else {
            $('#Privelege').val(ed);
            $('#toLim').val(0);
            $('#fromLim').val(0);
            $('#overLim').val(0);
            var pr1 = ed * TEB;
            $('#SumP').val(pr1);
            $('#SumT').val(0);
            $('#SumF').val(0);
            $('#SumO').val(0);
           
            $('#Sum').val(pr1);

        }
        

        console.log("споживання",  ed,TEB);
     });
       

        
        
        
       
        
   

    // console.log(benefit,benefitPerson);
    //  console.log("limit", lim1, lim2, lim3);
    //   console.log("tarrif", TEL1, TEL2, TEL3,TEB)


});