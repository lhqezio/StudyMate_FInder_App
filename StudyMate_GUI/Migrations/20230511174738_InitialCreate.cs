using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyMate.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobby",
                columns: table => new
                {
                    HobbyId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    HobbyName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobby", x => x.HobbyId);
                });

            migrationBuilder.CreateTable(
                name: "StudyMate_Conversations",
                columns: table => new
                {
                    ConversationId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ConversationName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyMate_Conversations", x => x.ConversationId);
                });

            migrationBuilder.CreateTable(
                name: "StudyMate_Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CourseName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyMate_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "StudyMate_Messages",
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
                    table.PrimaryKey("PK_StudyMate_Messages", x => x.MessageID);
                });

            migrationBuilder.CreateTable(
                name: "StudyMate_Schools",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SchoolName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyMate_Schools", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "StudyMate_Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Username = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyMate_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "StudyMate_Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    SchoolId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Age = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Program = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PersonalDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyMate_Profiles", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_StudyMate_Profiles_StudyMate_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "StudyMate_Schools",
                        principalColumn: "SchoolId");
                    table.ForeignKey(
                        name: "FK_StudyMate_Profiles_StudyMate_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "StudyMate_Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserConversation",
                columns: table => new
                {
                    ConversationId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConversation", x => new { x.ConversationId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserConversation_StudyMate_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "StudyMate_Conversations",
                        principalColumn: "ConversationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserConversation_StudyMate_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "StudyMate_Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseProfile",
                columns: table => new
                {
                    CourseNeedHelpWithCourseId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    StudentsNeedHelpCourseProfileId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProfile", x => new { x.CourseNeedHelpWithCourseId, x.StudentsNeedHelpCourseProfileId });
                    table.ForeignKey(
                        name: "FK_CourseProfile_StudyMate_Courses_CourseNeedHelpWithCourseId",
                        column: x => x.CourseNeedHelpWithCourseId,
                        principalTable: "StudyMate_Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProfile_StudyMate_Profiles_StudentsNeedHelpCourseProfileId",
                        column: x => x.StudentsNeedHelpCourseProfileId,
                        principalTable: "StudyMate_Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseProfile1",
                columns: table => new
                {
                    CourseTakenCourseId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    StudentsTakingCourseProfileId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProfile1", x => new { x.CourseTakenCourseId, x.StudentsTakingCourseProfileId });
                    table.ForeignKey(
                        name: "FK_CourseProfile1_StudyMate_Courses_CourseTakenCourseId",
                        column: x => x.CourseTakenCourseId,
                        principalTable: "StudyMate_Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProfile1_StudyMate_Profiles_StudentsTakingCourseProfileId",
                        column: x => x.StudentsTakingCourseProfileId,
                        principalTable: "StudyMate_Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseProfile2",
                columns: table => new
                {
                    CourseCanHelpWithCourseId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    StudentsTutoringCourseProfileId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProfile2", x => new { x.CourseCanHelpWithCourseId, x.StudentsTutoringCourseProfileId });
                    table.ForeignKey(
                        name: "FK_CourseProfile2_StudyMate_Courses_CourseCanHelpWithCourseId",
                        column: x => x.CourseCanHelpWithCourseId,
                        principalTable: "StudyMate_Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseProfile2_StudyMate_Profiles_StudentsTutoringCourseProfileId",
                        column: x => x.StudentsTutoringCourseProfileId,
                        principalTable: "StudyMate_Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HobbyProfile",
                columns: table => new
                {
                    HobbiesHobbyId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProfilesProfileId = table.Column<int>(type: "NUMBER(10)", nullable: false)
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
                        name: "FK_HobbyProfile_StudyMate_Profiles_ProfilesProfileId",
                        column: x => x.ProfilesProfileId,
                        principalTable: "StudyMate_Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyMate_Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ProfileId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Location = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Subjects = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SchoolId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    IsSent = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyMate_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_StudyMate_Events_StudyMate_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "StudyMate_Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyMate_Events_StudyMate_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "StudyMate_Schools",
                        principalColumn: "SchoolId");
                });

            migrationBuilder.CreateTable(
                name: "CourseEvent",
                columns: table => new
                {
                    CoursesCourseId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventsEventId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEvent", x => new { x.CoursesCourseId, x.EventsEventId });
                    table.ForeignKey(
                        name: "FK_CourseEvent_StudyMate_Courses_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "StudyMate_Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEvent_StudyMate_Events_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "StudyMate_Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventProfile",
                columns: table => new
                {
                    ParticipantEventsEventId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ParticipantsProfileId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventProfile", x => new { x.ParticipantEventsEventId, x.ParticipantsProfileId });
                    table.ForeignKey(
                        name: "FK_EventProfile_StudyMate_Events_ParticipantEventsEventId",
                        column: x => x.ParticipantEventsEventId,
                        principalTable: "StudyMate_Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventProfile_StudyMate_Profiles_ParticipantsProfileId",
                        column: x => x.ParticipantsProfileId,
                        principalTable: "StudyMate_Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseEvent_EventsEventId",
                table: "CourseEvent",
                column: "EventsEventId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProfile_StudentsNeedHelpCourseProfileId",
                table: "CourseProfile",
                column: "StudentsNeedHelpCourseProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProfile1_StudentsTakingCourseProfileId",
                table: "CourseProfile1",
                column: "StudentsTakingCourseProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProfile2_StudentsTutoringCourseProfileId",
                table: "CourseProfile2",
                column: "StudentsTutoringCourseProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_EventProfile_ParticipantsProfileId",
                table: "EventProfile",
                column: "ParticipantsProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_HobbyProfile_ProfilesProfileId",
                table: "HobbyProfile",
                column: "ProfilesProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyMate_Events_ProfileId",
                table: "StudyMate_Events",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyMate_Events_SchoolId",
                table: "StudyMate_Events",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyMate_Profiles_SchoolId",
                table: "StudyMate_Profiles",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyMate_Profiles_UserId",
                table: "StudyMate_Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudyMate_Users_Email",
                table: "StudyMate_Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudyMate_Users_Username",
                table: "StudyMate_Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserConversation_UserId",
                table: "UserConversation",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "StudyMate_Messages");

            migrationBuilder.DropTable(
                name: "UserConversation");

            migrationBuilder.DropTable(
                name: "StudyMate_Courses");

            migrationBuilder.DropTable(
                name: "StudyMate_Events");

            migrationBuilder.DropTable(
                name: "Hobby");

            migrationBuilder.DropTable(
                name: "StudyMate_Conversations");

            migrationBuilder.DropTable(
                name: "StudyMate_Profiles");

            migrationBuilder.DropTable(
                name: "StudyMate_Schools");

            migrationBuilder.DropTable(
                name: "StudyMate_Users");
        }
    }
}
