using Microsoft.EntityFrameworkCore.Migrations;

namespace CapsuleHotels.Migrations.Migrations
{
    public partial class correccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Hotel_HotelId",
                table: "Reserva");

            migrationBuilder.RenameColumn(
                name: "NumeroHbitacion",
                table: "Habtacion",
                newName: "NumeroHabitacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Hotel_HotelId",
                table: "Reserva",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Hotel_HotelId",
                table: "Reserva");

            migrationBuilder.RenameColumn(
                name: "NumeroHabitacion",
                table: "Habtacion",
                newName: "NumeroHbitacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Hotel_HotelId",
                table: "Reserva",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id");
        }
    }
}
