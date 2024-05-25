using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSI_BE.Migrations
{
    /// <inheritdoc />
    public partial class InsereMaioridadeCivilNoSocio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaioridadeCivil",
                table: "Socio",
                type: "text",
                nullable: false,
                defaultValue: "maior de idade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaioridadeCivil",
                table: "Socio");
        }
    }
}
