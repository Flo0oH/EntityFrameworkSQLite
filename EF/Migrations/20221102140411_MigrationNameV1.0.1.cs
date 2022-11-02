using Microsoft.EntityFrameworkCore.Migrations;

namespace entiframe.Migrations
{
    public partial class MigrationNameV101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Identifier = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LoginName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    SensorsId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Room = table.Column<string>(nullable: true),
                    RoomNr = table.Column<int>(nullable: false),
                    LoginId = table.Column<int>(nullable: true),
                    LoginsForeignKeys = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.SensorsId);
                    table.ForeignKey(
                        name: "FK_Sensors_Logins_LoginsForeignKeys",
                        column: x => x.LoginsForeignKeys,
                        principalTable: "Logins",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TempSensors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Temperaturedate = table.Column<string>(nullable: true),
                    Temperature = table.Column<float>(nullable: false),
                    Sensornr = table.Column<int>(nullable: false),
                    SensorsId = table.Column<int>(nullable: true),
                    SensorsForeignKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempSensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TempSensors_Sensors_SensorsForeignKey",
                        column: x => x.SensorsForeignKey,
                        principalTable: "Sensors",
                        principalColumn: "SensorsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_LoginsForeignKeys",
                table: "Sensors",
                column: "LoginsForeignKeys");

            migrationBuilder.CreateIndex(
                name: "IX_TempSensors_SensorsForeignKey",
                table: "TempSensors",
                column: "SensorsForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempSensors");

            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "Logins");
        }
    }
}
