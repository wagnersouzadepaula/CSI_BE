using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSI_BE.Migrations
{
    /// <inheritdoc />
    public partial class AlteraDateNaPJ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "PrazoInicialDeDuracao",
                table: "PessoaJuridica",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PrazoInicialDeDuracao",
                table: "PessoaJuridica",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
