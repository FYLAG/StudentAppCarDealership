using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Contractservices
    {
        public int IdContract { get; set; }
        public int IdServices { get; set; }

        public virtual Treatiessalecars IdContractNavigation { get; set; }
        public virtual Cardealershipservices IdServicesNavigation { get; set; }
    }
}
