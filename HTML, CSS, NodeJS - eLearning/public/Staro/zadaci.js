function funkcijaSearch()
{
    var mojDiv=document.getElementById("greskaDiv");
    var inputUsername=document.getElementById("input");    
    var validacija = new Validacija(mojDiv);
    validacija.ime(inputUsername);        
}
