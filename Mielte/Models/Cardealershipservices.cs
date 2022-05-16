using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Cardealershipservices
    {
        public Cardealershipservices()
        {
            Contractservices = new HashSet<Contractservices>();
        }

        public int IdServices { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Contractservices> Contractservices { get; set; }
    }
}
