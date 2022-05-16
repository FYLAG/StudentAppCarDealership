using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Carmanufacturers
    {
        public Carmanufacturers()
        {
            Carmodels = new HashSet<Carmodels>();
            Suppliedbrands = new HashSet<Suppliedbrands>();
        }

        public int Country { get; set; }
        public int IdManufacturer { get; set; }
        public string Title { get; set; }
        public DateTime? YearFoundation { get; set; }

        public virtual Countries CountryNavigation { get; set; }
        public virtual ICollection<Carmodels> Carmodels { get; set; }
        public virtual ICollection<Suppliedbrands> Suppliedbrands { get; set; }
    }
}
