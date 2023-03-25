using AirBnb.Model;
using static AirBnb.Model.Location;

namespace AirBNBAPI.Model.DTO
{
    public class SearchDto
    {
       public Features? Feature { get; set; }
        
       public LocationType? Type { get; set; }

       public int? Room { get; set; }
        
       public int? MinPrice { get; set; }
       public int? MaxPrice { get; set; }


    }
}