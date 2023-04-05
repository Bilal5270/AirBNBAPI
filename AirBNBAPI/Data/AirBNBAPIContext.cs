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
            new { FirstName = "Jaap ", LastName = "Keizer", Id = 2, Age = 61, AvatarId = 2 },
            new { FirstName = "Gert ", LastName = "Jan", Age = 23, Id = 3, AvatarId = 23 }
                );



            modelBuilder.Entity<Location>().HasData(
                new { Id = 1, Rooms = 3, Description = "Mooi huis gelegen in het centrum", Features = AirBnb.Model.Location.LocationFeatures.Smoking, SubTitle = "Huis word al jaren goed bevonden door 100+ klanten", NumberOfGuests = 3, Title = "BeeldhouwerKasteel", Type = AirBnb.Model.Location.LocationType.Appartment, PricePerDay = 50.99F, LandlordId = 1, ImageId = 3 },
                new { Id = 2, Rooms = 4, Description = "Prachtig kasteel van Nederland", Features = AirBnb.Model.Location.LocationFeatures.Smoking, SubTitle = "Prijzig, maar een echte ervaring.", NumberOfGuests = 20, Title = "Kasteel", Type = AirBnb.Model.Location.LocationType.House, PricePerDay = 500.99F, LandlordId = 2, ImageId = 4 },
                new { Id = 3, Rooms = 2, Description = "Een gezellig appartement dichtbij het strand", Features = AirBnb.Model.Location.LocationFeatures.Smoking, SubTitle = "Geniet van een ontspannen vakantie in ons mooie appartement", NumberOfGuests = 4, Title = "Strandhuisje", Type = AirBnb.Model.Location.LocationType.Appartment, PricePerDay = 70.50F, LandlordId = 1, ImageId = 5 },
                new { Id = 4, Rooms = 5, Description = "Een prachtige villa met uitzicht op het meer", Features = AirBnb.Model.Location.LocationFeatures.Wifi, SubTitle = "Ontspan en geniet van de natuur in deze geweldige villa", NumberOfGuests = 8, Title = "Lakeside Villa", Type = AirBnb.Model.Location.LocationType.House, PricePerDay = 320.99F, LandlordId = 2, ImageId = 6 },
                new { Id = 5, Rooms = 1, Description = "Een gezellige kamer in het centrum van de stad", Features = AirBnb.Model.Location.LocationFeatures.Smoking, SubTitle = "Een betaalbare optie voor een stedentrip", NumberOfGuests = 2, Title = "Centrumkamer", Type = AirBnb.Model.Location.LocationType.Room, PricePerDay = 25.99F, LandlordId = 3, ImageId = 7 },
                new { Id = 6, Rooms = 3, Description = "Een unieke boomhut in het bos", Features = AirBnb.Model.Location.LocationFeatures.Breakfast, SubTitle = "Een avontuurlijke vakantie in onze boomhut", NumberOfGuests = 4, Title = "Boomhut in het bos", Type = AirBnb.Model.Location.LocationType.Appartment, PricePerDay = 90.99F, LandlordId = 1, ImageId = 8 },
                new { Id = 7, Rooms = 2, Description = "Een modern appartement in het hart van de stad", Features = AirBnb.Model.Location.LocationFeatures.Smoking, SubTitle = "Een luxe verblijf in een bruisende omgeving", NumberOfGuests = 3, Title = "Stadsluxe", Type = AirBnb.Model.Location.LocationType.Appartment, PricePerDay = 85.50F, LandlordId = 2, ImageId = 9 },
                new { Id = 8, Rooms = 4, Description = "Een ruime woning met grote tuin en zwembad", Features = AirBnb.Model.Location.LocationFeatures.Bath | AirBnb.Model.Location.LocationFeatures.PetsAllowed, SubTitle = "Een ideale plek voor een gezinsvakantie", NumberOfGuests = 6, Title = "Gezinswoning met zwembad", Type = AirBnb.Model.Location.LocationType.House, PricePerDay = 280.99F, LandlordId = 3, ImageId = 10 },
                new { Id = 9, Rooms = 2, Description = "Een sfeervol appartement in het historische centrum", Features = AirBnb.Model.Location.LocationFeatures.Wifi, SubTitle = "Ontdek de geschiedenis van de stad vanuit ons gezellige appartement", NumberOfGuests = 4, Title = "Historisch appartement", Type = AirBnb.Model.Location.LocationType.Appartment, PricePerDay = 60.99F, LandlordId = 1, ImageId = 11 },
                new { Id = 10, Rooms = 6, Description = "Een prachtige villa aan de kust met privézwembad", Features = AirBnb.Model.Location.LocationFeatures.TV | AirBnb.Model.Location.LocationFeatures.PetsAllowed, SubTitle = "Een luxe verblijf met directe toegang tot het strand", NumberOfGuests = 10, Title = "Luxe kustvilla", Type = AirBnb.Model.Location.LocationType.House, PricePerDay = 800.99F, LandlordId = 2, ImageId = 12 }
                );


            modelBuilder.Entity<Image>().HasData(
           new { Id = 1, IsCover = false, Url = "https://dq1eylutsoz4u.cloudfront.net/2019/12/20060024/adult-man-baby-boomer-clean-cut_t20_b8wV6V-800x600-50-year-old-man.jpg" },
           new { Id = 2, IsCover = false, Url = "https://as1.ftcdn.net/v2/jpg/04/70/50/70/1000_F_470507000_FxGToXZnkwPgMYAc5KdX9SvtlYLjPhKf.jpg"},
           new { Id = 3, IsCover = true, Url = "https://www.chr-apartments.com/sites/default/files/styles/tile_image_cropped/public/video_thumbnails/Rwiy-8x8o5w.jpg?itok=X0MqiZeY", LocationId = 1 },
           new { Id = 4, IsCover = true, Url = "https://www.mapofjoy.nl/wp-content/uploads/2022/11/kasteel-de-haar-mapofjoy.jpg", LocationId = 2 },
           new { Id = 5, IsCover = true, Url = "https://cf.bstatic.com/images/hotel/max1024x768/209/209048312.jpg", LocationId = 3 },
           new { Id = 6, IsCover = true, Url = "https://static.wixstatic.com/media/5314a7_0bebda9bf9a64502a678d9d0a5299a16~mv2.jpg/v1/fill/w_640,h_476,al_c,q_80,usm_0.66_1.00_0.01,enc_auto/5314a7_0bebda9bf9a64502a678d9d0a5299a16~mv2.jpg", LocationId = 4 },
           new { Id = 7, IsCover = true, Url = "https://comfortable-room-in-centrum-hertogenbosch-s.booked.net/data/Photos/OriginalPhoto/7778/777848/777848626/Comfortable-Room-In-Centrum-Hertogenbosch-s-Hertogenbosch-Exterior.JPEG", LocationId = 5 },
           new { Id = 8, IsCover = true, Url = "https://vipio-production.s3.eu-central-1.amazonaws.com/variants/lqvol5wgqw9vnpkbu749hbw9w0fz/484f81c71345635b474672abe3162578b4a7d2c457f7211ce8381b69429182cb", LocationId = 6 },
           new { Id = 9, IsCover = true, Url = "https://www.aanhetij.com/wp-content/uploads/sites/4/2018/07/2801_overhoeks_Blok_A1_c2_01-1024x655.jpg?t=1676034752", LocationId = 7 },
           new { Id = 10, IsCover = true, Url = "https://www.lpw.be/blog/wp-content/uploads/2020/03/LPW-Pools_LaPlage-11_Pearl-Grey_-2-1-scaled.jpg", LocationId = 8 },
           new { Id = 11, IsCover = true, Url = "https://media.inmobalia.com/imgV1/B98Le8~d7M9k3DegigWkzHXQlgzMFGqGJJp6ZRUcpX033lqadFBp2i4GGW4X3JDm~11J_coE7XMgSyFWgioo4vCKf4wULfyiG_jT740CcoSCZWD4a5INBsSGgFKceH3cBeinqAa3gLH_su~4pk8M~Bodk6u55hMd85jPRuGVFtndsb_KIdGitYg6mYc0if9~aEx~TbbEG78TVl8fUHU6THfH24xtjnOrdR56IuAjbmoYpn1h0BpyhyWPYcXCSRbtlzDJUUV4OY8DykPts3bl4PDHxmJToMHm2kizr6AdxW1FPZ_h~lWcLwfkWcb_aNsRy9y3lOTmJwMP9rhI0WMhUtqJk3IWw0_u2Kw6uASDSUilpQFXEDLvGSsIv~o-.jpg", LocationId = 9 },
           new { Id = 12, IsCover = true, Url = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/301483769.jpg?k=5b851fb7a31f48b7ad4e06e0709a9ab552705ac58148dfeaeb0a28e304919c3c&o=&hp=1", LocationId = 10 },
           new { Id = 13, IsCover = false, Url = "https://www.cbw-erkend.nl/uploads/inspiration/klein-appartement-inrichten-tips-inspiratie.95e5ed.jpg", LocationId = 1 },
           new { Id = 14, IsCover = false, Url = "https://kastelenmagazine.nl/wp-content/uploads/2021/03/20-kastelen-die-je-gezien-moet-hebben.002.jpeg", LocationId = 2 },
           new { Id = 15, IsCover = false, Url = "https://www.visitzandvoort.nl/uploads/Strand-appartement-Zandvoort-1680x633.jpg", LocationId = 3 },
           new { Id = 16, IsCover = false, Url = "https://www.privatevillasofitaly.com/wp-content/uploads/Breakwater.Como_.jpg", LocationId = 4 },
           new { Id = 17, IsCover = false, Url = "https://images0.persgroep.net/rcs/Ow8bUxgkHiunjQxenWP6q51JzAw/diocontent/158813549/_fill/1349/900/?appId=21791a8992982cd8da851550a453bd7f&quality=0.9", LocationId = 5 },
           new { Id = 18, IsCover = false, Url = "https://boomhutdrenthe.nl/wp-content/uploads/2019/12/luxe-boomhut-aan-de-rand-van-landgoed-camping-tolhek-512x250.jpg", LocationId = 6 },
           new { Id = 19, IsCover = false, Url = "https://www.huis-inrichten.com/wp-content/uploads/modern-elegant-appartement-van-164m2.jpg", LocationId = 7 },
           new { Id = 20, IsCover = false, Url = "https://www.zwembad-plaatsen-tuin.be/wp-content/uploads/2021/11/Zwembad-plaatsen-in-de-tuin-tuin.webp", LocationId = 8 },
           new { Id = 21, IsCover = false, Url = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/408740280.jpg?k=c815e0a193ab61c6180f4430c46bad60a435fdeb28e03acfda1bd32333b0d9ff&o=&hp=1", LocationId = 9 },
           new { Id = 22, IsCover = false, Url = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/301483797.jpg?k=7d089acdca2fd57c7d767a167a3f78707d9a7b4dcee73218e86140293a45db88&o=&hp=1", LocationId = 10 },
           new { Id = 23, IsCover = false, Url = "https://www.cameo.com/cdn-cgi/image/fit=cover,format=auto,width=500,height=500/https://cdn.cameo.com/resizer/static/user/avatar-yZlgNegGG.jpg" }
                 );





            modelBuilder.Entity<Reservation>().HasData(
               new { Id = 1, StartDate = new DateTime(2022, 6, 1), EndDate = new DateTime(2022, 7, 1), CustomerId = 1, LocationId = 1, Discount = 0F },
               new { Id = 2, StartDate = new DateTime(2022, 6, 7), EndDate = new DateTime(2022, 7, 7), CustomerId = 2, LocationId = 2, Discount = 0F }

           );






        }
    }
}
