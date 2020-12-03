using MannuBusinessWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MannuBusinessWebApi.Persistence
{
    public class MannuDbContext : DbContext
    {
        public DbSet<Business> Businesses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<BusinessTypes> BusinessTypes { get; set; }

        public MannuDbContext(DbContextOptions<MannuDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>()
                .Property(b => b.Name)
                .HasMaxLength(128)
                .IsRequired();

            modelBuilder.Entity<Business>()
                .Property(b => b.OwnerName)
                .HasMaxLength(128)
                .IsRequired();

            modelBuilder.Entity<Business>()
                .Property(b => b.Description)
                .HasMaxLength(128)
                .IsRequired();

            modelBuilder.Entity<Business>()
                .Property(b => b.BusinessTypeId)
                .IsRequired();

            modelBuilder.Entity<Business>()
                .Property(b => b.BusinessPartnerName)
                .HasMaxLength(128)
                .IsRequired();

            modelBuilder.Entity<Business>()
                .OwnsOne(o => o.Address, b =>
                {
                    b.Property(a => a.CityId).HasColumnName("City").IsRequired();
                    b.Property(a => a.ProvinceId).HasColumnName("Province").IsRequired();
                    b.Property(a => a.CountryId).HasColumnName("CountryId").IsRequired();
                    b.Property(a => a.ShopLocation).HasColumnName("ShopLocation").IsRequired();

                    b.HasOne(a => a.Country)
                        .WithMany()
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne(a => a.Province)
                        .WithMany()
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne(a => a.City)
                        .WithMany()
                        .OnDelete(DeleteBehavior.Restrict);
                });

            //City
            modelBuilder.Entity<City>()
                .Property(c => c.Name)
                .HasMaxLength(128)
                .IsRequired();

            modelBuilder.Entity<Province>()
                .Property(p => p.Name)
                .HasMaxLength(128)
                .IsRequired();

            modelBuilder.Entity<Country>()
                .Property(p => p.Name)
                .HasMaxLength(128)
                .IsRequired();

            // BusinessTypes
            modelBuilder.Entity<BusinessTypes>()
                .Property(bt => bt.Name)
                .HasMaxLength(128)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}