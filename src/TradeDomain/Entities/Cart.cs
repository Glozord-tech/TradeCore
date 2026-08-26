using System;
using System.Collections.Generic;
using System.Text;

namespace TradeDomain.Entities
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User user { get; set; }
        public decimal Price {  get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
