using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Treatiessalecars = new HashSet<Treatiessalecars>();
        }

        public string Address { get; set; }
        public int CarDealership { get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }
        public int IdEmployees { get; set; }
        public string Name { get; set; }
        public string Passport { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public int Position { get; set; }
        public decimal Salary { get; set; }
        public string Surname { get; set; }

        public virtual Cardealerships CarDealershipNavigation { get; set; }
        public virtual Positions PositionNavigation { get; set; }
        public virtual Cardealerships Cardealerships { get; set; }
        public virtual ICollection<Treatiessalecars> Treatiessalecars { get; set; }
    }
}
