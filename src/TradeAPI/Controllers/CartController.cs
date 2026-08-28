using Microsoft.AspNetCore.Mvc;
using TradeApplication.DTOs;
using TradeApplication.Interfaces;
using TradeDomain.Entities;

namespace TradeCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartById(Guid id,CancellationToken token)
        {
            var cart = await _cartService.GetCartById(id, token);
            if(cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCart(CancellationToken token)
        {
            var cart = await _cartService.GetAllCart(token);
            return Ok(cart);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCart(CartDTO dto, CancellationToken token)
        {
            var cart = new Cart()
            {
                Id = Guid.NewGuid(),
                Price = dto.Price
            };
            await _cartService.CreateCart(cart, token);
            return Ok(cart);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(Guid id, CartDTO dto, CancellationToken token)
        {
            var cart = new Cart()
            {
                Id=id,
                Price = dto.Price
            };
            var update = await _cartService.UpdateCart(id, cart, token);
            if(update == null) {  return NotFound(); }
            return Ok(update);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(Guid id, CancellationToken token)
        {
            var deleted = await _cartService.DeleteCart(id, token);
            if(deleted == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
