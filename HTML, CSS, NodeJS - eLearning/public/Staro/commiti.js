function createTable()
{
  var mojDiv=document.getElementById("tabela");
  var brojZadataka = document.getElementById("ZadaciCreate").value;  
  if(mojDiv.getElementsByTagName("table") && mojDiv.getElementsByTagName("table").length>0)
  mojDiv.removeChild(mojDiv.getElementsByTagName("table")[0]);
  tabela= new CommitTabela(mojDiv,parseInt(brojZadataka)); 
  var buttonAdd = document.getElementById("buttonAdd");  
  var buttonEdit = document.getElementById("buttonEdit");  
  var buttonDelete = document.getElementById("buttonDelete");
  if(tabela && brojZadataka>=0)
  {
    buttonAdd.disabled=false; 
    buttonEdit.disabled=false; 
    buttonDelete.disabled=false;    
  }
  else
  {
    buttonAdd.disabled=true; 
    buttonEdit.disabled=true; 
    buttonDelete.disabled=true;
  }
  
}
function addCommit()
{  
  var brojZadatka = document.getElementById('ZadaciAdd').value;
  var urlZadatkaAdd = document.getElementById("UrlAdd");
  var greskaAdd = document.getElementById("GreskaAdd");
  var validacija = new Validacija(greskaAdd);
  validacija.url(urlZadatkaAdd);  
  tabela.dodajCommit(parseInt(brojZadatka),urlZadatkaAdd);   
}
    
function editCommit()
{
  var brojZadatka = document.getElementById("ZadaciEdit").value;
  var brojCommita = document.getElementById("CommitiEdit").value;
  var urlZadatkaEdit = document.getElementById("UrlEdit");
  var greskaEdit = document.getElementById("GreskaEdit");
  var validacija = new Validacija(greskaEdit);
  validacija.url(urlZadatkaEdit); 
  tabela.editujCommit(parseInt(brojZadatka),parseInt(brojCommita),urlZadatkaEdit);  
}
    
function deleteCommit()
{  
  var brojZadatka = document.getElementById("ZadaciDelete").value;
  var brojCommita = document.getElementById("CommitiDelete").value;
  tabela.obrisiCommit(parseInt(brojZadatka),parseInt(brojCommita));  
}
    
    