$(document).ready(function () {
    $('#Difference').focus(function () {

        
        var cur = parseInt($('#Current').val());
        var previus = parseInt($('#Previous').val());
        var difference = $('#Difference').val(cur - previus);
       
    });


    $('#Difference_half').focus(function () {

        $('#Difference_half').val(75);
    });

    $('#Difference_fullhalf').focus(function () {
        var dhalf = parseInt($('#Difference_half').val());
        var dif = parseInt($('#Difference').val());
        $('#Difference_fullhalf').val(dif - dhalf);
    });
    $('#Price_half').focus(function () {
        $('#Price_half').val(5.2537);
    });
    $('#Price').focus(function () {
        var difhalf = $('#Difference_fullhalf').val();
        $('#Price').val(difhalf * 0.2802);
    });
    $('#TotaltoPay').focus(function () {
        var difference = parseFloat($('#Price_half').val());
        var price = parseFloat($('#Price').val());
        var total = $('#TotaltoPay').val(difference + price)
    });


});