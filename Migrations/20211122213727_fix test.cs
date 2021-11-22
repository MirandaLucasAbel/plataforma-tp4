using Microsoft.EntityFrameworkCore.Migrations;

namespace tp4EF.Migrations
{
    public partial class fixtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: "pass");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: "pass");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "id",
                keyValue: 1,
                column: "password",
                value: null);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "id",
                keyValue: 2,
                column: "password",
                value: null);
        }
    }
}
