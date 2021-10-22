using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.SqlServermigrations
{
    public partial class SqlServerInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Place = table.Column<string>(type: "TEXT", nullable: true),
                    Schedule = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Day = table.Column<string>(type: "TEXT", nullable: true),
                    Hour = table.Column<string>(type: "TEXT", nullable: true),
                    Career = table.Column<string>(type: "TEXT", nullable: true),
                    ActivityType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    StudentNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    RegisterAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Day = table.Column<string>(type: "TEXT", nullable: true),
                    Hour = table.Column<string>(type: "TEXT", nullable: true),
                    Career = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rapportuers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Biography = table.Column<string>(type: "TEXT", nullable: true),
                    ActivityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rapportuers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rapportuers_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityAttendee",
                columns: table => new
                {
                    ActivitiesId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttendeesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityAttendee", x => new { x.ActivitiesId, x.AttendeesId });
                    table.ForeignKey(
                        name: "FK_ActivityAttendee_Activities_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityAttendee_Attendees_AttendeesId",
                        column: x => x.AttendeesId,
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAttendee_AttendeesId",
                table: "ActivityAttendee",
                column: "AttendeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Rapportuers_ActivityId",
                table: "Rapportuers",
                column: "ActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityAttendee");

            migrationBuilder.DropTable(
                name: "Rapportuers");

            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}
