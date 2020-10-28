using Microsoft.EntityFrameworkCore;
using Holtz_ProductCatalog.Models;
using Holtz_ProductCatalog.Data.Maps;

namespace Holtz_ProductCatalog.Data
{
    public class Context : DbContext {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Password=123456;Persist Security Info=True;User ID=sa;Initial Catalog=Holtz_ProductCatalog;Data Source=HENRIQUE-NOT\\SQL2014");
        }
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
        }
    }
}