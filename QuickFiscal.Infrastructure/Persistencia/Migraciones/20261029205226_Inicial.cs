using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickFiscal.Infrastructure.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rnc = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    Ncf = table.Column<string>(type: "TEXT", maxLength: 13, nullable: true),
                    Fecha = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Itbis = table.Column<decimal>(type: "TEXT", nullable: true),
                    Total = table.Column<decimal>(type: "TEXT", nullable: true),
                    Categoria = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FormaPago = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Dudas = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_Rnc_Ncf",
                table: "Facturas",
                columns: new[] { "Rnc", "Ncf" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturas");
        }
    }
}
