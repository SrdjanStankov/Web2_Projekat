using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class AddedRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingGiverEmail = table.Column<string>(nullable: true),
                    Value = table.Column<double>(nullable: false),
                    AviationCompanyId = table.Column<long>(nullable: true),
                    CarId = table.Column<long>(nullable: true),
                    FlightId = table.Column<long>(nullable: true),
                    RentACarId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_AviationCompany_AviationCompanyId",
                        column: x => x.AviationCompanyId,
                        principalTable: "AviationCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_User_RatingGiverEmail",
                        column: x => x.RatingGiverEmail,
                        principalTable: "User",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rating_RentACar_RentACarId",
                        column: x => x.RentACarId,
                        principalTable: "RentACar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_AviationCompanyId",
                table: "Rating",
                column: "AviationCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_CarId",
                table: "Rating",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_FlightId",
                table: "Rating",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_RatingGiverEmail",
                table: "Rating",
                column: "RatingGiverEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_RentACarId",
                table: "Rating",
                column: "RentACarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");
        }
    }
}
