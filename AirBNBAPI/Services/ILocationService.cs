using AirBnb.Model;

namespace AirBNBAPI.Services
{
    public interface ILocationService
    {
        public IEnumerable<Location> GetAllLocations();
        public Location GetSpecificLocation(int id);

        public Location ChangeLocation(int id, Location location);
    }
}
