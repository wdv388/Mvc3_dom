$(document).ready(function () {
    $('#HWT').focus(function () {
        var hw1 = parseInt($('#HW1').val());
        var hw0 = parseInt($('#HW0').val());
        $('#HWT').val(hw1 + hw0);
    });

    $('#HWD').focus(function () {
        var hwt = parseInt($('#HWT').val());
        var hwp = parseInt($('#HWP').val());
        $('#HWD').val(hwt - hwp);


    });
    $('#Sum').focus(function () {

        var tarrif = parseFloat($('#tarrif').val());

        var hwd = $('#HWD').val();

        var benefit = $('#benefit').text();

        if (benefit == 0) {

            $('#Sum').val(tarrif * hwd);

        }
        else {
            // alert("else");
            var benefit_tarif = (tarrif * 25) / 100;
            var sum_benefit = (benefit_tarif * (hwd / 2));
            var sum_half = tarrif * (hwd / 2);
            var lim = 1.4 * 2;
            var hwdlim = hwd / 2;
            if (hwdlim>lim) {
                alert("Увага перевищенно ліміт споживання гарячої води");
            }
            $('#Sum').val(sum_benefit + sum_half);
        };

    });

  

});