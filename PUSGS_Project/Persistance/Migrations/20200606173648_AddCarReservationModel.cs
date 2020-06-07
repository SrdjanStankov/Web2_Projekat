using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class AddCarReservationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservedFrom",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "ReservedTo",
                table: "Car");

            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "Car",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CarReservations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<DateTime>(nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    Discount = table.Column<double>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    ReservedCarId = table.Column<long>(nullable: false),
                    OwnerEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarReservations_User_OwnerEmail",
                        column: x => x.OwnerEmail,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarReservations_Car_ReservedCarId",
                        column: x => x.ReservedCarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarReservations_OwnerEmail",
                table: "CarReservations",
                column: "OwnerEmail");

            migrationBuilder.CreateIndex(
                name: "IX_CarReservations_ReservedCarId",
                table: "CarReservations",
                column: "ReservedCarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarReservations");

            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "Car");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservedFrom",
                table: "Car",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservedTo",
                table: "Car",
                type: "datetime2",
                nullable: true);
        }
    }
}
