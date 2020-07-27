using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.RentACar.Migrations
{
    public partial class RatingsFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Cars_CarId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_RentACars_RentACarId",
                table: "Ratings");

            migrationBuilder.AlterColumn<long>(
                name: "RentACarId",
                table: "Ratings",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CarId",
                table: "Ratings",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AviationCompanyId",
                table: "Ratings",
                nullable: true,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "FlightId",
                table: "Ratings",
                nullable: true,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Cars_CarId",
                table: "Ratings",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_RentACars_RentACarId",
                table: "Ratings",
                column: "RentACarId",
                principalTable: "RentACars",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Cars_CarId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_RentACars_RentACarId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "AviationCompanyId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Ratings");

            migrationBuilder.AlterColumn<long>(
                name: "RentACarId",
                table: "Ratings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "CarId",
                table: "Ratings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Cars_CarId",
                table: "Ratings",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_RentACars_RentACarId",
                table: "Ratings",
                column: "RentACarId",
                principalTable: "RentACars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
