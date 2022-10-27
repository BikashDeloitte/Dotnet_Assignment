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
                CouponCode = "15%OFF",
                DiscountPercentage = 15
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponCode = "25%OFF",
                DiscountPercentage = 25
            });
        }
    }
}
