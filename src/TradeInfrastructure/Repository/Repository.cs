using Microsoft.EntityFrameworkCore;
using TradeApplication.Interfaces;
using TradeDomain.Entities;
using TradeInfrastructure.Data;

namespace TradeInfrastructure.Repository
{
    public class Repository : IProductRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetProductByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _context.Products
                .FirstOrDefaultAsync(
                    x => x.Id == id,
                    cancellationToken);
        }

        public async Task<List<Product>> GetAllProduct(
            CancellationToken cancellationToken = default)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }

        public async Task AddAsync(
            Product product,
            CancellationToken cancellationToken = default)
        {
            await _context.Products.AddAsync(
                product,
                cancellationToken);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }
    }
}
