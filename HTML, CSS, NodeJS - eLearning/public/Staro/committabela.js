var CommitTabela=(function(){
    var nizCommita;
    var matricaCommita;
    var maksimumKolona=0;
 
    var konstruktor=function(divElement,brojZadataka){
      if(!divElement || brojZadataka<0)
      return -1;


      nizCommita = new Array(brojZadataka);
      matricaCommita=new Array(brojZadataka);
     
      for(var i=0;i<brojZadataka;i++)
      {
        nizCommita[i]=0;
      }
      for(var i=0;i<brojZadataka;i++)
      {
        matricaCommita[i]=new Array();        
      }
      maksimumKolona=0;

     
      table=document.createElement("table");
      var red = document.createElement("tr");
      var naslovPrvi = document.createElement("th");
      naslovPrvi.setAttribute("class","td3");
      naslovPrvi.textContent="Naziv zadatka";
      var naslovDrugi = document.createElement("th");
      naslovDrugi.setAttribute("colspan","1");
      naslovDrugi.textContent="Commiti";
      red.appendChild(naslovPrvi);
      red.appendChild(naslovDrugi);
      table.appendChild(red);
      for(var i=1;i<=brojZadataka;i++)
      {
        var red = document.createElement("tr");
        var podnaslov = document.createElement("td");
        podnaslov.setAttribute("class","td3");
        podnaslov.textContent="Zadatak "+i;
        var commitPrvi = document.createElement("td");
        commitPrvi.setAttribute("colspan","1");
        commitPrvi.textContent="";
        red.appendChild(podnaslov);
        red.appendChild(commitPrvi);
        table.appendChild(red);
      }
      divElement.appendChild(table);


      
    return{
    dodajCommit:function(rbZadatka,url){
      if(!matricaCommita || rbZadatka>=matricaCommita.length || rbZadatka<0)
      return -1;
      
      var row = table.getElementsByTagName("tr")[rbZadatka+1];
      var novaCelija;
      var proslaCelija;

      if(!matricaCommita[rbZadatka] || matricaCommita[rbZadatka].length==0)
      {
        novaCelija=row.getElementsByTagName("td")[1];
        var noviLink = document.createElement("a");            
        noviLink.textContent = ++nizCommita[rbZadatka];
        noviLink.setAttribute("href",url);
        novaCelija.setAttribute("colspan",1);
        novaCelija.appendChild(noviLink); 
        

        matricaCommita[rbZadatka].push(nizCommita[rbZadatka]);
        if(maksimumKolona==0)
        maksimumKolona=1;
        if(maksimumKolona>1)
        {
          var ekstraCelija = document.createElement("td");
          ekstraCelija.setAttribute("colspan",(maksimumKolona-1).toString());
          row.appendChild(ekstraCelija);
        }
      }
      else
      {
        var trenutnaDuzina = matricaCommita[rbZadatka].length;
        if(trenutnaDuzina==maksimumKolona)
        {
          
          novaCelija = document.createElement("td");
          var noviLink = document.createElement("a");      
          noviLink.textContent = ++nizCommita[rbZadatka];
          noviLink.setAttribute("href",url);
          novaCelija.appendChild(noviLink);  
          row.appendChild(novaCelija);          
          maksimumKolona++;
          matricaCommita[rbZadatka].push(nizCommita[rbZadatka]);
          
          var naslovRed = table.getElementsByTagName("tr")[0];
          var celijaNaslov = naslovRed.getElementsByTagName("th")[1];
          celijaNaslov.setAttribute("colspan",maksimumKolona.toString());

          for(var ii=0;ii<matricaCommita.length;ii++)
          {
            if(ii!=rbZadatka)
            {
              var duzinaReda = matricaCommita[ii].length;
              var editingRow = table.getElementsByTagName("tr")[ii+1];
            
              if(duzinaReda==trenutnaDuzina)
              {                          
                var dodanaCelija = document.createElement("td");
                dodanaCelija.setAttribute("colspan","1");
                editingRow.appendChild(dodanaCelija);                
              }
              else
              {                
                var editovanaCelija;
                if(duzinaReda==0)
                editovanaCelija = editingRow.getElementsByTagName("td")[1];
                else
                editovanaCelija = editingRow.getElementsByTagName("td")[duzinaReda+1];                
                var span = editovanaCelija.getAttribute("colspan");                
                editovanaCelija.setAttribute("colspan",parseInt(span)+1);                
              }
            }
          }
         
        }
        else
        {
          var staraCelija = row.getElementsByTagName("td")[trenutnaDuzina+1];
          var stringex = staraCelija.getAttribute("colspan");          
          var span = parseInt(stringex);          
          row.removeChild(staraCelija);
          novaCelija = document.createElement("td");
          var noviLink = document.createElement("a");      
          noviLink.textContent = ++nizCommita[rbZadatka];          
          noviLink.setAttribute("href",url);
          novaCelija.appendChild(noviLink);  
          row.appendChild(novaCelija);
          
          if(span!=1)
          {
            var dodanaCelija = document.createElement("td");
            dodanaCelija.setAttribute("colspan",span-1);
            row.appendChild(dodanaCelija);
          }     
          matricaCommita[rbZadatka].push(nizCommita[rbZadatka]);     
        }
      }
    },


    editujCommit:function(rbZadatka,rbCommita,url){
      if(!matricaCommita || rbZadatka>=matricaCommita.length || rbZadatka<0 || rbCommita<0 || !matricaCommita[rbZadatka] || rbCommita>=matricaCommita[rbZadatka].length)
      return -1;
      var red=table.getElementsByTagName("tr")[rbZadatka+1];
      var celija=red.getElementsByTagName("td")[rbCommita+1];
      var link = celija.getElementsByTagName("a")[0];
      link.setAttribute("href",url);
      celija.appendChild(link); 
        
    },


    obrisiCommit:function(rbZadatka,rbCommita){
      if(!matricaCommita || rbZadatka>=matricaCommita.length || rbZadatka<0 || rbCommita<0 || !matricaCommita[rbZadatka] || rbCommita>=matricaCommita[rbZadatka].length)
      return -1;

      var red= table.getElementsByTagName("tr")[rbZadatka+1];
      var celija = red.getElementsByTagName("td")[rbCommita+1];
      matricaCommita[rbZadatka].splice(rbCommita,1);
      var maksi = 0;
      for(var iii=0;iii<matricaCommita.length;iii++)
      {
        if(matricaCommita[iii].length>maksi)
        maksi=matricaCommita[iii].length;
      }

      if(matricaCommita[rbZadatka].length==0)
      {
        if(maksi!=maksimumKolona)
        {
          red.removeChild(celija);
          var dodanaCelija = document.createElement("td");
          dodanaCelija.setAttribute("colspan","1");
          red.appendChild(dodanaCelija);
        }
        else
        {
          red.removeChild(celija);
          var dodanaCelija = red.getElementsByTagName("td")[1];
          dodanaCelija.setAttribute("colspan",maksi);
          red.appendChild(dodanaCelija);
        }
      }
      else
      {
        if(maksi!=maksimumKolona)
        {
          red.removeChild(celija);
          for(var t=0;t<matricaCommita.length;t++)
          {
            if(t!=rbZadatka)
            {
              if(matricaCommita[t].length==maksi)
              {
                // ukidamo zadnju celiju
                var redd= table.getElementsByTagName("tr")[t+1];
                var ukidanaCelija = redd.getElementsByTagName("td")[matricaCommita[t].length+1];
                redd.removeChild(ukidanaCelija);
              }
              else
              {
                var redd= table.getElementsByTagName("tr")[t+1];
                var smanjenaCelija = redd.getElementsByTagName("td")[matricaCommita[t].length+1];
                smanjenaCelija.setAttribute("colspan",parseInt(smanjenaCelija.getAttribute("colspan"))-1);
                //smanjujemo zadnju celiju za 1
              }
            }
          }
        }
        else
        {
          if(maksimumKolona==matricaCommita[rbZadatka].length+1)
          {
            red.removeChild(celija);
            var addedCelija = document.createElement("td");
            addedCelija.setAttribute("colspan","1");
            red.appendChild(addedCelija);
          }
          else
          {
            red.removeChild(celija);
            var zadnjaCell = red.getElementsByTagName("td")[matricaCommita[rbZadatka].length+1];
            zadnjaCell.setAttribute("colspan",parseInt(zadnjaCell.getAttribute("colspan"))+1);
            red.appendChild(zadnjaCell);
          }
        }
      }
      maksimumKolona=maksi;    
    }
    }
    }
    return konstruktor;
    }());
   


