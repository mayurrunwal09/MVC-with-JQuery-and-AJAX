using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication_Employee.Models
{
    public class MainDBContext : IdentityDbContext
    {
        public MainDBContext(DbContextOptions options): base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
