using System;
using System.Collections.Generic;
using System.Text;
using TradeApplication.Interfaces;
using TradeDomain.Entities;

namespace TradeApplication.Services
{
    public class ProductServices : IProductInterface
    {
        private readonly IProductRepository _repository;
        public ProductServices(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Product?> GetProductById(Guid id,CancellationToken token)
        {
            return await _repository.GetProductByIdAsync(id, token);
        }
        public async Task<List<Product?>> GetAllProduct(CancellationToken token)
        {
            return await _repository.GetAllProduct(token);
        }
        public async Task<Product> CreateProduct(Product product,CancellationToken token)
        {
            if (product.Price < 0)
            {
                throw new ArgumentException("Price<0");
            }
            if (product.Stock < 0)
            {
                throw new ArgumentException("Stock<0");
            }
            await _repository.AddAsync(product, token);
            await _repository.SaveChangesAsync(token);
            return product;
        } 
        public async Task<Product?> UpdateAsync(Guid id,Product product,CancellationToken token)
        {
            var existsprod =await _repository.GetProductByIdAsync(id, token);
            if(existsprod == null)
            {
                return null;
            }
            existsprod.Name = product.Name;
            existsprod.Price = product.Price;
            existsprod.Stock = product.Stock;

            await _repository.SaveChangesAsync(token);
            return existsprod;
        }
        public async Task<bool> DeleteProduct(Guid id,CancellationToken token)
        {
            var product = await _repository.GetProductByIdAsync(id, token);
            if(product == null) {  return false; }
            _repository.Delete(product);
            await _repository.SaveChangesAsync(token);
            return true;
        }
    }
}
