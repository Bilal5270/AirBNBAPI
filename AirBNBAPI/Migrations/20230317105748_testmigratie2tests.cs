using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBNBAPI.Migrations
{
    public partial class testmigratie2tests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Bilal.youssry@gmail.com", "Bilal", "Yousef" },
                    { 2, "maxmetz8@gmail.com", "Max", "Metz" }
                });

            migrationBuilder.InsertData(
                table: "Landlord",
                columns: new[] { "Id", "Age", "AvatarId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 55, null, "Herman ", "Mol" },
                    { 2, 61, null, "Jaap", "Keizer" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Description", "Feature", "LandlordId", "NumberOfGuests", "PricePerDay", "Rooms", "SubTitle", "Title", "Type" },
                values: new object[] { 1, "Mooi huis gelegen in het centrum", 1, 1, 3, 50.99f, 3, "Huis word al jaren goed bevonden door 100+ klanten", "BeeldhouwerKasteel", 0 });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Description", "Feature", "LandlordId", "NumberOfGuests", "PricePerDay", "Rooms", "SubTitle", "Title", "Type" },
                values: new object[] { 2, "Prachtig kasteel van Nederland", 1, 2, 20, 500.99f, 4, "Prijzig, maar een echte ervaring.", "Kasteel", 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "IsCover", "LocationId", "Url" },
                values: new object[,]
                {
                    { 1, false, 1, "https://thumbs.dreamstime.com/b/outdoor-portrait-year-old-man-wearing-brown-pullover-eyeglasses-outdoor-portrait-year-old-man-146976531.jpg" },
                    { 2, false, 2, "https://as1.ftcdn.net/v2/jpg/04/70/50/70/1000_F_470507000_FxGToXZnkwPgMYAc5KdX9SvtlYLjPhKf.jpg" },
                    { 3, true, 1, "https://media.istockphoto.com/id/1165384568/nl/foto/europa-modern-complex-van-residenti%C3%ABle-gebouwen.jpg?s=612x612&w=is&k=20&c=KayrzIyyBnvebnLbpUlW9xJTHfqSMt8k-pOId4BMWO8=" },
                    { 4, true, 2, "https://kastelenmagazine.nl/wp-content/uploads/2021/03/Kasteel-Helmond-e1646478334654-1120x705.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Landlord",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Landlord",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
