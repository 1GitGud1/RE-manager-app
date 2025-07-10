using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ApartmentServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartmentService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ServiceDate = table.Column<DateTime>(type: "date", nullable: false),
                    ApartmentNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentService_Apartments2_ApartmentNumber",
                        column: x => x.ApartmentNumber,
                        principalTable: "Apartments2",
                        principalColumn: "ApartmentNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentService_ApartmentNumber",
                table: "ApartmentService",
                column: "ApartmentNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentService");
        }
    }
}
