using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Events_EventId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_EventId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Profiles");

            migrationBuilder.CreateTable(
                name: "ProfileEvent",
                columns: table => new
                {
                    EventId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileEvent", x => new { x.EventId, x.ProfileId });
                    table.ForeignKey(
                        name: "FK_ProfileEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileEvent_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileEvent_ProfileId",
                table: "ProfileEvent",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileEvent");

            migrationBuilder.AddColumn<string>(
                name: "EventId",
                table: "Profiles",
                type: "NVARCHAR2(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_EventId",
                table: "Profiles",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Events_EventId",
                table: "Profiles",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId");
        }
    }
}
