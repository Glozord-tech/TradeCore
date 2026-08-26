using TradeDomain.Entities;
namespace TradeApplication.Services
{
    public class UserServices
    {
        private User _user;
        public UserServices(User user)
        {
            _user = user;
        }
        public void UpdateBalance(decimal balance)
        {
            _user.Balance = balance;
        }
        public void AddToCart()
        {

        }
    }
}
