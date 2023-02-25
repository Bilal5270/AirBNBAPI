using AirBnb.Model;

namespace AirBNBAPI.Services
{
    public interface IPropertyService
    {
        public IEnumerable<Property> GetAllProperties();
        public Property GetSpecificProperty(int id);

        public Property ChangeProperty(int id, Property property);
    }
}
