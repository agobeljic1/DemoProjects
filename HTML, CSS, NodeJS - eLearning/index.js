var express = require('express');
var path = require('path');
var fs = require('fs');
var pug = require('pug');
var bodyParser = require('body-parser');
var upload = require('express-fileupload');
var cors = require('cors');
const db = require('./db.js');

var app = express();
app.use(upload());
app.use(cors());
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.static('public'));
app.set('views',path.join(__dirname+"/public/",'views'));
app.set('view engine', 'pug');

db.sequelize.sync(/*{force:true}*/).then(function(){
    {
        inicijalizacija();
        console.log("Baza podataka kreirana");
    }
});
function inicijalizacija(){
    /*db.zadatak.create({naziv:'Zadatak1',postavka:"localhost:8080/PDF/Zadatak1.pdf"}).then(function(k){
        return new Promise(function(resolve,reject){
            resolve(k);
            db.zadatak.create({naziv:'Zadatak2',postavka:"localhost:8080/PDF/Zadatak2.pdf"}).then(function(k){
                return new Promise(function(resolve,reject){
                    resolve(k);
                    db.zadatak.create({naziv:'Zadatak3',postavka:"localhost:8080/PDF/Zadatak3.pdf"}).then(function(k){
                        return new Promise(function(resolve,reject){resolve(k);});
                    })
                });
            })
        });
    })
    return new Promise(function(resolve,reject){}); */               
}


app.post('/addZadatak',function(req,res)
{  
    if(req.files)
    {
        var file = req.files.postavka;
        var document = file.mimetype.endsWith("pdf");
        var imeFajla = req.body["naziv"];
        if(document)
        {

            var putanja= __dirname+"/public/PDF/"+imeFajla + "Zad.json";
            if (fs.existsSync(putanja))
            {
                console.log("File already exists");
                res.render('greska.pug',{Greska:"File vec postoji"});      
            }
            else
            {
                file.mv(__dirname+"/public/PDF/"+req.body["naziv"] + ".pdf",function(err){
                    if(err)
                    {
                        console.log(err);
                        res.render('greska.pug',{Greska:"Desila se greska prilikom uploada pdf-a"});                   
                    }
                    else
                    {
                        res.sendFile(path.join(__dirname + '/public/Staro/'+'addZadatak.html')); 
                    }
                }) 
                filePath=__dirname + "/public/PDF/"+req.body["naziv"]+"Zad.json";
                fileContent={naziv: req.body["naziv"], postavka: "localhost:8080/PDF/"+req.body["naziv"]+".pdf"};
                
                fs.writeFile(filePath,JSON.stringify(fileContent),function(err){
                    if(err)
                    {
                        res.render('greska.pug',{Greska:"Desila se greska prilikom pravljenja jsona"});
                    } 
                    else
                    {
                        db.zadatak.create({naziv:req.body["naziv"],postavka:"localhost:8080/PDF/"+req.body["naziv"]+".pdf"}).then(function(k){
                            return new Promise(function(resolve,reject){resolve(k);});
                        })
                        res.writeHead(200, {'Content-Type': 'application/json'});
                        res.end(JSON.stringify({naziv:req.body["naziv"],postavka:"localhost:8080/PDF/"+req.body["naziv"]+".pdf"})); 
                        console.log("The file was successfully saved");
                    }                     
                })
            }           
        }
        else
        {
           res.render('greska.pug',{Greska:"Nije odabran dokument pdf formata"});            
        }        
    }
    else
    {
        res.render('greska.pug',{Greska:"Dokument nije odabran"});  
    }
});

app.get('/public/views/greska.js',function(req,res){
    
    res.sendFile(path.join(__dirname + '/public/views/greska.js'));
});

