using Microsoft.EntityFrameworkCore;
using TradeDomain.Entities;
using System.Net.Http.Headers;

namespace TradeInfrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set;  }
    }
}
