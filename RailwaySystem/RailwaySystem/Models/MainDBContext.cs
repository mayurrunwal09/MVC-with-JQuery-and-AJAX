using Microsoft.EntityFrameworkCore;

namespace RailwaySystem.Models
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions options):base(options) { }
        public DbSet<Railway> Railways { get; set; }
    }
}
