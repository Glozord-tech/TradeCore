namespace TradeDomain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance {  get; set; }
        public string Password {  get; set; }
        public Cart Cart { get; set; }
    }
}
