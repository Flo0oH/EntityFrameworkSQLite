using Microsoft.EntityFrameworkCore.Migrations;

namespace entiframe.Migrations
{
    public partial class InitialCreate13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sensors",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Identifier",
                table: "Logins",
                type: "date",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sensors");

            migrationBuilder.AlterColumn<int>(
                name: "Identifier",
                table: "Logins",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "date")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);
        }
    }
}
