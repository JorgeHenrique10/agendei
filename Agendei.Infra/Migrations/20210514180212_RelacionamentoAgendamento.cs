using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agendei.Infra.Migrations
{
    public partial class RelacionamentoAgendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedimentos_Agendamentos_AgendamentoId",
                table: "Procedimentos");

            migrationBuilder.DropIndex(
                name: "IX_Procedimentos_AgendamentoId",
                table: "Procedimentos");

            migrationBuilder.DropColumn(
                name: "AgendamentoId",
                table: "Procedimentos");

            migrationBuilder.CreateTable(
                name: "AgendamentoProcedimento",
                columns: table => new
                {
                    AgendamentosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcedimentosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentoProcedimento", x => new { x.AgendamentosId, x.ProcedimentosId });
                    table.ForeignKey(
                        name: "FK_AgendamentoProcedimento_Agendamentos_AgendamentosId",
                        column: x => x.AgendamentosId,
                        principalTable: "Agendamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentoProcedimento_Procedimentos_ProcedimentosId",
                        column: x => x.ProcedimentosId,
                        principalTable: "Procedimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoProcedimento_ProcedimentosId",
                table: "AgendamentoProcedimento",
                column: "ProcedimentosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendamentoProcedimento");

            migrationBuilder.AddColumn<Guid>(
                name: "AgendamentoId",
                table: "Procedimentos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_AgendamentoId",
                table: "Procedimentos",
                column: "AgendamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedimentos_Agendamentos_AgendamentoId",
                table: "Procedimentos",
                column: "AgendamentoId",
                principalTable: "Agendamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
