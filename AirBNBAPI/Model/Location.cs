using AirBNBAPI.Model;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBnb.Model
{
    public class Location
    {
        public int Id { get; set; }

        public List<Image> Images { get; set; }
        public int Rooms { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Landlord Landlord { get; set; }
        public int LandlordId { get; set; }
        public List<Reservation> Reservations { get; set; }
        public string SubTitle { get; set; }
        public float PricePerDay { get; set; }
        public int NumberOfGuests { get; set; }
     
        public LocationType Type { get; set; }
        public Features Feature { get; set; }
        public Location()
        {
            Images = new List<Image>();
            Reservations = new List<Reservation>();

        }

        [Flags]
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
    }
}
