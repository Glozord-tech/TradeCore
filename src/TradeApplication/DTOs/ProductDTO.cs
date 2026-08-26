using System;
using System.Collections.Generic;
using System.Text;

namespace TradeApplication.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock {  get; set; }
    }
}
