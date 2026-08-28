using System;
using System.Collections.Generic;
using System.Text;
using TradeDomain.Entities;

namespace TradeApplication.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetById(Guid id, CancellationToken token = default);
        Task<List<User>?> GetAll(CancellationToken token = default);
        Task Create(User user, CancellationToken token = default);
        void Update(User user);
        void Delete(User user);
        Task AddChangesAsync(CancellationToken token = default);
    }
}
