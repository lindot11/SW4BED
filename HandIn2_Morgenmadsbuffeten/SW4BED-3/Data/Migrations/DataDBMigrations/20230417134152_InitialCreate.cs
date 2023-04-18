using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SW4BED_3.Migrations.DataDBMigrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Adults = table.Column<int>(type: "int", nullable: false),
                    Kids = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomNumber);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    AdultsReservations = table.Column<int>(type: "int", nullable: false),
                    KidsReservations = table.Column<int>(type: "int", nullable: false),
                    AdultsCheckIn = table.Column<int>(type: "int", nullable: false),
                    KidsCheckIn = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomsRoomNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomsRoomNumber",
                        column: x => x.RoomsRoomNumber,
                        principalTable: "Rooms",
                        principalColumn: "RoomNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomsRoomNumber",
                table: "Reservations",
                column: "RoomsRoomNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
