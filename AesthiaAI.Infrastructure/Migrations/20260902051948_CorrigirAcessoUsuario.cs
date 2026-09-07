using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AesthiaAI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirAcessoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cliente_Acesso",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Acesso",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Acesso",
                table: "Usuarios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Cliente_Acesso",
                table: "Usuarios",
                type: "text",
                nullable: true);
        }
    }
}
