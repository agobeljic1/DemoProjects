using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zadaca
{
    interface IKlinika
    {
        int RegistrirajNovogPacijenta(string pime, string pprezime, DateTime pdatumRodjenja, string pmaticniBroj, string pspol, string padresa, string pstanje, Dictionary<DateTime,string> vakcinacije, Dictionary<DateTime,string> alergije,string plozinka,Image slikica);
        void ObrisiPacijenta(string pime, string pprezime, string pmaticniBroj);
        /*void PrikaziRasporedPregleda();
        void PretraziKartonePacijenata();
        void RegistrirajNovogPregleda();
        void AnalizirajSadrzaj();
        void NaplatiPacijentu();*/
    }
}