app.get('/godine',function(req,res){ 
    var jsonString = new Array();
    db.godina.findAll().then(function(obicni){
        obicni.forEach(godina => {             
            if(godina.nazivGod!=undefined && godina.nazivRepSpi!=undefined && godina.nazivRepVje!=undefined)
            {
                jsonString.push({nazivGod:godina.nazivGod,nazivRepVje:godina.nazivRepSpi,nazivRepSpi:godina.nazivRepVje});
            }
        });
     res.writeHead(200, {'Content-Type': 'application/json'});
     res.end(JSON.stringify(jsonString));
    });  
});
app.get('/godinee',function(req,res){ 
    var jsonString = new Array();
    db.godina.findAll().then(function(obicni){
        obicni.forEach(godina => {             
            if(godina.nazivGod!=undefined && godina.nazivRepSpi!=undefined && godina.nazivRepVje!=undefined)
            {
                jsonString.push({id:godina.id,nazivGod:godina.nazivGod,nazivRepVje:godina.nazivRepSpi,nazivRepSpi:godina.nazivRepVje});
            }
        });
     res.writeHead(200, {'Content-Type': 'application/json'});
     res.end(JSON.stringify(jsonString));
    });  
});
app.get('/vjezbe',function(req,res){ 
    var jsonString = new Array();
    db.vjezba.findAll().then(function(obicni){
        obicni.forEach(vjezba => {             
            if(vjezba.naziv!=undefined && vjezba.spirala!=undefined)
            {
                jsonString.push({id:vjezba.id,naziv:vjezba.naziv,spirala:vjezba.spirala});
            }
        });
     res.writeHead(200, {'Content-Type': 'application/json'});
     res.end(JSON.stringify(jsonString));
    });  
});
app.post('/addVjezba',function(req,res){ 
    if(req.body.sGodine!=undefined && req.body.sVjezbe!=undefined && req.body.spirala==undefined)
    {
        db.vjezba.findOne({where:{id:req.body.sVjezbe}}).then(function(Vjezba){
            db.godina.findOne({where:{id:req.body.sGodine}}).then(function(Godina)
            {
                Godina.addVjezbe(Vjezba);
            });                    
        });
        res.sendFile(path.join(__dirname + '/public/Staro/'+'addVjezba.html'));
        return;
    }
    if(req.body.sGodine!=undefined && req.body.naziv!=undefined)
    {
        var redniBroj=-1;
        var idGodine=-1;
        var dodaniId=-1;
        var spiralaBool = (req.body.spirala!=null);
        db.vjezba.create({naziv:req.body.naziv,spirala:spiralaBool}).then(function(k){
            return new Promise(function(resolve,reject){resolve(k);  
                db.vjezba.findOne({where:{naziv:req.body.naziv}}).then(function(dodanaVjezba){
                    dodaniId=dodanaVjezba.id;
                    db.godina.findOne({where:{id:req.body.sGodine}}).then(function(relatedGodina)
                    {
                        relatedGodina.setVjezbe(dodanaVjezba);
                    });                    
                });              
            });            
        });  
        res.sendFile(path.join(__dirname + '/public/Staro/'+'addVjezba.html'));
        return;
    }
    res.render('greska.pug',{Greska:"Invalidni podaci"});
    
});
app.post('/addGodina',function(req,res)
{             
    db.godina.findOne({where:{nazivGod:req.body['nazivGod']}}).then(function(nadjenaGodina){
        if(nadjenaGodina!=null)
        {
            res.render('greska.pug',{Greska:"Godina vec postoji"});
        }
        else
        {
            console.log("Red ne postoji ");
            if(req.body['nazivGod'] && req.body['nazivRepVje'] && req.body['nazivRepSpi'])
            {
                db.godina.create({nazivGod:req.body['nazivGod'],nazivRepVje:req.body['nazivRepVje'],nazivRepSpi:req.body['nazivRepSpi']}).then(function(k){
                    return new Promise(function(resolve,reject){resolve(k);});
                })
                res.sendFile(path.join(__dirname + '/public/Staro/'+'addGodina.html'));
            }
            else
            {
                res.render('greska.pug',{Greska:"Invalidni podaci"});
            }
        }
    });     
});

