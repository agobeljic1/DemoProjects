const Sequelize = require("sequelize");
const sequelize = new Sequelize("wt2018","root","root",{host:"127.0.0.1",dialect:"mysql",logging:false});
const db={};

db.Sequelize = Sequelize;  
db.sequelize = sequelize;

//import modela
db.student = sequelize.import(__dirname+'/moduli/student.js');
db.godina = sequelize.import(__dirname+'/moduli/godina.js');
db.zadatak = sequelize.import(__dirname+'/moduli/zadatak.js');
db.vjezba = sequelize.import(__dirname+'/moduli/vjezba.js');

//relacije
db.godina.hasMany(db.student,{as:'studenti',foreignKey:'studentGod'});

// Veza n-m autor moze imati vise knjiga, a knjiga vise autora
db.godina_vjezba = db.vjezba.belongsToMany(db.godina,{as:'godine',through:'godina_vjezba',foreignKey:'idvjezba'});
db.godina.belongsToMany(db.vjezba,{as:'vjezbe',through:'godina_vjezba',foreignKey:'idgodina'});

//
db.vjezba_zadatak = db.zadatak.belongsToMany(db.vjezba,{as:'vjezbe',through:'vjezba_zadatak',foreignKey:'idzadatak'});
db.vjezba.belongsToMany(db.zadatak,{as:'zadaci',through:'vjezba_zadatak',foreignKey:'idvjezba'});
module.exports=db;