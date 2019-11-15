function funkcijaUnosGodine()
{
    var mojPojedinacni=document.getElementById("greskaDiv");
    var inputVjezbaGodina=document.getElementById("input11");    
    var inputVjezbaRepozitorij1=document.getElementById("input22");  
    var inputVjezbaRepozitorij2=document.getElementById("input33");
    var validacija = new Validacija(mojPojedinacni);
    var regex = /(([a-z])+)/g;
    validacija.godina(inputVjezbaGodina);
    validacija.repozitorij(inputVjezbaRepozitorij1,regex);
    validacija.repozitorij(inputVjezbaRepozitorij2,regex);
}

