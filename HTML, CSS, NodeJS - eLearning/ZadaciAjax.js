var ZadaciAjax = (function(){
    var zauzetModul=false;
    var konstruktor = function(callbackFn){
    return {
    dajXML:function()
    {
        if(zauzetModul)
        {
           callbackFn({greska:"Već ste uputili zahtjev"});
        }
        else
        {
            var ajax=new XMLHttpRequest();
            ajax.ontimeout=function(){
                console.log("Zahtjev timeout");
                zauzetModul=false;
            }
            ajax.onreadystatechange=function()
            {
                zauzetModul=false; 
                if(ajax.readyState==4 && ajax.status==200)
                {   
                    callbackFn(ajax.response);                               
                }
                else
                {
                    
                }
            }
            
            ajax.open("GET","http://localhost:8080/zadaci",true);   
            ajax.timeout=2000;
            ajax.setRequestHeader("Accept","application/xml");  
            zauzetModul=true;   
            ajax.send();
        }
       
        
       


    },
    dajCSV:function()
    {
        if(zauzetModul)
        {
            callbackFn({greska:"Već ste uputili zahtjev"});
        }
        else
        {
            var ajax=new XMLHttpRequest();
            ajax.ontimeout=function(){
                console.log("Zahtjev timeout");
                zauzetModul=false;
            }
            ajax.onreadystatechange=function()
            {
                zauzetModul=false;
                if(ajax.readyState==4 && ajax.status==200)
                {  
                    callbackFn(ajax.response);        
                }
                else
                {
                    
            
                }
            }
            
            ajax.open("GET","http://localhost:8080/zadaci",true);
            ajax.timeout=2000;
            ajax.setRequestHeader("Accept","text/csv");
            zauzetModul=true; 
            ajax.send();
        }        
    },
    dajJSON:function()
    {
        if(zauzetModul)
        {
            callbackFn({greska:"Već ste uputili zahtjev"});
        }
        else
        {
            var ajax=new XMLHttpRequest();
            ajax.ontimeout=function(){
                console.log("Zahtjev timeout");
                zauzetModul=false;
            }
            ajax.onreadystatechange=function()
            {
                zauzetModul=false;
                if(ajax.readyState==4 && ajax.status==200)
                {
                    callbackFn(ajax.response);        
                }
                else
                {
                    
                }
            }
            
            ajax.open("GET","http://localhost:8080/zadaci",true);
            ajax.timeout=2000;
            ajax.setRequestHeader("Accept","application/json");   
            zauzetModul=true;      
            ajax.send();
        }
    }
    }
    }
    return konstruktor;
    }());


//module.exports=ZadaciAjax;