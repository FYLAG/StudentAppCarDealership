using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Buyers
    {
        public Buyers()
        {
            Treatiessalecars = new HashSet<Treatiessalecars>();
        }

        public string Address { get; set; }
        public string Certificate { get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }
        public int IdBuyer { get; set; }
        public string Name { get; set; }
        public string Passport { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Treatiessalecars> Treatiessalecars { get; set; }
    }
}
