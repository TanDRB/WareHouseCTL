﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WareHouseCTL.Data;

#nullable disable

namespace WareHouseCTL.Migrations
{
    [DbContext(typeof(WareHouseCTLContext))]
    [Migration("20250606081405_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WareHouseCTL.Models.Chemical", b =>
                {
                    b.Property<string>("ChemicalID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChemicalDescribe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChemicalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChemicalID");

                    b.ToTable("Chemicals");
                });

            modelBuilder.Entity("WareHouseCTL.Models.ChemicalDetail", b =>
                {
                    b.Property<string>("DetailId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ShelfContainerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StorageDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DetailId");

                    b.HasIndex("ItemName");

                    b.HasIndex("ShelfContainerId");

                    b.ToTable("ChemicalDetails");
                });

            modelBuilder.Entity("WareHouseCTL.Models.Shelf", b =>
                {
                    b.Property<string>("ShelfID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChemicalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChemicalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShelfName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShelfID");

                    b.HasIndex("ChemicalId")
                        .IsUnique();

                    b.ToTable("Shelves");
                });

            modelBuilder.Entity("WareHouseCTL.Models.ShelfContainer", b =>
                {
                    b.Property<int>("ShelfContainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShelfContainerId"));

                    b.Property<string>("ShelfContainerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShelfID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StorageDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ShelfContainerId");

                    b.HasIndex("ShelfID");

                    b.ToTable("ShelfContainers");
                });

            modelBuilder.Entity("WareHouseCTL.Models.ChemicalDetail", b =>
                {
                    b.HasOne("WareHouseCTL.Models.Chemical", "Chemical")
                        .WithMany()
                        .HasForeignKey("ItemName")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WareHouseCTL.Models.ShelfContainer", "ShelfContainer")
                        .WithMany("ChemicalDetails")
                        .HasForeignKey("ShelfContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chemical");

                    b.Navigation("ShelfContainer");
                });

            modelBuilder.Entity("WareHouseCTL.Models.Shelf", b =>
                {
                    b.HasOne("WareHouseCTL.Models.Chemical", "Chemical")
                        .WithOne("Shelf")
                        .HasForeignKey("WareHouseCTL.Models.Shelf", "ChemicalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Chemical");
                });

            modelBuilder.Entity("WareHouseCTL.Models.ShelfContainer", b =>
                {
                    b.HasOne("WareHouseCTL.Models.Shelf", "Shelf")
                        .WithMany("ShelfContainers")
                        .HasForeignKey("ShelfID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Shelf");
                });

            modelBuilder.Entity("WareHouseCTL.Models.Chemical", b =>
                {
                    b.Navigation("Shelf")
                        .IsRequired();
                });

            modelBuilder.Entity("WareHouseCTL.Models.Shelf", b =>
                {
                    b.Navigation("ShelfContainers");
                });

            modelBuilder.Entity("WareHouseCTL.Models.ShelfContainer", b =>
                {
                    b.Navigation("ChemicalDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
