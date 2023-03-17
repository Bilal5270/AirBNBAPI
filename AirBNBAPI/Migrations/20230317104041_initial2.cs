using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBNBAPI.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Landlord_Image_AvatarId",
                table: "Landlord");

            migrationBuilder.DropIndex(
                name: "IX_Landlord_AvatarId",
                table: "Landlord");

            migrationBuilder.AlterColumn<int>(
                name: "AvatarId",
                table: "Landlord",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Landlord_AvatarId",
                table: "Landlord",
                column: "AvatarId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Landlord_Image_AvatarId",
                table: "Landlord",
                column: "AvatarId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Landlord_Image_AvatarId",
                table: "Landlord");

            migrationBuilder.DropIndex(
                name: "IX_Landlord_AvatarId",
                table: "Landlord");

            migrationBuilder.AlterColumn<int>(
                name: "AvatarId",
                table: "Landlord",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Landlord_AvatarId",
                table: "Landlord",
                column: "AvatarId",
                unique: true,
                filter: "[AvatarId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Landlord_Image_AvatarId",
                table: "Landlord",
                column: "AvatarId",
                principalTable: "Image",
                principalColumn: "Id");
        }
    }
}
