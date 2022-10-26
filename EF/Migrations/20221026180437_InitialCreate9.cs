using Microsoft.EntityFrameworkCore.Migrations;

namespace entiframe.Migrations
{
    public partial class InitialCreate9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TempSensors",
                table: "TempSensors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sensors",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sensors");

            migrationBuilder.RenameTable(
                name: "TempSensors",
                newName: "PapasTempSensor");

            migrationBuilder.RenameTable(
                name: "Sensors",
                newName: "olderSensors");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FluentApiTable",
                newName: "MyName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PapasTempSensor",
                table: "PapasTempSensor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_olderSensors",
                table: "olderSensors",
                column: "SensorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PapasTempSensor",
                table: "PapasTempSensor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_olderSensors",
                table: "olderSensors");

            migrationBuilder.RenameTable(
                name: "PapasTempSensor",
                newName: "TempSensors");

            migrationBuilder.RenameTable(
                name: "olderSensors",
                newName: "Sensors");

            migrationBuilder.RenameColumn(
                name: "MyName",
                table: "FluentApiTable",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sensors",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TempSensors",
                table: "TempSensors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sensors",
                table: "Sensors",
                column: "SensorsId");
        }
    }
}
