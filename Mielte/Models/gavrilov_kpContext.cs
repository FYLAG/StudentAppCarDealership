using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mielte.Models
{
    public partial class gavrilov_kpContext : DbContext
    {
        public gavrilov_kpContext()
        {
        }

        public gavrilov_kpContext(DbContextOptions<gavrilov_kpContext> options)
            : base(options)
        {
        }

        private static gavrilov_kpContext _context;
        public static gavrilov_kpContext GetContext()
        {
            if (_context == null)
                _context = new gavrilov_kpContext();
            return _context;
            {
            }
        }

        public virtual DbSet<Alloptions> Alloptions { get; set; }
        public virtual DbSet<Buyers> Buyers { get; set; }
        public virtual DbSet<Carbody> Carbody { get; set; }
        public virtual DbSet<Carbox> Carbox { get; set; }
        public virtual DbSet<Carcatalog> Carcatalog { get; set; }
        public virtual DbSet<Carclass> Carclass { get; set; }
        public virtual DbSet<Cardealerships> Cardealerships { get; set; }
        public virtual DbSet<Cardealershipservices> Cardealershipservices { get; set; }
        public virtual DbSet<Cardrive> Cardrive { get; set; }
        public virtual DbSet<Carenginestype> Carenginestype { get; set; }
        public virtual DbSet<Carenvironmentalclass> Carenvironmentalclass { get; set; }
        public virtual DbSet<Cargenerations> Cargenerations { get; set; }
        public virtual DbSet<Carmanufacturers> Carmanufacturers { get; set; }
        public virtual DbSet<Carmodels> Carmodels { get; set; }
        public virtual DbSet<Caroptions> Caroptions { get; set; }
        public virtual DbSet<Carsforsale> Carsforsale { get; set; }
        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<Contractservices> Contractservices { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Historyemployees> Historyemployees { get; set; }
        public virtual DbSet<Interiormaterials> Interiormaterials { get; set; }
        public virtual DbSet<Oldbuyer> Oldbuyer { get; set; }
        public virtual DbSet<Popularcar> Popularcar { get; set; }
        public virtual DbSet<Popularcolor> Popularcolor { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Salesmanagers> Salesmanagers { get; set; }
        public virtual DbSet<Suppliedbrands> Suppliedbrands { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Treatiesbuycars> Treatiesbuycars { get; set; }
        public virtual DbSet<Treatiessalecars> Treatiessalecars { get; set; }
        public virtual DbSet<Userprogram> Userprogram { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;database=gavrilov_kp;user=root;password=QxNgMI35P1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alloptions>(entity =>
            {
                entity.HasKey(e => e.IdOption)
                    .HasName("PRIMARY");

                entity.ToTable("alloptions");

                entity.HasIndex(e => e.Title)
                    .HasName("Title_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdOption).HasColumnName("idOption");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Buyers>(entity =>
            {
                entity.HasKey(e => e.IdBuyer)
                    .HasName("PRIMARY");

                entity.ToTable("buyers");

                entity.HasIndex(e => e.Certificate)
                    .HasName("Certificate_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Passport)
                    .HasName("Pasport_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("Phone_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdBuyer).HasColumnName("idBuyer");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Certificate)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DateBirth).HasColumnType("date");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("enum('М','Ж')")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Passport)
                    .IsRequired()
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Carbody>(entity =>
            {
                entity.HasKey(e => e.IdBody)
                    .HasName("PRIMARY");

                entity.ToTable("carbody");

                entity.HasIndex(e => e.Title)
                    .HasName("Title_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdBody).HasColumnName("idBody");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Carbox>(entity =>
            {
                entity.HasKey(e => e.IdBox)
                    .HasName("PRIMARY");

                entity.ToTable("carbox");

                entity.HasIndex(e => e.Title)
                    .HasName("Title_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdBox).HasColumnName("idBox");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Carcatalog>(entity =>
            {
                entity.HasKey(e => e.IdCatalog)
                    .HasName("PRIMARY");

                entity.ToTable("carcatalog");

                entity.HasIndex(e => e.BodyColor)
                    .HasName("carCatalog_Frk1_idx");

                entity.HasIndex(e => e.Car)
                    .HasName("carCatalog_Frk4_idx");

                entity.HasIndex(e => e.CarBox)
                    .HasName("carCatalog_Frk6_idx");

                entity.HasIndex(e => e.CarDrive)
                    .HasName("carCatalog_Frk7_idx");

                entity.HasIndex(e => e.EngineType)
                    .HasName("carCatalog_Frk5_idx");

                entity.HasIndex(e => e.InteriorColor)
                    .HasName("carCatalog_Frk2_idx");

                entity.HasIndex(e => e.InteriorMaterial)
                    .HasName("carCatalog_Frk3_idx");

                entity.Property(e => e.IdCatalog).HasColumnName("idCatalog");

                entity.Property(e => e.DateManufacture).HasColumnType("date");

                entity.Property(e => e.EngineVolume).HasColumnType("decimal(4,1)");

                entity.HasOne(d => d.BodyColorNavigation)
                    .WithMany(p => p.CarcatalogBodyColorNavigation)
                    .HasForeignKey(d => d.BodyColor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carCatalog_Frk1");

                entity.HasOne(d => d.CarNavigation)
                    .WithMany(p => p.Carcatalog)
                    .HasForeignKey(d => d.Car)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carCatalog_Frk4");

                entity.HasOne(d => d.CarBoxNavigation)
                    .WithMany(p => p.Carcatalog)
                    .HasForeignKey(d => d.CarBox)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carCatalog_Frk6");

                entity.HasOne(d => d.CarDriveNavigation)
                    .WithMany(p => p.Carcatalog)
                    .HasForeignKey(d => d.CarDrive)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carCatalog_Frk7");

                entity.HasOne(d => d.EngineTypeNavigation)
                    .WithMany(p => p.Carcatalog)
                    .HasForeignKey(d => d.EngineType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carCatalog_Frk5");

                entity.HasOne(d => d.InteriorColorNavigation)
                    .WithMany(p => p.CarcatalogInteriorColorNavigation)
                    .HasForeignKey(d => d.InteriorColor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carCatalog_Frk2");

                entity.HasOne(d => d.InteriorMaterialNavigation)
                    .WithMany(p => p.Carcatalog)
                    .HasForeignKey(d => d.InteriorMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carCatalog_Frk3");
            });

            modelBuilder.Entity<Carclass>(entity =>
            {
                entity.HasKey(e => e.IdClass)
                    .HasName("PRIMARY");

                entity.ToTable("carclass");

                entity.HasIndex(e => e.Title)
                    .HasName("Name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdClass).HasColumnName("idClass");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Cardealerships>(entity =>
            {
                entity.HasKey(e => e.IdCarDealership)
                    .HasName("PRIMARY");

                entity.ToTable("cardealerships");

                entity.HasIndex(e => e.Address)
                    .HasName("TheAddress_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Director)
                    .HasName("Director_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Title)
                    .HasName("Name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdCarDealership).HasColumnName("idCarDealership");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DateOpen).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.DirectorNavigation)
                    .WithOne(p => p.Cardealerships)
                    .HasForeignKey<Cardealerships>(d => d.Director)
                    .HasConstraintName("carDealerships_Frk1");
            });

            modelBuilder.Entity<Cardealershipservices>(entity =>
            {
                entity.HasKey(e => e.IdServices)
                    .HasName("PRIMARY");

                entity.ToTable("cardealershipservices");

                entity.HasIndex(e => e.Title)
                    .HasName("Title_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdServices).HasColumnName("idServices");

                entity.Property(e => e.Price).HasColumnType("decimal(12,2)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Cardrive>(entity =>
            {
                entity.HasKey(e => e.IdDrive)
                    .HasName("PRIMARY");

                entity.ToTable("cardrive");

                entity.HasIndex(e => e.Title)
                    .HasName("Title_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdDrive).HasColumnName("idDrive");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Carenginestype>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("PRIMARY");

                entity.ToTable("carenginestype");

                entity.HasIndex(e => e.Title)
                    .HasName("Title_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdType).HasColumnName("idType");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Carenvironmentalclass>(entity =>
            {
                entity.HasKey(e => e.IdClass)
                    .HasName("PRIMARY");

                entity.ToTable("carenvironmentalclass");

                entity.HasIndex(e => e.Title)
                    .HasName("Title_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdClass).HasColumnName("idClass");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Cargenerations>(entity =>
            {
                entity.HasKey(e => e.IdGeneration)
                    .HasName("PRIMARY");

                entity.ToTable("cargenerations");

                entity.HasIndex(e => e.Body)
                    .HasName("carGenerations_Frk1_idx");

                entity.HasIndex(e => e.Class)
                    .HasName("carGenerations_Frk2_idx");

                entity.HasIndex(e => e.EnvironmentalClass)
                    .HasName("carGenerations_Frk3_idx");

                entity.HasIndex(e => e.Image)
                    .HasName("Image_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Model)
                    .HasName("carGenerations_Frk4_idx");

                entity.Property(e => e.IdGeneration).HasColumnName("idGeneration");

                entity.Property(e => e.Generation)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Image)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.BodyNavigation)
                    .WithMany(p => p.Cargenerations)
                    .HasForeignKey(d => d.Body)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carGenerations_Frk1");

                entity.HasOne(d => d.ClassNavigation)
                    .WithMany(p => p.Cargenerations)
                    .HasForeignKey(d => d.Class)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carGenerations_Frk2");

                entity.HasOne(d => d.EnvironmentalClassNavigation)
                    .WithMany(p => p.Cargenerations)
                    .HasForeignKey(d => d.EnvironmentalClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carGenerations_Frk3");

                entity.HasOne(d => d.ModelNavigation)
                    .WithMany(p => p.Cargenerations)
                    .HasForeignKey(d => d.Model)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carGenerations_Frk4");
            });

            modelBuilder.Entity<Carmanufacturers>(entity =>
            {
                entity.HasKey(e => e.IdManufacturer)
                    .HasName("PRIMARY");

                entity.ToTable("carmanufacturers");

                entity.HasIndex(e => e.Country)
                    .HasName("carManufacturers_Frk1_idx");

                entity.HasIndex(e => e.Title)
                    .HasName("Title_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdManufacturer).HasColumnName("idManufacturer");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.YearFoundation).HasColumnType("date");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Carmanufacturers)
                    .HasForeignKey(d => d.Country)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carManufacturers_Frk1");
            });

            modelBuilder.Entity<Carmodels>(entity =>
            {
                entity.HasKey(e => e.IdModel)
                    .HasName("PRIMARY");

                entity.ToTable("carmodels");

                entity.HasIndex(e => e.Manufacturer)
                    .HasName("carModels_Frk1_idx");

                entity.HasIndex(e => e.Model)
                    .HasName("Model_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdModel).HasColumnName("idModel");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.ManufacturerNavigation)
                    .WithMany(p => p.Carmodels)
                    .HasForeignKey(d => d.Manufacturer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carModels_Frk1");
            });

            modelBuilder.Entity<Caroptions>(entity =>
            {
                entity.HasKey(e => new { e.IdCar, e.IdOption })
                    .HasName("PRIMARY");

                entity.ToTable("caroptions");

                entity.HasIndex(e => e.IdCar)
                    .HasName("carOptions_Frk1_idx");

                entity.HasIndex(e => e.IdOption)
                    .HasName("carOptions_Frk2_idx");

                entity.Property(e => e.IdCar).HasColumnName("idCar");

                entity.Property(e => e.IdOption).HasColumnName("idOption");

                entity.HasOne(d => d.IdCarNavigation)
                    .WithMany(p => p.Caroptions)
                    .HasForeignKey(d => d.IdCar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carOptions_Frk1");

                entity.HasOne(d => d.IdOptionNavigation)
                    .WithMany(p => p.Caroptions)
                    .HasForeignKey(d => d.IdOption)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carOptions_Frk2");
            });

            modelBuilder.Entity<Carsforsale>(entity =>
            {
                entity.HasKey(e => e.IdCar)
                    .HasName("PRIMARY");

                entity.ToTable("carsforsale");

                entity.HasIndex(e => e.IdCarDealerships)
                    .HasName("carsForSale_Frk2_idx");

                entity.Property(e => e.IdCar).HasColumnName("idCar");

                entity.Property(e => e.IdCarDealerships).HasColumnName("idCarDealerships");

                entity.Property(e => e.Price).HasColumnType("decimal(12,2)");

                entity.HasOne(d => d.IdCarNavigation)
                    .WithOne(p => p.Carsforsale)
                    .HasForeignKey<Carsforsale>(d => d.IdCar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carsForSale_Frk1");

                entity.HasOne(d => d.IdCarDealershipsNavigation)
                    .WithMany(p => p.Carsforsale)
                    .HasForeignKey(d => d.IdCarDealerships)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carsForSale_Frk2");
            });

            modelBuilder.Entity<Colors>(entity =>
            {
                entity.HasKey(e => e.IdColor)
                    .HasName("PRIMARY");

                entity.ToTable("colors");

                entity.HasIndex(e => e.Title)
                    .HasName("Title_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdColor).HasColumnName("idColor");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Contractservices>(entity =>
            {
                entity.HasKey(e => new { e.IdContract, e.IdServices })
                    .HasName("PRIMARY");

                entity.ToTable("contractservices");

                entity.HasIndex(e => e.IdContract)
                    .HasName("contractServices_Frk1_idx");

                entity.HasIndex(e => e.IdServices)
                    .HasName("contractServices_Frk2_idx");

                entity.Property(e => e.IdContract).HasColumnName("idContract");

                entity.Property(e => e.IdServices).HasColumnName("idServices");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.Contractservices)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contractServices_Frk1");

                entity.HasOne(d => d.IdServicesNavigation)
                    .WithMany(p => p.Contractservices)
                    .HasForeignKey(d => d.IdServices)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contractServices_Frk2");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.IdCountry)
                    .HasName("PRIMARY");

                entity.ToTable("countries");

                entity.HasIndex(e => e.Title)
                    .HasName("Title_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdCountry).HasColumnName("idCountry");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.IdEmployees)
                    .HasName("PRIMARY");

                entity.ToTable("employees");

                entity.HasIndex(e => e.CarDealership)
                    .HasName("employees_Frk2_idx");

                entity.HasIndex(e => e.Passport)
                    .HasName("Passport_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("Phone_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Position)
                    .HasName("employees_Frk1_idx");

                entity.Property(e => e.IdEmployees).HasColumnName("idEmployees");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DateBirth).HasColumnType("date");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("enum('М','Ж')")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Passport)
                    .IsRequired()
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Salary).HasColumnType("decimal(10,2)");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.CarDealershipNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CarDealership)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees_Frk2");

                entity.HasOne(d => d.PositionNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Position)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees_Frk1");
            });

            modelBuilder.Entity<Historyemployees>(entity =>
            {
                entity.HasKey(e => e.IdChange)
                    .HasName("PRIMARY");

                entity.ToTable("historyemployees");

                entity.Property(e => e.IdChange).HasColumnName("idChange");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DateBirth).HasColumnType("date");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("enum('М','Ж')")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IdEmployees).HasColumnName("idEmployees");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Passport)
                    .IsRequired()
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Salary).HasColumnType("decimal(10,2)");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Interiormaterials>(entity =>
            {
                entity.HasKey(e => e.IdMaterial)
                    .HasName("PRIMARY");

                entity.ToTable("interiormaterials");

                entity.HasIndex(e => e.Title)
                    .HasName("Title_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdMaterial).HasColumnName("idMaterial");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Oldbuyer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("oldbuyer");

                entity.Property(e => e.Car)
                    .HasColumnType("varchar(272)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DateSale).HasColumnType("date");

                entity.Property(e => e.Fio)
                    .HasColumnName("FIO")
                    .HasColumnType("varchar(272)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Phone)
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Price).HasColumnType("decimal(12,2)");
            });

            modelBuilder.Entity<Popularcar>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("popularcar");

                entity.Property(e => e.Amount).HasColumnType("decimal(42,0)");

                entity.Property(e => e.CarTitle)
                    .HasColumnType("varchar(272)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Popularcolor>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("popularcolor");

                entity.Property(e => e.Amount).HasColumnType("decimal(42,0)");

                entity.Property(e => e.Colors).HasColumnName("colors");

                entity.Property(e => e.Result)
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.HasKey(e => e.IdPosition)
                    .HasName("PRIMARY");

                entity.ToTable("positions");

                entity.HasIndex(e => e.Title)
                    .HasName("Name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdPosition).HasColumnName("idPosition");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Requirements)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Salesmanagers>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("salesmanagers");

                entity.Property(e => e.Fio)
                    .HasColumnName("FIO")
                    .HasColumnType("varchar(272)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IdEmployees)
                    .HasColumnName("idEmployees")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Suppliedbrands>(entity =>
            {
                entity.HasKey(e => new { e.IdSupplier, e.IdBrands })
                    .HasName("PRIMARY");

                entity.ToTable("suppliedbrands");

                entity.HasIndex(e => e.IdBrands)
                    .HasName("suppliedBrands_Frk2_idx");

                entity.HasIndex(e => e.IdSupplier)
                    .HasName("suppliedBrands_Frk1_idx");

                entity.Property(e => e.IdSupplier).HasColumnName("idSupplier");

                entity.Property(e => e.IdBrands).HasColumnName("idBrands");

                entity.HasOne(d => d.IdBrandsNavigation)
                    .WithMany(p => p.Suppliedbrands)
                    .HasForeignKey(d => d.IdBrands)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("suppliedBrands_Frk2");

                entity.HasOne(d => d.IdSupplierNavigation)
                    .WithMany(p => p.Suppliedbrands)
                    .HasForeignKey(d => d.IdSupplier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("suppliedBrands_Frk1");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.IdSupplier)
                    .HasName("PRIMARY");

                entity.ToTable("suppliers");

                entity.HasIndex(e => e.Address)
                    .HasName("Address_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Inn)
                    .HasName("INN_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("Phone_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Title)
                    .HasName("Title_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdSupplier).HasColumnName("idSupplier");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Inn)
                    .IsRequired()
                    .HasColumnName("INN")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Treatiesbuycars>(entity =>
            {
                entity.HasKey(e => e.IdTreaty)
                    .HasName("PRIMARY");

                entity.ToTable("treatiesbuycars");

                entity.HasIndex(e => e.Car)
                    .HasName("treatiesBuyCars_Frk1_idx");

                entity.HasIndex(e => e.Supplier)
                    .HasName("treatiesBuyCars_Frk2_idx");

                entity.Property(e => e.IdTreaty).HasColumnName("idTreaty");

                entity.Property(e => e.DateBuy).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("decimal(20,2)");

                entity.HasOne(d => d.CarNavigation)
                    .WithMany(p => p.Treatiesbuycars)
                    .HasForeignKey(d => d.Car)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("treatiesBuyCars_Frk1");

                entity.HasOne(d => d.SupplierNavigation)
                    .WithMany(p => p.Treatiesbuycars)
                    .HasForeignKey(d => d.Supplier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("treatiesBuyCars_Frk2");
            });

            modelBuilder.Entity<Treatiessalecars>(entity =>
            {
                entity.HasKey(e => e.IdTreaty)
                    .HasName("PRIMARY");

                entity.ToTable("treatiessalecars");

                entity.HasIndex(e => e.Buyer)
                    .HasName("treatiesSaleCars_Frk2_idx");

                entity.HasIndex(e => e.Car)
                    .HasName("treatiesSaleCars_Frk1_idx");

                entity.HasIndex(e => e.Manager)
                    .HasName("treatiesSaleCars_Frk3_idx");

                entity.HasIndex(e => e.Vin)
                    .HasName("VIN_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdTreaty).HasColumnName("idTreaty");

                entity.Property(e => e.DateSale).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("decimal(12,2)");

                entity.Property(e => e.Vin)
                    .IsRequired()
                    .HasColumnName("VIN")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.BuyerNavigation)
                    .WithMany(p => p.Treatiessalecars)
                    .HasForeignKey(d => d.Buyer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("treatiesSaleCars_Frk2");

                entity.HasOne(d => d.CarNavigation)
                    .WithMany(p => p.Treatiessalecars)
                    .HasForeignKey(d => d.Car)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("treatiesSaleCars_Frk1");

                entity.HasOne(d => d.ManagerNavigation)
                    .WithMany(p => p.Treatiessalecars)
                    .HasForeignKey(d => d.Manager)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("treatiesSaleCars_Frk3");
            });

            modelBuilder.Entity<Userprogram>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("userprogram");

                entity.HasIndex(e => e.Email)
                    .HasName("Email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Login)
                    .HasName("Login_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(90)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Role)
                    .HasColumnType("varchar(90)")
                    .HasDefaultValueSql("'User'")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
