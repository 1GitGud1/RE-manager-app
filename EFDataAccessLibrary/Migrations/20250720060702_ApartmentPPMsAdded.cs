using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ApartmentPPMsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartmentPPMs2",
                columns: table => new
                {
                    ApartmentNumber = table.Column<int>(type: "int", nullable: false),
                    Q1Date = table.Column<DateTime>(type: "date", nullable: false),
                    Q1Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Q1Done = table.Column<bool>(type: "bit", nullable: false),
                    Q2Date = table.Column<DateTime>(type: "date", nullable: false),
                    Q2Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Q2Done = table.Column<bool>(type: "bit", nullable: false),
                    Q3Date = table.Column<DateTime>(type: "date", nullable: false),
                    Q3Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Q3Done = table.Column<bool>(type: "bit", nullable: false),
                    Q4Date = table.Column<DateTime>(type: "date", nullable: false),
                    Q4Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Q4Done = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentPPMs2", x => x.ApartmentNumber);
                    table.ForeignKey(
                        name: "FK_ApartmentPPMs2_Apartments2_ApartmentNumber",
                        column: x => x.ApartmentNumber,
                        principalTable: "Apartments2",
                        principalColumn: "ApartmentNumber",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentPPMs2");
        }
    }
}
