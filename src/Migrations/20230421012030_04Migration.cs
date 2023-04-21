using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class _04Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEventEventCalendar_EventCalendar_EventsEventId",
                table: "CourseEventEventCalendar");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCalendar_Profiles_ProfileId",
                table: "EventCalendar");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCalendarProfile_EventCalendar_EventsEventId",
                table: "EventCalendarProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCalendarSchool_EventCalendar_EventId",
                table: "EventCalendarSchool");

            migrationBuilder.DropForeignKey(
                name: "FK_NeedHelpCoursesProfile_Profiles_profilesProfileId",
                table: "NeedHelpCoursesProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCalendar",
                table: "EventCalendar");

            migrationBuilder.RenameTable(
                name: "EventCalendar",
                newName: "Events");

            migrationBuilder.RenameColumn(
                name: "profilesProfileId",
                table: "NeedHelpCoursesProfile",
                newName: "ProfilesProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_NeedHelpCoursesProfile_profilesProfileId",
                table: "NeedHelpCoursesProfile",
                newName: "IX_NeedHelpCoursesProfile_ProfilesProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCalendar_ProfileId",
                table: "Events",
                newName: "IX_Events_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "EventId");

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionKey = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Expiration = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionKey);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEventEventCalendar_Events_EventsEventId",
                table: "CourseEventEventCalendar",
                column: "EventsEventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventCalendarProfile_Events_EventsEventId",
                table: "EventCalendarProfile",
                column: "EventsEventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventCalendarSchool_Events_EventId",
                table: "EventCalendarSchool",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Profiles_ProfileId",
                table: "Events",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NeedHelpCoursesProfile_Profiles_ProfilesProfileId",
                table: "NeedHelpCoursesProfile",
                column: "ProfilesProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEventEventCalendar_Events_EventsEventId",
                table: "CourseEventEventCalendar");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCalendarProfile_Events_EventsEventId",
                table: "EventCalendarProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCalendarSchool_Events_EventId",
                table: "EventCalendarSchool");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Profiles_ProfileId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_NeedHelpCoursesProfile_Profiles_ProfilesProfileId",
                table: "NeedHelpCoursesProfile");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "EventCalendar");

            migrationBuilder.RenameColumn(
                name: "ProfilesProfileId",
                table: "NeedHelpCoursesProfile",
                newName: "profilesProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_NeedHelpCoursesProfile_ProfilesProfileId",
                table: "NeedHelpCoursesProfile",
                newName: "IX_NeedHelpCoursesProfile_profilesProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_ProfileId",
                table: "EventCalendar",
                newName: "IX_EventCalendar_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCalendar",
                table: "EventCalendar",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEventEventCalendar_EventCalendar_EventsEventId",
                table: "CourseEventEventCalendar",
                column: "EventsEventId",
                principalTable: "EventCalendar",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventCalendar_Profiles_ProfileId",
                table: "EventCalendar",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventCalendarProfile_EventCalendar_EventsEventId",
                table: "EventCalendarProfile",
                column: "EventsEventId",
                principalTable: "EventCalendar",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventCalendarSchool_EventCalendar_EventId",
                table: "EventCalendarSchool",
                column: "EventId",
                principalTable: "EventCalendar",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NeedHelpCoursesProfile_Profiles_profilesProfileId",
                table: "NeedHelpCoursesProfile",
                column: "profilesProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
