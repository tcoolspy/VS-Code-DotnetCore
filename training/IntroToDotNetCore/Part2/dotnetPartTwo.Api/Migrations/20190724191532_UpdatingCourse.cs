using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetPartTwo.Api.Migrations
{
    public partial class UpdatingCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseHours",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CourseIdentifier",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseHours",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseIdentifier",
                table: "Courses");
        }
    }
}
