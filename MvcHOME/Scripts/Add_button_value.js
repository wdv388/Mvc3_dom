
    jQuery(document).ready(function () {
       
       
        $(function () {

            $('#past input').bind('click', function (e) {
                var vl = $(this).attr('name');
                console.log("aprtament",vl);
           
           
            

                $('#cldf input:first').attr('value', vl);

                $('#form0 ').append(function (i) { return '<button id=btnc type="submit" class="btn btn-default  ">Cold water </button>' });
                $('#htf input:first').attr('value', vl);
                $('#form1 ').append(function (i) { return '<button type="submit" class="btn btn-default  ">Hot water </button>' });
                $('#swgf input:first').attr('value', vl);
                $('#form2 ').append(function (i) { return '<button type="submit" class="btn btn-default ">Sawage</button>' });
                $('#elf input:first').attr('value', vl);
                $('#form3 ').append(function (i) { return '<button type="submit" class="btn btn-default " > Electric</button>' });
                $('#past input').attr('disabled', 'disabled');
                $('#Data').removeAttr('disabled');
                $('#reload').removeAttr('disabled');

                //  $('input').unbind();
            });


        });
   
        
    });

