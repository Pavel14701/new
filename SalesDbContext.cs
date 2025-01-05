using Microsoft.EntityFrameworkCore;

namespace SalesApp
{
    public class SalesDbContext : DbContext
    {
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=sales.db");
        }
    }

    public class Sale
    {
        public int Id { get; set; }
        public required string Product { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
