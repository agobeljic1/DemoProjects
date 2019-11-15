var filtiraj=false;
function osvjeziGodine()
{
    var ajax=new XMLHttpRequest();
    ajax.onreadystatechange=function()
    {
        if(ajax.readyState==4 && ajax.status==200)
        {
            var json=ajax.response;            
            var array=JSON.parse(json);
            var selectUp = document.getElementsByName("sGodine")[0];
            var selectDown = document.getElementsByName("sGodine")[1];

            var string="";
            if(array.length!=0)
            {
                var data = array[0];
                string+="<option value=\""+data.id.toString()+"\" selected>" + data.nazivGod + "</option>";
            }
            for(var i=1;i<array.length;i++)
            {
                var data = array[i];
                string+="<option value=\""+data.id.toString()+"\">" + data.nazivGod + "</option>";
            }
            selectUp.innerHTML=string;
            selectDown.innerHTML=string;
        }
        else
        {
    
        }
    }
    ajax.open("GET","http://localhost:8080/godinee",true);
    ajax.send();
}
function osvjeziVjezbe()
{
    var ajax=new XMLHttpRequest();
    ajax.onreadystatechange=function()
    {
        if(ajax.readyState==4 && ajax.status==200)
        {
            var json=ajax.response;
            var array=JSON.parse(json);
            var select1 = document.getElementsByName("sVjezbe")[0];
            var select2 = document.getElementsByName("sVjezbe")[1];


            var string="";
            if(array.length!=0)
            {
                var data = array[0];
                string+="<option value=\""+data.id.toString()+"\" selected>" + data.naziv + "</option>";
            }
            for(var i=1;i<array.length;i++)
            {
                var data = array[i];
                string+="<option value=\""+data.id.toString()+"\">" + data.naziv + "</option>";
            }
            select1.innerHTML=string;
            select2.innerHTML=string;
            promjenaId();
        }
        else
        {
    
        }
    }
    ajax.open("GET","http://localhost:8080/vjezbe",true);
    ajax.send();
}
function osvjeziZadatke()
{
    var ajax=new XMLHttpRequest();
    ajax.onreadystatechange=function()
    {
        if(ajax.readyState==4 && ajax.status==200)
        {
            var json=ajax.response;
            var array=JSON.parse(json);
            var select1 = document.getElementsByName("sZadatak")[0];


            var string="";
            if(array.length!=0)
            {
                var data = array[0];
                string+="<option value=\""+data.id.toString()+"\" selected>" + data.naziv + "</option>";
            }
            for(var i=1;i<array.length;i++)
            {
                var data = array[i];
                string+="<option value=\""+data.id.toString()+"\">" + data.naziv + "</option>";
            }
            select1.innerHTML=string;
        }
        else
        {
    
        }
    }
    ajax.open("GET","http://localhost:8080/zadacii",true);
    ajax.send();
}
function filtrirajZadatke()
{
    var selectId = document.getElementById("fPoveziVjezbe");
    var parame=selectId.value;
    var ajax=new XMLHttpRequest();
    ajax.onreadystatechange=function()
    {
        if(ajax.readyState==4 && ajax.status==200)
        {
            console.log("sfilasjilcfcil");
            var json=ajax.response;
            var array=JSON.parse(json);
            var select1 = document.getElementsByName("sZadatak")[0];


            var string="";
            if(array.length!=0)
            {
                var data = array[0];
                string+="<option value=\""+data.id.toString()+"\" selected>" + data.naziv + "</option>";
            }
            for(var i=1;i<array.length;i++)
            {
                var data = array[i];
                string+="<option value=\""+data.id.toString()+"\">" + data.naziv + "</option>";
            }
            select1.innerHTML=string;
        }
        else
        {
    
        }
    }
    ajax.open("GET","http://localhost:8080/zadaaci",true);
    ajax.send('zadatak='+parame);
    
}
//filtrirajZadatke();
osvjeziGodine();
osvjeziVjezbe();
osvjeziZadatke();


function funkcijaDodajPojedinacni()
{
        
}
function funkcijaDodajMasovni()
{
    var mojMasovniDiv=document.getElementById("greskaDivMasovni");
    var inputVjezba=document.getElementById("input1");    
    var validacija = new Validacija(mojMasovniDiv);
    validacija.naziv(inputVjezba);        
}
function promjenaId()
{
    var forma = document.getElementsByName("fPoveziZadatak")[0];
    var selectId = document.getElementById("fPoveziVjezbe");
    //filtrirajZadatke();

    



    forma.action="/vjezba/"+selectId.value+"/zadatak";
    
}

