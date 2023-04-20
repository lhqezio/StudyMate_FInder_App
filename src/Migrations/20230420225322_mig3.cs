using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "CreatedEventId",
                table: "Profiles",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CourseEvent",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Course = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEvent", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "EventCalendar",
                columns: table => new
                {
                    EventId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsSent = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCalendar", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CourseEventEventCalendar",
                columns: table => new
                {
                    CourseEventsCourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EventsEventId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEventEventCalendar", x => new { x.CourseEventsCourseId, x.EventsEventId });
                    table.ForeignKey(
                        name: "FK_CourseEventEventCalendar_CourseEvent_CourseEventsCourseId",
                        column: x => x.CourseEventsCourseId,
                        principalTable: "CourseEvent",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEventEventCalendar_EventCalendar_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "EventCalendar",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventCalendarProfile",
                columns: table => new
                {
                    EventsEventId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ParticipantsProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCalendarProfile", x => new { x.EventsEventId, x.ParticipantsProfileId });
                    table.ForeignKey(
                        name: "FK_EventCalendarProfile_EventCalendar_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "EventCalendar",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventCalendarProfile_Profiles_ParticipantsProfileId",
                        column: x => x.ParticipantsProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventCalendarSchool",
                columns: table => new
                {
                    EventId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Schoolsid = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCalendarSchool", x => new { x.EventId, x.Schoolsid });
                    table.ForeignKey(
                        name: "FK_EventCalendarSchool_EventCalendar_EventId",
                        column: x => x.EventId,
                        principalTable: "EventCalendar",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventCalendarSchool_School_Schoolsid",
                        column: x => x.Schoolsid,
                        principalTable: "School",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseEventEventCalendar_EventsEventId",
                table: "CourseEventEventCalendar",
                column: "EventsEventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCalendarProfile_ParticipantsProfileId",
                table: "EventCalendarProfile",
                column: "ParticipantsProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCalendarSchool_Schoolsid",
                table: "EventCalendarSchool",
                column: "Schoolsid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseEventEventCalendar");

            migrationBuilder.DropTable(
                name: "EventCalendarProfile");

            migrationBuilder.DropTable(
                name: "EventCalendarSchool");

            migrationBuilder.DropTable(
                name: "CourseEvent");

            migrationBuilder.DropTable(
                name: "EventCalendar");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropColumn(
                name: "CreatedEventId",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");
        }
    }
}
