using Microsoft.AspNetCore.Mvc;
using TradeApplication.DTOs;
using TradeApplication.Interfaces;
using TradeApplication.Services;
using TradeDomain.Entities;

namespace TradeCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id, CancellationToken token)
        {
            var user = await _userService.GetUserById(id, token);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser(CancellationToken token)
        {
            var user = await _userService.GetAllUser(token);
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDTO dto, CancellationToken token)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Balance = dto.Balance,
                Name = dto.Name
            };
            await _userService.CreateUser(user, token);
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(Guid id, UserDTO dto, CancellationToken token)
        {
            var user = new User()
            {
                Id = id,
                Balance = dto.Balance,
                Name = dto.Name
            };
            var update = await _userService.UpdateUser(id, user, token);
            if (update == null) { return NotFound(); }
            return Ok(update);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(Guid id, CancellationToken token)
        {
            var deleted = await _userService.DeleteUser(id, token);
            if (deleted == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
