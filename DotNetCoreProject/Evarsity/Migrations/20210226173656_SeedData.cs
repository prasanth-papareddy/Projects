using Microsoft.EntityFrameworkCore.Migrations;

namespace Evarsity.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "StudentId", "StudentDepartment", "StudentEmail", "StudentName", "StudentYear" },
                values: new object[] { 555, 2, "Prasanth@gmail.com", "Prasanth", null });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "StudentId", "StudentDepartment", "StudentEmail", "StudentName", "StudentYear" },
                values: new object[] { 666, 2, "Prasanth@gmail.com", "Prasanth", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 555);

            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "StudentId",
                keyValue: 666);
        }
    }
}
