using System;
using System.Collections.Generic;

namespace Mielte.Models
{
    public partial class Carcatalog
    {
        public Carcatalog()
        {
            Caroptions = new HashSet<Caroptions>();
            Treatiesbuycars = new HashSet<Treatiesbuycars>();
            Treatiessalecars = new HashSet<Treatiessalecars>();
        }

        public int BodyColor { get; set; }
        public int Car { get; set; }
        public int CarBox { get; set; }
        public int CarDrive { get; set; }
        public DateTime DateManufacture { get; set; }
        public int EnginePower { get; set; }
        public int EngineType { get; set; }
        public decimal EngineVolume { get; set; }
        public int IdCatalog { get; set; }
        public int InteriorColor { get; set; }
        public int InteriorMaterial { get; set; }

        public virtual Colors BodyColorNavigation { get; set; }
        public virtual Carbox CarBoxNavigation { get; set; }
        public virtual Cardrive CarDriveNavigation { get; set; }
        public virtual Cargenerations CarNavigation { get; set; }
        public virtual Carenginestype EngineTypeNavigation { get; set; }
        public virtual Colors InteriorColorNavigation { get; set; }
        public virtual Interiormaterials InteriorMaterialNavigation { get; set; }
        public virtual Carsforsale Carsforsale { get; set; }
        public virtual ICollection<Caroptions> Caroptions { get; set; }
        public virtual ICollection<Treatiesbuycars> Treatiesbuycars { get; set; }
        public virtual ICollection<Treatiessalecars> Treatiessalecars { get; set; }
    }
}
