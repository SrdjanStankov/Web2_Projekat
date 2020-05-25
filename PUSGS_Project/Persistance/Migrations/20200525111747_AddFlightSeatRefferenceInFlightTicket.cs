using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class AddFlightSeatRefferenceInFlightTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightSeats_FlightTicket_ReservedById",
                table: "FlightSeats");

            migrationBuilder.DropIndex(
                name: "IX_FlightSeats_ReservedById",
                table: "FlightSeats");

            migrationBuilder.DropColumn(
                name: "AirplaneSeat",
                table: "FlightTicket");

            migrationBuilder.DropColumn(
                name: "ReservedById",
                table: "FlightSeats");

            migrationBuilder.AddColumn<long>(
                name: "FlightSeatId",
                table: "FlightTicket",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TicketOwnerId",
                table: "FlightTicket",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_FlightTicket_FlightSeatId",
                table: "FlightTicket",
                column: "FlightSeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightTicket_FlightSeats_FlightSeatId",
                table: "FlightTicket",
                column: "FlightSeatId",
                principalTable: "FlightSeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightTicket_FlightSeats_FlightSeatId",
                table: "FlightTicket");

            migrationBuilder.DropIndex(
                name: "IX_FlightTicket_FlightSeatId",
                table: "FlightTicket");

            migrationBuilder.DropColumn(
                name: "FlightSeatId",
                table: "FlightTicket");

            migrationBuilder.DropColumn(
                name: "TicketOwnerId",
                table: "FlightTicket");

            migrationBuilder.AddColumn<int>(
                name: "AirplaneSeat",
                table: "FlightTicket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "ReservedById",
                table: "FlightSeats",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightSeats_ReservedById",
                table: "FlightSeats",
                column: "ReservedById");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightSeats_FlightTicket_ReservedById",
                table: "FlightSeats",
                column: "ReservedById",
                principalTable: "FlightTicket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
