using Microsoft.EntityFrameworkCore;

namespace PersonModel.Models
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions options): base(options) { }   

        public DbSet<Person> Persons { get; set;}
    }
}
