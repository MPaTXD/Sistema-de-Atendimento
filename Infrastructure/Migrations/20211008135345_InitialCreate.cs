using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operador",
                columns: table => new
                {
                    IdOperador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula_Operador = table.Column<int>(type: "int", nullable: false),
                    Nome_Operador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Atendimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operador", x => x.IdOperador);
                });

            migrationBuilder.CreateTable(
                name: "Ordem",
                columns: table => new
                {
                    IdOrdem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo_Ordem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Solicitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Motivo_Solicitacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Atendimemto = table.Column<int>(type: "int", nullable: false),
                    OrdemStatus = table.Column<int>(type: "int", nullable: false),
                    DOrdemGerada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DOrdemFinalizada = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordem", x => x.IdOrdem);
                });

            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    IdAtendimento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Protocolo_Atendimento = table.Column<int>(type: "int", nullable: false),
                    DAtendimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusAtendimento = table.Column<int>(type: "int", nullable: false),
                    OrdemId = table.Column<int>(type: "int", nullable: false),
                    OperadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.IdAtendimento);
                    table.ForeignKey(
                        name: "FK_Atendimento_Operador_OperadorId",
                        column: x => x.OperadorId,
                        principalTable: "Operador",
                        principalColumn: "IdOperador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atendimento_Ordem_OrdemId",
                        column: x => x.OrdemId,
                        principalTable: "Ordem",
                        principalColumn: "IdOrdem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    IdTelefone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DDD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrdemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.IdTelefone);
                    table.ForeignKey(
                        name: "FK_Telefone_Ordem_OrdemId",
                        column: x => x.OrdemId,
                        principalTable: "Ordem",
                        principalColumn: "IdOrdem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_OperadorId",
                table: "Atendimento",
                column: "OperadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_OrdemId",
                table: "Atendimento",
                column: "OrdemId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_OrdemId",
                table: "Telefone",
                column: "OrdemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimento");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Operador");

            migrationBuilder.DropTable(
                name: "Ordem");
        }
    }
}
