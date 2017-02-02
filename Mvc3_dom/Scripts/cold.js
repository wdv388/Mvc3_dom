$(document).ready(function () {


    $('#CurrentTotal').focus(function () {
       
        var cur =parseInt( $('#Current').val());
        var cur1 = parseInt( $('#Current1').val());
        var total = $('input#CurrentTotal').val(cur + cur1);
        console.log(total);
    });
    $('#Difference').focus(function () {
        var curtotal = parseInt($('#CurrentTotal').val());
        var previus = parseInt($('#Previous').val());
        var difference = $('#Difference').val(curtotal - previus);
        console.log(curtotal,previus,difference);
    });

    $('#TotaltoPay').focus(function () {
        var difference = parseInt($('#Difference').val());
        var price= parseFloat ($('#Price').val());
        var total = $('#TotaltoPay').val(difference*price)
    });

});
