using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TradeApplication.Interfaces;
using TradeDomain.Entities;
using TradeInfrastructure.Data;

namespace TradeInfrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddChangesAsync(CancellationToken token = default)
        {
            await _appDbContext.SaveChangesAsync(token);
        }

        public async Task Create(User user, CancellationToken token = default)
        {
            await _appDbContext.AddAsync(user, token);
        }

        public void Delete(User user)
        {
            _appDbContext.Users.Remove(user);
        }

        public async Task<List<User>?> GetAll(CancellationToken token = default)
        {
            return await _appDbContext.Users.ToListAsync(token);
        }

        public async Task<User?> GetById(Guid id,CancellationToken token = default)
        {
            return await _appDbContext.Users.FirstAsync(x=> x.Id == id,token); //Добавить исключение на null
        }

        public void Update(User user)
        {
            _appDbContext.Users.Update(user);
        }
    }
}
