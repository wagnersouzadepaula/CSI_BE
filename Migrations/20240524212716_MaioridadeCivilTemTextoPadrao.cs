using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSI_BE.Migrations
{
    /// <inheritdoc />
    public partial class MaioridadeCivilTemTextoPadrao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaioridadeCivil",
                table: "Socio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaioridadeCivil",
                table: "Socio",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
