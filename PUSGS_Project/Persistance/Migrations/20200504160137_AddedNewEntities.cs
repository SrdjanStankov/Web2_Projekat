using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class AddedNewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentACar",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentACar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AviationCompany",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AddressId = table.Column<long>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AviationCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AviationCompany_Location_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PassengerNumber = table.Column<int>(nullable: false),
                    ReservedFrom = table.Column<DateTime>(nullable: true),
                    ReservedTo = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    CostPerDay = table.Column<double>(nullable: false),
                    RentACarId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_RentACar_RentACarId",
                        column: x => x.RentACarId,
                        principalTable: "RentACar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AviationCompanyId = table.Column<long>(nullable: true),
                    DepartureTime = table.Column<DateTime>(nullable: true),
                    ArrivalTime = table.Column<DateTime>(nullable: true),
                    TravelLength = table.Column<double>(nullable: false),
                    TicketPrice = table.Column<double>(nullable: false),
                    NumberOfChangeovers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_AviationCompany_AviationCompanyId",
                        column: x => x.AviationCompanyId,
                        principalTable: "AviationCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightTicket",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketOwnerEmail = table.Column<string>(nullable: true),
                    FlightId = table.Column<long>(nullable: true),
                    Discount = table.Column<double>(nullable: false),
                    AirplaneSeat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightTicket_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightTicket_User_TicketOwnerEmail",
                        column: x => x.TicketOwnerEmail,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AviationCompany_AddressId",
                table: "AviationCompany",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_RentACarId",
                table: "Car",
                column: "RentACarId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AviationCompanyId",
                table: "Flight",
                column: "AviationCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightTicket_FlightId",
                table: "FlightTicket",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightTicket_TicketOwnerEmail",
                table: "FlightTicket",
                column: "TicketOwnerEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "FlightTicket");

            migrationBuilder.DropTable(
                name: "RentACar");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "AviationCompany");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
