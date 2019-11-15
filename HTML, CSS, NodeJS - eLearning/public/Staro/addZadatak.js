function funkcijaDodaj()
{
    var mojDiv=document.getElementById("greskaDiv");
    var inputNaziv=document.getElementById("input1");    
    var validacija = new Validacija(mojDiv);
    validacija.naziv(inputNaziv);        
}
