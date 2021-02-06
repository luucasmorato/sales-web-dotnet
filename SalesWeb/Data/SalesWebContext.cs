using Microsoft.EntityFrameworkCore;

namespace SalesWeb.Data
{
    public class SalesWebContext : DbContext
    {
        public SalesWebContext (DbContextOptions<SalesWebContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWeb.Models.Department> Department { get; set; }
        public DbSet<SalesWeb.Models.Seller> Seller { get; set; }
        public DbSet<SalesWeb.Models.SalesRecord> SalesRecord { get; set; }
    }
}
