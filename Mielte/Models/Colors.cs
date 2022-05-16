using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Colors
    {
        public Colors()
        {
            CarcatalogBodyColorNavigation = new HashSet<Carcatalog>();
            CarcatalogInteriorColorNavigation = new HashSet<Carcatalog>();
        }

        public int IdColor { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Carcatalog> CarcatalogBodyColorNavigation { get; set; }
        public virtual ICollection<Carcatalog> CarcatalogInteriorColorNavigation { get; set; }
    }
}
