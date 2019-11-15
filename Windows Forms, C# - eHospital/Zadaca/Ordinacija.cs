using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca
{
    public class Ordinacija
    {
        private string odjel;
        private bool slobodno;
        private Doktor odgovorniDoktor=new Doktor();
        
        private bool aparat = true;
        private double cijenaPregleda;
        public Ordinacija(string podjel,double pcijenaPregleda)
        {
            Slobodno = true;
            Odjel = podjel;
            Aparat = true; 
            CijenaPregleda = pcijenaPregleda;
        }
        public Ordinacija()
        {
            
        }
        public bool Slobodno { get => slobodno; set => slobodno = value; }




        public bool Aparat { get => aparat; set => aparat = value; }
        
        public double CijenaPregleda { get => cijenaPregleda; set => cijenaPregleda = value; }
        public string Odjel { get => odjel; set => odjel = value; }
        internal Doktor OdgovorniDoktor { get => odgovorniDoktor; set => odgovorniDoktor = value; }
    }
}
