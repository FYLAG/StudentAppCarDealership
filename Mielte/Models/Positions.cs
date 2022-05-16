using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Positions
    {
        public Positions()
        {
            Employees = new HashSet<Employees>();
        }

        public string Description { get; set; }
        public int IdPosition { get; set; }
        public string Requirements { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
