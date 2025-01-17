﻿// <auto-generated />
using System;
using HepsiApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HepsiApi.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231230200443_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CategoryProduct");
                });

            modelBuilder.Entity("HepsiApi.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 12, 30, 23, 4, 43, 750, DateTimeKind.Local).AddTicks(9342),
                            Name = "Books & Movies",
                            isDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 12, 30, 23, 4, 43, 750, DateTimeKind.Local).AddTicks(9444),
                            Name = "Electronics, Movies & Music",
                            isDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 12, 30, 23, 4, 43, 750, DateTimeKind.Local).AddTicks(9461),
                            Name = "Electronics & Health",
                            isDeleted = true
                        });
                });

            modelBuilder.Entity("HepsiApi.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 12, 30, 23, 4, 43, 751, DateTimeKind.Local).AddTicks(1417),
                            Name = "Elektrik",
                            ParentId = 0,
                            Priority = 1,
                            isDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 12, 30, 23, 4, 43, 751, DateTimeKind.Local).AddTicks(1419),
                            Name = "Moda",
                            ParentId = 0,
                            Priority = 2,
                            isDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 12, 30, 23, 4, 43, 751, DateTimeKind.Local).AddTicks(1421),
                            Name = "Bilgisayar",
                            ParentId = 1,
                            Priority = 1,
                            isDeleted = false
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2023, 12, 30, 23, 4, 43, 751, DateTimeKind.Local).AddTicks(1422),
                            Name = "Kadın",
                            ParentId = 2,
                            Priority = 1,
                            isDeleted = false
                        });
                });

            modelBuilder.Entity("HepsiApi.Domain.Entities.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2023, 12, 30, 23, 4, 43, 752, DateTimeKind.Local).AddTicks(5519),
                            Description = "Quia karşıdakine vitae masanın eaque.",
                            Title = "Veritatis.",
                            isDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2023, 12, 30, 23, 4, 43, 752, DateTimeKind.Local).AddTicks(5555),
                            Description = "Esse domates mıknatıslı minima yazın.",
                            Title = "Modi gülüyorum.",
                            isDeleted = true
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 4,
                            CreatedDate = new DateTime(2023, 12, 30, 23, 4, 43, 752, DateTimeKind.Local).AddTicks(5582),
                            Description = "Nihil lambadaki dağılımı reprehenderit esse.",
                            Title = "Laboriosam.",
                            isDeleted = false
                        });
                });

            modelBuilder.Entity("HepsiApi.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CreatedDate = new DateTime(2023, 12, 30, 23, 4, 43, 753, DateTimeKind.Local).AddTicks(9915),
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            Discount = 0.5473060126212890m,
                            Price = 579.70m,
                            Title = "Handmade Wooden Gloves",
                            isDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 3,
                            CreatedDate = new DateTime(2023, 12, 30, 23, 4, 43, 753, DateTimeKind.Local).AddTicks(9940),
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            Discount = 9.351746391088850m,
                            Price = 526.71m,
                            Title = "Gorgeous Fresh Gloves",
                            isDeleted = false
                        });
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("HepsiApi.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HepsiApi.Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HepsiApi.Domain.Entities.Detail", b =>
                {
                    b.HasOne("HepsiApi.Domain.Entities.Category", "Category")
                        .WithMany("Details")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("HepsiApi.Domain.Entities.Product", b =>
                {
                    b.HasOne("HepsiApi.Domain.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("HepsiApi.Domain.Entities.Category", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
