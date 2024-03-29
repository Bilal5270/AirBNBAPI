﻿using AirBnb.Model;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Location = AirBnb.Model.Location;

namespace AirBnb.Model
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public  Landlord? Landlord { get; set; }
        public Location? Location { get; set; }
        public bool IsCover { get; set; }
        
    }
}
