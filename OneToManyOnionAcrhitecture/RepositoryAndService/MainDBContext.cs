using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndService
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions options) : base(options) { }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Catagory> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemImages> ItemImages { get; set; }
        public DbSet<CustomerItem> CustomerItems { get; set; }
        public DbSet<SupplierItem> SupplierItems { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne<UserType>(s => s.UserType)
                .WithMany(s => s.Users)
                .HasForeignKey(e => e.UserTypeId)
                .IsRequired();

            modelBuilder.Entity<SupplierItem>()
                .HasOne(s=>s.User)
                .WithMany(s=>s.Suppliers)
                .HasForeignKey(s=>s.UserId)
                .IsRequired();

            modelBuilder.Entity<CustomerItem>()
                .HasOne(s=>s.User)
                .WithMany(s=>s.CustomerItems)
                .HasForeignKey(s=>s.UserId)
                .IsRequired();


            modelBuilder.Entity<SupplierItem>()
                 .HasOne(b => b.Item)
                 .WithOne(b => b.SupplierItem)
                 .HasForeignKey<SupplierItem>(s => s.ItemId)
                 .IsRequired();

            modelBuilder.Entity<CustomerItem>()
                .HasOne(b => b.Item)
                .WithOne(b => b.CustomerItem)
                .HasForeignKey<CustomerItem>(s => s.ItemId)
                .IsRequired();

            modelBuilder.Entity<ItemImages>()
                    .HasOne(b => b.Item)
                    .WithMany(b => b.ItemImages)
                    .HasForeignKey(s => s.ItemId)
                    .IsRequired();

            modelBuilder.Entity<Catagory>()
                    .HasMany(b => b.Items)
                    .WithOne(b => b.Catagory)
                    .HasForeignKey(s => s.CatagoryId)
                    .IsRequired();





        }
    }
}
