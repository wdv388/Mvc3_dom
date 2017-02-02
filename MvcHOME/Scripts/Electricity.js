$(document).ready(function () {
    

    $('#ED').focus(function () {
        var ec = parseInt($('#EC').val());
        var ep = parseInt($('#EP').val());
        $('#ED').val(ec - ep);


    });
    $('#L150_250').focus(function () {
        var limit =parseInt( $('#gas').text());
        var ed = $('#ED').val();
        
        if (ed >= limit) {
            $('#L150_250').val(limit);
            $('#upL150_250').val(ed - limit);
        }
        else {
            $('#L150_250').val(ed);
            $('#upL150_250').val(0);
        }
    });
    $('#Sum').focus(function () {

        var tarrif = parseFloat($('#tarrif').val());

       
        var benefit =parseFloat( $('#benefit').text());

        var uptarrif = parseFloat($('#uptarrif').val());

            var lim1 =parseInt( $('#L150_250').val());
            var lim2 = parseInt($('#upL150_250').val());

            if (benefit == 0) {
            var sum1 =parseInt(lim1) * tarrif / 100;
            var sum2 =parseInt(lim2) * uptarrif / 100;
            $('#Sum').val(sum1+sum2);

        }
                //to do : if{}else --replease 100
            else {
          var half =parseInt(lim1)-75;
          
            var sum_benefit = (benefit * 75) / 100;
            var sum_half = tarrif * half;
            var sum1 = sum_benefit + sum_half / 100;
            var sum2 =parseInt( lim2) * uptarrif / 100;
            $('#Sum').val(sum1+sum2);
            
        };
        console.log("sum1,2",sum1, sum2);
        console.log("benefit",half, sum_benefit, sum_half);
        console.log("lim1,2",lim1, lim2);
        console.log("tarrif",tarrif, uptarrif, benefit);

    });



});