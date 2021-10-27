using System;
using Catalog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Catalog.Data
{
    public partial class CatalogDBContext : DbContext
    {
        public CatalogDBContext()
        {
        }

        public CatalogDBContext(DbContextOptions<CatalogDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CuisineType> CuisineTypes { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<FoodCategory> FoodCategories { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<RestaurantAndFood> RestaurantAndFoods { get; set; }
        public virtual DbSet<RestaurantsAndCuisineType> RestaurantsAndCuisineTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:catalogmicroservicedbserver.database.windows.net,1433;Initial Catalog=CatalogDB;Persist Security Info=False;User ID=Abilda;Password=Amirkhan007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CuisineType>(entity =>
            {
                entity.ToTable("CuisineType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Name).HasColumnType("ntext");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("Food");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.ExpectedCookingTime).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Name).HasColumnType("ntext");

                entity.Property(e => e.Price).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<FoodCategory>(entity =>
            {
                entity.ToTable("FoodCategory");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("ntext");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("ntext");

                entity.Property(e => e.PhotoUrl).HasColumnType("text");

                entity.Property(e => e.PlaceQuality).HasColumnType("ntext");

                entity.Property(e => e.WorkingEndTime).HasColumnType("ntext");

                entity.Property(e => e.WorkingStartTime).HasColumnType("ntext");

            });

            modelBuilder.Entity<RestaurantAndFood>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<RestaurantsAndCuisineType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
