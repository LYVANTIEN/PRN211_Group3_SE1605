using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    public partial class huh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Baned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Upcoming = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Theater",
                columns: table => new
                {
                    TheaterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheaterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberTheateHall = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theater", x => x.TheaterId);
                });

            migrationBuilder.CreateTable(
                name: "Revenue_statics",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalMoney = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheaterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenue_statics", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Revenue_statics_Theater_TheaterId",
                        column: x => x.TheaterId,
                        principalTable: "Theater",
                        principalColumn: "TheaterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "theaterHalls",
                columns: table => new
                {
                    TheaterHallId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheaterHallName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    TheaterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theaterHalls", x => x.TheaterHallId);
                    table.ForeignKey(
                        name: "FK_theaterHalls_Theater_TheaterId",
                        column: x => x.TheaterId,
                        principalTable: "Theater",
                        principalColumn: "TheaterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesShows",
                columns: table => new
                {
                    MovieShowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    TheaterHallId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesShows", x => x.MovieShowId);
                    table.ForeignKey(
                        name: "FK_MoviesShows_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesShows_theaterHalls_TheaterHallId",
                        column: x => x.TheaterHallId,
                        principalTable: "theaterHalls",
                        principalColumn: "TheaterHallId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheaterHallId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seats_theaterHalls_TheaterHallId",
                        column: x => x.TheaterHallId,
                        principalTable: "theaterHalls",
                        principalColumn: "TheaterHallId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payment_Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieShowId = table.Column<int>(type: "int", nullable: false),
                    NumberSeat = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_MoviesShows_MovieShowId",
                        column: x => x.MovieShowId,
                        principalTable: "MoviesShows",
                        principalColumn: "MovieShowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "SeatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SeatId",
                table: "Bookings",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesShows_MovieId",
                table: "MoviesShows",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesShows_TheaterHallId",
                table: "MoviesShows",
                column: "TheaterHallId");

            migrationBuilder.CreateIndex(
                name: "IX_Revenue_statics_TheaterId",
                table: "Revenue_statics",
                column: "TheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_TheaterHallId",
                table: "Seats",
                column: "TheaterHallId");

            migrationBuilder.CreateIndex(
                name: "IX_theaterHalls_TheaterId",
                table: "theaterHalls",
                column: "TheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_AccountId",
                table: "Ticket",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_MovieShowId",
                table: "Ticket",
                column: "MovieShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Revenue_statics");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "MoviesShows");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "theaterHalls");

            migrationBuilder.DropTable(
                name: "Theater");
        }
    }
}
