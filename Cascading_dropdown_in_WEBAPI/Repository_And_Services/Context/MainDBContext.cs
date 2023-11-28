using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_And_Services.Context
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions options): base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> Citys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(d => d.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(d => d.DepId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasOne(d=>d.Country)
                .WithMany(d=>d.Employees)
                .HasForeignKey(d=>d.CountryId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasOne(d=>d.State)
                .WithMany(d=>d.Employees)
                .HasForeignKey(d=>d.StateId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasOne(d => d.City)
                .WithMany(d => d.Employees)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<City>()
                .HasOne(d=>d.State)
                .WithMany(d=>d.City)
                .HasForeignKey(d=>d.StateId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<State>()
                .HasOne(d => d.Country)
                .WithMany(d => d.State)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
