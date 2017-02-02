$(document).ready(function () {
    $('#ST').focus(function () {
        var hw1 = parseInt($('#S1').val());
        var hw0 = parseInt($('#S0').val());
        $('#ST').val(hw1 + hw0);
    });

    $('#SD').focus(function () {
        var hwt = parseInt($('#ST').val());
        var hwp = parseInt($('#SP').val());
        $('#SD').val(hwt - hwp);


    });
    $('#Sum').focus(function () {

        var tarrif = parseFloat($('#tarrif').val());

        var hwd = $('#SD').val();

        var benefit = $('#benefit').text();

        if (benefit == 0) {

            $('#Sum').val(tarrif * hwd);

        }
        else {
            // alert("else");
            var benefit_tarif = (tarrif * 25) / 100;
            var sum_benefit = (benefit_tarif * (hwd / 2));
            var sum_half = tarrif * (hwd / 2);
            $('#Sum').val(sum_benefit + sum_half);
        };

    });

    $("#auto").click(function () {
        var hw1 = $('#HW1').val();
        var hw0 = $('#HW0').val();
        var hwt = $('#HWT').val();
        var hwp = $('#HWP').val();
        var hwd = $('#HWD').val();
        var sum = $('#Su').val();
        $('#S1').val(hw1);
        $('#S0').val(hw0);
        $('#SP').val(hwp);
        $('#ST').val(hwt);
        $('#SD').val(hwd);
        //$('#Sum').val(sum);






    });

});