﻿// <auto-generated />
using System;
using ECommerceMVC.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommerceMVC.DataAccess.Migrations
{
    [DbContext(typeof(ECommerceDbContext))]
    partial class ECommerceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ECommerceMVC.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Phone"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Computer"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tablet"
                        });
                });

            modelBuilder.Entity("ECommerceMVC.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Discount")
                        .HasColumnType("float");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Awasome",
                            Discount = 0.02,
                            ImageURL = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/113155-2_large.jpg",
                            IsActive = true,
                            Name = "iPhone 11",
                            Price = 7000.0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Cool",
                            Discount = 0.02,
                            ImageURL = "https://productimages.hepsiburada.net/s/44/550/10769576230962.jpg/format:webp",
                            IsActive = true,
                            Name = "Samsung",
                            Price = 7000.0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Chang Ching Chong",
                            Discount = 0.02,
                            ImageURL = "https://productimages.hepsiburada.net/s/198/550/110000168630735.jpg/format:webp",
                            IsActive = true,
                            Name = "Xiomi",
                            Price = 7000.0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Description = "Interesting",
                            Discount = 0.089999999999999997,
                            ImageURL = "https://productimages.hepsiburada.net/s/44/222-222/10817626898482.jpg/format:webp",
                            IsActive = true,
                            Name = "MacBook Pro1",
                            Price = 20000.0
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "Ghost",
                            Discount = 0.02,
                            ImageURL = "https://productimages.hepsiburada.net/s/203/550/110000176911589.jpg/format:webp",
                            IsActive = true,
                            Name = "Casper",
                            Price = 7000.0
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "Canavar",
                            Discount = 0.02,
                            ImageURL = "https://productimages.hepsiburada.net/s/108/550/110000052006351.jpg/format:webp",
                            IsActive = true,
                            Name = "Monster",
                            Price = 7000.0
                        });
                });

            modelBuilder.Entity("ECommerceMVC.Entities.Product", b =>
                {
                    b.HasOne("ECommerceMVC.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ECommerceMVC.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
