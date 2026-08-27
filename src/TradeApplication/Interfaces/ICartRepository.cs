using System;
using System.Collections.Generic;
using System.Text;
using TradeDomain.Entities;

namespace TradeApplication.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart?> GetById(Guid id,CancellationToken cancellationToken=default);
        Task<List<Cart>?> GetAll(CancellationToken cancellationToken = default);
        Task Add(Cart cart, CancellationToken cancellationToken=default);
        void Update(Cart cart);
        void Delete(Cart cart);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
