using TieredWebAPI.Models;

namespace TieredWebAPI.Data
{
    public interface ICustomerRepo
    {
        ICollection<Customer> GetCustomers();
        Customer GetCustomer(int id);
        void CreateCustomer(Customer customer);
    }
}
