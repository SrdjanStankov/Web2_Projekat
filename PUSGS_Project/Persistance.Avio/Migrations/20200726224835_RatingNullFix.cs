using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Avio.Migrations
{
    public partial class RatingNullFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_AviationCompanies_AviationCompanyId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Flights_FlightId",
                table: "Rating");

            migrationBuilder.AlterColumn<long>(
                name: "RentACarId",
                table: "Rating",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "FlightId",
                table: "Rating",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CarId",
                table: "Rating",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AviationCompanyId",
                table: "Rating",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_AviationCompanies_AviationCompanyId",
                table: "Rating",
                column: "AviationCompanyId",
                principalTable: "AviationCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Flights_FlightId",
                table: "Rating",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_AviationCompanies_AviationCompanyId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Flights_FlightId",
                table: "Rating");

            migrationBuilder.AlterColumn<long>(
                name: "RentACarId",
                table: "Rating",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FlightId",
                table: "Rating",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CarId",
                table: "Rating",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AviationCompanyId",
                table: "Rating",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_AviationCompanies_AviationCompanyId",
                table: "Rating",
                column: "AviationCompanyId",
                principalTable: "AviationCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Flights_FlightId",
                table: "Rating",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
