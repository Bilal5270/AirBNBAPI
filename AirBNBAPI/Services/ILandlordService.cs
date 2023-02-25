using AirBnb.Model;

namespace AirBNBAPI.Services
{
    public interface ILandlordService
    {
        public IEnumerable<Landlord> GetAllLandlords();
        public Landlord GetSpecificLandlord(int id);

        public Landlord ChangeLandlord(int id, Landlord landlord);
    }
}
