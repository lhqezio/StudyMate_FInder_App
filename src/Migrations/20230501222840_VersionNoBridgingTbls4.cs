using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class VersionNoBridgingTbls4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    ConversationId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ConversationName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.ConversationId);
                });

            migrationBuilder.CreateTable(
                name: "Hobby",
                columns: table => new
                {
                    HobbyId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    HobbyName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobby", x => x.HobbyId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    SenderID = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ConversationID = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Body = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Sent = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    SchoolName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "StudyCourses",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    CourseName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyCourses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Username = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PasswordHash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ConversationUser",
                columns: table => new
                {
                    ConversationsConversationId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    UsersUserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationUser", x => new { x.ConversationsConversationId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_ConversationUser_Conversations_ConversationsConversationId",
                        column: x => x.ConversationsConversationId,
                        principalTable: "Conversations",
                        principalColumn: "ConversationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConversationUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    SchoolId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Age = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Program = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PersonalDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
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
                name: "CourseProfile",
                columns: table => new
                {
                    CourseCanHelpWithCourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    StudentsTutoringCourseProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProfile", x => new { x.CourseCanHelpWithCourseId, x.StudentsTutoringCourseProfileId });
                    table.ForeignKey(
                        name: "FK_CourseProfile_Profiles_StudentsTutoringCourseProfileId",
                        column: x => x.StudentsTutoringCourseProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProfile_StudyCourses_CourseCanHelpWithCourseId",
                        column: x => x.CourseCanHelpWithCourseId,
                        principalTable: "StudyCourses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseProfile1",
                columns: table => new
                {
                    CourseNeedHelpWithCourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    StudentsNeedHelpCourseProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProfile1", x => new { x.CourseNeedHelpWithCourseId, x.StudentsNeedHelpCourseProfileId });
                    table.ForeignKey(
                        name: "FK_CourseProfile1_Profiles_StudentsNeedHelpCourseProfileId",
                        column: x => x.StudentsNeedHelpCourseProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProfile1_StudyCourses_CourseNeedHelpWithCourseId",
                        column: x => x.CourseNeedHelpWithCourseId,
                        principalTable: "StudyCourses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseProfile2",
                columns: table => new
                {
                    CourseTakenCourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    StudentsTakingCourseProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProfile2", x => new { x.CourseTakenCourseId, x.StudentsTakingCourseProfileId });
                    table.ForeignKey(
                        name: "FK_CourseProfile2_Profiles_StudentsTakingCourseProfileId",
                        column: x => x.StudentsTakingCourseProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProfile2_StudyCourses_CourseTakenCourseId",
                        column: x => x.CourseTakenCourseId,
                        principalTable: "StudyCourses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Location = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Subjects = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SchoolId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    IsSent = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId");
                    table.ForeignKey(
                        name: "FK_Events_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HobbyProfile",
                columns: table => new
                {
                    HobbiesHobbyId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProfilesProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbyProfile", x => new { x.HobbiesHobbyId, x.ProfilesProfileId });
                    table.ForeignKey(
                        name: "FK_HobbyProfile_Hobby_HobbiesHobbyId",
                        column: x => x.HobbiesHobbyId,
                        principalTable: "Hobby",
                        principalColumn: "HobbyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HobbyProfile_Profiles_ProfilesProfileId",
                        column: x => x.ProfilesProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseEvent",
                columns: table => new
                {
                    CoursesCourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EventsEventId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEvent", x => new { x.CoursesCourseId, x.EventsEventId });
                    table.ForeignKey(
                        name: "FK_CourseEvent_Events_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEvent_StudyCourses_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "StudyCourses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventProfile",
                columns: table => new
                {
                    ParticipantEventsEventId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ParticipantsProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventProfile", x => new { x.ParticipantEventsEventId, x.ParticipantsProfileId });
                    table.ForeignKey(
                        name: "FK_EventProfile_Events_ParticipantEventsEventId",
                        column: x => x.ParticipantEventsEventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventProfile_Profiles_ParticipantsProfileId",
                        column: x => x.ParticipantsProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConversationUser_UsersUserId",
                table: "ConversationUser",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEvent_EventsEventId",
                table: "CourseEvent",
                column: "EventsEventId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProfile_StudentsTutoringCourseProfileId",
                table: "CourseProfile",
                column: "StudentsTutoringCourseProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProfile1_StudentsNeedHelpCourseProfileId",
                table: "CourseProfile1",
                column: "StudentsNeedHelpCourseProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProfile2_StudentsTakingCourseProfileId",
                table: "CourseProfile2",
                column: "StudentsTakingCourseProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_EventProfile_ParticipantsProfileId",
                table: "EventProfile",
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
                name: "IX_HobbyProfile_ProfilesProfileId",
                table: "HobbyProfile",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConversationUser");

            migrationBuilder.DropTable(
                name: "CourseEvent");

            migrationBuilder.DropTable(
                name: "CourseProfile");

            migrationBuilder.DropTable(
                name: "CourseProfile1");

            migrationBuilder.DropTable(
                name: "CourseProfile2");

            migrationBuilder.DropTable(
                name: "EventProfile");

            migrationBuilder.DropTable(
                name: "HobbyProfile");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "StudyCourses");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Hobby");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
