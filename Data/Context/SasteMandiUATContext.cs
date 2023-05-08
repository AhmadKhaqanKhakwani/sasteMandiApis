using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Entities
{
    public partial class SasteMandiUATContext : DbContext
    {
        public SasteMandiUATContext()
        {
        }

        public SasteMandiUATContext(DbContextOptions<SasteMandiUATContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<ColsedStock> ColsedStocks { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<FeaturedCategory> FeaturedCategories { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderEntityType> OrderEntityTypes { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PackageCategory> PackageCategories { get; set; }
        public virtual DbSet<PackageDetail> PackageDetails { get; set; }
        public virtual DbSet<Pricing> Pricings { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductPacking> ProductPackings { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<StockEntityType> StockEntityTypes { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<SubCategoryToPackage> SubCategoryToPackages { get; set; }
        public virtual DbSet<SubCategoryToProduct> SubCategoryToProducts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=Hamza;Database=SasteMandiUAT;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.AddressText).IsRequired();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.GeoLocaton).IsRequired();

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Locations");
            });

            modelBuilder.Entity<ColsedStock>(entity =>
            {
                entity.ToTable("ColsedStock");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Qty).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Sku)
                    .HasMaxLength(10)
                    .HasColumnName("SKU")
                    .IsFixedLength();

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ColsedStocks)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ColsedStock_Products");
            });

            modelBuilder.Entity<EmailTemplate>(entity =>
            {
                entity.ToTable("EmailTemplate");

                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FeaturedCategory>(entity =>
            {
                entity.ToTable("FeaturedCategory");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ImageURL");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("createdOn");

                entity.Property(e => e.DiscountTotal).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TaxTotal).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Total).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Orders_OrderStatus");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.TotalQty).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.EntityType)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.EntityTypeId)
                    .HasConstraintName("FK_OrderDetails_Orders");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetails_Orders1");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.PriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_ProductPricing");
            });

            modelBuilder.Entity<OrderEntityType>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("Package");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.PackageTitle).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.PackageCategory)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.PackageCategoryId)
                    .HasConstraintName("FK_Package_PackageCategory");
            });

            modelBuilder.Entity<PackageCategory>(entity =>
            {
                entity.ToTable("PackageCategory");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<PackageDetail>(entity =>
            {
                entity.ToTable("PackageDetail");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackageDetails)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK_PackageDetail_Package");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.PackageDetails)
                    .HasForeignKey(d => d.PriceId)
                    .HasConstraintName("FK_PackageDetail_Pricing");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PackageDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_PackageDetail_Products");
            });

            modelBuilder.Entity<Pricing>(entity =>
            {
                entity.ToTable("Pricing");

                entity.Property(e => e.Amount).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SKU");

                entity.Property(e => e.TitleEng).HasMaxLength(50);

                entity.Property(e => e.TitleUrdu).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Description)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.DescriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_ProductDescription");

                entity.HasOne(d => d.FeaturedCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.FeaturedCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_FeaturedCategory");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductDescription>(entity =>
            {
                entity.ToTable("ProductDescription");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DetailEng).HasMaxLength(50);

                entity.Property(e => e.DetailUrdu).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("imageUrl");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductImages_Products");
            });

            modelBuilder.Entity<ProductPacking>(entity =>
            {
                entity.ToTable("ProductPacking");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.PackingTitle).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.ProductPackings)
                    .HasForeignKey(d => d.PriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPacking_Pricing");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPackings)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPacking_Products");
            });

            modelBuilder.Entity<Slider>(entity =>
            {
                entity.ToTable("Slider");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("imageUrl");

                entity.Property(e => e.Task)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("Stock");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SKU");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.PriceNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.Price)
                    .HasConstraintName("FK_Stock_Products");
            });

            modelBuilder.Entity<StockEntityType>(entity =>
            {
                entity.ToTable("StockEntityType");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CreatedOn)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.IsActive)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedOn)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.ToTable("SubCategory");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.FeaturedCategory)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.FeaturedCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubCategory_FeaturedCategory");
            });

            modelBuilder.Entity<SubCategoryToPackage>(entity =>
            {
                entity.ToTable("SubCategoryToPackage");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.SubCategoryToPackages)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubCategoryToPackage_SubCategory");
            });

            modelBuilder.Entity<SubCategoryToProduct>(entity =>
            {
                entity.ToTable("SubCategoryToProduct");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SubCategoryToProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubCategoryToProduct_Products");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.SubCategoryToProducts)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubCategoryToProduct_SubCategory");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNo).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
