using Microsoft.EntityFrameworkCore.Migrations;

namespace tp4EF.Migrations
{
    public partial class fixdatos1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "id",
                keyValue: 1,
                column: "cuil",
                value: "123");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "id",
                keyValue: 2,
                column: "cuil",
                value: "423");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "id",
                keyValue: 1,
                column: "cuil",
                value: null);

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "id",
                keyValue: 2,
                column: "cuil",
                value: null);
        }
    }
}
