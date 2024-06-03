using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CSI_BE.Migrations
{
    /// <inheritdoc />
    public partial class pessoasjuridicas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PessoaJuridica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrazoInicialDeDuracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Socio1Id = table.Column<int>(type: "integer", nullable: false),
                    Socio2Id = table.Column<int>(type: "integer", nullable: false),
                    QuotaSocio1 = table.Column<int>(type: "integer", nullable: false),
                    QuotaSocio2 = table.Column<int>(type: "integer", nullable: false),
                    CnaeId = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Endereco = table.Column<string>(type: "text", nullable: false),
                    NroImovel = table.Column<string>(type: "text", nullable: false),
                    Complemento = table.Column<string>(type: "text", nullable: true),
                    Bairro = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Uf = table.Column<string>(type: "text", nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaJuridica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_Cnae_CnaeId",
                        column: x => x.CnaeId,
                        principalTable: "Cnae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_Socio_Socio1Id",
                        column: x => x.Socio1Id,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_Socio_Socio2Id",
                        column: x => x.Socio2Id,
                        principalTable: "Socio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PessoaJuridica");
        }
    }
}
