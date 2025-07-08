using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WareHouseCTL.Models;

namespace WareHouseCTL.Data
{
    public class WareHouseCTLContext : DbContext
    {
        // Định nghĩa các DbSet cho các bảng
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Chemical> Chemicals { get; set; }
        public DbSet<ShelfContainer> ShelfContainers { get; set; } // Sửa từ Container thành ShelfContainer
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
            // Cấu hình khóa chính
            modelBuilder.Entity<Chemical>()
                .HasKey(c => c.ChemicalID); // Sửa từ ChemicalID thành ChemicalId

            modelBuilder.Entity<Shelf>()
                .HasKey(s => s.ShelfID);

            modelBuilder.Entity<ShelfContainer>()
                .HasKey(sc => sc.ShelfContainerId);

            modelBuilder.Entity<ChemicalDetail>()
                .HasKey(ct => ct.DetailId);

            // Cấu hình quan hệ 1-1 giữa Chemical và Shelf (một hóa chất chỉ gán cho một kệ)
            modelBuilder.Entity<Shelf>()
                .HasOne(s => s.Chemical)
                .WithOne(c => c.Shelf)
                .HasForeignKey<Shelf>(s => s.ChemicalId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình quan hệ giữa Shelf và ShelfContainer
            modelBuilder.Entity<ShelfContainer>()
                .HasOne(sc => sc.Shelf)
                .WithMany(s => s.ShelfContainers)
                .HasForeignKey(sc => sc.ShelfID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Cấu hình quan hệ giữa ShelfContainer và ChemicalDetail
            modelBuilder.Entity<ChemicalDetail>()
                .HasOne(ct => ct.ShelfContainer)
                .WithMany(sc => sc.ChemicalDetails)
                .HasForeignKey(ct => ct.ShelfContainerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình quan hệ giữa ChemicalDetail và Chemical
            modelBuilder.Entity<ChemicalDetail>()
                .HasOne(ct => ct.Chemical)
                .WithMany()
                .HasForeignKey(ct => ct.ItemName)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}