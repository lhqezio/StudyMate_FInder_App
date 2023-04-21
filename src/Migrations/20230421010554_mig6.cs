using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventCalendarSchool");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "School",
                newName: "SchoolId");

            migrationBuilder.AddColumn<string>(
                name: "SchoolId",
                table: "EventCalendar",
                type: "NVARCHAR2(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_EventCalendar_SchoolId",
                table: "EventCalendar",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCalendar_School_SchoolId",
                table: "EventCalendar",
                column: "SchoolId",
                principalTable: "School",
                principalColumn: "SchoolId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCalendar_School_SchoolId",
                table: "EventCalendar");

            migrationBuilder.DropIndex(
                name: "IX_EventCalendar_SchoolId",
                table: "EventCalendar");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "EventCalendar");

            migrationBuilder.RenameColumn(
                name: "SchoolId",
                table: "School",
                newName: "id");

            migrationBuilder.CreateTable(
                name: "EventCalendarSchool",
                columns: table => new
                {
                    EventId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Schoolsid = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCalendarSchool", x => new { x.EventId, x.Schoolsid });
                    table.ForeignKey(
                        name: "FK_EventCalendarSchool_EventCalendar_EventId",
                        column: x => x.EventId,
                        principalTable: "EventCalendar",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventCalendarSchool_School_Schoolsid",
                        column: x => x.Schoolsid,
                        principalTable: "School",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventCalendarSchool_Schoolsid",
                table: "EventCalendarSchool",
                column: "Schoolsid");
        }
    }
}
