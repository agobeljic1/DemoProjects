using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elevate.Models.DatabaseKlase
{
    public class Gorivo
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Auto> VrstaGoriva { get; set; }
        // benzin, dizel, plin
    }
}
