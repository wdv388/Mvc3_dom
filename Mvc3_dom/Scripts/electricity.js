$(document).ready(function () {
    $('#Difference').focus(function () {
        var cur = parseInt($('#Current').val());
        var previus = parseInt($('#Previous').val());
        var difference = $('#Difference').val(cur - previus);
        console.log(curtotal, previus, difference);
    });

    $('#TotaltoPay').focus(function () {
        var difference = parseInt($('#Difference').val());
        var price = parseFloat($('#Price').val());
        var total = $('#TotaltoPay').val(difference * price)
    });


});