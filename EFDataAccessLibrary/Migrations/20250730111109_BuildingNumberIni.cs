using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class BuildingNumberIni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentCheques2_Apartments2_ApartmentNumber1",
                table: "ApartmentCheques2");

            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentPPMs2_Apartments2_ApartmentNumber",
                table: "ApartmentPPMs2");

            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentServices2_Apartments2_ApartmentNumber1",
                table: "ApartmentServices2");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentServices2_ApartmentNumber1",
                table: "ApartmentServices2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apartments2",
                table: "Apartments2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentPPMs2",
                table: "ApartmentPPMs2");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentCheques2_ApartmentNumber1",
                table: "ApartmentCheques2");

            migrationBuilder.AddColumn<int>(
                name: "ApartmentBuildingNumber",
                table: "ApartmentServices2",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuildingNumber",
                table: "ApartmentServices2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BuildingNumber",
                table: "Apartments2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BuildingNumber",
                table: "ApartmentPPMs2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApartmentBuildingNumber",
                table: "ApartmentCheques2",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuildingNumber",
                table: "ApartmentCheques2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apartments2",
                table: "Apartments2",
                columns: new[] { "BuildingNumber", "ApartmentNumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentPPMs2",
                table: "ApartmentPPMs2",
                columns: new[] { "BuildingNumber", "ApartmentNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentServices2_ApartmentBuildingNumber_ApartmentNumber1",
                table: "ApartmentServices2",
                columns: new[] { "ApartmentBuildingNumber", "ApartmentNumber1" });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentCheques2_ApartmentBuildingNumber_ApartmentNumber1",
                table: "ApartmentCheques2",
                columns: new[] { "ApartmentBuildingNumber", "ApartmentNumber1" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentCheques2_Apartments2_ApartmentBuildingNumber_ApartmentNumber1",
                table: "ApartmentCheques2",
                columns: new[] { "ApartmentBuildingNumber", "ApartmentNumber1" },
                principalTable: "Apartments2",
                principalColumns: new[] { "BuildingNumber", "ApartmentNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentPPMs2_Apartments2_BuildingNumber_ApartmentNumber",
                table: "ApartmentPPMs2",
                columns: new[] { "BuildingNumber", "ApartmentNumber" },
                principalTable: "Apartments2",
                principalColumns: new[] { "BuildingNumber", "ApartmentNumber" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentServices2_Apartments2_ApartmentBuildingNumber_ApartmentNumber1",
                table: "ApartmentServices2",
                columns: new[] { "ApartmentBuildingNumber", "ApartmentNumber1" },
                principalTable: "Apartments2",
                principalColumns: new[] { "BuildingNumber", "ApartmentNumber" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentCheques2_Apartments2_ApartmentBuildingNumber_ApartmentNumber1",
                table: "ApartmentCheques2");

            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentPPMs2_Apartments2_BuildingNumber_ApartmentNumber",
                table: "ApartmentPPMs2");

            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentServices2_Apartments2_ApartmentBuildingNumber_ApartmentNumber1",
                table: "ApartmentServices2");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentServices2_ApartmentBuildingNumber_ApartmentNumber1",
                table: "ApartmentServices2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apartments2",
                table: "Apartments2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentPPMs2",
                table: "ApartmentPPMs2");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentCheques2_ApartmentBuildingNumber_ApartmentNumber1",
                table: "ApartmentCheques2");

            migrationBuilder.DropColumn(
                name: "ApartmentBuildingNumber",
                table: "ApartmentServices2");

            migrationBuilder.DropColumn(
                name: "BuildingNumber",
                table: "ApartmentServices2");

            migrationBuilder.DropColumn(
                name: "BuildingNumber",
                table: "Apartments2");

            migrationBuilder.DropColumn(
                name: "BuildingNumber",
                table: "ApartmentPPMs2");

            migrationBuilder.DropColumn(
                name: "ApartmentBuildingNumber",
                table: "ApartmentCheques2");

            migrationBuilder.DropColumn(
                name: "BuildingNumber",
                table: "ApartmentCheques2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apartments2",
                table: "Apartments2",
                column: "ApartmentNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentPPMs2",
                table: "ApartmentPPMs2",
                column: "ApartmentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentServices2_ApartmentNumber1",
                table: "ApartmentServices2",
                column: "ApartmentNumber1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentPPMs2_Apartments2_ApartmentNumber",
                table: "ApartmentPPMs2",
                column: "ApartmentNumber",
                principalTable: "Apartments2",
                principalColumn: "ApartmentNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentServices2_Apartments2_ApartmentNumber1",
                table: "ApartmentServices2",
                column: "ApartmentNumber1",
                principalTable: "Apartments2",
                principalColumn: "ApartmentNumber");
        }
    }
}
