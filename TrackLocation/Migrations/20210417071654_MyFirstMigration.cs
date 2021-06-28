using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackLocation.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FamilyCar",
                columns: table => new
                {
                    FamilyCarId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFamily = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyCar", x => x.FamilyCarId);
                });

            migrationBuilder.CreateTable(
                name: "TypeCar",
                columns: table => new
                {
                    TypeCarId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCar", x => x.TypeCarId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Cin = table.Column<string>(nullable: false),
                    NumTel = table.Column<string>(nullable: false),
                    NumPassport = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    TypeUser = table.Column<string>(nullable: false),
                    CreatedByAdminID = table.Column<long>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCar = table.Column<string>(nullable: false),
                    Puissance = table.Column<int>(nullable: false),
                    NumberPlace = table.Column<int>(nullable: false),
                    Matricule = table.Column<string>(nullable: false),
                    DateCirculation = table.Column<DateTime>(nullable: false),
                    TotKm = table.Column<int>(nullable: true),
                    FamilyCarId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    TypeCarId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Car_FamilyCar_FamilyCarId",
                        column: x => x.FamilyCarId,
                        principalTable: "FamilyCar",
                        principalColumn: "FamilyCarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_TypeCar_TypeCarId",
                        column: x => x.TypeCarId,
                        principalTable: "TypeCar",
                        principalColumn: "TypeCarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    CarId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Location_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Location_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    TrackID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    latitude = table.Column<double>(nullable: false),
                    longitude = table.Column<double>(nullable: false),
                    SPEED = table.Column<int>(nullable: false),
                    ENGINE_RPM = table.Column<long>(nullable: false),
                    ENGINE_LOAD = table.Column<string>(nullable: true),
                    AmbientAirTemp = table.Column<string>(nullable: true),
                    ThrottlePos = table.Column<string>(nullable: true),
                    insFuel = table.Column<double>(nullable: false),
                    valX = table.Column<double>(nullable: false),
                    valY = table.Column<double>(nullable: false),
                    valZ = table.Column<double>(nullable: false),
                    zone = table.Column<string>(nullable: true),
                    timestamp = table.Column<DateTime>(nullable: false),
                    LocationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.TrackID);
                    table.ForeignKey(
                        name: "FK_Tracks_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_FamilyCarId",
                table: "Car",
                column: "FamilyCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_TypeCarId",
                table: "Car",
                column: "TypeCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_UserId",
                table: "Car",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_CarId",
                table: "Location",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_UserId",
                table: "Location",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_LocationId",
                table: "Tracks",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "FamilyCar");

            migrationBuilder.DropTable(
                name: "TypeCar");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
