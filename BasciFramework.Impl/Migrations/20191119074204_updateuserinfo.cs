using Microsoft.EntityFrameworkCore.Migrations;

namespace BasicFramework.Impl.Migrations
{
    public partial class updateuserinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "t_User_User",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QQNumber",
                table: "t_User_User",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeCharNumber",
                table: "t_User_User",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "t_User_User");

            migrationBuilder.DropColumn(
                name: "QQNumber",
                table: "t_User_User");

            migrationBuilder.DropColumn(
                name: "WeCharNumber",
                table: "t_User_User");
        }
    }
}
