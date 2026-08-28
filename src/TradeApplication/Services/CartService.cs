using System;
using System.Collections.Generic;
using System.Text;
using TradeApplication.Interfaces;
using TradeDomain.Entities;

namespace TradeApplication.Services
{
    public class CartService : ICartService
    {
        private ICartRepository _repository;
        public CartService(ICartRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cart?> CreateCart(Cart cart, CancellationToken token)
        {
            if(cart.Price < 0)
            {
                throw new ArgumentException("Price<0");
            }
            await _repository.Add(cart,token);
            await _repository.SaveChangesAsync(token);
            return cart;
        }

        public async Task<bool> DeleteCart(Guid id, CancellationToken token)
        {
            var cart = await _repository.GetById(id,token);
            if(cart == null)
            {
                return false;
            }
            _repository.Delete(cart);
            await _repository.SaveChangesAsync(token);
            return true;
        }

        public async Task<List<Cart>?> GetAllCart(CancellationToken token)
        {
            var products = await _repository.GetAll(token);
            return products;
        }

        public async Task<Cart?> GetCartById(Guid id, CancellationToken token)
        {
            return await _repository.GetById(id, token);
        }

        public async Task<Cart?> UpdateCart(Guid id, Cart cart, CancellationToken token)
        {
            var cartt = await _repository.GetById(id, token);
            if(cartt == null)
            {
                return null;
            }
            cartt.Price = cart.Price;
            await _repository.SaveChangesAsync(token);
            return cartt;
        }
    }
}
