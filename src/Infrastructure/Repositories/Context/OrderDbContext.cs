using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Context
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<Item> Item { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServerConString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureOrderModelBinding(modelBuilder);
            ConfigureItemModelBinding(modelBuilder);
        }

        private void ConfigureOrderModelBinding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
            .HasKey(o => o.OrderId);

            modelBuilder.Entity<Order>()
                .Property(o => o.Address)
                .HasMaxLength(150)
            .IsRequired();

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(o => o.ItemId);
        }
        private void ConfigureItemModelBinding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
            .HasKey(i => i.ItemId);

            modelBuilder.Entity<Item>()
                .Property(i => i.ProductName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
