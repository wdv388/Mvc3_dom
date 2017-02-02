
    $(document).ready(function () {
        $('#reload').click(function () {
            $("body").load("/Home/ShowTrend/");
            console.log("I click")
        });
        //$('.btn.btn-default ').click(function () {
        //    console.log('Click button')
        //});
        //$(function () {
        //    $("#datepicker").datepicker({ dateFormat: "yy", yearRange: "2015:2018", changeYear: true });
        //});numberOfMonths: 12, showButtonPanel: true,
       
    });
