$(document).ready(function () {

    $(function () {
        $("#dialog").dialog();
        var maxHeight = $("#dialog").dialog("option", "maxHeight");
        // setter
        $("#dialog").dialog("option", "maxHeight", 6000);
        var maxWidth = $("#dialog").dialog("option", "maxWidth");
        // setter
        $("#dialog").dialog("option", "maxWidth", 6000);
        var modal = $("#dialog").dialog("option", "modal");
        // setter
        $("#dialog").dialog("option", "modal", true);
        //var width = $(".selector").dialog("option", "width");
        //// setter
        //$("#dialog").dialog("option", "width", 500);
    });
    $.ajax({
        url: "/Electricity/Index_Partal",
        cache: false,
        success: function (html) {
            $("#dialog").html(html);
        }
    });
});