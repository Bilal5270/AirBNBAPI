using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBNBAPI.Migrations
{
    public partial class changedseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "Id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "CustomerId", "Discount", "EndDate", "LocationId", "StartDate" },
                values: new object[] { 1, 1, 0f, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "CustomerId", "Discount", "EndDate", "LocationId", "StartDate" },
                values: new object[] { 2, 2, 0f, new DateTime(2022, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2022, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
