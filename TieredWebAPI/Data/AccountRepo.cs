using TieredWebAPI.Models;

namespace TieredWebAPI.Data
{

    public class AccountRepository: IAccountRepo
    {
        private TieredWebAPIContext _context;
        public int GetClientNumber()
        {
            return 1;
        }

        public AccountRepository(TieredWebAPIContext context)
        {
            _context = context;
        }

        public ICollection<BankAccount> GetBankAccounts()
        {
            return _context.BankAccount.ToList();
        }

        public ICollection<BankAccount> GetUserAccounts(int customerId)
        {
            return _context.BankAccount.Where(ba => ba.CustomerId == customerId).ToList();
        }

        public void CreateBankAccount(BankAccount bankAccount)
        {
            _context.BankAccount.Add(bankAccount);
            _context.SaveChanges();
        }
    }
}
