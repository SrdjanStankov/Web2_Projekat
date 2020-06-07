using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class RemoveExtraFieldFromFlightTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketOwnerId",
                table: "FlightTicket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TicketOwnerId",
                table: "FlightTicket",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
