using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.Model
{
    public class Listing
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public Property Property { get; set; }
       
    }
}
