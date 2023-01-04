using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DYDN_Company.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Set Idenity for primary key
            modelBuilder.Entity<AccountUser>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<AccountAdmin>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<BillDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Factory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<WareHouse>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            // Set Unique Constraint
            modelBuilder.Entity<AccountUser>().HasIndex(account => account.Email).IsUnique();
            modelBuilder.Entity<AccountUser>().HasIndex(account => account.Code).IsUnique();
            modelBuilder.Entity<AccountAdmin>().HasIndex(account => account.Email).IsUnique();
            modelBuilder.Entity<AccountAdmin>().HasIndex(account => account.Code).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(product => product.Name).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(product => product.Code).IsUnique();
            modelBuilder.Entity<CategoryProduct>().HasIndex(category => category.Name).IsUnique();
            modelBuilder.Entity<CategoryProduct>().HasIndex(category => category.Code).IsUnique();
            modelBuilder.Entity<Department>().HasIndex(dep => dep.Name).IsUnique();
            modelBuilder.Entity<Department>().HasIndex(dep => dep.Code).IsUnique();
            modelBuilder.Entity<WareHouse>().HasIndex(warehouse => warehouse.Code).IsUnique();
            modelBuilder.Entity<WareHouse>().HasIndex(warehouse => warehouse.Name).IsUnique();
            modelBuilder.Entity<Factory>().HasIndex(factory => factory.Name).IsUnique();
            modelBuilder.Entity<Factory>().HasIndex(factory => factory.Code).IsUnique();
            modelBuilder.Entity<Order>().HasIndex(order => order.Name).IsUnique();
            modelBuilder.Entity<AccountAdmin>()
           .HasOne(b => b.Departments)
           .WithMany(b => b.AccountAdmins)
            .HasForeignKey(p => p.DepartmentId);
        }

        public DbSet<AccountUser> AccountUsers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<AccountAdmin> AccountAdmins { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }
        public DbSet<Banner> Banners { get; set; }
    }
}