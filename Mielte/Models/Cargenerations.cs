using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Cargenerations
    {
        public Cargenerations()
        {
            Carcatalog = new HashSet<Carcatalog>();
        }

        public int Body { get; set; }
        public int Class { get; set; }
        public int EnvironmentalClass { get; set; }
        public string Generation { get; set; }
        public int IdGeneration { get; set; }
        public string Image { get; set; }
        public int Model { get; set; }

        public virtual Carbody BodyNavigation { get; set; }
        public virtual Carclass ClassNavigation { get; set; }
        public virtual Carenvironmentalclass EnvironmentalClassNavigation { get; set; }
        public virtual Carmodels ModelNavigation { get; set; }
        public virtual ICollection<Carcatalog> Carcatalog { get; set; }
    }
}
