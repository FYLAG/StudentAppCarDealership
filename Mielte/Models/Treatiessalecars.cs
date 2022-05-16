using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Treatiessalecars
    {
        public Treatiessalecars()
        {
            Contractservices = new HashSet<Contractservices>();
        }

        public int Buyer { get; set; }
        public int Car { get; set; }
        public DateTime DateSale { get; set; }
        public int IdTreaty { get; set; }
        public int Manager { get; set; }
        public decimal Price { get; set; }
        public string Vin { get; set; }

        public virtual Buyers BuyerNavigation { get; set; }
        public virtual Carcatalog CarNavigation { get; set; }
        public virtual Employees ManagerNavigation { get; set; }
        public virtual ICollection<Contractservices> Contractservices { get; set; }
    }
}
