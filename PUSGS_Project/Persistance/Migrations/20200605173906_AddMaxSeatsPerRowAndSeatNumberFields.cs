using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class AddMaxSeatsPerRowAndSeatNumberFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SeatNumber",
                table: "FlightSeats",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "MaxSeatsPerRow",
                table: "Flight",
                nullable: false,
                defaultValue: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatNumber",
                table: "FlightSeats");

            migrationBuilder.DropColumn(
                name: "MaxSeatsPerRow",
                table: "Flight");
        }
    }
}
