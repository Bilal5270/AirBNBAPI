using AirBnb.Model;

namespace AirBNBAPI.Model.DTO
{
    public class SearchDto
    {
       public Features? Feature { get; set; }
        
       public LocationType? Type { get; set; }

       public int? Room { get; set; }
        
       public int? MinPrice { get; set; }
       public int? MaxPrice { get; set; }

        public enum Features
        {
            Smoking = 1,
            PetsAllowed = 2,
            Wifi = 4,
            TV = 8,
            Bath = 16,
            Breakfast = 32
        }

        public enum LocationType
        {
            Appartment,
            Cottage,
            Chalet,
            Room,
            Hotel,
            House
        }
    }
}