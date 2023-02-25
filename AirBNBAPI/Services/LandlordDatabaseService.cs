using AirBnb.Model;
using AirBNBAPI.Data;
using AirBNBAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirBNBAPI.Services
{
    public class LandlordDatabaseService : ILandlordService
    {
        private readonly IAirBnBRepository _airBnBRepository;
        public LandlordDatabaseService(IAirBnBRepository airBnBRepository)
        {
            _airBnBRepository = airBnBRepository;
        }

        public Landlord ChangeLandlord(int id, Landlord landlord)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Landlord> GetAllLandlords()
        {
            return _airBnBRepository.GetAllLandlords();
            
        }

        public Landlord GetSpecificLandlord(int id)
        {
            return _airBnBRepository.GetLandlord(id);
        }

        
    }
}
