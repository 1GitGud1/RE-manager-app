using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SQLiteIni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartments2",
                columns: table => new
                {
                    BuildingNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ApartmentNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    TenantName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ContractStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    ContractEndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Ejari = table.Column<bool>(type: "INTEGER", nullable: false),
                    Deposit = table.Column<int>(type: "INTEGER", maxLength: 50, nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments2", x => new { x.BuildingNumber, x.ApartmentNumber });
                });

            migrationBuilder.CreateTable(
                name: "Contracts2",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BuildingNumber = table.Column<int>(type: "INTEGER", maxLength: 50, nullable: false),
                    Company = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts2", x => x.ContractId);
                });

            migrationBuilder.CreateTable(
                name: "PPMs2",
                columns: table => new
                {
                    PPMId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BuildingNumber = table.Column<int>(type: "INTEGER", maxLength: 50, nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PPMs2", x => x.PPMId);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentCheques2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<int>(type: "INTEGER", maxLength: 50, nullable: false),
                    DueDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsCashed = table.Column<bool>(type: "INTEGER", nullable: false),
                    ApartmentNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    BuildingNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ApartmentBuildingNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    ApartmentNumber1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentCheques2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentCheques2_Apartments2_ApartmentBuildingNumber_ApartmentNumber1",
                        columns: x => new { x.ApartmentBuildingNumber, x.ApartmentNumber1 },
                        principalTable: "Apartments2",
                        principalColumns: new[] { "BuildingNumber", "ApartmentNumber" });
                });

            migrationBuilder.CreateTable(
                name: "ApartmentPPMs2",
                columns: table => new
                {
                    BuildingNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ApartmentNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Q1Date = table.Column<DateTime>(type: "date", nullable: false),
                    Q1Time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Q1Done = table.Column<bool>(type: "INTEGER", nullable: false),
                    Q2Date = table.Column<DateTime>(type: "date", nullable: false),
                    Q2Time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Q2Done = table.Column<bool>(type: "INTEGER", nullable: false),
                    Q3Date = table.Column<DateTime>(type: "date", nullable: false),
                    Q3Time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Q3Done = table.Column<bool>(type: "INTEGER", nullable: false),
                    Q4Date = table.Column<DateTime>(type: "date", nullable: false),
                    Q4Time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Q4Done = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentPPMs2", x => new { x.BuildingNumber, x.ApartmentNumber });
                    table.ForeignKey(
                        name: "FK_ApartmentPPMs2_Apartments2_BuildingNumber_ApartmentNumber",
                        columns: x => new { x.BuildingNumber, x.ApartmentNumber },
                        principalTable: "Apartments2",
                        principalColumns: new[] { "BuildingNumber", "ApartmentNumber" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentServices2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ServiceDate = table.Column<DateTime>(type: "date", nullable: false),
                    Time = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Done = table.Column<bool>(type: "INTEGER", nullable: false),
                    ApartmentNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    BuildingNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ApartmentBuildingNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    ApartmentNumber1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentServices2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentServices2_Apartments2_ApartmentBuildingNumber_ApartmentNumber1",
                        columns: x => new { x.ApartmentBuildingNumber, x.ApartmentNumber1 },
                        principalTable: "Apartments2",
                        principalColumns: new[] { "BuildingNumber", "ApartmentNumber" });
                });

            migrationBuilder.CreateTable(
                name: "ContractDues2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<int>(type: "INTEGER", maxLength: 50, nullable: false),
                    DueDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsPaid = table.Column<bool>(type: "INTEGER", nullable: false),
                    ContractId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractDues2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractDues2_Contracts2_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts2",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PPMtimes2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsDone = table.Column<bool>(type: "INTEGER", nullable: false),
                    PPMId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PPMtimes2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PPMtimes2_PPMs2_PPMId",
                        column: x => x.PPMId,
                        principalTable: "PPMs2",
                        principalColumn: "PPMId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentCheques2_ApartmentBuildingNumber_ApartmentNumber1",
                table: "ApartmentCheques2",
                columns: new[] { "ApartmentBuildingNumber", "ApartmentNumber1" });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentServices2_ApartmentBuildingNumber_ApartmentNumber1",
                table: "ApartmentServices2",
                columns: new[] { "ApartmentBuildingNumber", "ApartmentNumber1" });

            migrationBuilder.CreateIndex(
                name: "IX_ContractDues2_ContractId",
                table: "ContractDues2",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_PPMtimes2_PPMId",
                table: "PPMtimes2",
                column: "PPMId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentCheques2");

            migrationBuilder.DropTable(
                name: "ApartmentPPMs2");

            migrationBuilder.DropTable(
                name: "ApartmentServices2");

            migrationBuilder.DropTable(
                name: "ContractDues2");

            migrationBuilder.DropTable(
                name: "PPMtimes2");

            migrationBuilder.DropTable(
                name: "Apartments2");

            migrationBuilder.DropTable(
                name: "Contracts2");

            migrationBuilder.DropTable(
                name: "PPMs2");
        }
    }
}
