using AirBnb.Model;
using AirBNBAPI.Data;
using AirBNBAPI.Repositories;

namespace AirBNBAPI.Services
{
    public class CustomerDatabaseService : ICustomerService
    {
        private readonly IAirBnBRepository _airBnBRepository;
        public CustomerDatabaseService(IAirBnBRepository airBnBRepository)
        {
            _airBnBRepository = airBnBRepository;
        }

        public Customer ChangeCustomer(int id, Customer customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _airBnBRepository.GetAllCustomers();

        }

        public Customer GetSpecificCustomer(int id)
        {
            return _airBnBRepository.GetCustomer(id);
        }

         
    }
}
