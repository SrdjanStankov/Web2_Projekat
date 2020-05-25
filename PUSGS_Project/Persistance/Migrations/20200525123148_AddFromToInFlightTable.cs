using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class AddFromToInFlightTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FromId",
                table: "Flight",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ToId",
                table: "Flight",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flight_FromId",
                table: "Flight",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ToId",
                table: "Flight",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Location_FromId",
                table: "Flight",
                column: "FromId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Location_ToId",
                table: "Flight",
                column: "ToId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Location_FromId",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Location_ToId",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_FromId",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_ToId",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "FromId",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "ToId",
                table: "Flight");
        }
    }
}
