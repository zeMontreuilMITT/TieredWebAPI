using TieredWebAPI.Models;

namespace TieredWebAPI.Data
{
    public class CustomerRepo: ICustomerRepo
    {
        private TieredWebAPIContext _context;

        public CustomerRepo(TieredWebAPIContext context)
        {
            _context = context;
        }

        // basic CRUD
        public ICollection<Customer> GetCustomers()
        {
            return _context.Customer.ToList();
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customer.Find(id);
        }

        public void CreateCustomer(Customer customer)
        {
            // finds and deletes customer with same id
            Delete();
            _context.Add(customer);
            _context.SaveChanges();
        }
            
        private void Delete()
        {
            return;
        }
    }
}
