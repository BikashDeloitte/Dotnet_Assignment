using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SystemManagement.Models;

namespace SystemManagement.DbContexts
{
    public class SystemManagementDbContext : DbContext
    {
        public SystemManagementDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<LPN> LPNs { get; set; }
        public DbSet<Pallet> Pallets { get; set; }
        public DbSet<Node> Nodes { get; set; }
    }
}
