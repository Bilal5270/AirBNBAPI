using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBNBAPI.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Image_LocationId",
                table: "Image",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Location_LocationId",
                table: "Image",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Location_LocationId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_LocationId",
                table: "Image");
        }
    }
}
