using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class EditedApartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Deposit",
                table: "Apartments2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApartmentNumber1",
                table: "ApartmentCheques2",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentCheques2_ApartmentNumber1",
                table: "ApartmentCheques2",
                column: "ApartmentNumber1");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentCheques2_Apartments2_ApartmentNumber1",
                table: "ApartmentCheques2",
                column: "ApartmentNumber1",
                principalTable: "Apartments2",
                principalColumn: "ApartmentNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentCheques2_Apartments2_ApartmentNumber1",
                table: "ApartmentCheques2");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentCheques2_ApartmentNumber1",
                table: "ApartmentCheques2");

            migrationBuilder.DropColumn(
                name: "Deposit",
                table: "Apartments2");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber1",
                table: "ApartmentCheques2");
        }
    }
}
