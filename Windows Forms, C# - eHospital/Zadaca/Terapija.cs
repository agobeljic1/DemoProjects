using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca
{
    sealed class Terapija
    {
        private List<string> lijek = new List<string>();
        private List<int> brojUnosa = new List<int>();
        private List<int> razmakUnosa = new List<int>();
        private List<string> opisUnosa = new List<string>();

        public List<string> Lijek { get => lijek; set => lijek = value; }
        public List<int> BrojUnosa { get => brojUnosa; set => brojUnosa = value; }
        public List<int> RazmakUnosa { get => razmakUnosa; set => razmakUnosa = value; }
        public List<string> OpisUnosa { get => opisUnosa; set => opisUnosa = value; }

        public Terapija(List<string> plijek, List<int> pbrojUnosa,List<int> prazmakUnosa,List<string> popisUnosa)
        {
            lijek = plijek;
            brojUnosa = pbrojUnosa;
            razmakUnosa = prazmakUnosa;
            opisUnosa = popisUnosa;
        }
    }
}