app.get('/zadatak',function(req,res)
{
    var naziv = req.query.naziv;
    var putanja= __dirname+"/public/PDF/"+naziv + "Zad.json";

    if (fs.existsSync(putanja))
    {
        res.sendFile(path.join(__dirname+"/public/PDF/"+naziv + ".pdf"));     
    }
    else
    {
        res.render('greska.pug',{Greska:"Dokument postavke ne postoji"});
    }
});
app.get('/zadaci',function(req,res)
{
    
    
    var obj = JSON.parse(JSON.stringify(req.headers));    
    var accept = obj.accept;
    const jsonFolder = './public/PDF/';
    
    var spisakNaziva=new Array();
    var spisakPostavki = new Array();
    var vel=0;
    db.zadatak.findAll().then(function(obicni){
        obicni.forEach(zadatak => {             
            if(zadatak.naziv!=undefined && zadatak.postavka!=undefined)
            {
                spisakNaziva.push(zadatak.naziv);
                spisakPostavki.push(zadatak.postavka);
                vel++;
            }
        });        
                      
        var jsonAccept = (accept.toUpperCase().includes("APPLICATION/JSON"));
        var xmlAccept1 = (accept.toUpperCase().includes("APPLICATION/XML"));
        var xmlAccept2 = (accept.toUpperCase().includes("TEXT/XML"));
        var csvAccept = (accept.toUpperCase().includes("TEXT/CSV"));
        
        if(jsonAccept)
        {
            var jsonContent="";
            
            jsonContent="[";
            if(vel!=0)
            {
                jsonContent+="{\n";
                jsonContent+="\"naziv\": ";
                jsonContent+="\"";
                jsonContent+=spisakNaziva[0];
                jsonContent+="\",";
                jsonContent+="\n\"postavka\": ";
                jsonContent+="\"";
                jsonContent+=spisakPostavki[0];
                jsonContent+="\"";
                jsonContent+="}";
    
            }
    
            for(let i=1;i<vel;i++)
            {
                jsonContent+=",{\n";
                jsonContent+="\"naziv\": ";
                jsonContent+="\"";
                jsonContent+=spisakNaziva[i];
                jsonContent+="\",";
                jsonContent+="\n\"postavka\": ";
                jsonContent+="\"";
                jsonContent+=spisakPostavki[i];
                jsonContent+="\"";
                jsonContent+="}";
            }
            jsonContent+="]";
            res.writeHead(200, {'Content-Type': 'application/json'});        
            res.end(jsonContent);
        }
        else
        {
            if(xmlAccept1 || xmlAccept2)
            {
                var xmlContent="<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
                xmlContent+="<zadaci>\n";
                
                for(let i=0;i<vel;i++)
                {
                    xmlContent+="    <zadatak>\n";    
                    xmlContent+="        <naziv> "+spisakNaziva[i]+" </naziv>\n";
                    xmlContent+="        <postavka> "+spisakPostavki[i]+" </postavka>\n";
                    xmlContent+="    </zadatak>\n";
                }
                xmlContent+="</zadaci>";
                
                res.writeHead(200, {'Content-Type': 'application/xml'});
    
                res.end(xmlContent);
    
    
            }
            else
            {
                if(csvAccept)
                {
                    var csvContent="";
                    for(let i=0;i<vel;i++)
                    {
                        csvContent+=spisakNaziva[i]+","+spisakPostavki[i]+"\n";
                    }
                    res.writeHead(200, {'Content-Type': 'text/csv'});
    
                    res.end(csvContent);
                }
                else
                {
                    res.render('greska.pug',{Greska:"Neodgovarajuci accept header"}); 
                }
            }
        }        
    });    
});
app.get('/zadacii',function(req,res)
{
    var jsonString = new Array();
    db.zadatak.findAll().then(function(obicni){
        obicni.forEach(zadatak => {             
            if(zadatak.naziv!=undefined && zadatak.postavka!=undefined)
            {
                jsonString.push({id:zadatak.id,naziv:zadatak.naziv,spirala:zadatak.postavka});
            }
        });
     res.writeHead(200, {'Content-Type': 'application/json'});
     res.end(JSON.stringify(jsonString));
    }); 
});



app.get('/:urlZadatka',function(req,res)
{
    var urlZad = req.params.urlZadatka;
    res.sendFile(path.join(__dirname + '/public/Staro/'+urlZad));
});
app.post('/vjezba/:idVjezbe/zadatak',function(req,res)
{
    var idVjezbe=req.params.idVjezbe;
    db.vjezba.findOne({where:{id:idVjezbe}}).then(function(Vjezba)
    {
        if(Vjezba==null)
        {
            res.render('greska.pug',{Greska:"Ne postoji vjezba sa datim id-em"}); 
        }
        else
        {
            db.zadatak.findOne({where:{id:req.body.sZadatak}}).then(function(Zadatak)
            {
                if(Zadatak==null)
                {
                    res.render('greska.pug',{Greska:"Ne postoji zadatak sa datim nazivom "});                     
                }
                else
                {
                    Zadatak.addVjezbe(Vjezba);                                     
                    res.redirect('/addVjezba.html'); 
                }                
            });
        }        
    });
});
app.post('/student',function(req,res)
{
    var nazivGodd = req.body.godina;
    var jsonNiz = new Array();
    jsonNiz = req.body.studenti;
    var upisano = 0;
    var dodano = 0;
    var velicinaStudenti = req.body.studenti.length;
    var nizPromisea = new Array();

    for(let i=0;i<velicinaStudenti;i++)
    {
        nizPromisea.push(db.student.findOne({where:{index:jsonNiz[i].index}}).then(function(student)
        {
            return new Promise(function(resolve,reject)
            {
                if(student==null)
                {
                    db.student.create({imePrezime:jsonNiz[i].imePrezime,index:jsonNiz[i].index}).then(function(stud){
                        
                        db.godina.findOne({where:{nazivGod:nazivGodd}}).then(function(Godina)
                        {
                            Godina.addStudenti(stud);
                            upisano++;
                            dodano++;
                            resolve();
                        }); 
                    })
                }
                else
                {
                    db.godina.findOne({where:{nazivGod:nazivGodd}}).then(function(Godina)
                    {
                        Godina.addStudenti(student);
                        upisano++;
                        resolve();
                    }); 
                }    
            });            
        }));
    }
    Promise.all(nizPromisea).then(function(values)
    {    
        var jsonOdgovor = "{\"message\":\"Dodano je "+dodano+" novih studenata i upisano "+upisano+" na godinu "+nazivGodd+"\"}"; 
        res.writeHead(200, {'Content-Type': 'application/json'});
        res.end(JSON.stringify(JSON.parse(jsonOdgovor)));
    })
});
app.listen(8080);
console.log("Server running on localhost:8080");

