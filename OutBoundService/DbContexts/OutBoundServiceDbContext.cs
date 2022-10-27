using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using OutBoundService.Models;

namespace OutBoundService.DbContexts
{
    public class OutBoundServiceDbContext : DbContext
    {
        public OutBoundServiceDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = "15%OFF",
                DiscountPercentage = 15
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "25%OFF",
                DiscountPercentage = 25
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 3,
                CouponCode = "5%OFF",
                DiscountPercentage = 5
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 4,
                CouponCode = "35%OFF",
                DiscountPercentage = 35
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 5,
                CouponCode = "45%OFF",
                DiscountPercentage = 45
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 6,
                CouponCode = "55%OFF",
                DiscountPercentage = 55
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 7,
                CouponCode = "25%OFF",
                DiscountPercentage = 25
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 8,
                CouponCode = "65%OFF",
                DiscountPercentage = 65
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 9,
                CouponCode = "75%OFF",
                DiscountPercentage = 75
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 10,
                CouponCode = "85%OFF",
                DiscountPercentage = 85
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 11,
                CouponCode = "90%OFF",
                DiscountPercentage = 90
            });
        }
    }
}
