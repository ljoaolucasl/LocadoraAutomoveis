using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraAutomoveis.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class AddTBPlanoCobranca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPlanoCobranca",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorDia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorKmRodado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KmLivre = table.Column<int>(type: "int", nullable: false),
                    Plano = table.Column<int>(type: "int", nullable: false),
                    CategoriaAutomoveisID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoCobranca", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBPlanoCobranca_TBCategoriaAutomoveis",
                        column: x => x.CategoriaAutomoveisID,
                        principalTable: "TBCategoriaAutomoveis",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoCobranca_CategoriaAutomoveisID",
                table: "TBPlanoCobranca",
                column: "CategoriaAutomoveisID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPlanoCobranca");
        }
    }
}
