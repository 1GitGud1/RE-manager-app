using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddedApartmentsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartments2",
                columns: table => new
                {
                    ApartmentNumber = table.Column<int>(type: "int", nullable: false),
                    TenantName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContractStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    ContractEndDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments2", x => x.ApartmentNumber);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartments2");
        }
    }
}
