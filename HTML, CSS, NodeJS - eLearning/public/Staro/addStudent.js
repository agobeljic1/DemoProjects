var nazivSpi;
var nazivVje;
var nazivGod;
var listaSpi = new Array();
var listaVje = new Array();
var listaGod = new Array();
var listaId = new Array();
var jsonLista=JSON.parse("[]");
function ispisi(greska,x){
    if(greska==null) {
        console.log("Lista studenata:\n"+JSON.stringify(x));
        jsonLista=JSON.parse(JSON.stringify(x));
    }
    else
    {
        console.log(greska);
    }
}
var bitbucket;
var key;
var secret;
function funkcijaUcitaj()
{
    if(bitbucket==null || bitbucket==undefined)
    {
        key = document.getElementById("inputKey").value;
        secret = document.getElementById("inputSecret").value;        
        bitbucket = new BitBucket(key,secret);
        var dodaj = document.getElementById("inputDodaj");          
        bitbucket.ucitaj(nazivSpi,nazivVje,ispisi);
        dodaj.disabled=false; 
    }
    else
    {
        var newkey = document.getElementById("inputKey").value;
        var newsecret = document.getElementById("inputSecret").value;
        if(newkey!=key || newsecret!=secret)
        {
            key=newkey;
            secret=newsecret;             
            bitbucket = new BitBucket(key,secret);
        }
        var dodaj = document.getElementById("inputDodaj");
        bitbucket.ucitaj(nazivSpi,nazivVje,ispisi);
        dodaj.disabled=false;  
    }
    
}
function osvjeziGodine()
{
    var ajax=new XMLHttpRequest();
    ajax.onreadystatechange=function()
    {
        if(ajax.readyState==4 && ajax.status==200)
        {
            var json=ajax.response;            
            var array=JSON.parse(json);
            var selectUp = document.getElementsByName("sGodina")[0];

            var string="";
            listaSpi = new Array();
            listaVje = new Array();
            listaGod = new Array();
            listaId = new Array();
            if(array.length!=0)
            {
                var data = array[0];
                string+="<option value=\""+data.id.toString()+"\" selected>" + data.nazivGod + "</option>";
                nazivSpi=data.nazivRepSpi;
                nazivVje=data.nazivRepVje;
                nazivGod=data.nazivGod;
                listaSpi.push(data.nazivRepSpi);
                listaVje.push(data.nazivRepVje);
                listaGod.push(data.nazivGod);
                listaId.push(data.id);
                
            }
            for(var i=1;i<array.length;i++)
            {
                var data = array[i];
                string+="<option value=\""+data.id.toString()+"\">" + data.nazivGod + "</option>";
                listaSpi.push(data.nazivRepSpi);
                listaVje.push(data.nazivRepVje);
                listaGod.push(data.nazivGod);
                listaId.push(data.id);
            }
            selectUp.innerHTML=string;
            ChangeGodina();
        }
        else
        {
    
        }
    }
    ajax.open("GET","http://localhost:8080/godinee",true);
    ajax.send();
}

function ChangeGodina()
{
    var selectUp = document.getElementsByName("sGodina")[0];
    for(let i=0;i<listaId.length;i++)
    {
        if(listaId[i]==selectUp.value)
        {
            nazivSpi=listaSpi[i];
            nazivVje=listaVje[i];
            nazivGod=listaGod[i];
            return;
        }
    }
    
}
function funkcijaDodaj()
{
    var ajax=new XMLHttpRequest();
    ajax.onreadystatechange=function()
    {
        if(ajax.readyState==4 && ajax.status==200)
        {
            console.log("Doso");
            console.log(ajax.response);
            alert(JSON.parse(ajax.response).message);            
        }
        else
        {
            
        }
    }
    
    
    var stringJson = JSON.stringify(jsonLista);
    stringJson="{\"godina\":\""+nazivGod+"\",\"studenti\":"+stringJson+"}";
    ajax.open("POST","http://localhost:8080/student",true);    
    ajax.setRequestHeader("Content-Type", "application/json");
    ajax.send(JSON.stringify(JSON.parse(stringJson)));
}

osvjeziGodine();
