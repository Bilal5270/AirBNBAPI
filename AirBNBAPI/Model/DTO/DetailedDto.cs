using AirBnb.Model;
using static AirBnb.Model.Location;

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
        public virtual List<ImageDto> Images { get; set; }
        public virtual LandlordDto Landlord { get; set; }

        public DetailedDto()
        {
            Images = new List<ImageDto>();

        }


   


    }
}