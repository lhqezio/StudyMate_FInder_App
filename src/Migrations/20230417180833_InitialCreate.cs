using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Gender = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Age = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    School = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Program = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PersonalDescription = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ProfilePicture = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ProfileId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Username = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Salt = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PasswordHash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
