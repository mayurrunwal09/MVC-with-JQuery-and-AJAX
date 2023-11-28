using Microsoft.EntityFrameworkCore;

namespace StudentModel.Models
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions options):base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}
