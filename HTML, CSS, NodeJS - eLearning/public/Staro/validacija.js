var Validacija=(function(){
    
    var listaInvalida;
    var brojInvalida;

    var editStringa=function(){
        var brojOdradjenih=0;
        var text;
        if(brojInvalida==0)
        text="";
        else
        {  
            text="Sljedeća polja nisu validna:";
            if(listaInvalida[0]==1)
            {
                text+="ime";
                brojOdradjenih++;
            }
            if(listaInvalida[1]==1)
            {
                if(brojOdradjenih!=0)
                text+=",";
                text+="godina";
                brojOdradjenih++;
            }
            if(listaInvalida[2]==1)
            {
                if(brojOdradjenih!=0)
                text+=",";
                text+="repozitorij";
                brojOdradjenih++;
            }
            if(listaInvalida[3]==1)
            {
                if(brojOdradjenih!=0)
                text+=",";
                text+="index";
                brojOdradjenih++;
            }
            if(listaInvalida[4]==1)
            {
                if(brojOdradjenih!=0)
                text+=",";
                text+="naziv";
                brojOdradjenih++;
            }
            if(listaInvalida[5]==1)
            {
                if(brojOdradjenih!=0)
                text+=",";
                text+="password";
                brojOdradjenih++;
            }
            if(listaInvalida[6]==1)
            {
                if(brojOdradjenih!=0)
                text+=",";
                text+="url";
                brojOdradjenih++;
            }
            text+="!";
        }
        return text;
    }

    var konstruktor=function(divElementPoruke){
        listaInvalida = new Array(7);
        for(var i=0;i<7;i++)
        listaInvalida[i]=0;
        brojInvalida=0;

    return{
    ime:function(inputElement){
        var imeString = inputElement.value;
        var dobarIme=false;

        var regexIme=/([A-Z]\'?(([A-Z]|[a-z])\'?)+(\s|\-)){0,3}[A-Z]\'?(([A-Z]|[a-z])\'?)+/g;
        dobarIme=imeString.match(regexIme);
        
        // var listaRezultataIme = imeString.match(regexIme);
        // if(listaRezultataIme)
        // {
        //   for(var lokal=0;lokal<listaRezultataIme.length;lokal++)
        //   {
        //       if(listaRezultataIme[lokal]==imeString)
        //       dobarIme=true;
        //   }
        // }
        if(dobarIme)
        {
            if(listaInvalida[0]==1)
            brojInvalida--;
            listaInvalida[0]=0;
            inputElement.setAttribute("style", "background-color: white;");
            
        }
        else
        {           
            if(listaInvalida[0]==0)
            brojInvalida++;
            listaInvalida[0]=1;      
            inputElement.setAttribute("style", "background-color: orangered;");
        }
        divElementPoruke.textContent=editStringa();
    },
    godina:function(inputElement){
        var godinaString = inputElement.value;
        var dobarGodina=false;        
        var regexGodina= /(20[0-9][0-9])\/(20[0-9][0-9])/g;
        dobarGodina=godinaString.match(regexGodina);
        // var listaRezultataGodina= godinaString.match(regexGodina);
        // if(listaRezultataGodina)
        // {
        //   for(var lokal=0;lokal<listaRezultataGodina.length;lokal++)
        //   {
        //       if(listaRezultataGodina[lokal]==godinaString)
        //       dobarGodina=true;
        //   }
        // }
        if(dobarGodina && parseInt(godinaString.substring(2,4))+1==parseInt(godinaString.substring(7)))
        {
            if(listaInvalida[1]==1)
            brojInvalida--;
            listaInvalida[1]=0;
            inputElement.setAttribute("style", "background-color: white;");
        }
        else
        {           
            if(listaInvalida[1]==0)
            brojInvalida++;
            listaInvalida[1]=1; 
            inputElement.setAttribute("style", "background-color: orangered;");              
        }
        divElementPoruke.textContent=editStringa();
    },
    repozitorij:function(inputElement,regex){
        var repozitorijString = inputElement.textContent;
        var dobarRepozitorij=false;
        dobarRepozitorij = repozitorijString.match(regex);
        
        // var listaRezultataRepozitorij= repozitorijString.match(regex);
        // if(listaRezultataRepozitorij)
        // {
        //   for(var lokal=0;lokal<listaRezultataRepozitorij.length;lokal++)
        //   {
        //       if(listaRezultataRepozitorij[lokal]==repozitorijString)
        //       dobarRepozitorij=true;
        //   }
        // }
        if(dobarRepozitorij)
        {
            if(listaInvalida[2]==1)
            brojInvalida--;
            listaInvalida[2]=0;
            inputElement.setAttribute("style", "background-color: white;");
        }
        else
        {           
            if(listaInvalida[2]==0)
            brojInvalida++;
            listaInvalida[2]=1; 
            inputElement.setAttribute("style", "background-color: orangered;");                  
        }
        divElementPoruke.textContent=editStringa();
    },
    index:function(inputElement){
        var indexString = inputElement.textContent;
        var dobarIndex=false;

        var regexIndex= /((1[4-9])|(20))([0-9]){3}/g;
        dobarIndex = indexString.match(regexIndex);
        // var listaRezultataIndex= indexString.match(regexIndex);
        // if(listaRezultataIndex)
        // {
        //   for(var lokal=0;lokal<listaRezultataIndex.length;lokal++)
        //   {
        //       if(listaRezultataIndex[lokal]==indexString)
        //       dobarIndex=true;
        //   }
        // }

        if(dobarIndex)
        {
            if(listaInvalida[3]==1)
            brojInvalida--;
            listaInvalida[3]=0;
            inputElement.setAttribute("style", "background-color: white;");
        }
        else
        {           
            if(listaInvalida[3]==0)
            brojInvalida++;
            listaInvalida[3]=1;
            inputElement.setAttribute("style", "background-color: orangered;");             
        }
        divElementPoruke.textContent=editStringa();
    },
    naziv:function(inputElement){
        var nazivString = inputElement.textContent;
        var dobarNaziv=false;

        var regexNaziv= /([A-Z]|[a-z])(\d|[A-Z]|[a-z]|\\|\/|\-|\"|\'|\!|\?|\:|\;|\,)+([a-z]|[0-9])/g;
        dobarNaziv = nazivString.match(regexNaziv);
        // var listaRezultataNaziv= nazivString.match(regexNaziv);
        // if(listaRezultataNaziv)
        // {
        //   for(var lokal=0;lokal<listaRezultataNaziv.length;lokal++)
        //   {
        //       if(listaRezultataNaziv[lokal]==nazivString)
        //       dobarNaziv=true;
        //   }
        // }       
        if(dobarNaziv)
        {
            if(listaInvalida[4]==1)
            brojInvalida--;
            listaInvalida[4]=0;
            inputElement.setAttribute("style", "background-color: white;");
        }
        else
        {           
            if(listaInvalida[4]==0)
            brojInvalida++;
            listaInvalida[4]=1; 
            inputElement.setAttribute("style", "background-color: orangered;");                 
        }
        divElementPoruke.textContent=editStringa();
    },
    password:function(inputElement){
        var passwordString = inputElement.textContent;
        var dobarPassword=false;

        var regexPassword= /([0-9]|[A-Z]|[a-z]){8,}/g;
        dobarPassword = passwordString.match(regexPassword);
        // var listaRezultataPassword= passwordString.match(regexPassword);
        // if(listaRezultataPassword)
        // {
        //   for(var lokal=0;lokal<listaRezultataPassword.length;lokal++)
        //   {
        //       if(listaRezultataPassword[lokal]==passwordString)
        //       dobarPassword=true;
        //   }
        // }
        var brojRazlicitihSimbola=0; 

        if(dobarPassword)
        {
            for(var i=0;i<passwordString.length;i++)
            {
                if(passwordString[i]>='a' && passwordString[i]<='z')
                {
                    brojRazlicitihSimbola++;
                    break;
                }
            }
            for(var j=0;j<passwordString.length;j++)
            {
                if(passwordString[j]>='A' && passwordString[j]<='Z')
                {
                    brojRazlicitihSimbola++;
                    break;
                }
            }
            for(var k=0;k<passwordString.length;k++)
            {
                if(passwordString[k]>='0' && passwordString[k]<='9')
                {
                    brojRazlicitihSimbola++;
                    break;
                }
            }  
        }

        if(dobarPassword && brojRazlicitihSimbola>=2)
        {
            if(listaInvalida[5]==1)
            brojInvalida--;
            listaInvalida[5]=0;
            inputElement.setAttribute("style", "background-color: white;");
        }
        else
        {           
            if(listaInvalida[5]==0)
            brojInvalida++;
            listaInvalida[5]=1;  
            inputElement.setAttribute("style", "background-color: orangered;");       
        }
        divElementPoruke.textContent=editStringa();
    },
    url:function(inputElement){
        var urlString = inputElement.textContent;
        var dobarUrl=false;
        var regexUrl=/(((((http)|(https)|(ftp)|(ssh)):\/\/)(((([a-z]|[0-9])(([a-z]|[0-9]|\-)+)([a-z]|[0-9]))|(([a-z]|[0-9])+))((\.((([a-z]|[0-9])(([a-z]|[0-9]|\-)+)([a-z]|[0-9]))|(([a-z]|[0-9])+)))*)))((\/)?))((((([a-z]|[0-9])(([a-z]|[0-9]|\-)+)([a-z]|[0-9]))|(([a-z]|[0-9])+))((\/((([a-z]|[0-9])(([a-z]|[0-9]|\-)+)([a-z]|[0-9]))|(([a-z]|[0-9])+)))*))?)((\?(((((([a-z]|[0-9])(([a-z]|[0-9]|\-)+)([a-z]|[0-9]))|(([a-z]|[0-9])+))\=((([a-z]|[0-9])(([a-z]|[0-9]|\-)+)([a-z]|[0-9]))|(([a-z]|[0-9])+)))((\&(((([a-z]|[0-9])(([a-z]|[0-9]|\-)+)([a-z]|[0-9]))|(([a-z]|[0-9])+))\=((([a-z]|[0-9])(([a-z]|[0-9]|\-)+)([a-z]|[0-9]))|(([a-z]|[0-9])+))))*))))?)/g;
        dobarUrl = urlString.match(regexUrl);
        // var listaRezultataUrl = urlString.match(regexUrl);
        // if(listaRezultataUrl)
        // {
        //     for(var lokal=0;lokal<listaRezultataUrl.length;lokal++)
        //     {
        //         if(listaRezultataUrl[lokal]==urlString)
        //         dobarUrl=true;
        //     }  
        // }       
        if(dobarUrl)
        {
            if(listaInvalida[6]==1)
            brojInvalida--;
            listaInvalida[6]=0;
            inputElement.setAttribute("style", "background-color: white;");
        }
        else
        {           
            if(listaInvalida[6]==0)
            brojInvalida++;
            listaInvalida[6]=1;    
            inputElement.setAttribute("style", "background-color: orangered;");               
        }
        divElementPoruke.textContent=editStringa();
    }
    }
    }
    return konstruktor;
    }());