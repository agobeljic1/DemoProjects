using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca
{
    public partial class Pacijent
    {
        
        public DateTime DatumPrijema { get => datumPrijema; set => datumPrijema = value; }
        public int BrojPosjeta { get => brojPosjeta; set => brojPosjeta = value; }

        internal Karton KartonPacijenta { get => kartonPacijenta; set => kartonPacijenta = value; }

        public bool ImaLiKarton { get => imaLiKarton; set => imaLiKarton = value; }
    }
}
