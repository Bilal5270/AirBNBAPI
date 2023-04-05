using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBNBAPI.Migrations
{
    public partial class addedmoreseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "IsCover", "LocationId", "Url" },
                values: new object[,]
                {
                    { 13, false, 1, "https://www.cbw-erkend.nl/uploads/inspiration/klein-appartement-inrichten-tips-inspiratie.95e5ed.jpg" },
                    { 14, false, 2, "https://kastelenmagazine.nl/wp-content/uploads/2021/03/20-kastelen-die-je-gezien-moet-hebben.002.jpeg" },
                    { 23, false, null, "https://www.cameo.com/cdn-cgi/image/fit=cover,format=auto,width=500,height=500/https://cdn.cameo.com/resizer/static/user/avatar-yZlgNegGG.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Description", "Features", "LandlordId", "NumberOfGuests", "PricePerDay", "Rooms", "SubTitle", "Title", "Type" },
                values: new object[,]
                {
                    { 3, "Een gezellig appartement dichtbij het strand", 1, 1, 4, 70.5f, 2, "Geniet van een ontspannen vakantie in ons mooie appartement", "Strandhuisje", 0 },
                    { 4, "Een prachtige villa met uitzicht op het meer", 4, 2, 8, 320.99f, 5, "Ontspan en geniet van de natuur in deze geweldige villa", "Lakeside Villa", 5 },
                    { 6, "Een unieke boomhut in het bos", 32, 1, 4, 90.99f, 3, "Een avontuurlijke vakantie in onze boomhut", "Boomhut in het bos", 0 },
                    { 7, "Een modern appartement in het hart van de stad", 1, 2, 3, 85.5f, 2, "Een luxe verblijf in een bruisende omgeving", "Stadsluxe", 0 },
                    { 9, "Een sfeervol appartement in het historische centrum", 4, 1, 4, 60.99f, 2, "Ontdek de geschiedenis van de stad vanuit ons gezellige appartement", "Historisch appartement", 0 },
                    { 10, "Een prachtige villa aan de kust met privézwembad", 10, 2, 10, 800.99f, 6, "Een luxe verblijf met directe toegang tot het strand", "Luxe kustvilla", 5 }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "IsCover", "LocationId", "Url" },
                values: new object[,]
                {
                    { 5, true, 3, "https://cf.bstatic.com/images/hotel/max1024x768/209/209048312.jpg" },
                    { 6, true, 4, "https://static.wixstatic.com/media/5314a7_0bebda9bf9a64502a678d9d0a5299a16~mv2.jpg/v1/fill/w_640,h_476,al_c,q_80,usm_0.66_1.00_0.01,enc_auto/5314a7_0bebda9bf9a64502a678d9d0a5299a16~mv2.jpg" },
                    { 8, true, 6, "https://vipio-production.s3.eu-central-1.amazonaws.com/variants/lqvol5wgqw9vnpkbu749hbw9w0fz/484f81c71345635b474672abe3162578b4a7d2c457f7211ce8381b69429182cb" },
                    { 9, true, 7, "https://www.aanhetij.com/wp-content/uploads/sites/4/2018/07/2801_overhoeks_Blok_A1_c2_01-1024x655.jpg?t=1676034752" },
                    { 11, true, 9, "https://media.inmobalia.com/imgV1/B98Le8~d7M9k3DegigWkzHXQlgzMFGqGJJp6ZRUcpX033lqadFBp2i4GGW4X3JDm~11J_coE7XMgSyFWgioo4vCKf4wULfyiG_jT740CcoSCZWD4a5INBsSGgFKceH3cBeinqAa3gLH_su~4pk8M~Bodk6u55hMd85jPRuGVFtndsb_KIdGitYg6mYc0if9~aEx~TbbEG78TVl8fUHU6THfH24xtjnOrdR56IuAjbmoYpn1h0BpyhyWPYcXCSRbtlzDJUUV4OY8DykPts3bl4PDHxmJToMHm2kizr6AdxW1FPZ_h~lWcLwfkWcb_aNsRy9y3lOTmJwMP9rhI0WMhUtqJk3IWw0_u2Kw6uASDSUilpQFXEDLvGSsIv~o-.jpg" },
                    { 12, true, 10, "https://cf.bstatic.com/xdata/images/hotel/max1024x768/301483769.jpg?k=5b851fb7a31f48b7ad4e06e0709a9ab552705ac58148dfeaeb0a28e304919c3c&o=&hp=1" },
                    { 15, false, 3, "https://www.visitzandvoort.nl/uploads/Strand-appartement-Zandvoort-1680x633.jpg" },
                    { 16, false, 4, "https://www.privatevillasofitaly.com/wp-content/uploads/Breakwater.Como_.jpg" },
                    { 18, false, 6, "https://boomhutdrenthe.nl/wp-content/uploads/2019/12/luxe-boomhut-aan-de-rand-van-landgoed-camping-tolhek-512x250.jpg" },
                    { 19, false, 7, "https://www.huis-inrichten.com/wp-content/uploads/modern-elegant-appartement-van-164m2.jpg" },
                    { 21, false, 9, "https://cf.bstatic.com/xdata/images/hotel/max1024x768/408740280.jpg?k=c815e0a193ab61c6180f4430c46bad60a435fdeb28e03acfda1bd32333b0d9ff&o=&hp=1" },
                    { 22, false, 10, "https://cf.bstatic.com/xdata/images/hotel/max1024x768/301483797.jpg?k=7d089acdca2fd57c7d767a167a3f78707d9a7b4dcee73218e86140293a45db88&o=&hp=1" }
                });

            migrationBuilder.InsertData(
                table: "Landlord",
                columns: new[] { "Id", "Age", "AvatarId", "FirstName", "LastName" },
                values: new object[] { 3, 23, 23, "Gert ", "Jan" });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Description", "Features", "LandlordId", "NumberOfGuests", "PricePerDay", "Rooms", "SubTitle", "Title", "Type" },
                values: new object[] { 5, "Een gezellige kamer in het centrum van de stad", 1, 3, 2, 25.99f, 1, "Een betaalbare optie voor een stedentrip", "Centrumkamer", 3 });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Description", "Features", "LandlordId", "NumberOfGuests", "PricePerDay", "Rooms", "SubTitle", "Title", "Type" },
                values: new object[] { 8, "Een ruime woning met grote tuin en zwembad", 18, 3, 6, 280.99f, 4, "Een ideale plek voor een gezinsvakantie", "Gezinswoning met zwembad", 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "IsCover", "LocationId", "Url" },
                values: new object[,]
                {
                    { 7, true, 5, "https://comfortable-room-in-centrum-hertogenbosch-s.booked.net/data/Photos/OriginalPhoto/7778/777848/777848626/Comfortable-Room-In-Centrum-Hertogenbosch-s-Hertogenbosch-Exterior.JPEG" },
                    { 10, true, 8, "https://www.lpw.be/blog/wp-content/uploads/2020/03/LPW-Pools_LaPlage-11_Pearl-Grey_-2-1-scaled.jpg" },
                    { 17, false, 5, "https://images0.persgroep.net/rcs/Ow8bUxgkHiunjQxenWP6q51JzAw/diocontent/158813549/_fill/1349/900/?appId=21791a8992982cd8da851550a453bd7f&quality=0.9" },
                    { 20, false, 8, "https://www.zwembad-plaatsen-tuin.be/wp-content/uploads/2021/11/Zwembad-plaatsen-in-de-tuin-tuin.webp" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Landlord",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 23);
        }
    }
}
