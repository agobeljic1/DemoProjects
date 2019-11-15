function funkcijaLogin()
{
    var mojDiv=document.getElementById("greskaDiv");
    var inputUsername=document.getElementById("username");
    var inputPassword=document.getElementById("password");  
    var validacija = new Validacija(mojDiv);
    validacija.ime(inputUsername);     
    validacija.password(inputPassword);
}