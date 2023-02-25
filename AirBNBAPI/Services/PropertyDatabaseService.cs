using AirBnb.Model;
using AirBNBAPI.Data;
using AirBNBAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirBNBAPI.Services
{
    public class PropertyDatabaseService : IPropertyService
    {
        private readonly IAirBnBRepository _airBnBRepository;
        public PropertyDatabaseService(IAirBnBRepository airBnBRepository)
        {
            _airBnBRepository = airBnBRepository;
        }

        public Property ChangeProperty(int id, Property Property)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Property> GetAllProperties()
        {
            return _airBnBRepository.GetAllProperties();
            
        }

        public Property GetSpecificProperty(int id)
        {
            return _airBnBRepository.GetProperty(id);
        }

        
    }
}
