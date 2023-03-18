using AirBnb.Model;

namespace AirBNBAPI.Model.DTO
{
    public class PricedLocationDto
    {
        public int Id { get; set; }
        public string SubTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string LandlordAvatarURL { get; set; }

        public float Price { get; set; }
        public LocationType Type { get; set; }


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