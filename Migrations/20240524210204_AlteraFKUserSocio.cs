using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSI_BE.Migrations
{
    /// <inheritdoc />
    public partial class AlteraFKUserSocio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaioridadeCivil",
                table: "Socio");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Socio",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Socio",
                newName: "UserEmail");

            migrationBuilder.AddColumn<string>(
                name: "MaioridadeCivil",
                table: "Socio",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
