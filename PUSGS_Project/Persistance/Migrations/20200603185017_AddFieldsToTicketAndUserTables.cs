using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class AddFieldsToTicketAndUserTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RequirePasswordChange",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "FlightTicket",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "FlightTicket",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequirePasswordChange",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "FlightTicket");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "FlightTicket");
        }
    }
}
