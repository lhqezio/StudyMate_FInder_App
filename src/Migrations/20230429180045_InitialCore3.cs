using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class InitialCore3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_CoursesCanHelpWith_ProfileId",
                table: "CoursesCanHelpWith",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesNeedHelpWith_ProfileId",
                table: "CoursesNeedHelpWith",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesCanHelpWith");

            migrationBuilder.DropTable(
                name: "CoursesNeedHelpWith");
        }
    }
}
