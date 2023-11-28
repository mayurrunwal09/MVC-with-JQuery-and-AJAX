using Microsoft.EntityFrameworkCore;

namespace OneToManyPopup.Models
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions options): base(options) { }   
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne<Department>(d=>d.Department)
                .WithMany(e=>e.Employees)
                .HasForeignKey(d=>d.DepId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
