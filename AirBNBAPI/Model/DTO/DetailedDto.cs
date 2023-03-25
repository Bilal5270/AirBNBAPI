using AirBnb.Model;

namespace AirBNBAPI.Model.DTO
{
    public class DetailedDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public int Rooms { get; set; }

        public int NumberOfGuests { get; set; }

        public float PricePerDay { get; set; }

        public LocationType Type { get; set; }
        public Features Feature { get; set; }
        public virtual List<Image> Images { get; set; }
        public virtual Landlord Landlord { get; set; }

        public DetailedDto()
        {
            Images = new List<Image>();

        }


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


        //public LocationDto()
        //{
        //    LandlordAvatarURL = location.Landlord.Avatar.Url;
        //    ImageUrl = location.Images.FirstOrDefault().Url;
        //}


    }
}