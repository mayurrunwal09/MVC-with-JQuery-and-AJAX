using Microsoft.EntityFrameworkCore;

namespace Product.Models
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions options):base(options) { }
        public DbSet<Product> Products { get; set;}
    }
}
