using Domain.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LoginUserMapper());
            base.OnModelCreating(modelBuilder);
        }
    }
}
