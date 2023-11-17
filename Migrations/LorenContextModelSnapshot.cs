﻿// <auto-generated />
using System;
using Loren_TPI_Prog3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Loren_TPI_Prog3.Migrations
{
    [DbContext(typeof(LorenContext))]
    partial class LorenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Loren_TPI_Prog3.Data.Entities.Products.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ColorCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ColorCode = 34,
                            Name = "Negro"
                        },
                        new
                        {
                            Id = 2,
                            ColorCode = 65,
                            Name = "Blanco"
                        },
                        new
                        {
                            Id = 3,
                            ColorCode = 28,
                            Name = "Rojo"
                        });
                });

            modelBuilder.Entity("Loren_TPI_Prog3.Data.Entities.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Code")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Discount")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<bool>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Corpiños",
                            Code = new Guid("b8fc619e-7922-44b5-98f2-6eab1eeb6ac3"),
                            CreationDate = new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Corpiño push-up de suave textura y excelente calidad",
                            Discount = 0m,
                            ImageLink = "https://http2.mlstatic.com/D_NQ_NP_692024-MLA53006038573_122022-O.webp",
                            LastModifiedDate = new DateTime(2023, 11, 16, 14, 23, 44, 956, DateTimeKind.Local).AddTicks(1360),
                            Name = "Corpiño",
                            Price = 5000.34m,
                            State = true
                        },
                        new
                        {
                            Id = 2,
                            Category = "Mallas",
                            Code = new Guid("69abb697-e7c5-45df-a479-9b3b45a5bce3"),
                            CreationDate = new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Malla de algodón",
                            Discount = 10.5m,
                            ImageLink = "https://http2.mlstatic.com/D_NQ_NP_674011-MLA52236140541_112022-O.webp",
                            LastModifiedDate = new DateTime(2023, 11, 16, 14, 23, 44, 956, DateTimeKind.Local).AddTicks(1463),
                            Name = "Malla",
                            Price = 5000.34m,
                            State = true
                        },
                        new
                        {
                            Id = 3,
                            Category = "Camisones",
                            Code = new Guid("ed9bf2e4-ac08-4344-85de-51e3b1be731e"),
                            CreationDate = new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Camisón de seda confeccionado con un material suave y lujoso",
                            Discount = 0m,
                            ImageLink = "https://selulen.vtexassets.com/arquivos/ids/179923/SL16202_vison_1-selu-camison-raso-pijama-regulable-enagua-puntilla-estampado.jpg?v=638104325419730000",
                            LastModifiedDate = new DateTime(2023, 11, 16, 14, 23, 44, 956, DateTimeKind.Local).AddTicks(1467),
                            Name = "Camisón",
                            Price = 5000.34m,
                            State = true
                        });
                });

            modelBuilder.Entity("Loren_TPI_Prog3.Data.Entities.Products.ProductVariant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ColorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SizeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.ToTable("ProductVariants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ColorId = 2,
                            ProductId = 1,
                            SizeId = 3,
                            Stock = 14
                        },
                        new
                        {
                            Id = 2,
                            ColorId = 3,
                            ProductId = 2,
                            SizeId = 1,
                            Stock = 24
                        },
                        new
                        {
                            Id = 3,
                            ColorId = 1,
                            ProductId = 3,
                            SizeId = 2,
                            Stock = 5
                        });
                });

            modelBuilder.Entity("Loren_TPI_Prog3.Data.Entities.Products.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SizeCode")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "S",
                            SizeCode = 23
                        },
                        new
                        {
                            Id = 2,
                            Name = "M",
                            SizeCode = 75
                        },
                        new
                        {
                            Id = 3,
                            Name = "L",
                            SizeCode = 12
                        });
                });

            modelBuilder.Entity("Loren_TPI_Prog3.Data.Entities.SaleOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("OrderCode")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("State")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("SaleOrders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            Completed = false,
                            OrderCode = new Guid("4f3cb87b-6b92-4130-b6b9-18849f0e2e04"),
                            OrderDate = new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethod = 0,
                            State = true,
                            TotalPrice = 15000.34m
                        },
                        new
                        {
                            Id = 2,
                            ClientId = 1,
                            Completed = false,
                            OrderCode = new Guid("7fd697d3-9a61-4c6a-a4fa-85a6702a325b"),
                            OrderDate = new DateTime(2023, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentMethod = 1,
                            State = true,
                            TotalPrice = 38000.95m
                        });
                });

            modelBuilder.Entity("Loren_TPI_Prog3.Data.Entities.SaleOrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuantityOrdered")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SaleOrderId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleOrderId");

                    b.ToTable("SaleOrderLine");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            QuantityOrdered = 2,
                            SaleOrderId = 2,
                            Total = 0m
                        });
                });

            modelBuilder.Entity("Loren_TPI_Prog3.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("State")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Loren_TPI_Prog3.Data.Entities.Admin", b =>
                {
                    b.HasBaseType("Loren_TPI_Prog3.Data.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Email = "ezecoria@gmail.com",
                            LastName = "Coria",
                            Name = "Ezequiel",
                            Password = "eze123456",
                            State = true,
                            UserName = "eze95",
                            UserType = "Admin"
                        });
                });

            modelBuilder.Entity("Loren_TPI_Prog3.Data.Entities.Client", b =>
                {
                    b.HasBaseType("Loren_TPI_Prog3.Data.Entities.User");

                    b.HasDiscriminator().HasValue("Client");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Montevideo 1150 7B",
                            Email = "leocabral@gmail.com",
                            LastName = "Cabral",
                            Name = "Leandro",
                            Password = "leo123456",
                            State = true,
                            UserName = "lean94",
                            UserType = "Client"
                        });
                });

            modelBuilder.Entity("Loren_TPI_Prog3.Data.Entities.SuperAdmin", b =>
                {
                    b.HasBaseType("Loren_TPI_Prog3.Data.Entities.User");

                    b.HasDiscriminator().HasValue("SuperAdmin");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Email = "santibrasca@gmail.com",
                            LastName = "Brasca",
                            Name = "Santiago",
                            Password = "santi123456",
                            State = true,
                            UserName = "santi02",
                            UserType = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("Loren_TPI_Prog3.Data.Entities.Products.ProductVariant", b =>
                {
                    b.HasOne("Loren_TPI_Prog3.Data.Entities.Products.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Loren_TPI_Prog3.Data.Entities.Products.Product", null)
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Loren_TPI_Prog3.Data.Entities.Products.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("Loren_TPI_Prog3.Data.Entities.SaleOrder", b =>
                {
                    b.HasOne("Loren_TPI_Prog3.Data.Entities.Client", "Client")
                        .WithMany("SaleOrders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Loren_TPI_Prog3.Data.Entities.SaleOrderLine", b =>
                {
                    b.HasOne("Loren_TPI_Prog3.Data.Entities.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Loren_TPI_Prog3.Data.Entities.SaleOrder", "SaleOrder")
                        .WithMany("SaleOrderLines")
                        .HasForeignKey("SaleOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SaleOrder");
                });

            modelBuilder.Entity("Loren_TPI_Prog3.Data.Entities.Products.Product", b =>
                {
                    b.Navigation("Variants");
                });

            modelBuilder.Entity("Loren_TPI_Prog3.Data.Entities.SaleOrder", b =>
                {
                    b.Navigation("SaleOrderLines");
                });

            modelBuilder.Entity("Loren_TPI_Prog3.Data.Entities.Client", b =>
                {
                    b.Navigation("SaleOrders");
                });
#pragma warning restore 612, 618
        }
    }
}