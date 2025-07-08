using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WareHouseCTL.Models;

namespace WareHouseCTL.Data
{
    public class WareHouseCTLContext : DbContext
    {
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Chemical> Chemicals { get; set; }
        public DbSet<ShelfContainer> ShelfContainers { get; set; }
        public DbSet<ChemicalDetail> ChemicalDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                try
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["WarehouseDBConnection"]?.ConnectionString;
                    Console.WriteLine($"Connection string: {connectionString}");
                    if (string.IsNullOrEmpty(connectionString))
                    {
                        throw new ConfigurationErrorsException("Chuỗi kết nối 'WarehouseDBConnection' không được tìm thấy trong App.config.");
                    }
                    optionsBuilder.UseSqlServer(connectionString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc App.config: {ex.Message}");
                    throw;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chemical>()
                .HasKey(c => c.ChemicalId);

            modelBuilder.Entity<Shelf>()
                .HasKey(s => s.ShelfID);

            modelBuilder.Entity<ShelfContainer>()
                .HasKey(sc => sc.ShelfContainerId);

            modelBuilder.Entity<ChemicalDetail>()
                .HasKey(ct => ct.DetailId);

            modelBuilder.Entity<Shelf>()
                .HasOne(s => s.Chemical)
                .WithOne(c => c.Shelf)
                .HasForeignKey<Shelf>(s => s.ChemicalId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShelfContainer>()
                .HasOne(sc => sc.Shelf)
                .WithMany(s => s.ShelfContainers)
                .HasForeignKey(sc => sc.ShelfID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShelfContainer>()
                .HasOne(sc => sc.Chemical)
                .WithMany(c => c.ShelfContainers)
                .HasForeignKey(sc => sc.ChemicalId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChemicalDetail>()
                .HasOne(ct => ct.ShelfContainer)
                .WithMany(sc => sc.ChemicalDetails)
                .HasForeignKey(ct => ct.ShelfContainerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChemicalDetail>()
                .HasOne(ct => ct.Chemical)
                .WithMany(c => c.ChemicalDetails)
                .HasForeignKey(ct => ct.ChemicalId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}