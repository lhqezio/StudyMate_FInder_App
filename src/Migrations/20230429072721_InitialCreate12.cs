using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Profiles",
                type: "NVARCHAR2(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId1",
                table: "Profiles",
                column: "UserId1",
                unique: true,
                filter: "\"UserId1\" IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Users_UserId1",
                table: "Profiles",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Users_UserId1",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserId1",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Profiles");
        }
    }
}
