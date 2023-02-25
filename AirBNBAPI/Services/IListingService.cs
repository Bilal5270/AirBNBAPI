using AirBnb.Model;

namespace AirBNBAPI.Services
{
    public interface IListingService
    {
        public IEnumerable<Listing> GetAllListings();
        public Listing GetSpecificListing(int id);

        public Listing ChangeListing(int id, Listing listing);
    }
}
