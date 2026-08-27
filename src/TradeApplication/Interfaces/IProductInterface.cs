using System;
using System.Collections.Generic;
using System.Text;
using TradeDomain.Entities;

namespace TradeApplication.Interfaces
{
    public interface IProductInterface
    {
        Task<Product?> GetProductById(Guid id, CancellationToken token=default);
        Task<List<Product?>> GetAllProduct(CancellationToken token=default);
        Task<Product?> CreateProduct(Product product,CancellationToken token = default);
        Task<Product?> UpdateAsync(Guid id, Product product,CancellationToken token=default);
        Task<bool> DeleteProduct(Guid id, CancellationToken token=default);

    }
}
