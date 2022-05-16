using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Carbody
    {
        public Carbody()
        {
            Cargenerations = new HashSet<Cargenerations>();
        }

        public string Description { get; set; }
        public int IdBody { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Cargenerations> Cargenerations { get; set; }
    }
}
