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


        List<Property> Properties { get; set; }
        List<Listing> Listings  { get; set; }

        public Landlord() {
            Properties = new List<Property>();
            Listings = new List<Listing>();
        }
    }
}
