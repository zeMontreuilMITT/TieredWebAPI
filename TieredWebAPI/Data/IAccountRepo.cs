using TieredWebAPI.Models;

namespace TieredWebAPI.Data
{
    public interface IAccountRepo
    {
        public ICollection<BankAccount> GetBankAccounts();
        public ICollection<BankAccount> GetUserAccounts(int customerId);

        public void CreateBankAccount(BankAccount bankAccount);
    }

}
