using Microsoft.EntityFrameworkCore.Migrations;

namespace entiframe.Migrations
{
    public partial class InitialCreate12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_olderSensors",
                table: "olderSensors");

            migrationBuilder.RenameTable(
                name: "olderSensors",
                newName: "Sensors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sensors",
                table: "Sensors",
                column: "SensorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sensors",
                table: "Sensors");

            migrationBuilder.RenameTable(
                name: "Sensors",
                newName: "olderSensors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_olderSensors",
                table: "olderSensors",
                column: "SensorsId");
        }
    }
}
