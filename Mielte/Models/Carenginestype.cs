using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Carenginestype
    {
        public Carenginestype()
        {
            Carcatalog = new HashSet<Carcatalog>();
        }

        public string Description { get; set; }
        public int IdType { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Carcatalog> Carcatalog { get; set; }
    }
}
