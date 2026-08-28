using TradeApplication.Interfaces;
using TradeDomain.Entities;
namespace TradeApplication.Services
{
    public class UserServices : IUserService
    {
        private IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> CreateUser(User user, CancellationToken token = default)
        {
            await _userRepository.Create(user, token);
            await _userRepository.AddChangesAsync(token);
            return user;
        }

        public async Task<bool> DeleteUser(Guid id, CancellationToken token = default)
        {
            var user = await _userRepository.GetById(id,token);
            if(user == null)
            {
                return false;
            }
            _userRepository.Delete(user);
            await _userRepository.AddChangesAsync(token);
            return true;
        }

        public async Task<List<User>?> GetAllUser(CancellationToken token = default)
        {
            return await _userRepository.GetAll(token);
        }

        public async Task<User?> GetUserById(Guid id, CancellationToken token = default)
        {
            return await _userRepository.GetById(id, token);
        }

        public async Task<User?> UpdateUser(Guid id, User user, CancellationToken token = default)
        {
            var userup = await _userRepository.GetById(id, token);
            if( userup == null)
            {
                return null;
            }
            userup.Name = user.Name;
            userup.Balance = user.Balance;
            _userRepository.Update(userup);
            await _userRepository.AddChangesAsync(token);
            return userup;
        }
    }
}
