using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class VersionNoBridgingTbls18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyMate_Users_StudyMate_Profiles_ProfileId",
                table: "StudyMate_Users");

            migrationBuilder.DropIndex(
                name: "IX_StudyMate_Users_ProfileId",
                table: "StudyMate_Users");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "StudyMate_Users");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "StudyMate_Profiles",
                type: "NVARCHAR2(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_StudyMate_Profiles_UserId",
                table: "StudyMate_Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyMate_Profiles_StudyMate_Users_UserId",
                table: "StudyMate_Profiles",
                column: "UserId",
                principalTable: "StudyMate_Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyMate_Profiles_StudyMate_Users_UserId",
                table: "StudyMate_Profiles");

            migrationBuilder.DropIndex(
                name: "IX_StudyMate_Profiles_UserId",
                table: "StudyMate_Profiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StudyMate_Profiles");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "StudyMate_Users",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudyMate_Users_ProfileId",
                table: "StudyMate_Users",
                column: "ProfileId",
                unique: true,
                filter: "\"ProfileId\" IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyMate_Users_StudyMate_Profiles_ProfileId",
                table: "StudyMate_Users",
                column: "ProfileId",
                principalTable: "StudyMate_Profiles",
                principalColumn: "ProfileId");
        }
    }
}
