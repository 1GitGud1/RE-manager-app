using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ApartmentServicesForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentServices2_Apartments2_ApartmentNumber",
                table: "ApartmentServices2");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentServices2_ApartmentNumber",
                table: "ApartmentServices2");

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentNumber",
                table: "ApartmentServices2",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApartmentNumber1",
                table: "ApartmentServices2",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentServices2_ApartmentNumber1",
                table: "ApartmentServices2",
                column: "ApartmentNumber1");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentServices2_Apartments2_ApartmentNumber1",
                table: "ApartmentServices2",
                column: "ApartmentNumber1",
                principalTable: "Apartments2",
                principalColumn: "ApartmentNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentServices2_Apartments2_ApartmentNumber1",
                table: "ApartmentServices2");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentServices2_ApartmentNumber1",
                table: "ApartmentServices2");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber1",
                table: "ApartmentServices2");

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentNumber",
                table: "ApartmentServices2",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentServices2_ApartmentNumber",
                table: "ApartmentServices2",
                column: "ApartmentNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentServices2_Apartments2_ApartmentNumber",
                table: "ApartmentServices2",
                column: "ApartmentNumber",
                principalTable: "Apartments2",
                principalColumn: "ApartmentNumber");
        }
    }
}
