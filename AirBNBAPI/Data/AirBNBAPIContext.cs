using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AirBnb.Model;

namespace AirBNBAPI.Data
{
    public class AirBNBAPIContext : DbContext
    {
        public AirBNBAPIContext (DbContextOptions<AirBNBAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AirBnb.Model.Landlord> Landlord { get; set; } = default!;

        public DbSet<AirBnb.Model.Reservation> Reservation { get; set; }

        public DbSet<AirBnb.Model.Location> Location{ get; set; }

        public DbSet<AirBnb.Model.Customer> Customer { get; set; }
    }
}
