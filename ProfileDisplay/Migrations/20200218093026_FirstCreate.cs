using Microsoft.EntityFrameworkCore.Migrations;

namespace ProfileDisplay.Migrations
{
    public partial class FirstCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ProfileImage = table.Column<string>(nullable: true),
                    CoverImage = table.Column<string>(nullable: true),
                    Degree = table.Column<string>(nullable: true),
                    University = table.Column<string>(nullable: true),
                    JobPost = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    Experience = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.UserName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfile");
        }
    }
}
