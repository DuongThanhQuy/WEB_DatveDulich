using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TravelFinalProject.Models
{
    public partial class Travel_DatabaseContext : DbContext
    {
        public Travel_DatabaseContext()
        {
        }

        public Travel_DatabaseContext(DbContextOptions<Travel_DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DboAccount> DboAccounts { get; set; }
        public virtual DbSet<DboAttribute> DboAttributes { get; set; }
        public virtual DbSet<DboAttributesCruisePrice> DboAttributesCruisePrices { get; set; }
        public virtual DbSet<DboAttributesFlightPrice> DboAttributesFlightPrices { get; set; }
        public virtual DbSet<DboAttributesHotelPrice> DboAttributesHotelPrices { get; set; }
        public virtual DbSet<DboAttributesTourPrice> DboAttributesTourPrices { get; set; }
        public virtual DbSet<DboAttributesTraPrice> DboAttributesTraPrices { get; set; }
        public virtual DbSet<DboCategoriesFlight> DboCategoriesFlights { get; set; }
        public virtual DbSet<DboCategoriesHotel> DboCategoriesHotels { get; set; }
        public virtual DbSet<DboCategoriesTour> DboCategoriesTours { get; set; }
        public virtual DbSet<DboCategoriesTra> DboCategoriesTras { get; set; }
        public virtual DbSet<DboCategory> DboCategories { get; set; }
        public virtual DbSet<DboCruise> DboCruises { get; set; }
        public virtual DbSet<DboCustomer> DboCustomers { get; set; }
        public virtual DbSet<DboFlight> DboFlights { get; set; }
        public virtual DbSet<DboHotel> DboHotels { get; set; }
        public virtual DbSet<DboLocation> DboLocations { get; set; }
        public virtual DbSet<DboNews> DboNews { get; set; }
        public virtual DbSet<DboOrder> DboOrders { get; set; }
        public virtual DbSet<DboOrderDetail> DboOrderDetails { get; set; }
        public virtual DbSet<DboPage> DboPages { get; set; }
        public virtual DbSet<DboRole> DboRoles { get; set; }
        public virtual DbSet<DboTour> DboTours { get; set; }
        public virtual DbSet<DboTransactStatus> DboTransactStatuses { get; set; }
        public virtual DbSet<DboTransport> DboTransports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-TQNQ8F9B\\SQLEXPRESS_QUY;Database=Travel_Database;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DboAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("dbo_Accounts");

                entity.Property(e => e.AccountId)
                    .ValueGeneratedNever()
                    .HasColumnName("AccountID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(12);

                entity.Property(e => e.RoleId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("RoleID");

                entity.Property(e => e.Salt)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.DboAccounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo_Accounts_dbo_Roles");
            });

            modelBuilder.Entity<DboAttribute>(entity =>
            {
                entity.HasKey(e => e.AttributeId)
                    .HasName("PK_dbo_Attribute");

                entity.ToTable("dbo_Attributes");

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<DboAttributesCruisePrice>(entity =>
            {
                entity.HasKey(e => e.AttributesPriceCruiseId);

                entity.ToTable("dbo_AttributesCruisePrices");

                entity.Property(e => e.AttributesPriceCruiseId).HasColumnName("AttributesPriceCruiseID");

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

                entity.Property(e => e.CruiseId).HasColumnName("CruiseID");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.DboAttributesCruisePrices)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_dbo_AttributesCruisePrices_dbo_Attributes");

                entity.HasOne(d => d.Cruise)
                    .WithMany(p => p.DboAttributesCruisePrices)
                    .HasForeignKey(d => d.CruiseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo_AttributesCruisePrices_dbo_Cruise");
            });

            modelBuilder.Entity<DboAttributesFlightPrice>(entity =>
            {
                entity.HasKey(e => e.AttributesPriceFightId);

                entity.ToTable("dbo_AttributesFlightPrices");

                entity.Property(e => e.AttributesPriceFightId).HasColumnName("AttributesPriceFightID");

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.DboAttributesFlightPrices)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_dbo_AttributesFlightPrices_dbo_Attributes");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.DboAttributesFlightPrices)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo_AttributesFlightPrices_dbo_Flight");
            });

            modelBuilder.Entity<DboAttributesHotelPrice>(entity =>
            {
                entity.HasKey(e => e.AttributesPriceHotelId)
                    .HasName("PK_AttributesHotelPrices");

                entity.ToTable("dbo_AttributesHotelPrices");

                entity.Property(e => e.AttributesPriceHotelId).HasColumnName("AttributesPriceHotelID");

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.DboAttributesHotelPrices)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_dbo_AttributesHotelPrices_dbo_Attributes");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.DboAttributesHotelPrices)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo_AttributesHotelPrices_dbo_Hotel");
            });

            modelBuilder.Entity<DboAttributesTourPrice>(entity =>
            {
                entity.HasKey(e => e.AttributesPriceTourD)
                    .HasName("PK_AttributesTourPrices");

                entity.ToTable("dbo_AttributesTourPrices");

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.DboAttributesTourPrices)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_dbo_AttributesTourPrices_dbo_Attributes");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.DboAttributesTourPrices)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo_AttributesTourPrices_dbo_Tour");
            });

            modelBuilder.Entity<DboAttributesTraPrice>(entity =>
            {
                entity.HasKey(e => e.AttributesPriceTraId)
                    .HasName("PK_dbo_AttributesPrices");

                entity.ToTable("dbo_AttributesTraPrices");

                entity.Property(e => e.AttributesPriceTraId).HasColumnName("AttributesPriceTraID");

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

                entity.Property(e => e.TransportId).HasColumnName("TransportID");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.DboAttributesTraPrices)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_dbo_AttributesTraPrices_dbo_Attributes");

                entity.HasOne(d => d.Transport)
                    .WithMany(p => p.DboAttributesTraPrices)
                    .HasForeignKey(d => d.TransportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo_AttributesPrices_dbo_Transports");
            });

            modelBuilder.Entity<DboCategoriesFlight>(entity =>
            {
                entity.HasKey(e => e.CatFlightId);

                entity.ToTable("dbo_CategoriesFlight");

                entity.Property(e => e.CatFlightId).HasColumnName("CatFlightID");

                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.CatFlightName).HasMaxLength(250);

                entity.Property(e => e.Cover).HasMaxLength(250);

                entity.Property(e => e.MetaDesc).HasMaxLength(250);

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Picture)
                    .HasMaxLength(255)
                    .HasColumnName("picture");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<DboCategoriesHotel>(entity =>
            {
                entity.HasKey(e => e.CatHotelId);

                entity.ToTable("dbo_CategoriesHotel");

                entity.Property(e => e.CatHotelId).HasColumnName("CatHotelID");

                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.CatHotelName).HasMaxLength(250);

                entity.Property(e => e.Cover).HasMaxLength(250);

                entity.Property(e => e.MetaDesc).HasMaxLength(250);

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Picture)
                    .HasMaxLength(255)
                    .HasColumnName("picture");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<DboCategoriesTour>(entity =>
            {
                entity.HasKey(e => e.CatTourId);

                entity.ToTable("dbo_CategoriesTour");

                entity.Property(e => e.CatTourId).HasColumnName("CatTourID");

                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.CatTourName).HasMaxLength(250);

                entity.Property(e => e.Cover).HasMaxLength(250);

                entity.Property(e => e.MetaDesc).HasMaxLength(250);

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Picture)
                    .HasMaxLength(255)
                    .HasColumnName("picture");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<DboCategoriesTra>(entity =>
            {
                entity.HasKey(e => e.CatTraId)
                    .HasName("PK_dbo_CategoriesTra_1");

                entity.ToTable("dbo_CategoriesTra");

                entity.Property(e => e.CatTraId).HasColumnName("CatTraID");

                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.CatTraName).HasMaxLength(250);

                entity.Property(e => e.Cover).HasMaxLength(250);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.MetaDesc).HasMaxLength(250);

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<DboCategory>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.ToTable("dbo_Categories");

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.CatName).HasMaxLength(250);

                entity.Property(e => e.Cover).HasMaxLength(250);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.MetaDesc).HasMaxLength(250);

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<DboCruise>(entity =>
            {
                entity.HasKey(e => e.CruiseId);

                entity.ToTable("dbo_Cruise");

                entity.Property(e => e.CruiseId).HasColumnName("CruiseID");

                entity.Property(e => e.Alias).HasMaxLength(255);

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CruiseName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Duration).HasMaxLength(250);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.MetaDesc).HasMaxLength(255);

                entity.Property(e => e.MetaKey).HasMaxLength(255);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ShortDesc).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(150);

                entity.Property(e => e.Video).HasMaxLength(255);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.DboCruises)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_dbo_Cruise_dbo_Categories");
            });

            modelBuilder.Entity<DboCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("dbo_Customers");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsFixedLength(true);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .HasMaxLength(8)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.DboCustomers)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_dbo_Customers_dbo_Locations");
            });

            modelBuilder.Entity<DboFlight>(entity =>
            {
                entity.HasKey(e => e.FlightId);

                entity.ToTable("dbo_Flight");

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.Alias).HasMaxLength(255);

                entity.Property(e => e.CatFlightId).HasColumnName("CatFlightID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.FlightName).HasMaxLength(255);

                entity.Property(e => e.From).HasMaxLength(250);

                entity.Property(e => e.MetaDesc).HasMaxLength(255);

                entity.Property(e => e.MetaKey).HasMaxLength(255);

                entity.Property(e => e.Picture)
                    .HasMaxLength(255)
                    .HasColumnName("picture");

                entity.Property(e => e.ShortDesc).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.To).HasMaxLength(250);

                entity.Property(e => e.Video).HasMaxLength(255);

                entity.HasOne(d => d.CatFlight)
                    .WithMany(p => p.DboFlights)
                    .HasForeignKey(d => d.CatFlightId)
                    .HasConstraintName("FK_dbo_Flight_dbo_CategoriesFlight");
            });

            modelBuilder.Entity<DboHotel>(entity =>
            {
                entity.HasKey(e => e.HotelId);

                entity.ToTable("dbo_Hotel");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Alias).HasMaxLength(255);

                entity.Property(e => e.Bed).HasMaxLength(250);

                entity.Property(e => e.CatHotelId).HasColumnName("CatHotelID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.HotelName).HasMaxLength(255);

                entity.Property(e => e.MetaDesc).HasMaxLength(255);

                entity.Property(e => e.MetaKey).HasMaxLength(255);

                entity.Property(e => e.Picture)
                    .HasMaxLength(255)
                    .HasColumnName("picture");

                entity.Property(e => e.Rate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ShortDesc).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.Video).HasMaxLength(255);

                entity.HasOne(d => d.CatHotel)
                    .WithMany(p => p.DboHotels)
                    .HasForeignKey(d => d.CatHotelId)
                    .HasConstraintName("FK_dbo_Hotel_dbo_CategoriesHotel");
            });

            modelBuilder.Entity<DboLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK_dbo_Location");

                entity.ToTable("dbo_Locations");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.NameWithType).HasMaxLength(255);

                entity.Property(e => e.PathWithType).HasMaxLength(255);

                entity.Property(e => e.Slug).HasMaxLength(150);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<DboNews>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.ToTable("dbo_News");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.Author).HasMaxLength(250);

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsHot).HasColumnName("isHot");

                entity.Property(e => e.IsNewfeed).HasColumnName("isNewfeed");

                entity.Property(e => e.MetaDesc).HasMaxLength(255);

                entity.Property(e => e.MetaKey).HasMaxLength(255);

                entity.Property(e => e.Picture)
                    .HasMaxLength(255)
                    .HasColumnName("picture");

                entity.Property(e => e.Scontents)
                    .HasMaxLength(250)
                    .HasColumnName("SContents");

                entity.Property(e => e.Title).HasMaxLength(150);
            });

            modelBuilder.Entity<DboOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("dbo_Orders");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.TransactStatusId).HasColumnName("TransactStatusID");

                entity.Property(e => e.TravelDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.DboOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_dbo_Orders_dbo_Customers");

                entity.HasOne(d => d.TransactStatus)
                    .WithMany(p => p.DboOrders)
                    .HasForeignKey(d => d.TransactStatusId)
                    .HasConstraintName("FK_dbo_Orders_dbo_TransactStatus");
            });

            modelBuilder.Entity<DboOrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailId);

                entity.ToTable("dbo_OrderDetail");

                entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.DboOrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_dbo_OrderDetail_dbo_Orders");
            });

            modelBuilder.Entity<DboPage>(entity =>
            {
                entity.HasKey(e => e.PageId);

                entity.ToTable("dbo_Pages");

                entity.Property(e => e.PageId).HasColumnName("PageID");

                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.MetaDesc).HasMaxLength(250);

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.PageName).HasMaxLength(50);

                entity.Property(e => e.Picture)
                    .HasMaxLength(255)
                    .HasColumnName("picture");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.Title2).HasMaxLength(250);

                entity.Property(e => e.Title3).HasMaxLength(250);

                entity.Property(e => e.Title4).HasMaxLength(250);
            });

            modelBuilder.Entity<DboRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("dbo_Roles");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<DboTour>(entity =>
            {
                entity.HasKey(e => e.TourId);

                entity.ToTable("dbo_Tour");

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.Property(e => e.Alias).HasMaxLength(255);

                entity.Property(e => e.CatTourId).HasColumnName("CatTourID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.MetaDesc).HasMaxLength(255);

                entity.Property(e => e.MetaKey).HasMaxLength(255);

                entity.Property(e => e.Picture)
                    .HasMaxLength(255)
                    .HasColumnName("picture");

                entity.Property(e => e.ShortDesc).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.TourName).HasMaxLength(255);

                entity.Property(e => e.Video).HasMaxLength(255);

                entity.HasOne(d => d.CatTour)
                    .WithMany(p => p.DboTours)
                    .HasForeignKey(d => d.CatTourId)
                    .HasConstraintName("FK_dbo_Tour_dbo_CategoriesTour");
            });

            modelBuilder.Entity<DboTransactStatus>(entity =>
            {
                entity.HasKey(e => e.TransactStatusId);

                entity.ToTable("dbo_TransactStatus");

                entity.Property(e => e.TransactStatusId).HasColumnName("TransactStatusID");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<DboTransport>(entity =>
            {
                entity.HasKey(e => e.TransportId);

                entity.ToTable("dbo_Transports");

                entity.Property(e => e.TransportId).HasColumnName("TransportID");

                entity.Property(e => e.Alias).HasMaxLength(255);

                entity.Property(e => e.CatTraId).HasColumnName("CatTraID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.MetaDesc).HasMaxLength(255);

                entity.Property(e => e.MetaKey).HasMaxLength(255);

                entity.Property(e => e.Picture)
                    .HasMaxLength(255)
                    .HasColumnName("picture");

                entity.Property(e => e.ShortDesc).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.TransportName).HasMaxLength(255);

                entity.Property(e => e.UnitslnStock).HasMaxLength(255);

                entity.Property(e => e.Video).HasMaxLength(255);

                entity.HasOne(d => d.CatTra)
                    .WithMany(p => p.DboTransports)
                    .HasForeignKey(d => d.CatTraId)
                    .HasConstraintName("FK_dbo_Transports_dbo_CategoriesTra");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
