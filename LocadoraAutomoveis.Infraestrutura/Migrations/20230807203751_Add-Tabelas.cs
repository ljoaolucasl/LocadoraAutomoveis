using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraAutomoveis.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class AddTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCategoriaAutomoveis",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCategoriaAutomoveis", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBCliente",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    TipoCliente = table.Column<int>(type: "int", nullable: false),
                    Documento = table.Column<string>(type: "varchar(20)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(60)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(120)", nullable: false),
                    Rua = table.Column<string>(type: "varchar(100)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCliente", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBFuncionario",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Admissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFuncionario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBParceiro",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBParceiro", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBTaxaEServico",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTaxaEServico", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBAutomovel",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Placa = table.Column<string>(type: "varchar(20)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cor = table.Column<string>(type: "varchar(100)", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Imagem = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    TipoCombustivel = table.Column<int>(type: "int", nullable: false),
                    CapacidadeCombustivel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Quilometragem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Alugado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAutomovel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBAutomovel_TBCategoriaAutomoveis",
                        column: x => x.CategoriaID,
                        principalTable: "TBCategoriaAutomoveis",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TBPlanoCobranca",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoDiario_ValorDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanoDiario_ValorKm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanoLivre_ValorDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanoControlador_ValorDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanoControlador_ValorKm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanoControlador_LimiteKm = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "TBCondutor",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoCondutor = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(20)", nullable: false),
                    CNH = table.Column<string>(type: "varchar(30)", nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCondutor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBCondutor_TBCliente",
                        column: x => x.ClienteID,
                        principalTable: "TBCliente",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TBCupom",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParceiroID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QtdUsos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCupom", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBCupom_TBParceiro",
                        column: x => x.ParceiroID,
                        principalTable: "TBParceiro",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TBAluguel",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaAutomoveisID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoCobrancaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondutorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AutomovelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CupomID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataLocacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPrevistaRetorno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuilometrosRodados = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CombustivelRestante = table.Column<int>(type: "int", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Concluido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAluguel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBAutomovel",
                        column: x => x.AutomovelID,
                        principalTable: "TBAutomovel",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBCategoriaAutomoveis",
                        column: x => x.CategoriaAutomoveisID,
                        principalTable: "TBCategoriaAutomoveis",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBCliente",
                        column: x => x.ClienteID,
                        principalTable: "TBCliente",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBCondutor",
                        column: x => x.CondutorID,
                        principalTable: "TBCondutor",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBCupom",
                        column: x => x.CupomID,
                        principalTable: "TBCupom",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBFuncionario",
                        column: x => x.FuncionarioID,
                        principalTable: "TBFuncionario",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBPlanoCobranca",
                        column: x => x.PlanoCobrancaID,
                        principalTable: "TBPlanoCobranca",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FK_TBAluguel_TBTaxaEServico",
                columns: table => new
                {
                    AluguelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ListaTaxasEServicosID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FK_TBAluguel_TBTaxaEServico", x => new { x.AluguelID, x.ListaTaxasEServicosID });
                    table.ForeignKey(
                        name: "FK_FK_TBAluguel_TBTaxaEServico_TBAluguel_AluguelID",
                        column: x => x.AluguelID,
                        principalTable: "TBAluguel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FK_TBAluguel_TBTaxaEServico_TBTaxaEServico_ListaTaxasEServicosID",
                        column: x => x.ListaTaxasEServicosID,
                        principalTable: "TBTaxaEServico",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FK_TBAluguel_TBTaxaEServico_ListaTaxasEServicosID",
                table: "FK_TBAluguel_TBTaxaEServico",
                column: "ListaTaxasEServicosID");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_AutomovelID",
                table: "TBAluguel",
                column: "AutomovelID");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_CategoriaAutomoveisID",
                table: "TBAluguel",
                column: "CategoriaAutomoveisID");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_ClienteID",
                table: "TBAluguel",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_CondutorID",
                table: "TBAluguel",
                column: "CondutorID");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_CupomID",
                table: "TBAluguel",
                column: "CupomID");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_FuncionarioID",
                table: "TBAluguel",
                column: "FuncionarioID");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_PlanoCobrancaID",
                table: "TBAluguel",
                column: "PlanoCobrancaID");

            migrationBuilder.CreateIndex(
                name: "IX_TBAutomovel_CategoriaID",
                table: "TBAutomovel",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_ClienteID",
                table: "TBCondutor",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_TBCupom_ParceiroID",
                table: "TBCupom",
                column: "ParceiroID");

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoCobranca_CategoriaAutomoveisID",
                table: "TBPlanoCobranca",
                column: "CategoriaAutomoveisID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FK_TBAluguel_TBTaxaEServico");

            migrationBuilder.DropTable(
                name: "TBAluguel");

            migrationBuilder.DropTable(
                name: "TBTaxaEServico");

            migrationBuilder.DropTable(
                name: "TBAutomovel");

            migrationBuilder.DropTable(
                name: "TBCondutor");

            migrationBuilder.DropTable(
                name: "TBCupom");

            migrationBuilder.DropTable(
                name: "TBFuncionario");

            migrationBuilder.DropTable(
                name: "TBPlanoCobranca");

            migrationBuilder.DropTable(
                name: "TBCliente");

            migrationBuilder.DropTable(
                name: "TBParceiro");

            migrationBuilder.DropTable(
                name: "TBCategoriaAutomoveis");
        }
    }
}
