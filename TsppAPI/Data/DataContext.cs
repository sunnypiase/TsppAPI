using Microsoft.EntityFrameworkCore;
using TsppAPI.Models;

namespace TsppAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<SoldProduct> SoldProducts { get; set; }
        public DbSet<StorageProduct> StorageProducts { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
