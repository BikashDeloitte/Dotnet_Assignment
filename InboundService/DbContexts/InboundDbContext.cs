using InboundService.Models;
using Microsoft.EntityFrameworkCore;

namespace InboundService.DbContexts
{
    public class InboundDbContext : DbContext
    {
        public InboundDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Order> Orders { get; set; }
    }
}