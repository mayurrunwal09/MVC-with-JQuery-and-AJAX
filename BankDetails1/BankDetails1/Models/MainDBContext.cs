using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankDetails1.Models
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Transaction> Transaction { get; set; }
    }
}
