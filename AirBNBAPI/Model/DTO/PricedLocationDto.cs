﻿using AirBnb.Model;
using static AirBnb.Model.Location;

namespace AirBNBAPI.Model.DTO
{
    public class PricedLocationDto
    {
        public int Id { get; set; }
        public string SubTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string LandlordAvatarURL { get; set; }

        public float Price { get; set; }
        public LocationType Type { get; set; }


      
    }
}