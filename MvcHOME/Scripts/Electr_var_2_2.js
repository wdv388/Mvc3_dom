$(document).ready(function () {
    var limits = {
     benefit:$('#benefit').val(),//true or false
     benefitPerson : $('#benefitPerson').val(), // 2 or 0
     lim1 : parseInt($('#lim1').val()), // 100 kWh
     lim2 : parseInt($('#lim2').val()), //600kWh
     lim3 : parseInt($('#lim3').val()), //benefit kWh 75? change to 120 
     tarrif1 : parseFloat($('#TEL1').val()) ,//36.6 this is first price for first limit
     tarrif2 : parseFloat($('#TEL2').val()) ,//63 this is second price  for second limit
     tarrif3 : parseFloat($('#TEL3').val()) //1.407 this is price for third limit
    

    };

    function calculatebenefittarrif() {
        return (limits.tarrif1* 25) / 100; //tarif po pilge 75%
    };
    function calculateconsumption() {
        var a = parseInt($('#EC').val());
        var b= parseInt($('#EP').val());
        return a - b;
    };
    function fillthefields(a,b,c,d,e,f,g,h,k) {
        $('#Privelege').val(a);//75
        $('#toLim').val(b);//25
        $('#fromLim').val(c);//20
        $('#overLim').val(d);
        $('#SumP').val(e);
        $('#SumT').val(f);
        $('#SumF').val(g);
        $('#SumO').val(h);
        $('#Sum').val(k);
    };
    $('#ED').focus(function () {
       
        
        $('#ED').val(calculateconsumption());//spogito

        console.log("споживання",calculateconsumption());


    });
 
    $('#Privelege').focus(function () {
        var ed = calculateconsumption();//spochito

         //  console.log('limt1',limits.lim1,'limit2',limits.lim2,'limit3',limits.lim3)
        switch (true) {
            case limits.lim3 < limits.lim1 && ed<=limits.lim1:// if benefit(for example) 75kWh and limit 100kWh
                var fargument = limits.lim1 - ed;//
                var sargument = ed * calculatebenefittarrif();//
                var targument = fargument * limits.tarrif1;//
                console.log('limit3 > limit1')
                break;
            case ed <= limits.lim3 && limits.lim3>limits.lim1://0->120 if benefit greate than limit1
                var mult = ed * calculatebenefittarrif();
                fillthefields(ed,0,0,0,0,0,0,0,mult);
               console.log('case 1', mult);
                break;
            case ed > limits.lim3 && ed <= limits.lim2&&limits.lim3>limits.lim1://121-600
                var minus = ed - limits.lim3;//spogito ponad pilgu
                var mult = minus * limits.tarrif2;//suma ponad limit
                var pilgasum = limits.lim3 * calculatebenefittarrif();//suma pilgi(povna vartist spogivana po pilgovix tarifax)
                var sum = mult + pilgasum;//suma do splati
                fillthefields(limits.lim3,limits.lim1,minus,0,pilgasum,0,mult,0,sum);//fill those feilds
                console.log('case 2');
                break;
            case ed > limits.lim2&&limits.lim3>limits.lim1://601->
                var pilgsum = limits.lim3 * calculatebenefittarrif();
                var sumlim1 = limits.lim1 * limits.tarrif1;
                var sumlim2 = limits.lim2 * limits.tarrif2;
                var minus = ed - limits.lim2;
                var sumoverlim2 = minus * limits.tarrif3;
                var tottal = pilgsum + sumlim1 + sumlim2 + sumoverlim2;
                fillthefields(limits.lim3, limits.lim1, limits.lim2, minus, pilgsum, sumlim1, sumlim2, sumoverlim2, tottal);
                console.log('case 3');
                break;
            default:
                console.log('this is defauilt switch');
        }


    });


});