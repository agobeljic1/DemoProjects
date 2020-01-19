using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elevate.Models.DatabaseKlase
{
    public class NalogStatus
    {
        public int Id { get; set; }
        public string Naziv { get; set; }        

        public virtual ICollection<Nalog> Nalozi { get; set; }
        // evidentiran, potvrdjen, odbijen, zavrsen
    }
}
