$(document).ready(function(){
    $('#CWT').focus(function () {
        var cw1 = parseInt($('#CW1').val());
        var cw0 = parseInt($('#CW0').val());
        $('#CWT').val(cw1+cw0);
    });

    $('#CWD').focus(function () {
        var cwt = parseInt($('#CWT').val());
        var cwp = parseInt($('#CWP').val());
        $('#CWD').val(cwt - cwp);
        

    });
    $('#Sum').focus(function () {

        var tarrif = parseFloat($('#tarrif').val());
        
        var cwd = $('#CWD').val();
       
        var benefit = $('#benefit').text();
       
        if (benefit == 0) {

            $('#Sum').val(tarrif * cwd);

        }
        else {
           // alert("else");
            var benefit_tarif = (tarrif * 25) / 100;
            var sum_benefit = (benefit_tarif * (cwd / 2));
            var sum_half = tarrif * (cwd / 2);
            $('#Sum').val(sum_benefit+sum_half);
        };
        
    });
  
    //$('#Data').focus(function () {
        
    //    $('#Data').val();
    //});
 
})