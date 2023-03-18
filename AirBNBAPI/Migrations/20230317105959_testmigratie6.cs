using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBNBAPI.Migrations
{
    public partial class testmigratie6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Landlord",
                keyColumn: "Id",
                keyValue: 1,
                column: "AvatarId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Landlord",
                keyColumn: "Id",
                keyValue: 2,
                column: "AvatarId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Landlord",
                keyColumn: "Id",
                keyValue: 1,
                column: "AvatarId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Landlord",
                keyColumn: "Id",
                keyValue: 2,
                column: "AvatarId",
                value: null);
        }
    }
}
