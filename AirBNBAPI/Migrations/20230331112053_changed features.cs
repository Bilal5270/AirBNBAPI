using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBNBAPI.Migrations
{
    public partial class changedfeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Feature",
                table: "Location",
                newName: "Features");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "https://dq1eylutsoz4u.cloudfront.net/2019/12/20060024/adult-man-baby-boomer-clean-cut_t20_b8wV6V-800x600-50-year-old-man.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "https://www.chr-apartments.com/sites/default/files/styles/tile_image_cropped/public/video_thumbnails/Rwiy-8x8o5w.jpg?itok=X0MqiZeY");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 4,
                column: "Url",
                value: "https://www.mapofjoy.nl/wp-content/uploads/2022/11/kasteel-de-haar-mapofjoy.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Features",
                table: "Location",
                newName: "Feature");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 1,
                column: "Url",
                value: "https://thumbs.dreamstime.com/b/outdoor-portrait-year-old-man-wearing-brown-pullover-eyeglasses-outdoor-portrait-year-old-man-146976531.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "https://media.istockphoto.com/id/1165384568/nl/foto/europa-modern-complex-van-residenti%C3%ABle-gebouwen.jpg?s=612x612&w=is&k=20&c=KayrzIyyBnvebnLbpUlW9xJTHfqSMt8k-pOId4BMWO8=");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 4,
                column: "Url",
                value: "https://kastelenmagazine.nl/wp-content/uploads/2021/03/Kasteel-Helmond-e1646478334654-1120x705.jpg");
        }
    }
}
