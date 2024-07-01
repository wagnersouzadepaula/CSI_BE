using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSI_BE.Migrations
{
    /// <inheritdoc />
    public partial class contratoSocialCodVerificador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodVerificador",
                table: "ContratoSocial",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodVerificador",
                table: "ContratoSocial");
        }
    }
}
