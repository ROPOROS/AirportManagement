using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyPlane",
                columns: table => new
                {
                    PlaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaneCapacity = table.Column<int>(type: "int", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "Date", nullable: false),
                    PlaneType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyPlane", x => x.PlaneId);
                });

            migrationBuilder.CreateTable(
                name: "Passangers",
                columns: table => new
                {
                    PassportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    PassFirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PassLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: false),
                    TelNumber = table.Column<int>(type: "int", nullable: false),
                    EmailAdress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passangers", x => x.PassportNumber);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EstimatedDuration = table.Column<int>(type: "int", nullable: false),
                    EffictiveArriaval = table.Column<DateTime>(type: "Date", nullable: false),
                    Departure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaneFk = table.Column<int>(type: "int", nullable: false),
                    Airline = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_MyPlane_PlaneFk",
                        column: x => x.PlaneFk,
                        principalTable: "MyPlane",
                        principalColumn: "PlaneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    PassportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.PassportNumber);
                    table.ForeignKey(
                        name: "FK_Staffs_Passangers_PassportNumber",
                        column: x => x.PassportNumber,
                        principalTable: "Passangers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Travelllers",
                columns: table => new
                {
                    PassportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    HealthInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travelllers", x => x.PassportNumber);
                    table.ForeignKey(
                        name: "FK_Travelllers_Passangers_PassportNumber",
                        column: x => x.PassportNumber,
                        principalTable: "Passangers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    DateReservation = table.Column<DateTime>(type: "Date", nullable: false),
                    PassangerFk = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    TicketFk = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => new { x.TicketFk, x.PassangerFk, x.DateReservation });
                    table.ForeignKey(
                        name: "FK_Reservations_Passangers_PassangerFk",
                        column: x => x.PassangerFk,
                        principalTable: "Passangers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Tickets_TicketFk",
                        column: x => x.TicketFk,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyFlight",
                columns: table => new
                {
                    FlightsFlightId = table.Column<int>(type: "int", nullable: false),
                    PassangersPassportNumber = table.Column<string>(type: "nvarchar(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyFlight", x => new { x.FlightsFlightId, x.PassangersPassportNumber });
                    table.ForeignKey(
                        name: "FK_MyFlight_Flights_FlightsFlightId",
                        column: x => x.FlightsFlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyFlight_Passangers_PassangersPassportNumber",
                        column: x => x.PassangersPassportNumber,
                        principalTable: "Passangers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneFk",
                table: "Flights",
                column: "PlaneFk");

            migrationBuilder.CreateIndex(
                name: "IX_MyFlight_PassangersPassportNumber",
                table: "MyFlight",
                column: "PassangersPassportNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PassangerFk",
                table: "Reservations",
                column: "PassangerFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyFlight");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Travelllers");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Passangers");

            migrationBuilder.DropTable(
                name: "MyPlane");
        }
    }
}
