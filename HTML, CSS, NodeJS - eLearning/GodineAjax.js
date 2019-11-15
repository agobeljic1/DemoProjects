function pozovi(divSadrzaj)
{
    var ajax=new XMLHttpRequest();
    ajax.onreadystatechange=function()
    {
        if(ajax.readyState==4 && ajax.status==200)
        {
            var json=ajax.response;
            console.log(json);
            var array=JSON.parse(json);
            console.log(array);
            
            console.log(array.length);
            var string="";
            string+="<div id=\"glavniSadrzaj\">\r\n";
            string+="<div id=\"contentGlavni\">\r\n";
            for(let i=0;i<array.length;i++)
            {
                if(array[i].nazivGod="")
                break;
                string+="<div class=\"godina\">\r\n";
                var vrsta="a";
                if(i%2==0)
                vrsta="a";
                else
                vrsta="b";
                string+="<div class=\"Kocka"+vrsta+"\">\r\n"; 
                
                string+="<p class=\"popo\"><b>Godina:</b>" + array[i].nazivGod + "</p>\r\n";                
                string+="<p class=\"popo\"><b>Repozitorij vježbi:</b>" + array[i].nazivRepVje + "</p>\r\n"; 
                string+="<p class=\"popo\"><b>Repozitorij spirala:</b>" + array[i].nazivRepSpi + "</p>\r\n"; 



                string+="</div>\r\n";
                string+="</div>\r\n";
            }
            string+="</div>\r\n";
            string+="</div>\r\n";
            
            divSadrzaj.innerHTML=string;
        }
        else
        {
    
        }
    }
    ajax.open("GET","http://localhost:8080/godine",true);
    ajax.send();
}

var GodineAjax = (function(){
    var konstruktor = function(divSadrzaj){    
    pozovi(divSadrzaj);

    return {
    osvjezi:function(){
        pozovi(divSadrzaj);
    }
    }
    }
    return konstruktor;
    }());
    

//module.exports=GodineAjax;