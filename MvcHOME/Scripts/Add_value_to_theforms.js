jQuery(document).ready(function () {
    $('#Data').attr('disabled', 'disabled');
    $("#Data")
   .change(function () {
       var str = $('#Data :selected').val();
       console.log(str);
       $('#cldf input:last').attr('value', str);
       $('#htf input:last').attr('value', str);
       $('#swgf input:last').attr('value', str);
       $('#elf input:last').attr('value', str);
   });
    
    


    

})