using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Cardrive
    {
        public Cardrive()
        {
            Carcatalog = new HashSet<Carcatalog>();
        }

        public int IdDrive { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Carcatalog> Carcatalog { get; set; }
    }
}
