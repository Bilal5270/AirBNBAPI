using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public virtual List<Reservation > Reservations { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Customer()
        {
            Reservations = new List<Reservation>();
        }
    }
}
