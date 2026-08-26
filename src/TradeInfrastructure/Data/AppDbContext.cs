using Microsoft.EntityFrameworkCore;
using TradeDomain.Entities;
using System.Net.Http.Headers;

namespace TradeInfrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set;  }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        protected override void OnModelCreating(
    ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(x => x.Cart)
                .WithOne(x => x.user)
                .HasForeignKey<Cart>(x => x.UserId);


            modelBuilder.Entity<CartItem>()
                .HasOne(x => x.Cart)
                .WithMany(x => x.CartItems)
                .HasForeignKey(x => x.CartId);


            modelBuilder.Entity<CartItem>()
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductItems)
                .HasForeignKey(x => x.ProdId);
        }
    }
}
