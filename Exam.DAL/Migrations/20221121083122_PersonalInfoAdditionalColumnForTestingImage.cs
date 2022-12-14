using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam.DAL.Migrations
{
    public partial class PersonalInfoAdditionalColumnForTestingImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "PersonalInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "PersonalInfos");
        }
    }
}
