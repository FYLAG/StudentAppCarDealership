using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Carsforsale
    {
        public int IdCar { get; set; }
        public int IdCarDealerships { get; set; }
        public decimal Price { get; set; }

        public virtual Cardealerships IdCarDealershipsNavigation { get; set; }
        public virtual Carcatalog IdCarNavigation { get; set; }
    }
}
