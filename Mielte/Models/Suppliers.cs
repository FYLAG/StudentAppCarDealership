using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            Suppliedbrands = new HashSet<Suppliedbrands>();
            Treatiesbuycars = new HashSet<Treatiesbuycars>();
        }

        public string Address { get; set; }
        public int IdSupplier { get; set; }
        public string Inn { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Suppliedbrands> Suppliedbrands { get; set; }
        public virtual ICollection<Treatiesbuycars> Treatiesbuycars { get; set; }
    }
}
