using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Avio.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false),
                    CityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AviationCompanies",
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
                    table.PrimaryKey("PK_AviationCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AviationCompanies_Locations_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AviationCompanyId = table.Column<long>(nullable: false),
                    DepartureTime = table.Column<DateTime>(nullable: true),
                    ArrivalTime = table.Column<DateTime>(nullable: true),
                    FromId = table.Column<long>(nullable: true),
                    ToId = table.Column<long>(nullable: true),
                    MaxSeatsPerRow = table.Column<int>(nullable: false, defaultValue: 4),
                    NumberOfChangeovers = table.Column<int>(nullable: false),
                    TicketPrice = table.Column<double>(nullable: false),
                    TravelLength = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_AviationCompanies_AviationCompanyId",
                        column: x => x.AviationCompanyId,
                        principalTable: "AviationCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Locations_FromId",
                        column: x => x.FromId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Locations_ToId",
                        column: x => x.ToId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightSeats",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<long>(nullable: false),
                    SeatNumber = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightSeats_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(nullable: false),
                    RatingGiverEmail = table.Column<string>(nullable: true),
                    CarId = table.Column<long>(nullable: false),
                    FlightId = table.Column<long>(nullable: false),
                    RentACarId = table.Column<long>(nullable: false),
                    AviationCompanyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_AviationCompanies_AviationCompanyId",
                        column: x => x.AviationCompanyId,
                        principalTable: "AviationCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FlightTickets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketOwnerEmail = table.Column<string>(nullable: true),
                    FlightId = table.Column<long>(nullable: false),
                    FlightSeatId = table.Column<long>(nullable: true),
                    Discount = table.Column<double>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    Accepted = table.Column<bool>(nullable: false),
                    Rating = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightTickets_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightTickets_FlightSeats_FlightSeatId",
                        column: x => x.FlightSeatId,
                        principalTable: "FlightSeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AviationCompanies_AddressId",
                table: "AviationCompanies",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AviationCompanyId",
                table: "Flights",
                column: "AviationCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FromId",
                table: "Flights",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ToId",
                table: "Flights",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSeats_FlightId",
                table: "FlightSeats",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightTickets_FlightId",
                table: "FlightTickets",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightTickets_FlightSeatId",
                table: "FlightTickets",
                column: "FlightSeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_AviationCompanyId",
                table: "Rating",
                column: "AviationCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_FlightId",
                table: "Rating",
                column: "FlightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightTickets");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "FlightSeats");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "AviationCompanies");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
