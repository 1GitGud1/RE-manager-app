using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class MinorAdjustments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deposit",
                table: "Contracts2");

            migrationBuilder.AddColumn<bool>(
                name: "Ejari",
                table: "Apartments2",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "ApartmentCheques2",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ejari",
                table: "Apartments2");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ApartmentCheques2");

            migrationBuilder.AddColumn<int>(
                name: "Deposit",
                table: "Contracts2",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);
        }
    }
}
