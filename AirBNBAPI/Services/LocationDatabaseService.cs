using AirBnb.Model;
using AirBNBAPI.Data;
using AirBNBAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirBNBAPI.Services
{
    public class LocationDatabaseService : ILocationService
    {
        private readonly IAirBnBRepository _airBnBRepository;
        public LocationDatabaseService(IAirBnBRepository airBnBRepository)
        {
            _airBnBRepository = airBnBRepository;
        }

        public Location ChangeLocation(int id, Location location)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _airBnBRepository.GetAllLocations();
            
        }

        public Location GetSpecificLocation(int id)
        {
            return _airBnBRepository.GetLocation(id);
        }

        
    }
}
