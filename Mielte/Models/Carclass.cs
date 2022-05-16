using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Carclass
    {
        public Carclass()
        {
            Cargenerations = new HashSet<Cargenerations>();
        }

        public string Description { get; set; }
        public int IdClass { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Cargenerations> Cargenerations { get; set; }
    }
}
