using AirBnb.Model;

namespace AirBNBAPI.Model.DTO
{
    public class LocationDto
    {
        public string SubTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string LandlordAvatarURL { get; set; }


        //public LocationDto()
        //{
        //    LandlordAvatarURL = location.Landlord.Avatar.Url;
        //    ImageUrl = location.Images.FirstOrDefault().Url;
        //}


    }
}