using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Profiles_ProfileId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_School_SchoolId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_School_SchoolId",
                table: "Profiles");

            migrationBuilder.DropTable(
                name: "CanHelpCoursesProfile");

            migrationBuilder.DropTable(
                name: "CourseEventEventCalendar");

            migrationBuilder.DropTable(
                name: "EventCalendarProfile");

            migrationBuilder.DropTable(
                name: "InterestsProfileProfile");

            migrationBuilder.DropTable(
                name: "NeedHelpCoursesProfile");

            migrationBuilder.DropTable(
                name: "ProfileTakenCourses");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "CanHelpCourses");

            migrationBuilder.DropTable(
                name: "CourseEvent");

            migrationBuilder.DropTable(
                name: "InterestsProfile");

            migrationBuilder.DropTable(
                name: "NeedHelpCourses");

            migrationBuilder.DropTable(
                name: "TakenCourses");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_SchoolId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Events_ProfileId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_SchoolId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "IsSent",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "Profiles",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonalDescription",
                table: "Profiles",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Profiles",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Profiles",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventId",
                table: "Profiles",
                type: "NVARCHAR2(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hobbies",
                table: "Profiles",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NeedHelpCourses",
                table: "Profiles",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "School",
                table: "Profiles",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TakenCourses",
                table: "Profiles",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "TIMESTAMP(7) WITH TIME ZONE");

            migrationBuilder.AddColumn<string>(
                name: "Courses",
                table: "Events",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Events",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_EventId",
                table: "Profiles",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Events_EventId",
                table: "Profiles",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Events_EventId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_EventId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Hobbies",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "NeedHelpCourses",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "School",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "TakenCourses",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Courses",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                table: "Profiles",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "PersonalDescription",
                table: "Profiles",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Profiles",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Profiles",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddColumn<string>(
                name: "SchoolId",
                table: "Profiles",
                type: "NVARCHAR2(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Date",
                table: "Events",
                type: "TIMESTAMP(7) WITH TIME ZONE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AddColumn<bool>(
                name: "IsSent",
                table: "Events",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProfileId",
                table: "Events",
                type: "NVARCHAR2(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolId",
                table: "Events",
                type: "NVARCHAR2(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CanHelpCourses",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Course = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanHelpCourses", x => x.CourseId);
                });

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
                        name: "FK_EventCalendarProfile_Events_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "Events",
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
                name: "InterestsProfile",
                columns: table => new
                {
                    InterestId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Interests = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestsProfile", x => x.InterestId);
                });

            migrationBuilder.CreateTable(
                name: "NeedHelpCourses",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Course = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeedHelpCourses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    SchoolId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionKey = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Expiration = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionKey);
                });

            migrationBuilder.CreateTable(
                name: "TakenCourses",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Course = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakenCourses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "CanHelpCoursesProfile",
                columns: table => new
                {
                    CanHelpCoursesCourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProfilesProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanHelpCoursesProfile", x => new { x.CanHelpCoursesCourseId, x.ProfilesProfileId });
                    table.ForeignKey(
                        name: "FK_CanHelpCoursesProfile_CanHelpCourses_CanHelpCoursesCourseId",
                        column: x => x.CanHelpCoursesCourseId,
                        principalTable: "CanHelpCourses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CanHelpCoursesProfile_Profiles_ProfilesProfileId",
                        column: x => x.ProfilesProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_CourseEventEventCalendar_Events_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestsProfileProfile",
                columns: table => new
                {
                    HobbiesInterestId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProfilesProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestsProfileProfile", x => new { x.HobbiesInterestId, x.ProfilesProfileId });
                    table.ForeignKey(
                        name: "FK_InterestsProfileProfile_InterestsProfile_HobbiesInterestId",
                        column: x => x.HobbiesInterestId,
                        principalTable: "InterestsProfile",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestsProfileProfile_Profiles_ProfilesProfileId",
                        column: x => x.ProfilesProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NeedHelpCoursesProfile",
                columns: table => new
                {
                    NeedHelpCoursesCourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProfilesProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeedHelpCoursesProfile", x => new { x.NeedHelpCoursesCourseId, x.ProfilesProfileId });
                    table.ForeignKey(
                        name: "FK_NeedHelpCoursesProfile_NeedHelpCourses_NeedHelpCoursesCourseId",
                        column: x => x.NeedHelpCoursesCourseId,
                        principalTable: "NeedHelpCourses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NeedHelpCoursesProfile_Profiles_ProfilesProfileId",
                        column: x => x.ProfilesProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileTakenCourses",
                columns: table => new
                {
                    ProfilesProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    TakenCoursesCourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileTakenCourses", x => new { x.ProfilesProfileId, x.TakenCoursesCourseId });
                    table.ForeignKey(
                        name: "FK_ProfileTakenCourses_Profiles_ProfilesProfileId",
                        column: x => x.ProfilesProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileTakenCourses_TakenCourses_TakenCoursesCourseId",
                        column: x => x.TakenCoursesCourseId,
                        principalTable: "TakenCourses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_SchoolId",
                table: "Profiles",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ProfileId",
                table: "Events",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SchoolId",
                table: "Events",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_CanHelpCoursesProfile_ProfilesProfileId",
                table: "CanHelpCoursesProfile",
                column: "ProfilesProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEventEventCalendar_EventsEventId",
                table: "CourseEventEventCalendar",
                column: "EventsEventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCalendarProfile_ParticipantsProfileId",
                table: "EventCalendarProfile",
                column: "ParticipantsProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestsProfileProfile_ProfilesProfileId",
                table: "InterestsProfileProfile",
                column: "ProfilesProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_NeedHelpCoursesProfile_ProfilesProfileId",
                table: "NeedHelpCoursesProfile",
                column: "ProfilesProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTakenCourses_TakenCoursesCourseId",
                table: "ProfileTakenCourses",
                column: "TakenCoursesCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Profiles_ProfileId",
                table: "Events",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_School_SchoolId",
                table: "Events",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "SchoolId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_School_SchoolId",
                table: "Profiles",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "SchoolId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
