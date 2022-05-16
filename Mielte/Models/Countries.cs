using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Carmanufacturers = new HashSet<Carmanufacturers>();
        }

        public int IdCountry { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Carmanufacturers> Carmanufacturers { get; set; }
    }
}
