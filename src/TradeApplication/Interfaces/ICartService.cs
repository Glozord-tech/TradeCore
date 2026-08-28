using System;
using System.Collections.Generic;
using System.Text;
using TradeDomain.Entities;

namespace TradeApplication.Interfaces
{
    public interface ICartService
    {
        Task<Cart?> GetCartById(Guid id, CancellationToken token);
        Task<List<Cart>?> GetAllCart(CancellationToken token);
        Task<Cart?> CreateCart(Cart cart, CancellationToken token);
        Task<Cart?> UpdateCart(Guid id, Cart cart, CancellationToken token);
        Task<bool> DeleteCart(Guid id, CancellationToken token);
    }
}
