using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.RentACar.Migrations
{
    public partial class RatingNullFix : Migration
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
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "FlightId",
                table: "Ratings",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CarId",
                table: "Ratings",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AviationCompanyId",
                table: "Ratings",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FlightId",
                table: "Ratings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CarId",
                table: "Ratings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AviationCompanyId",
                table: "Ratings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
