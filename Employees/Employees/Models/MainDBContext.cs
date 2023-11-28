using Microsoft.EntityFrameworkCore;

namespace Employees.Models
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions options):base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
