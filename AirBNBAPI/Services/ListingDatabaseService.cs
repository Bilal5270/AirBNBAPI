using AirBnb.Model;
using AirBNBAPI.Data;
using AirBNBAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AirBNBAPI.Services
{
    public class ListingDatabaseService : IListingService
    {
        private readonly IAirBnBRepository _airBnBRepository;
        public ListingDatabaseService(IAirBnBRepository airBnBRepository)
        {
            _airBnBRepository = airBnBRepository;
        }

        

        public Listing ChangeListing(int id, Listing listing)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Listing> GetAllListings()
        {
            return _airBnBRepository.GetAllListings();
            
        }
        
        public Listing GetSpecificListing(int id)
        {
            return _airBnBRepository.GetListing(id);
        }

        
    }
}
