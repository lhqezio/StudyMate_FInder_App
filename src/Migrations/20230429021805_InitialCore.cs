using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class InitialCore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CanHelpCourses",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Course = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
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
                    Course = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEvent", x => x.CourseId);
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
                    Course = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeedHelpCourses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolId);
                });

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

            migrationBuilder.CreateTable(
                name: "TakenCourses",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Course = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakenCourses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Username = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Age = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Program = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PersonalDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SchoolId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_Profiles_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Location = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsSent = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    SchoolId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
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
                name: "IX_Events_ProfileId",
                table: "Events",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SchoolId",
                table: "Events",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestsProfileProfile_ProfilesProfileId",
                table: "InterestsProfileProfile",
                column: "ProfilesProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_NeedHelpCoursesProfile_ProfilesProfileId",
                table: "NeedHelpCoursesProfile",
                column: "ProfilesProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_SchoolId",
                table: "Profiles",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTakenCourses_TakenCoursesCourseId",
                table: "ProfileTakenCourses",
                column: "TakenCoursesCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_Name",
                table: "Schools",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "CanHelpCourses");

            migrationBuilder.DropTable(
                name: "CourseEvent");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "InterestsProfile");

            migrationBuilder.DropTable(
                name: "NeedHelpCourses");

            migrationBuilder.DropTable(
                name: "TakenCourses");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
