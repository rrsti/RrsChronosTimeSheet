using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGuidFkAndNoCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfissionalToComentarioTarefa",
                table: "TbComentarioTarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_TarefasToComentarioTarefa",
                table: "TbComentarioTarefa");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfissionalToComentarioTarefa",
                table: "TbComentarioTarefa",
                column: "ProfissionalId",
                principalTable: "TbProfissional",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TarefasToComentarioTarefa",
                table: "TbComentarioTarefa",
                column: "TarefaId",
                principalTable: "TbTarefas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfissionalToComentarioTarefa",
                table: "TbComentarioTarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_TarefasToComentarioTarefa",
                table: "TbComentarioTarefa");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfissionalToComentarioTarefa",
                table: "TbComentarioTarefa",
                column: "ProfissionalId",
                principalTable: "TbProfissional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TarefasToComentarioTarefa",
                table: "TbComentarioTarefa",
                column: "TarefaId",
                principalTable: "TbTarefas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
