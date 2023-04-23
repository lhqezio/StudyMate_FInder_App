using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedEventId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "School",
                table: "Profiles");

            migrationBuilder.AddColumn<string>(
                name: "SchoolId",
                table: "Profiles",
                type: "NVARCHAR2(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileId",
                table: "EventCalendar",
                type: "NVARCHAR2(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_SchoolId",
                table: "Profiles",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCalendar_ProfileId",
                table: "EventCalendar",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCalendar_Profiles_ProfileId",
                table: "EventCalendar",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_School_SchoolId",
                table: "Profiles",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCalendar_Profiles_ProfileId",
                table: "EventCalendar");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_School_SchoolId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_SchoolId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_EventCalendar_ProfileId",
                table: "EventCalendar");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "EventCalendar");

            migrationBuilder.AddColumn<string>(
                name: "CreatedEventId",
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
        }
    }
}
