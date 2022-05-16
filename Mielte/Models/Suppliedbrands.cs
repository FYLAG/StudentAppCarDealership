using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Suppliedbrands
    {
        public int IdBrands { get; set; }
        public int IdSupplier { get; set; }

        public virtual Carmanufacturers IdBrandsNavigation { get; set; }
        public virtual Suppliers IdSupplierNavigation { get; set; }
    }
}
