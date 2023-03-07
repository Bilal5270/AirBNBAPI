using AirBnb.Model;

namespace AirBNBAPI.Services
{
    public interface ICustomerService
    {
        public IEnumerable<Customer> GetAllCustomers();
        public Customer GetSpecificCustomer(int id);

        public Customer ChangeCustomer(int id, Customer customer);
    }
}
