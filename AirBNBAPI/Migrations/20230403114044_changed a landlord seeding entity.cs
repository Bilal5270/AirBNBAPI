using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBNBAPI.Migrations
{
    public partial class changedalandlordseedingentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Landlord",
                keyColumn: "Id",
                keyValue: 2,
                column: "FirstName",
                value: "Jaap ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Landlord",
                keyColumn: "Id",
                keyValue: 2,
                column: "FirstName",
                value: "Jaap");
        }
    }
}
