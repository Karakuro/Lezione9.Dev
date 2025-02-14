using Microsoft.EntityFrameworkCore;

namespace Lezione9.Dev.Data
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext() : base() { }

        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) 
            : base(options) { }

        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Allocation> Allocations { get; set; }
    }
}
