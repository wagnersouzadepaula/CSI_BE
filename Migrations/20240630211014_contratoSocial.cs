using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CSI_BE.Migrations
{
    /// <inheritdoc />
    public partial class contratoSocial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PessoaJuridica_Cnae_CnaeId",
                table: "PessoaJuridica");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaJuridica_Socio_Socio1Id",
                table: "PessoaJuridica");

            migrationBuilder.DropForeignKey(
                name: "FK_PessoaJuridica_Socio_Socio2Id",
                table: "PessoaJuridica");

            migrationBuilder.DropIndex(
                name: "IX_PessoaJuridica_CnaeId",
                table: "PessoaJuridica");

            migrationBuilder.DropIndex(
                name: "IX_PessoaJuridica_Socio1Id",
                table: "PessoaJuridica");

            migrationBuilder.DropIndex(
                name: "IX_PessoaJuridica_Socio2Id",
                table: "PessoaJuridica");

            migrationBuilder.CreateTable(
                name: "ContratoSocial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pdf = table.Column<byte[]>(type: "bytea", nullable: true),
                    PessoaJuridicaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoSocial", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContratoSocial");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_CnaeId",
                table: "PessoaJuridica",
                column: "CnaeId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_Socio1Id",
                table: "PessoaJuridica",
                column: "Socio1Id");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaJuridica_Socio2Id",
                table: "PessoaJuridica",
                column: "Socio2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaJuridica_Cnae_CnaeId",
                table: "PessoaJuridica",
                column: "CnaeId",
                principalTable: "Cnae",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaJuridica_Socio_Socio1Id",
                table: "PessoaJuridica",
                column: "Socio1Id",
                principalTable: "Socio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PessoaJuridica_Socio_Socio2Id",
                table: "PessoaJuridica",
                column: "Socio2Id",
                principalTable: "Socio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
