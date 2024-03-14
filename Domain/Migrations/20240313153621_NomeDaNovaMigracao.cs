using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class NomeDaNovaMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdivinhaInteiro",
                table: "AdivinhaInteiro");

            migrationBuilder.AlterColumn<int>(
                name: "COD_JOGADOR",
                table: "AdivinhaInteiro",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AdivinhaInteiro",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdivinhaInteiro",
                table: "AdivinhaInteiro",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AdivinhaInteiro",
                table: "AdivinhaInteiro");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AdivinhaInteiro");

            migrationBuilder.AlterColumn<int>(
                name: "COD_JOGADOR",
                table: "AdivinhaInteiro",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdivinhaInteiro",
                table: "AdivinhaInteiro",
                column: "COD_JOGADOR");
        }
    }
}
