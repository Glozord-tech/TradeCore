using System;
using System.Collections.Generic;
using System.Text;
using TradeDomain.Entities;

namespace TradeApplication.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserById(Guid id, CancellationToken token = default);
        Task<List<User>?> GetAllUser(CancellationToken token = default);
        Task<User?> CreateUser(User user, CancellationToken token = default);
        Task<User?> UpdateUser(Guid id, User user, CancellationToken token = default);
        Task<bool> DeleteUser(Guid id, CancellationToken token = default);
    }
}
