using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraAutomoveis.Infraestrutura.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:LocadoraAutomoveis.Infraestrutura/Migrations/20230804194701_add-TBCondutor-TBCliente.cs
    public partial class addTBCondutorTBCliente : Migration
========
    public partial class AddTBCliente : Migration
>>>>>>>> 1b20a84826b1df6b62bd9796606702f63e7be758:LocadoraAutomoveis.Infraestrutura/Migrations/20230804200016_Add-TBCliente.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_ClienteID",
                table: "TBCondutor",
                column: "ClienteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCondutor");

            migrationBuilder.DropTable(
                name: "TBCliente");
        }
    }
}
