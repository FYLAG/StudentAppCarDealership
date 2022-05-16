using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Cardealerships
    {
        public Cardealerships()
        {
            Carsforsale = new HashSet<Carsforsale>();
            Employees = new HashSet<Employees>();
        }

        public string Address { get; set; }
        public DateTime DateOpen { get; set; }
        public int? Director { get; set; }
        public int IdCarDealership { get; set; }
        public string Title { get; set; }

        public virtual Employees DirectorNavigation { get; set; }
        public virtual ICollection<Carsforsale> Carsforsale { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
