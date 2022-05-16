using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Alloptions
    {
        public Alloptions()
        {
            Caroptions = new HashSet<Caroptions>();
        }

        public int IdOption { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Caroptions> Caroptions { get; set; }
    }
}
