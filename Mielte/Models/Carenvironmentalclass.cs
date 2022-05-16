using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Carenvironmentalclass
    {
        public Carenvironmentalclass()
        {
            Cargenerations = new HashSet<Cargenerations>();
        }

        public int IdClass { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Cargenerations> Cargenerations { get; set; }
    }
}
