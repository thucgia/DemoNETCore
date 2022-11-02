using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> tblUsers { get; set; }
        public DbSet<Category> tblCategories { get; set; }
        public DbSet<Product> tblProducts { get; set; }
        public DbSet<Supplier> tblSuppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(p => p.Products);

            builder.Entity<ProductSupplier>()
                .HasKey(p => new { p.ProductId, p.SupplierId });

            builder.Entity<ProductSupplier>()
                .HasOne<Supplier>(s => s.Supplier)
                .WithMany(p => p.ProductSuppliers)
                .HasForeignKey(ps => ps.SupplierId);

            builder.Entity<ProductSupplier>()
                .HasOne<Product>(p => p.Product)
                .WithMany(s => s.ProductSuppliers)
                .HasForeignKey(ps => ps.ProductId);
        }
    }
}
