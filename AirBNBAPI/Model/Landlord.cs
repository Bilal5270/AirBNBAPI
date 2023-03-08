using AirBNBAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.Model
{
    public class Landlord
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Image? Avatar { get; set; }
        public int? AvatarId { get; set; }

        List<Location> Locations { get; set; }

        public Landlord()
        {
            Locations = new List<Location>();
   
        }
    }
}
