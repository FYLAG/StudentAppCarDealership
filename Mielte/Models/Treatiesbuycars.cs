using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Treatiesbuycars
    {
        public int Amount { get; set; }
        public int Car { get; set; }
        public DateTime DateBuy { get; set; }
        public int IdTreaty { get; set; }
        public decimal Price { get; set; }
        public int Supplier { get; set; }

        public virtual Carcatalog CarNavigation { get; set; }
        public virtual Suppliers SupplierNavigation { get; set; }
    }
}
