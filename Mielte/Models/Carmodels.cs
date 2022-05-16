using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Carmodels
    {
        public Carmodels()
        {
            Cargenerations = new HashSet<Cargenerations>();
        }

        public int IdModel { get; set; }
        public int Manufacturer { get; set; }
        public string Model { get; set; }

        public virtual Carmanufacturers ManufacturerNavigation { get; set; }
        public virtual ICollection<Cargenerations> Cargenerations { get; set; }
    }
}
