using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Caroptions
    {
        public int IdCar { get; set; }
        public int IdOption { get; set; }

        public virtual Carcatalog IdCarNavigation { get; set; }
        public virtual Alloptions IdOptionNavigation { get; set; }
    }
}
