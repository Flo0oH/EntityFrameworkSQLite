using Microsoft.EntityFrameworkCore.Migrations;

namespace entiframe.Migrations
{
    public partial class InitialCreate11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PapasTempSensor",
                table: "PapasTempSensor");

            migrationBuilder.RenameTable(
                name: "PapasTempSensor",
                newName: "TempSensors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TempSensors",
                table: "TempSensors",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TempSensors",
                table: "TempSensors");

            migrationBuilder.RenameTable(
                name: "TempSensors",
                newName: "PapasTempSensor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PapasTempSensor",
                table: "PapasTempSensor",
                column: "Id");
        }
    }
}
