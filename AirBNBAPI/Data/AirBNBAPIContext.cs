using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AirBnb.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AirBNBAPI.Model;
using System.Security.Policy;

namespace AirBNBAPI.Data
{
    public class AirBNBAPIContext : DbContext
    {
        public AirBNBAPIContext(DbContextOptions<AirBNBAPIContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=AirBnbAPIDatabase;Integrated Security=SSPI;");
            base.OnConfiguring(optionsBuilder);

        }
        public DbSet<AirBnb.Model.Landlord> Landlord { get; set; } = default!;

        public DbSet<AirBnb.Model.Reservation> Reservation { get; set; }

        public DbSet<AirBnb.Model.Location> Location { get; set; }

        public DbSet<AirBnb.Model.Customer> Customer { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Image>().HasOne(i => i.Landlord).WithOne(l => l.Avatar).HasForeignKey<Landlord>(i => i.AvatarId);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
             new { FirstName = "Bilal", LastName = "Yousef", Email = "Bilal.youssry@gmail.com", Id = 1 },
             new { FirstName = "Max", LastName = "Metz", Email = "maxmetz8@gmail.com", Id = 2 }
                );


            modelBuilder.Entity<Landlord>().HasData(
            new { FirstName = "Herman ", LastName = "Mol", Age = 55, Id = 1, AvatarId = 1 },
            new { FirstName = "Jaap", LastName = "Keizer", Id = 2, Age = 61, AvatarId = 2 }

                );



            modelBuilder.Entity<Location>().HasData(
                new { Id = 1, Rooms = 3, Description = "Mooi huis gelegen in het centrum", Features = AirBnb.Model.Location.LocationFeatures.Smoking, SubTitle = "Huis word al jaren goed bevonden door 100+ klanten", NumberOfGuests = 3, Title = "BeeldhouwerKasteel", Type = AirBnb.Model.Location.LocationType.Appartment, PricePerDay = 50.99F, LandlordId = 1, ImageId = 3 },
                new { Id = 2, Rooms = 4, Description = "Prachtig kasteel van Nederland", Features = AirBnb.Model.Location.LocationFeatures.Smoking, SubTitle = "Prijzig, maar een echte ervaring.", NumberOfGuests = 20, Title = "Kasteel", Type = AirBnb.Model.Location.LocationType.House, PricePerDay = 500.99F, LandlordId = 2, ImageId = 4 }
                );


            modelBuilder.Entity<Image>().HasData(
           new { Id = 1, IsCover = false, Url = "https://dq1eylutsoz4u.cloudfront.net/2019/12/20060024/adult-man-baby-boomer-clean-cut_t20_b8wV6V-800x600-50-year-old-man.jpg", LocationId = 1 },
           new { Id = 2, IsCover = false, Url = "https://as1.ftcdn.net/v2/jpg/04/70/50/70/1000_F_470507000_FxGToXZnkwPgMYAc5KdX9SvtlYLjPhKf.jpg", LocationId = 2 },
           new { Id = 3, IsCover = true, Url = "https://www.chr-apartments.com/sites/default/files/styles/tile_image_cropped/public/video_thumbnails/Rwiy-8x8o5w.jpg?itok=X0MqiZeY", LocationId = 1 },
           new { Id = 4, IsCover = true, Url = "https://www.mapofjoy.nl/wp-content/uploads/2022/11/kasteel-de-haar-mapofjoy.jpg", LocationId = 2 }
                 );





           // modelBuilder.Entity<Reservation>().HasData(
           //    new { Id = 1, StartDate = new DateTime(2022, 6, 1), EndDate = new DateTime(2022, 7, 1), CustomerId = 1, LocationId = 1, Discount = 0F },
           //    new { Id = 2, StartDate = new DateTime(2022, 6, 7), EndDate = new DateTime(2022, 7, 7), CustomerId = 2, LocationId = 2, Discount = 0F }

           //);






        }
    }
}
