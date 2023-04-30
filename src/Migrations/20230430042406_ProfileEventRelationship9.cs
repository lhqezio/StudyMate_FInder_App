using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class ProfileEventRelationship9 : Migration
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
                    SchoolId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Age = table.Column<int>(type: "NUMBER(10)", nullable: false),
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
                        name: "FK_UserConversation_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "ConversationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserConversation_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursesCanHelpWith",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesCanHelpWith", x => new { x.CourseId, x.ProfileId });
                    table.ForeignKey(
                        name: "FK_CoursesCanHelpWith_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesCanHelpWith_StudyCourses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "StudyCourses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursesNeedHelpWith",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesNeedHelpWith", x => new { x.CourseId, x.ProfileId });
                    table.ForeignKey(
                        name: "FK_CoursesNeedHelpWith_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesNeedHelpWith_StudyCourses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "StudyCourses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursesTaken",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesTaken", x => new { x.CourseId, x.ProfileId });
                    table.ForeignKey(
                        name: "FK_CoursesTaken_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesTaken_StudyCourses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "StudyCourses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    CreatorId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Location = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Subjects = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SchooId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    IsSent = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Profiles_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Schools_SchooId",
                        column: x => x.SchooId,
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
                name: "CourseEventCalendar",
                columns: table => new
                {
                    Course = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    CoursesCourseId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEventCalendar", x => new { x.Course, x.CoursesCourseId });
                    table.ForeignKey(
                        name: "FK_CourseEventCalendar_Events_Course",
                        column: x => x.Course,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEventCalendar_StudyCourses_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "StudyCourses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventProfile",
                columns: table => new
                {
                    EventsId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProfilesId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventProfile", x => new { x.EventsId, x.ProfilesId });
                    table.ForeignKey(
                        name: "FK_EventProfile_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventProfile_Profiles_ProfilesId",
                        column: x => x.ProfilesId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseEventCalendar_CoursesCourseId",
                table: "CourseEventCalendar",
                column: "CoursesCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesCanHelpWith_ProfileId",
                table: "CoursesCanHelpWith",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesNeedHelpWith_ProfileId",
                table: "CoursesNeedHelpWith",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesTaken_ProfileId",
                table: "CoursesTaken",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_EventProfile_ProfilesId",
                table: "EventProfile",
                column: "ProfilesId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatorId",
                table: "Events",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SchooId",
                table: "Events",
                column: "SchooId",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_UserConversation_UserId",
                table: "UserConversation",
                column: "UserId");

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
                name: "CourseEventCalendar");

            migrationBuilder.DropTable(
                name: "CoursesCanHelpWith");

            migrationBuilder.DropTable(
                name: "CoursesNeedHelpWith");

            migrationBuilder.DropTable(
                name: "CoursesTaken");

            migrationBuilder.DropTable(
                name: "EventProfile");

            migrationBuilder.DropTable(
                name: "HobbyProfile");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "UserConversation");

            migrationBuilder.DropTable(
                name: "StudyCourses");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Hobby");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
