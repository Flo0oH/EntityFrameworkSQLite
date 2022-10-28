using Microsoft.EntityFrameworkCore.Migrations;

namespace entiframe.Migrations
{
    public partial class MigrationNameV100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Identifier",
                table: "Logins",
                type: "Int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "date")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Identifier",
                table: "Logins",
                type: "date",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "Int")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);
        }
    }
}
