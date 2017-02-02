$(document).ready(function () {
    $(function () {
        $("#date").datepicker();
       
         //   $("#date").datepicker({ showAnim: "fold" });
        // getter
            var dateFormat = $("#date").datepicker("option", "dateFormat");
        // setter
            $("#date").datepicker("option", "dateFormat", "yy-mm-dd");
       
            $("#date").datepicker({dateFormat: "yy-mm-dd"});
        // getter
        //    var showAnim = $("#date").datepicker("option", "showAnim");
        // setter
       //     $("#date").datepicker("option", "showAnim", "fold");
    });



});