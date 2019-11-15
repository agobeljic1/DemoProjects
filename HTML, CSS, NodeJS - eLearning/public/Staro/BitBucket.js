var BitBucket=(function(){
    var promisToken;

    var konstruktor=function(key,secret){
        function funkcijaDajePromis(){
            return new Promise(function(resolve,reject){
                var ajax = new XMLHttpRequest(); 
                ajax.onreadystatechange = function() {// Anonimna funkcija
                    if (ajax.readyState == 4 && ajax.status == 200)
                         resolve(JSON.parse(ajax.responseText).access_token); 
                    else if (ajax.readyState == 4)
                         reject(ajax.status);
                }
                ajax.open("POST", "https://bitbucket.org/site/oauth2/access_token", true);
                ajax.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                ajax.setRequestHeader("Authorization", 'Basic ' + btoa(key+":"+secret));
                ajax.send("grant_type="+encodeURIComponent("client_credentials"));
              });
          }
        promisToken = funkcijaDajePromis();
        console.log(promisToken);
    return{
    ucitaj:function(nazivRepSpi,nazivRepVje,callback)
    {
        promisToken.then( function(tokencic){
            var ajax = new XMLHttpRequest();
            ajax.ontimeout=function(){
                callback("Timeout se desio",null);                
            }
            ajax.onreadystatechange = function(){
                if (ajax.readyState == 4 && ajax.status == 200)
                {
                    
                    var array=new Array();                        
                    var listaStudenata =new Array();
                    var listaIndexa = new Array();
                    var jsonString="[";
                    if(JSON.parse(ajax.responseText).values==null || JSON.parse(ajax.responseText).values==undefined)
                    {
                        
                    }
                    else
                    {                           
                        array=JSON.parse(ajax.responseText).values;
                        for(let i=0;i<array.length;i++)
                        {
                            if(array[i].name.startsWith(nazivRepSpi) || array[i].name.startsWith(nazivRepVje))
                            {
                                if(array[i].full_name.length-array[i].owner.username.length-1<5)
                                {
                                    //PrEKRATAK REPO                                        
                                }
                                else
                                {
                                    if(!listaIndexa.includes(array[i].full_name.substr(-5)))
                                    {
                                        listaStudenata.push(array[i].owner.display_name);
                                        listaIndexa.push(array[i].full_name.substr(-5));
                                        if(listaStudenata.length!=1)
                                        {
                                            jsonString+=",";
                                        }
                                        jsonString+="{ \"imePrezime\": \""+array[i].owner.display_name+"\",\"index\": \""+array[i].full_name.substr(-5)+"\"}"
                                        
                                    }  
                                }                                                                      
                            }
                        }
                    }
                    jsonString+="]";
                    callback(null,(JSON.parse(jsonString)));
                    
                }
                else if (ajax.readyState == 4)
                {
                    callback(ajax.status,null);    
                    return;                    
                }
            }
            
            ajax.open("GET","https://api.bitbucket.org/2.0/repositories?role=member&q=(name~\""+encodeURIComponent(nazivRepSpi)+"\" OR name~\""+encodeURIComponent(nazivRepVje)+"\")");
            ajax.setRequestHeader("Authorization", 'Bearer ' + tokencic);
            ajax.send();
        } );
    }
    }
    }
    return konstruktor;
    }());
