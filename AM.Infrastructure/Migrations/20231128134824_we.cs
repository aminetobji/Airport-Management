using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class we : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyPlanes",
                columns: table => new
                {
                    PlaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaneType = table.Column<int>(type: "int", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "date", nullable: false),
                    PlaneCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyPlanes", x => x.PlaneId);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PassLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    TelNumber = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassportNumber);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightDate = table.Column<DateTime>(type: "date", nullable: false),
                    EstimatedDuration = table.Column<int>(type: "int", nullable: false),
                    EffectiveArrival = table.Column<DateTime>(type: "date", nullable: false),
                    Departure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirlineLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_MyPlanes_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "MyPlanes",
                        principalColumn: "PlaneId");
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    PassportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployementDate = table.Column<DateTime>(type: "date", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.PassportNumber);
                    table.ForeignKey(
                        name: "FK_Staffs_Passengers_PassportNumber",
                        column: x => x.PassportNumber,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Travellers",
                columns: table => new
                {
                    PassportNumber = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    AdresseMail = table.Column<string>(name: "Adresse Mail", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HealthInformation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travellers", x => x.PassportNumber);
                    table.ForeignKey(
                        name: "FK_Travellers_Passengers_PassportNumber",
                        column: x => x.PassportNumber,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    PassengerFk = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    FlightFK = table.Column<int>(type: "int", nullable: false),
                    prix = table.Column<double>(type: "float", nullable: false),
                    Siege = table.Column<int>(type: "int", nullable: false),
                    Vip = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => new { x.FlightFK, x.PassengerFk });
                    table.ForeignKey(
                        name: "FK_Ticket_Flights_FlightFK",
                        column: x => x.FlightFK,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Passengers_PassengerFk",
                        column: x => x.PassengerFk,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneId",
                table: "Flights",
                column: "PlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PassengerFk",
                table: "Ticket",
                column: "PassengerFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Travellers");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "MyPlanes");
        }
    }
}
