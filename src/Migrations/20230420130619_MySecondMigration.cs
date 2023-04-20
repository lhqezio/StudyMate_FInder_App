using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class MySecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    profilesProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeedHelpCoursesProfile", x => new { x.NeedHelpCoursesCourseId, x.profilesProfileId });
                    table.ForeignKey(
                        name: "FK_NeedHelpCoursesProfile_NeedHelpCourses_NeedHelpCoursesCourseId",
                        column: x => x.NeedHelpCoursesCourseId,
                        principalTable: "NeedHelpCourses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NeedHelpCoursesProfile_Profiles_profilesProfileId",
                        column: x => x.profilesProfileId,
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
                name: "IX_CanHelpCoursesProfile_ProfilesProfileId",
                table: "CanHelpCoursesProfile",
                column: "ProfilesProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestsProfileProfile_ProfilesProfileId",
                table: "InterestsProfileProfile",
                column: "ProfilesProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_NeedHelpCoursesProfile_profilesProfileId",
                table: "NeedHelpCoursesProfile",
                column: "profilesProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTakenCourses_TakenCoursesCourseId",
                table: "ProfileTakenCourses",
                column: "TakenCoursesCourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CanHelpCoursesProfile");

            migrationBuilder.DropTable(
                name: "InterestsProfileProfile");

            migrationBuilder.DropTable(
                name: "NeedHelpCoursesProfile");

            migrationBuilder.DropTable(
                name: "ProfileTakenCourses");

            migrationBuilder.DropTable(
                name: "CanHelpCourses");

            migrationBuilder.DropTable(
                name: "InterestsProfile");

            migrationBuilder.DropTable(
                name: "NeedHelpCourses");

            migrationBuilder.DropTable(
                name: "TakenCourses");
        }
    }
}
