namespace TieredWebAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual HashSet<BankAccount> Accounts { get; set; } = new HashSet<BankAccount>();
    }
}
