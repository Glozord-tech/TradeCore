using Microsoft.AspNetCore.Mvc;
using TradeApplication.Services;
using TradeDomain.Entities;
using TradeApplication.DTOs;
using TradeApplication.Interfaces;

namespace TradeCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductInterface _services;
        public ProductController(IProductInterface services)
        {
            _services = services;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id, CancellationToken token)
        {
            var product = await _services.GetProductById(id, token);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct(CancellationToken token)
        {
            var products = await _services.GetAllProduct(token);
            if(products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO dto,CancellationToken token)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock
            };
            Product prod = await _services.CreateProduct(product,token);
            return CreatedAtAction(nameof(GetProductById),new { id = product.Id },product);
        } 
    }
}
