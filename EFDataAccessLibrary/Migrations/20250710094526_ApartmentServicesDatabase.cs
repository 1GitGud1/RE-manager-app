using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ApartmentServicesDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentService_Apartments2_ApartmentNumber",
                table: "ApartmentService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentService",
                table: "ApartmentService");

            migrationBuilder.RenameTable(
                name: "ApartmentService",
                newName: "ApartmentServices2");

            migrationBuilder.RenameIndex(
                name: "IX_ApartmentService_ApartmentNumber",
                table: "ApartmentServices2",
                newName: "IX_ApartmentServices2_ApartmentNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentServices2",
                table: "ApartmentServices2",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentServices2_Apartments2_ApartmentNumber",
                table: "ApartmentServices2",
                column: "ApartmentNumber",
                principalTable: "Apartments2",
                principalColumn: "ApartmentNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentServices2_Apartments2_ApartmentNumber",
                table: "ApartmentServices2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentServices2",
                table: "ApartmentServices2");

            migrationBuilder.RenameTable(
                name: "ApartmentServices2",
                newName: "ApartmentService");

            migrationBuilder.RenameIndex(
                name: "IX_ApartmentServices2_ApartmentNumber",
                table: "ApartmentService",
                newName: "IX_ApartmentService_ApartmentNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentService",
                table: "ApartmentService",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentService_Apartments2_ApartmentNumber",
                table: "ApartmentService",
                column: "ApartmentNumber",
                principalTable: "Apartments2",
                principalColumn: "ApartmentNumber");
        }
    }
}
