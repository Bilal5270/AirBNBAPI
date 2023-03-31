using AirBnb.Model;
using static AirBnb.Model.Location;

namespace AirBNBAPI.Model.DTO
{
    public class SearchDto
    {
       public LocationFeatures? Features { get; set; }
        
       public LocationType? Type { get; set; }

       public int? Rooms { get; set; }
        
       public int? MinPrice { get; set; }
       public int? MaxPrice { get; set; }


    }
}