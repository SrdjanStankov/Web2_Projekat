using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class AddFlightSeat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_AviationCompany_AviationCompanyId",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightTicket_Flight_FlightId",
                table: "FlightTicket");

            migrationBuilder.AlterColumn<long>(
                name: "FlightId",
                table: "FlightTicket",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AviationCompanyId",
                table: "Flight",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FlightSeats",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<long>(nullable: false),
                    ReservedById = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightSeats_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightSeats_FlightTicket_ReservedById",
                        column: x => x.ReservedById,
                        principalTable: "FlightTicket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightSeats_FlightId",
                table: "FlightSeats",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSeats_ReservedById",
                table: "FlightSeats",
                column: "ReservedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_AviationCompany_AviationCompanyId",
                table: "Flight",
                column: "AviationCompanyId",
                principalTable: "AviationCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightTicket_Flight_FlightId",
                table: "FlightTicket",
                column: "FlightId",
                principalTable: "Flight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_AviationCompany_AviationCompanyId",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightTicket_Flight_FlightId",
                table: "FlightTicket");

            migrationBuilder.DropTable(
                name: "FlightSeats");

            migrationBuilder.AlterColumn<long>(
                name: "FlightId",
                table: "FlightTicket",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "AviationCompanyId",
                table: "Flight",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_AviationCompany_AviationCompanyId",
                table: "Flight",
                column: "AviationCompanyId",
                principalTable: "AviationCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightTicket_Flight_FlightId",
                table: "FlightTicket",
                column: "FlightId",
                principalTable: "Flight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
