using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyMate.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HobbyProfile_Hobby_HobbiesHobbyId",
                table: "HobbyProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobby",
                table: "Hobby");

            migrationBuilder.RenameTable(
                name: "Hobby",
                newName: "StudyMate_Hobbies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudyMate_Hobbies",
                table: "StudyMate_Hobbies",
                column: "HobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_HobbyProfile_StudyMate_Hobbies_HobbiesHobbyId",
                table: "HobbyProfile",
                column: "HobbiesHobbyId",
                principalTable: "StudyMate_Hobbies",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HobbyProfile_StudyMate_Hobbies_HobbiesHobbyId",
                table: "HobbyProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudyMate_Hobbies",
                table: "StudyMate_Hobbies");

            migrationBuilder.RenameTable(
                name: "StudyMate_Hobbies",
                newName: "Hobby");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobby",
                table: "Hobby",
                column: "HobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_HobbyProfile_Hobby_HobbiesHobbyId",
                table: "HobbyProfile",
                column: "HobbiesHobbyId",
                principalTable: "Hobby",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
