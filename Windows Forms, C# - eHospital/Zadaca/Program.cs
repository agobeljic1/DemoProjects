using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace Zadaca
{
    

    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>


        [STAThread]
        

        static void Main(string[] args)
        {

            Klinika klinika17938 = new Klinika("DRVOPROMET") ;



            Ordinacija ordinacijaa = new Ordinacija("Hitna", 25);
            klinika17938.ListaOrdinacija.Add(ordinacijaa);

            klinika17938.DodajDoktora("Saban", "Saulic", Convert.ToDateTime("11.11.1989"), "1111989345216", "Muski", "Zmaja od Bosne 3", "Vjencan/a", Convert.ToDateTime("3.5.2005"), ordinacijaa, 1650,"SSA1111989");
            ordinacijaa = new Ordinacija("Opsta", 20);
            klinika17938.ListaOrdinacija.Add(ordinacijaa);
            klinika17938.DodajDoktora("Fahro", "Radoncic", Convert.ToDateTime("13.11.1988"), "1311988345216", "Muski", "Zmaja od Bosne 4", "Vjencan/a", Convert.ToDateTime("2.9.2005"), ordinacijaa, 1900, "FRA1311988");
            ordinacijaa = new Ordinacija("Ortopedija", 30);
            klinika17938.DodajDoktora("Kiko", "Kasilja", Convert.ToDateTime("15.11.1987"), "1511987345216", "Muski", "Zmaja od Bosne 5", "Vjencan/a", Convert.ToDateTime("1.8.2005"), ordinacijaa, 1150, "KKA1511987");
            ordinacijaa = new Ordinacija("Kardiologija", 20);
            klinika17938.ListaOrdinacija.Add(ordinacijaa);
            klinika17938.DodajDoktora("Halid", "Muslimovic", Convert.ToDateTime("17.11.1991"), "1711991345216", "Muski", "Zmaja od Bosne 6", "Vjencan/a", Convert.ToDateTime("1.1.2005"), ordinacijaa, 2050, "HMU1711991");
            ordinacijaa = new Ordinacija("Dermatologija", 15);
            klinika17938.ListaOrdinacija.Add(ordinacijaa);
            klinika17938.DodajDoktora("Serif", "Konjevic", Convert.ToDateTime("3.12.1992"), "0312992345216", "Muski", "Zmaja od Bosne 7", "Nevjencan/a", Convert.ToDateTime("1.6.2005"), ordinacijaa, 2125, "SKO0312992");
            ordinacijaa = new Ordinacija("Internistika", 25);
            klinika17938.ListaOrdinacija.Add(ordinacijaa);
            klinika17938.DodajDoktora("Ibro", "Bublin", Convert.ToDateTime("1.8.1993"), "0108993345216", "Muski", "Zmaja od Bosne 8", "Vjencan/a", Convert.ToDateTime("1.10.2005"), ordinacijaa, 1300, "IBU0108993");
            ordinacijaa = new Ordinacija("Otorinolaringologija", 30);
            klinika17938.ListaOrdinacija.Add(ordinacijaa);
            klinika17938.DodajDoktora("Amar", "Gile", Convert.ToDateTime("2.7.1989"), "0207989345216", "Muski", "Zmaja od Bosne 9", "Vjencan/a", Convert.ToDateTime("1.11.2005"), ordinacijaa, 1175, "AGI0207989");
            ordinacijaa = new Ordinacija("Oftamologija", 20);
            klinika17938.ListaOrdinacija.Add(ordinacijaa);
            klinika17938.DodajDoktora("Alex", "Ferguson", Convert.ToDateTime("1.8.1985"), "0108985345216", "Muski", "Zmaja od Bosne 10", "Vjencan/a", Convert.ToDateTime("1.12.2005"), ordinacijaa, 2515, "AFE0108985");
            ordinacijaa = new Ordinacija("Laboratorija", 20);
            klinika17938.ListaOrdinacija.Add(ordinacijaa);
            klinika17938.DodajDoktora("Albert", "Einstein", Convert.ToDateTime("11.3.1980"), "1103980345216", "Muski", "Zmaja od Bosne 11", "Nevjencan/a", Convert.ToDateTime("1.4.2005"), ordinacijaa, 1465, "AEI1103980");
            ordinacijaa = new Ordinacija("Stomatologija", 10);
            klinika17938.ListaOrdinacija.Add(ordinacijaa);
            klinika17938.DodajDoktora("Huse", "Fatkic", Convert.ToDateTime("17.6.1978"), "1706978345216", "Muski", "Zmaja od Bosne 12", "Vjencan/a", Convert.ToDateTime("1.1.2005"), ordinacijaa, 1433.33, "HFA1706978");
            ordinacijaa = new Ordinacija("Hirurgija", 50);
            klinika17938.ListaOrdinacija.Add(ordinacijaa);
            klinika17938.DodajDoktora("Robert", "Kumerle", Convert.ToDateTime("29.12.1972"), "2912972345216", "Muski", "Zmaja od Bosne 13", "Vjencan/a", Convert.ToDateTime("1.2.2005"), ordinacijaa, 1798, "RKU2912972");
            Dictionary<DateTime, string> vakc = new Dictionary<DateTime, string>();
            Dictionary<DateTime, string> alerg = new Dictionary<DateTime, string>();
            vakc.Add(Convert.ToDateTime("17.6.2007"), "Tetanus");
            vakc.Add(Convert.ToDateTime("17.6.2002"), "Difterija");
            alerg.Add(Convert.ToDateTime("22.11.2001"), "Mlijeko");
            alerg.Add(Convert.ToDateTime("3.9.2003"), "Salama");
            Pacijent pac = new Pacijent("imenko", "prezimenko", Convert.ToDateTime("22/07/1997"), "2207997178388", "Musko", "Zmaja od Bosne 94", "Vjencan/a", vakc,alerg,"password",Image.FromFile(@"D:\ADNAN\ETF\Druga Godina\Predmeti\NOVI\RPR\Zadace\Zadaca 2\Zadaca\sabansaulic.jpg"));
            klinika17938.ListaPacijenata.Add(pac);
            Admin adm = new Admin("Admin", "Adminovic", Convert.ToDateTime("12/03/1997"), "1203997170188", "Musko", "Zmaja od Bosne 22", "Vjencan/a", Convert.ToDateTime("1.7.2005"),3333, "adminska");
            klinika17938.ListaAdministratora.Add(adm);
            Portir portir = new Portir("Semsudin", "Poplava", Convert.ToDateTime("29/09/1965"), "2909965170088", "Musko", "Zmaja od Bosne 33", "Vjencan/a", Convert.ToDateTime("1.2.2005"), ordinacijaa, 798, "portirska");
            klinika17938.ListaZaposlenika.Add(portir);/*
            pac=new Pacijent("imenko", "prezimenko", "22/03/1997", 1703997170088, "Musko", "Zmaja od Bosne bb", "Ozenjen", "");
            klinika17938.ListaPacijenata.Add(pac);
             ZA LAKSE TESTIRANJE
             */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form forma = new Ulaz(klinika17938);
            
            Application.Run(forma);


            







            

        }



            



        /*

        static void RegistrovanjePacijenta(ref Klinika klinika17938)
        {

            string entry;
            string input;
            Console.WriteLine("Odaberite jednu od opcija:\n");
            Console.WriteLine("1. Registrovanje hitnog pacijenta");
            Console.WriteLine("2. Registrovanje obicnog pacijenta");            
            Console.WriteLine("3. Brisanje pacijenta");
            Console.WriteLine("4. Povratak na glavni meni");



            entry = Console.ReadLine();
            switch (entry)
            {
                case ("1"):
                    {
                        
                        Pacijent hitni = new Pacijent();
                        int a = klinika17938.ZakaziNoviPregled(0,hitni);
                        Console.WriteLine("Uspjesno zakazan pregled");
                        /*string spol;
                        Console.WriteLine("Unesite spol osobe: ");
                        bool dobarUnos;
                        do
                        {
                            Console.WriteLine("Odaberite opciju: ");
                            Console.WriteLine("1. Muski");
                            Console.WriteLine("2. Zenski");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    spol = "Muski";
                                    dobarUnos = true;
                                    break;
                                case "2":
                                    spol = "Zenski";
                                    dobarUnos = true;
                                    break;
                                default:
                                    Console.WriteLine("Pogresan unos.");
                                    spol = "";
                                    dobarUnos = false;
                                    break;
                                    

                            }
                        }
                        while (!dobarUnos);
                         
                         do
                        {
                            Console.WriteLine("Da li je pacijent prezivio: ");
                            Console.WriteLine("Odaberite opciju: ");
                            Console.WriteLine("1. Da");
                            Console.WriteLine("2. Ne");
                            switch(input)
                            {
                                case "1":

                                    dobarUnos = true;
                                    
                                    break;
                                case "2":
                                    dobarUnos = true;
                                    Pregled obdukcija = new Pregled("Patologija", hitni, false, false);
                                    klinika17938.ZakaziNoviPregled(11, pacijent);



                                    
                                    break;

                                default:
                                    dobarUnos = false;
                                    Console.WriteLine("Pogresan unos.");
                                    break;

                            }
                        }
                        while(!dobarUnos)*/







        /*
                        break;
                    }
                case ("2"):
                    {
                        string ime;
                        string prezime;
                        DateTime datumRodjenja;
                        string maticniBroj;
                        string spol;
                        string adresa;
                        string stanje;
                        

                        
                        Console.WriteLine("Unesite ime: ");
                        ime = Console.ReadLine();
                        Console.WriteLine("Unesite prezime: ");
                        prezime = Console.ReadLine();
                        bool unos = true;
                        do {
                            for (; ; )
                            {
                                Console.WriteLine("Unesite datum rodjenja: (DD/MM/YYYY)");
                                input = Console.ReadLine();
                                if (DateTime.TryParse(input, out datumRodjenja))
                                    break;
                                else
                                    Console.WriteLine("Pogresan unos.");
                            }
                            for (; ; )
                            {
                                Console.WriteLine("Unesite maticni broj: ");
                                input = Console.ReadLine();
                                
                                if (input.Length != 13)
                                {
                                    Console.WriteLine("Pogresan unos.");
                                    continue;
                                }
                                bool dobarUnos = true;
                                int broj;
                                List<int> brojevi = new List<int>();
                                for (int i = 0; i < 13; i++)
                                {
                                    broj = 0;
                                    brojevi.Add(broj);
                                    if (!Int32.TryParse(input[i].ToString(), out broj))
                                    {
                                        Console.WriteLine("Pogresan unos.");
                                        dobarUnos = false;
                                        break;
                                    }
                                    else
                                    {
                                        brojevi[i] = broj;
                                    }

                                }
                                
                                if (!dobarUnos)
                                    continue;
                                if (((datumRodjenja.Year) % 1000) != (brojevi[4]*100+brojevi[5]*10+brojevi[6]) || datumRodjenja.Day != (brojevi[0]*10+brojevi[1]) || datumRodjenja.Month != (10*brojevi[2] + brojevi[3]))
                                {
                                    Console.WriteLine("Datum nije kompatibilan sa maticnim brojem. Ponovite unos:");
                                    unos = false;
                                    break;
                                }
                                maticniBroj = input;
                                unos = true;
                                break;


                            }
                        }
                        while (!unos);
                        maticniBroj = input;
                        bool pronadjen = false;
                        int redniBroj = -1;
                        foreach (var pacijent in klinika17938.ListaPacijenata)
                        {
                            if (ime == pacijent.Ime && prezime == pacijent.Prezime && maticniBroj == pacijent.MaticniBroj)
                            {
                                pronadjen = true;
                                pacijent.BrojPosjeta++;
                                redniBroj++;
                                Console.WriteLine("\nIme: {0}", pacijent.Ime);
                                Console.WriteLine("Prezime: {0}", pacijent.Prezime);
                                Console.WriteLine("Maticni broj: {0}", pacijent.MaticniBroj);
                                Console.WriteLine("Datum rodjenja: {0}", pacijent.DatumRodjenja.ToString("dd/MM/yyyy"));
                                Console.WriteLine("Spol: {0}", pacijent.Spol);
                                Console.WriteLine("Adresa stanovanja: {0}", pacijent.AdresaStanovanja);
                                Console.WriteLine("Bracno stanje: {0}\n", pacijent.BracnoStanje);
                                break;
                            }
                        }
                        if (!pronadjen)
                        {
                            Console.WriteLine("Pacijent nije dosad evidentiran u klinici.");
                            bool dobarUnos;
                            Console.WriteLine("Unesite spol osobe: ");
                            do
                            {
                                Console.WriteLine("Odaberite opciju: ");
                                Console.WriteLine("1. Muski");
                                Console.WriteLine("2. Zenski");
                                input = Console.ReadLine();
                                switch (input)
                                {
                                    case "1":
                                        spol = "Muski";
                                        dobarUnos = true;
                                        break;
                                    case "2":
                                        spol = "Zenski";
                                        dobarUnos = true;
                                        break;
                                    default:
                                        Console.WriteLine("Pogresan unos.");
                                        spol = "";
                                        dobarUnos = false;
                                        break;

                                }
                            }
                            while (!dobarUnos);
                            Console.WriteLine("Unesite adresu stanovanja: ");
                            adresa = Console.ReadLine();

                            for (; ; )
                            {
                                Console.WriteLine("Unesite bracno stanje (N za Neozenjen/a,O za Ozenjen/a)");
                                input = Console.ReadLine();
                                if (input != "N" && input != "O")
                                    Console.WriteLine("Pogresan unos.");
                                else
                                {
                                    if (input == "N")
                                        stanje = "Neozenjen";
                                    else
                                        stanje = "Ozenjen";
                                    break;
                                }
                            }
                            Dictionary<DateTime, string> vakcinacije = new Dictionary<DateTime, string>();
                            
                            Console.WriteLine("Unesite podatke o vakcinacijama: ");
                            int velicina = 0;
                            
                            for(; ; )
                            {
                                string opisVakcinacije;
                                DateTime datumVakcinacije;

                                Console.WriteLine("Unesite {0}. vakcinaciju (X za prekid unosa)", velicina + 1);
                                input = Console.ReadLine();
                                switch (input)
                                {
                                    case ("X"):
                                        {
                                            velicina = -1;
                                            break;
                                        }
                                    default:
                                        {
                                            opisVakcinacije = input;
                                            for (; ; )
                                            {
                                                Console.WriteLine("Unesite datum vakcinacije: ");
                                                input = Console.ReadLine();
                                                if (DateTime.TryParse(input, out datumVakcinacije))
                                                    break;
                                                else
                                                    Console.WriteLine("Pogresan unos.");
                                            }
                                            vakcinacije.Add(datumVakcinacije, opisVakcinacije);
                                            velicina++;
                                            break;
                                        }
                                }
                                if (velicina == -1)
                                    break;
                            }
                            velicina = 0;
                            Dictionary<DateTime, string> alergije = new Dictionary<DateTime, string>();
                            for (; ; )
                            {
                                string opisAlergije;
                                DateTime datumAlergije;
                                Console.WriteLine("Unesite {0}. alergiju (X za prekid unosa)", velicina + 1);
                                input = Console.ReadLine();
                                switch (input)
                                {
                                    case ("X"):
                                        {
                                            velicina = -1;
                                            break;
                                        }
                                    default:
                                        {
                                            opisAlergije = input;
                                            for (; ; )
                                            {
                                                Console.WriteLine("Unesite datum ustanovljivanja alergije: ");
                                                input = Console.ReadLine();
                                                if (DateTime.TryParse(input, out datumAlergije))
                                                    break;
                                                else
                                                    Console.WriteLine("Pogresan unos.");
                                            }
                                            alergije.Add(datumAlergije, opisAlergije);
                                            velicina++;
                                            break;
                                        }
                                }
                                if (velicina == -1)
                                    break;  
                            }


                            redniBroj = klinika17938.RegistrirajNovogPacijenta(ime, prezime, datumRodjenja, maticniBroj, spol, adresa, stanje,vakcinacije,alergije);
                            Console.WriteLine("Uspjesno unesen pacijent");
                        }
                        
                        
                            for (; ; )
                            {
                                Console.WriteLine("Da li zelite zakazati pregled: (DA ili NE)");
                                input = Console.ReadLine();
                                if (input == "NE")
                                    break;
                                else if (input != "DA")
                                    Console.WriteLine("Pogresan unos.");
                                else
                                {
                                    
                                    
                                    Console.WriteLine("Koji pregled zelite?\n");
                                    Console.WriteLine("1. Opsti");
                                    Console.WriteLine("2. Ortopedski");
                                    Console.WriteLine("3. Kardioloski");
                                    Console.WriteLine("4. Dermatoloski");
                                    Console.WriteLine("5. Internisticki");
                                    Console.WriteLine("6. Otorinolaringoloski");
                                    Console.WriteLine("7. Oftamoloski");
                                    Console.WriteLine("8. Laboratorijski");
                                    Console.WriteLine("9. Stomatoloski");
                                    Console.WriteLine("10. Hirurski");
                                    Console.WriteLine("11. Pregled za vozacku dozvolu");
                                    Console.WriteLine("12. Pregled za konkurs za posao");
                                    

                                    input = Console.ReadLine();
                                    int broj;
                                    if (!Int32.TryParse(input, out broj) || broj < 1 || broj > 12)
                                    {
                                        Console.WriteLine("Pogresan unos.");
                                        break;
                                    }
                                    string[] lista = { "opsti", "ortopedski", "kardioloski", "dermatoloski", "internisticki", "otorinolaringolski", "oftamoloski", "laboratorijski", "stomatoloski","hirurski" };
                                    
                                    switch (broj)
                                    {
                                        case 1:
                                        case 2:
                                        case 3:
                                        case 4:
                                        case 5:
                                        case 6:
                                        case 7:
                                        case 8:
                                        case 9:
                                        case 10:
                                            {
                                                int index = klinika17938.ZakaziNoviPregled(broj, klinika17938.ListaPacijenata[redniBroj]);
                                                Console.WriteLine("Zabiljezen {0} pregled: {1} po redu u ordinaciji na listi cekanja", lista[broj - 1], index+1);
                                                break;
                                            }
                                        case 11:
                                            {
                                                Console.WriteLine("Zabiljezen {0} pregled: {1} po redu u ordinaciji na listi cekanja", lista[0], klinika17938.ZakaziNoviPregled(0, klinika17938.ListaPacijenata[redniBroj])+1);
                                                Console.WriteLine("Zabiljezen {0} pregled: {1} po redu u ordinaciji na listi cekanja", lista[5], klinika17938.ZakaziNoviPregled(5, klinika17938.ListaPacijenata[redniBroj])+1);
                                                Console.WriteLine("Zabiljezen {0} pregled: {1} po redu u ordinaciji na listi cekanja", lista[6], klinika17938.ZakaziNoviPregled(6, klinika17938.ListaPacijenata[redniBroj])+1);
                                                break;
                                            }
                                        case 12:
                                            {
                                                Console.WriteLine("Zabiljezen {0} pregled: {1} po redu u ordinaciji na listi cekanja", lista[0], klinika17938.ZakaziNoviPregled(0, klinika17938.ListaPacijenata[redniBroj])+1);
                                                Console.WriteLine("Zabiljezen {0} pregled: {1} po redu u ordinaciji na listi cekanja", lista[2], klinika17938.ZakaziNoviPregled(2, klinika17938.ListaPacijenata[redniBroj])+1);
                                                Console.WriteLine("Zabiljezen {0} pregled: {1} po redu u ordinaciji na listi cekanja", lista[4], klinika17938.ZakaziNoviPregled(4, klinika17938.ListaPacijenata[redniBroj])+1);
                                                Console.WriteLine("Zabiljezen {0} pregled: {1} po redu u ordinaciji na listi cekanja", lista[6], klinika17938.ZakaziNoviPregled(6, klinika17938.ListaPacijenata[redniBroj])+1);
                                                break;
                                            }

                                    }
                                    
                                }
                            }

                        /*else
                        {
                            Console.WriteLine("Koji pregled zelite?\n");
                                        Console.WriteLine("1. Opsti");
                                        Console.WriteLine("2. Ortopedski");
                                        Console.WriteLine("3. Kardioloski");
                                        Console.WriteLine("4. Dermatoloski");
                                        Console.WriteLine("5. Internisticki");
                                        Console.WriteLine("6. Otorinolaringoloski");
                                        Console.WriteLine("7. Oftamoloski");
                                        Console.WriteLine("8. Laboratorijski");
                                        Console.WriteLine("9. Stomatoloski");
                                        Console.WriteLine("10. Hirurski");
                                        Console.WriteLine("11. Pregled za vozacku dozvolu");
                                        Console.WriteLine("12. Pregled za konkurs za posao");
                                        Console.WriteLine("Hirurski uskoro dostupan");

                                        input = Console.ReadLine();
                                        int broj;
                                        if (!Int32.TryParse(input, out broj) || broj < 1 || broj > 12)
                                        {
                                            Console.WriteLine("Pogresan unos.");
                                            break;
                                        }
                                        string[] lista = { "opsti", "ortopedski", "kardioloski", "dermatoloski", "internisticki", "otorinolaringolski", "oftamoloski", "laboratorijski", "stomatoloski","hirurski" };
                                        
                                        switch (broj)
                                        {
                                            case 1:
                                            case 2:
                                            case 3:
                                            case 4:
                                            case 5:
                                            case 6:
                                            case 7:
                                            case 8:
                                            case 9:
                                            case 10:
                                                {
                                                    int index = klinika17938.ZakaziNoviPregled(broj, klinika17938.ListaPacijenata[redniBroj]);
                                                    Console.WriteLine("Zabiljezen {0} pregled: {1} po redu u ordinaciji na listi cekanja", lista[broj - 1], index);
                                                    break;
                                                }
                                            case 11:
                                                {
                                                    Console.WriteLine("Zabiljezen {0} pregled: {1} po redu u ordinaciji na listi cekanja", lista[0], klinika17938.ZakaziNoviPregled(0, klinika17938.ListaPacijenata[redniBroj])+1);
                                                    Console.WriteLine("Zabiljezen {0} pregled: {1} po redu u ordinaciji na listi cekanja", lista[5], klinika17938.ZakaziNoviPregled(5, klinika17938.ListaPacijenata[redniBroj])+1);
                                                    Console.WriteLine("Zabiljezen {0} pregled: {1} po redu u ordinaciji na listi cekanja", lista[6], klinika17938.ZakaziNoviPregled(6, klinika17938.ListaPacijenata[redniBroj])+1);
                                                    break;
                                                }
                                            case 12:
                                                {
                                                    Console.WriteLine("Zabiljezen {0} pregled: {1} po redu u ordinaciji na listi cekanja", lista[0], klinika17938.ZakaziNoviPregled(0, klinika17938.ListaPacijenata[redniBroj])+1);
                                                    Console.WriteLine("Zabiljezen {0} pregled: {1} po redu u ordinaciji na listi cekanja", lista[2], klinika17938.ZakaziNoviPregled(2, klinika17938.ListaPacijenata[redniBroj])+1);
                                                    Console.WriteLine("Zabiljezen {0} pregled: {1} po redu u ordinaciji na listi cekanja", lista[4], klinika17938.ZakaziNoviPregled(4, klinika17938.ListaPacijenata[redniBroj])+1);
                                                    Console.WriteLine("Zabiljezen {0} pregled: {1} po redu u ordinaciji na listi cekanja", lista[6], klinika17938.ZakaziNoviPregled(6, klinika17938.ListaPacijenata[redniBroj])+1);
                                                    break;
                                                }

                                        }




                                    }
                                }
                            }




                        }*/




        /*
                        break;
                    }
                case ("3"):
                    {
                        string ime;
                        string prezime;
                        string maticniBroj;
                        Console.WriteLine("Unesite ime: ");
                        ime = Console.ReadLine();
                        Console.WriteLine("Unesite prezime: ");
                        prezime = Console.ReadLine();
                        bool dobarUnos = false;
                        do
                        {
                            Console.WriteLine("Unesite maticni broj: ");
                            input = Console.ReadLine();
                            int broj;
                            if (input.Length != 13)
                            {
                                Console.WriteLine("Pogresan unos.");
                                continue;
                            }
                            dobarUnos = true;
                            for (int i = 0; i < 13; i++)
                            {
                                if (!Int32.TryParse(input[i].ToString(), out broj))
                                {
                                    Console.WriteLine("Pogresan unos.");
                                    dobarUnos = false;
                                    break;
                                }
                            }
                        }
                        while (!dobarUnos);
                        maticniBroj = input;
                        bool pronadjen = false;
                        int indeks=0;
                        foreach (var pacijent in klinika17938.ListaPacijenata)
                        {
                            if (ime == pacijent.Ime && prezime == pacijent.Prezime && maticniBroj == pacijent.MaticniBroj)
                            {
                                pronadjen = true;

                                Console.WriteLine("\nIme: {0}", pacijent.Ime);
                                Console.WriteLine("Prezime: {0}", pacijent.Prezime);
                                Console.WriteLine("Maticni broj: {0}", pacijent.MaticniBroj);
                                Console.WriteLine("Datum rodjenja: {0}", pacijent.DatumRodjenja.ToString("dd/MM/yyyy"));
                                Console.WriteLine("Spol: {0}", pacijent.Spol);
                                Console.WriteLine("Adresa stanovanja: {0}", pacijent.AdresaStanovanja);
                                Console.WriteLine("Bracno stanje: {0}\n", pacijent.BracnoStanje);
                                klinika17938.ListaPacijenata.RemoveAt(indeks);
                                Console.WriteLine("Pacijent uspjesno obrisan");
                                break;
                            }
                            indeks++;
                        }
                        if (!pronadjen)
                            Console.WriteLine("Uneseni pacijent nije pronadjen.");
                        break;
                    }
                case ("0"):
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Pogresan unos.");
                        break;
                    }
            }            
        }

    









    
        static void RasporedPregledaPacijenta(ref Klinika klinika17938)
        {
            string input;
            string ime, prezime;
            string maticniBroj;
            Console.WriteLine("Unesite ime pacijenta: ");
            ime = Console.ReadLine();
            Console.WriteLine("Unesite prezime: ");
            prezime = Console.ReadLine();

            bool dobarUnos = false;
            do
            {
                Console.WriteLine("Unesite maticni broj: ");
                input = Console.ReadLine();
                int broj;
                if (input.Length != 13)
                {
                    Console.WriteLine("Pogresan unos.");
                    continue;
                }
                dobarUnos = true;
                for (int i = 0; i < 13; i++)
                {
                    if (!Int32.TryParse(input[i].ToString(), out broj))
                    {
                        Console.WriteLine("Pogresan unos.");
                        dobarUnos = false;
                        break;
                    }
                }
            }
            while (!dobarUnos);
            maticniBroj = input;

            bool pronadjen = false;
            int brojRedni = -1;
            foreach (var pacijent in klinika17938.ListaPacijenata)
            {
                brojRedni++;
                if (ime == pacijent.Ime && prezime == pacijent.Prezime && maticniBroj == pacijent.MaticniBroj)
                {
                    pronadjen = true;
                    pacijent.BrojPosjeta++;
                    foreach (int a in pacijent.KartonPacijenta.ListaCekanja)
                    {
                        Console.Write("{0} ", klinika17938.ListaPregledaCekanja[a].Ordinacija);
                        Console.Write("{0}\n ", klinika17938.ListaPregledaCekanja[a].VrijemePregleda);

                    }

                    break;
                }
            }
            if (!pronadjen)
            {
                Console.WriteLine("Pacijent nije pronadjen");
            }
            
        }
        static void KreiranjeKartonaPacijenta(ref Klinika klinika17938)
        {
            Console.WriteLine("Unesite ime pacijenta: ");
            string ime = Console.ReadLine();
            Console.WriteLine("Unesite prezime pacijenta: ");
            string prezime = Console.ReadLine();
            string maticniBroj;
            string inp;
            bool unos = false;
            do
            {
                Console.WriteLine("Unesite maticni broj: ");
                inp = Console.ReadLine();
                int broj;
                if (inp.Length != 13)
                {
                    Console.WriteLine("Pogresan unos.");
                    continue;
                }
                unos = true;
                for (int i = 0; i < 13; i++)
                {
                    if (!Int32.TryParse(inp[i].ToString(), out broj))
                    {
                        Console.WriteLine("Pogresan unos.");
                        unos = false;
                        break;
                    }
                }
            }
            while (!unos);
            maticniBroj = inp;

            foreach (Pacijent pac in klinika17938.ListaPacijenata)
            {
                if (pac.Ime == ime && pac.Prezime == prezime && pac.MaticniBroj == maticniBroj)
                {
                    Console.WriteLine("Opis bolesti: ");
                    string opisBolesti;
                    opisBolesti = Console.ReadLine();

                    Console.WriteLine("Zdravstveno stanje porodice: ");
                    string sadasnjeStanje;
                    sadasnjeStanje = Console.ReadLine();

                    Console.WriteLine("Sadasnje stanje: ");
                    string sadasnjeeStanje;
                    sadasnjeeStanje = Console.ReadLine();

                    Console.WriteLine("Zakljucak doktora: ");
                    string zakljucakDoktora;
                    zakljucakDoktora = Console.ReadLine();
                    pac.KartonPacijenta.OpisBolesti = opisBolesti;
                    pac.KartonPacijenta.ZdravstvenoStanjePorodice = sadasnjeStanje;
                    pac.KartonPacijenta.SadasnjeStanje = sadasnjeeStanje;
                    pac.KartonPacijenta.ZakljucakDoktora = zakljucakDoktora;

                    break;
                }
            }



            

            
    }

        static void PretragaKartonaPacijenta(ref Klinika klinika17938)
        {
            Console.WriteLine("Unesite ime pacijenta: ");
            string ime = Console.ReadLine();
            Console.WriteLine("Unesite prezime pacijenta: ");
            string prezime = Console.ReadLine();
            string maticniBroj;
            string inp;
            bool unos = false;
            do
            {
                Console.WriteLine("Unesite maticni broj: ");
                inp = Console.ReadLine();
                int broj;
                if (inp.Length != 13)
                {
                    Console.WriteLine("Pogresan unos.");
                    continue;
                }
                unos = true;
                for (int i = 0; i < 13; i++)
                {
                    if (!Int32.TryParse(inp[i].ToString(), out broj))
                    {
                        Console.WriteLine("Pogresan unos.");
                        unos = false;
                        break;
                    }
                }
            }
            while (!unos);
            maticniBroj = inp;

            foreach(Pacijent pac in klinika17938.ListaPacijenata)
            {
                if(pac.Ime==ime && pac.Prezime==prezime && pac.MaticniBroj==maticniBroj)
                {
                    Console.WriteLine("Alergije: ");
                    foreach (var a in pac.KartonPacijenta.Alergije)
                    {
                        Console.WriteLine("Alergija: {0}", a.Key);
                        Console.WriteLine("Datum ustanovljivanja alergije: {0}", a.Value);
                    }
                    Console.WriteLine("Vakcinacije: ");
                    foreach (var a in pac.KartonPacijenta.Vakcinacije)
                    {
                        Console.WriteLine("Vakcinacija: {0}", a.Key);
                        Console.WriteLine("Datum vakcinisanja: {0}", a.Value);
                    }
                    foreach (var a in pac.KartonPacijenta.SpisakPregleda)
                    {
                        Console.WriteLine("Datum pregleda: {0}", a.VrijemePregleda);
                        Console.WriteLine("Zakljucak doktora: {0}", a.ZakljucakDoktora);
                        
                    }

                    break;
                }
            }





        }
        static void RegistrovanjeNovogPregleda(ref Klinika klinika17938)
        {
            string ime;
            string prezime;
            string maticniBroj;
            string input;

            Console.WriteLine("Unesite ime pacijenta: ");
            ime = Console.ReadLine();
            Console.WriteLine("Unesite prezime pacijenta: ");
            prezime = Console.ReadLine();

            /*for (; ; )
            {
                Console.WriteLine("Unesite maticni broj pacijenta: ");
                input = Console.ReadLine();
                if (input.Length != 13 || !long.TryParse(input, out maticniBroj))
                    Console.WriteLine("Pogresan unos.");
                else
                    break;
            }*//*
            bool unos=false;
            do
            {
                Console.WriteLine("Unesite maticni broj: ");
                input = Console.ReadLine();
                int broj;
                if (input.Length != 13)
                {
                    Console.WriteLine("Pogresan unos.");
                    continue;
                }
                unos = true;
                for (int i = 0; i < 13; i++)
                {
                    if (!Int32.TryParse(input[i].ToString(), out broj))
                    {
                        Console.WriteLine("Pogresan unos.");
                        unos = false;
                        break;
                    }
                }
            }
            while (!unos);
            maticniBroj = input;
            Console.WriteLine("Unesite ordinaciju pregleda: ");
            string ord = Console.ReadLine();
            int indeks = 0;
            bool uletio = false;
            foreach(Pregled pregled in klinika17938.ListaPregledaCekanja)
            {
                if(pregled.PregledaniPacijent.Ime==ime && pregled.PregledaniPacijent.Prezime==prezime && pregled.PregledaniPacijent.MaticniBroj==maticniBroj)
                {
                    pregled.PregledaniPacijent.KartonPacijenta.ListaCekanja.Remove(indeks);
                    uletio = true;
                    
                    
                    pregled.NadlezniDoktor.ZaposlenikovaOrdinacija.Slobodno = false;
                    Console.WriteLine("Zakljucak doktora: ");
                    pregled.ZakljucakDoktora = Console.ReadLine();
                    bool dobarUnos;
                    do
                    {
                        Console.WriteLine("Da li je propisana terapija: ");
                        Console.WriteLine("1. DA");
                        Console.WriteLine("2. NE");
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                {
                                    List<string> lijekovi = new List<string>();
                                    List<string> opisUnosa = new List<string>();
                                    List<int> brojUnosa = new List<int>();
                                    List<int> razmakUnosa = new List<int>();
                                    int velicina = 0;
                                    for (; ; )
                                    {
                                        string lijek;
                                        string opis;
                                        int broj;
                                        int razmak;
                                        Console.WriteLine("Unesite {0}. lijek (X za prekid unosa)", velicina + 1);
                                        input = Console.ReadLine();
                                        switch (input)
                                        {
                                            case ("X"):
                                                {
                                                    velicina = -1;
                                                    break;
                                                }
                                            default:
                                                {
                                                    lijek = input;
                                                    for (; ; )
                                                    {
                                                        Console.WriteLine("Unesite broj unosa lijeka: ");
                                                        input = Console.ReadLine();
                                                        if (!Int32.TryParse(input, out broj) || broj <= 0)
                                                            Console.WriteLine("Pogresan unos.");
                                                        else
                                                            break;
                                                        
                                                    }
                                                    for (; ; )
                                                    { 
                                                        Console.WriteLine("Unesite razmak izmedju dva unosa lijeka: ");
                                                        input = Console.ReadLine();
                                                        if (!Int32.TryParse(input, out razmak) || razmak <= 0)
                                                            Console.WriteLine("Pogresan unos.");
                                                        else
                                                            break;
                                                    }
                                                    
                                                    Console.WriteLine("Unesite detaljniji opis unosa lijeka: ");
                                                    opis = Console.ReadLine();

                                                    lijekovi.Add(lijek);
                                                    opisUnosa.Add(opis);
                                                    brojUnosa.Add(broj);
                                                    razmakUnosa.Add(razmak);
                                                    break;
                                                }
                                        }
                                        if (velicina == -1)
                                            break;
                                        
                                        velicina++;
                                    }
                                    pregled.PropisanaTerapija = new Terapija(lijekovi, brojUnosa, razmakUnosa, opisUnosa);
                                    pregled.PregledaniPacijent.IsplacenPregled = false;
                                    pregled.PregledaniPacijent.ZadnjiPregled = pregled;


                                    dobarUnos = true;
                                    break;
                                }
                            case "2":
                                dobarUnos = true;
                                pregled.PregledaniPacijent.IsplacenPregled = false;
                                pregled.PregledaniPacijent.ZadnjiPregled = pregled;
                                break;
                            default:
                                dobarUnos = false;
                                Console.WriteLine("Pogresan unos.");
                                break;
                        }
                    }
                    while (!dobarUnos);
                    do
                    {
                        Console.WriteLine("Da li ordinacija postaje slobodna: ");
                        Console.WriteLine("1. Da");
                        Console.WriteLine("2. Ne");
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                pregled.NadlezniDoktor.ZaposlenikovaOrdinacija.Slobodno = true;
                                dobarUnos = true;
                                break;
                            case "2":
                                pregled.NadlezniDoktor.ZaposlenikovaOrdinacija.Slobodno = false;
                                dobarUnos = true;
                                break;

                            default:
                                dobarUnos = false;
                                break;
                        }

                    }
                    while (!dobarUnos);








                    pregled.PregledaniPacijent.KartonPacijenta.SpisakPregleda.Add(pregled);

                    klinika17938.ListaPregledaCekanja.Remove(pregled);
                    
                    break;

                }
                indeks++;
            }
            if (!uletio)
                Console.WriteLine("Pacijent nije pronadjen.");



        }
        static void AnalizaSadrzaja(ref Klinika klinika17938)
        {
            Console.WriteLine("Odaberite jednu od opcija: ");
            Console.WriteLine("1. Ordinacija sa najvecim redom cekanja");
            Console.WriteLine("2. Najprometniji dan u skorije vrijeme ");
            Console.WriteLine("3. Najcesce prezime pacijenta");

            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    {
                        var most = (from i in klinika17938.ListaPregledaCekanja
                                    group i by i.Ordinacija into grp
                                    orderby grp.Count() descending
                                    select grp.Key).First();
                        Console.WriteLine(" {0} ", most);
                        break;
                    }

                case "2":
                    {
                        if (!klinika17938.ListaPregledaCekanja.Any())
                            Console.WriteLine("Trenutno je prazna lista cekanja");
                        var most = (from i in klinika17938.ListaPregledaCekanja
                                   group i by i.PregledaniPacijent.DatumPrijema into grp
                                   orderby grp.Count() descending
                                   select grp.Key).First();
                        Console.WriteLine(" {0} ", most);

                        break;
                    }


                case "3":
                    {



                        break;
                    }



                default:
                    {



                        break;
                    }








            }
        }
        static void Naplata(ref Klinika klinika17938)
        {
            Console.WriteLine("Unesite ime pacijenta: ");
            string ime = Console.ReadLine();
            Console.WriteLine("Unesite prezime pacijenta: ");
            string prezime = Console.ReadLine();
            string maticniBroj;
            string inp;
            bool unos = false;
            do
            {
                Console.WriteLine("Unesite maticni broj: ");
                inp = Console.ReadLine();
                int broj;
                if (inp.Length != 13)
                {
                    Console.WriteLine("Pogresan unos.");
                    continue;
                }
                unos = true;
                for (int i = 0; i < 13; i++)
                {
                    if (!Int32.TryParse(inp[i].ToString(), out broj))
                    {
                        Console.WriteLine("Pogresan unos.");
                        unos = false;
                        break;
                    }
                }
            }
            while (!unos);
            maticniBroj = inp;
            Console.WriteLine("Unesite ordinaciju pregleda: ");
            string ord = Console.ReadLine();
            foreach (Pacijent pac in klinika17938.ListaPacijenata)
            {
                if(pac.Ime==ime && pac.Prezime==prezime && pac.MaticniBroj==maticniBroj && pac.IsplacenPregled==false && pac.ZadnjiPregled.Ordinacija==ord)
                {
                    bool dobarUnos;
                    do
                    {
                        Console.WriteLine("Na koji nacin pacijent zeli da plati: ");
                        Console.WriteLine("1. Gotovinski");
                        Console.WriteLine("2. Na rate");
                        string input = Console.ReadLine();

                        switch (input)
                        {
                            case "1":
                                dobarUnos = true;

                                Pregled p = pac.ZadnjiPregled;

                                Doktor d = pac.ZadnjiPregled.NadlezniDoktor;

                                Ordinacija or = pac.ZadnjiPregled.NadlezniDoktor.ZaposlenikovaOrdinacija;
                                
                                double cijena = pac.ZadnjiPregled.NadlezniDoktor.ZaposlenikovaOrdinacija.CijenaPregleda;

                                Doktor d1 = pac.ZadnjiPregled.NadlezniDoktor;
                                if (pac.BrojPosjeta > 3)
                                {
                                    Console.WriteLine("Redovni pacijent je dobio 10% popusta");
                                    cijena *= 0.9;
                                }

                                Console.WriteLine("\nNasa mala klinika");
                                Console.WriteLine("Datum pregleda: {0}", pac.ZadnjiPregled.VrijemePregleda);
                                Console.WriteLine("Ordinacija: {0}", pac.ZadnjiPregled.Ordinacija);
                                Console.WriteLine("Odgovorni doktor: {0} {1}", pac.ZadnjiPregled.NadlezniDoktor.Ime, pac.ZadnjiPregled.NadlezniDoktor.Prezime);
                                Console.WriteLine("Cijena pregleda: {0} KM", Convert.ToDouble(Convert.ToInt32(cijena*100)/100));
                                Console.WriteLine("Nacin placanja: Gotovina\n");
                                pac.IsplacenPregled = true;
                                break;
                            case "2":
                                dobarUnos = true;
                                int broj;
                                for (; ; )
                                {
                                    Console.WriteLine("Na koliko zelite rata da platite: ");
                                    input = Console.ReadLine();
                                    
                                    if (!Int32.TryParse(input, out broj) || broj < 2)
                                    {
                                        Console.WriteLine("Pogresan unos.");
                                    }
                                    else break;
                                }
                                
                                if (pac.BrojPosjeta > 3)
                                {
                                    Console.WriteLine("Redovnom pacijentu nije naplaceno poskupljenje na rate.");
                                    cijena = pac.ZadnjiPregled.NadlezniDoktor.ZaposlenikovaOrdinacija.CijenaPregleda;
                                }
                                else
                                    cijena = 1.15 * pac.ZadnjiPregled.NadlezniDoktor.ZaposlenikovaOrdinacija.CijenaPregleda;


                                Console.WriteLine("\nNasa mala klinika");
                                Console.WriteLine("Datum pregleda: {0}", pac.ZadnjiPregled.VrijemePregleda);
                                Console.WriteLine("Ordinacija: {0}", pac.ZadnjiPregled.Ordinacija);
                                Console.WriteLine("Odgovorni doktor: {0} {1}", pac.ZadnjiPregled.NadlezniDoktor.Ime, pac.ZadnjiPregled.NadlezniDoktor.Prezime);
                                Console.WriteLine("Cijena pregleda: {0} KM", cijena);
                                Console.WriteLine("Nacin placanja: Na rate");
                                Console.WriteLine("Cijena prve rate: {0} KM", Math.Round(cijena/broj,2));
                                Console.WriteLine("Broj preostalih rata: {0}\n", broj - 1);
                                pac.IsplacenPregled = true;
                                break;
                            default:
                                Console.WriteLine("Pogresan unos.");
                                dobarUnos = false;
                                break;
                        }
                        break;
                    }
                    while (!dobarUnos);                        
                    

                }
            }
        
        }

        
        static void PromjenaPassword(ref Klinika klinika17938)
        {
            /*for (; ; )
            {
                Console.WriteLine("Unesite password: ");
                string pass1 = Console.ReadLine();
                Console.WriteLine("Ponovite unos passworda: ");
                string pass2 = Console.ReadLine();
                if (pass1 != pass2)
                {
                    Console.WriteLine("Passwordi se ne slazu");
                    Console.WriteLine("Ponovite unos:");
                    continue;
                }
                else
                {
                    Pr
                }
            }
            Console.WriteLine("Unesite novi password: ");
            string pass3 = Console.ReadLine();*/
        
        
    }
}
