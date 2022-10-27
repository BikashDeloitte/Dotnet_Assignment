﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OutBoundService.DbContexts;

#nullable disable

namespace OutBoundService.Migrations
{
    [DbContext(typeof(OutBoundServiceDbContext))]
    [Migration("20221027112548_OutBoundMigration")]
    partial class OutBoundMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OutBoundService.Models.Coupon", b =>
                {
                    b.Property<int>("CouponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CouponId"), 1L, 1);

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountPercentage")
                        .HasColumnType("int");

                    b.HasKey("CouponId");

                    b.ToTable("Coupons");

                    b.HasData(
                        new
                        {
                            CouponId = 1,
                            CouponCode = "15%OFF",
                            DiscountPercentage = 15
                        },
                        new
                        {
                            CouponId = 2,
                            CouponCode = "25%OFF",
                            DiscountPercentage = 25
                        },
                        new
                        {
                            CouponId = 3,
                            CouponCode = "5%OFF",
                            DiscountPercentage = 5
                        },
                        new
                        {
                            CouponId = 4,
                            CouponCode = "35%OFF",
                            DiscountPercentage = 35
                        },
                        new
                        {
                            CouponId = 5,
                            CouponCode = "45%OFF",
                            DiscountPercentage = 45
                        },
                        new
                        {
                            CouponId = 6,
                            CouponCode = "55%OFF",
                            DiscountPercentage = 55
                        },
                        new
                        {
                            CouponId = 7,
                            CouponCode = "25%OFF",
                            DiscountPercentage = 25
                        },
                        new
                        {
                            CouponId = 8,
                            CouponCode = "65%OFF",
                            DiscountPercentage = 65
                        },
                        new
                        {
                            CouponId = 9,
                            CouponCode = "75%OFF",
                            DiscountPercentage = 75
                        },
                        new
                        {
                            CouponId = 10,
                            CouponCode = "85%OFF",
                            DiscountPercentage = 85
                        },
                        new
                        {
                            CouponId = 11,
                            CouponCode = "90%OFF",
                            DiscountPercentage = 90
                        });
                });

            modelBuilder.Entity("OutBoundService.Models.CustomerOrder", b =>
                {
                    b.Property<int>("CustomerOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerOrderId"), 1L, 1);

                    b.Property<string>("CouponCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreationTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerOrderNumber")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("CustomerOrderId");

                    b.ToTable("CustomerOrders");
                });

            modelBuilder.Entity("OutBoundService.Models.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DriverId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DriverId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("OutBoundService.Models.Shipment", b =>
                {
                    b.Property<int>("ShipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipmentId"), 1L, 1);

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<string>("ShipmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipmentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipmentTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TruckId")
                        .HasColumnType("int");

                    b.HasKey("ShipmentId");

                    b.HasIndex("DriverId");

                    b.HasIndex("TruckId");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("OutBoundService.Models.Truck", b =>
                {
                    b.Property<int>("TruckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TruckId"), 1L, 1);

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TruckId");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("OutBoundService.Models.Shipment", b =>
                {
                    b.HasOne("OutBoundService.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OutBoundService.Models.Truck", "Truck")
                        .WithMany()
                        .HasForeignKey("TruckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Truck");
                });
#pragma warning restore 612, 618
        }
    }
}