using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TradeApplication.Interfaces;
using TradeDomain.Entities;
using TradeInfrastructure.Data;

namespace TradeInfrastructure.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;
        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Cart cart, CancellationToken cancellationToken = default)
        {
            await _context.Carts.AddAsync(cart, cancellationToken);
        }

        public void Delete(Cart cart)
        {
            _context.Carts.Remove(cart);
        }

        public async Task<List<Cart>?> GetAll(CancellationToken cancellationToken = default)
        {
            return await _context.Carts.ToListAsync(cancellationToken);
        }

        public async Task<Cart?> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Carts.FirstAsync(c => c.Id == id, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Update(Cart cart)
        {
            _context.Carts.Update(cart);
        }
    }
}
