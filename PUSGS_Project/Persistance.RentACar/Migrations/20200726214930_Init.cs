using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.RentACar.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentACars",
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
                    table.PrimaryKey("PK_RentACars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    RentACarId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_RentACars_RentACarId",
                        column: x => x.RentACarId,
                        principalTable: "RentACars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PassengerNumber = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    CostPerDay = table.Column<double>(nullable: false),
                    BuildDate = table.Column<int>(nullable: false),
                    IsReserved = table.Column<bool>(nullable: false),
                    RentACarId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_RentACars_RentACarId",
                        column: x => x.RentACarId,
                        principalTable: "RentACars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    Rating = table.Column<double>(nullable: true),
                    CostForRange = table.Column<double>(nullable: false),
                    ReservedCarId = table.Column<long>(nullable: false),
                    OwnerEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarReservations_Cars_ReservedCarId",
                        column: x => x.ReservedCarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(nullable: false),
                    RatingGiverEmail = table.Column<string>(nullable: true),
                    CarId = table.Column<long>(nullable: true),
                    RentACarId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_RentACars_RentACarId",
                        column: x => x.RentACarId,
                        principalTable: "RentACars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_RentACarId",
                table: "Branches",
                column: "RentACarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarReservations_ReservedCarId",
                table: "CarReservations",
                column: "ReservedCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RentACarId",
                table: "Cars",
                column: "RentACarId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CarId",
                table: "Ratings",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RentACarId",
                table: "Ratings",
                column: "RentACarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "CarReservations");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "RentACars");
        }
    }
}
