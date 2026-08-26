using System;
using System.Collections.Generic;
using System.Text;

namespace TradeDomain.Entities
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Cart Cart { get; set; } = null!;
        public Guid ProdId { get; set; }
        public Product Product { get; set; } = null!;
        public int Quantity {  get; set; }
    }
}
