using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.Model
{
    public class Property
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int HouseNumber { get; set; }
        public bool IsAvailable { get; set; }
        public Landlord Landlord { get; set; }
    }
}
