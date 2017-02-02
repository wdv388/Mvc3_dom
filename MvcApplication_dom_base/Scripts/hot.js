$(document).ready(function () {
   

    $('#CurrentTotal').focus(function () {
        var cur = parseInt($('#Current').val());
        var cur1 = parseInt($('#Current1').val());
        $('input#CurrentTotal').val(cur + cur1);
      
    });
    $('#Difference').focus(function () {
        var curtotal = parseInt($('#CurrentTotal').val());
        var previus = parseInt($('#Previous').val());
       $('#Difference').val(curtotal - previus);
       
    });

    $('#water_half').focus(function () {
      var difference = $('#Difference').val();
       $('#water_half').val(difference/2);
     
    });

    $('#totaltopay_half').focus(function () {
        var whalf = $('#water_half').val();
        var price_half = $('#Price_half').val();
        $('#totaltopay_half').val(whalf*price_half);

    });
    $('#totaltoplayfull_half').focus(function () {
        var whlf = $('#water_half').val();
        var price = $('#Price').val();
        $('#totaltoplayfull_half').val(price*whlf);
    });

    $('#TotaltoPay').focus(function () {
        var payhalf = parseFloat($('#totaltopay_half').val());
        var payfull = parseFloat($('#totaltoplayfull_half').val());
        $('#TotaltoPay').val(payhalf + payfull);
        console.log(payfull,payhalf)
    });
    $('#Price').focus(function () {
        $('#Price').val(16.24);
    });
    $('#Price_half').focus(function () {
        $('#Price_half').val(4.06);
    });
});