using System;
using System.Collections.Generic;
using System.Text;
using TradeDomain.Entities;

namespace TradeApplication.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetProductByIdAsync(Guid id, CancellationToken token = default);
        Task<List<Product?>> GetAllProduct(CancellationToken token=default);
        Task AddAsync(
        Product product,
        CancellationToken cancellationToken = default);

        void Update(Product product);

        void Delete(Product product);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
