using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class NoCascadeGlobal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnidadeFederativaToCliente",
                table: "TbCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailClienteToCliente",
                table: "TbEmailCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailFornecedorToFornecedor",
                table: "TbEmailFornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailProfissionalToProfissional",
                table: "TbEmailProfissional");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfissionalToHorasProfissional",
                table: "TbHorasProfissional");

            migrationBuilder.DropForeignKey(
                name: "FK_TarefasToHorasProfissional",
                table: "TbHorasProfissional");

            migrationBuilder.DropForeignKey(
                name: "FK_ClienteToProjeto",
                table: "TbProjeto");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfissionalToProjeto",
                table: "TbProjeto");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusProjetoToProjeto",
                table: "TbProjeto");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoProjetoToProjeto",
                table: "TbProjeto");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjetoToTarefas",
                table: "TbTarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_ClienteToTelefoneCliente",
                table: "TbTelefoneCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_FornecedorToTelefoneFornecedor",
                table: "TbTelefoneFornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfissionalToTelefoneProfissional",
                table: "TbTelefoneProfissional");

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadeFederativaToCliente",
                table: "TbCliente",
                column: "UnidadeFederativaId",
                principalTable: "TbUnidadeFederativa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailClienteToCliente",
                table: "TbEmailCliente",
                column: "ClienteId",
                principalTable: "TbCliente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailFornecedorToFornecedor",
                table: "TbEmailFornecedor",
                column: "FornecedorId",
                principalTable: "TbFornecedor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailProfissionalToProfissional",
                table: "TbEmailProfissional",
                column: "ProfissionalId",
                principalTable: "TbProfissional",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfissionalToHorasProfissional",
                table: "TbHorasProfissional",
                column: "ProfissionalId",
                principalTable: "TbProfissional",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TarefasToHorasProfissional",
                table: "TbHorasProfissional",
                column: "TarefaId",
                principalTable: "TbTarefas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClienteToProjeto",
                table: "TbProjeto",
                column: "ClienteId",
                principalTable: "TbCliente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfissionalToProjeto",
                table: "TbProjeto",
                column: "ResponsavelId",
                principalTable: "TbProfissional",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusProjetoToProjeto",
                table: "TbProjeto",
                column: "StatusId",
                principalTable: "TbStatusProjeto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoProjetoToProjeto",
                table: "TbProjeto",
                column: "TipoId",
                principalTable: "TbTipoProjeto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjetoToTarefas",
                table: "TbTarefas",
                column: "ProjetoId",
                principalTable: "TbProjeto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClienteToTelefoneCliente",
                table: "TbTelefoneCliente",
                column: "ClienteId",
                principalTable: "TbCliente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FornecedorToTelefoneFornecedor",
                table: "TbTelefoneFornecedor",
                column: "FornecedorId",
                principalTable: "TbFornecedor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfissionalToTelefoneProfissional",
                table: "TbTelefoneProfissional",
                column: "ProfissionalId",
                principalTable: "TbProfissional",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnidadeFederativaToCliente",
                table: "TbCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailClienteToCliente",
                table: "TbEmailCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailFornecedorToFornecedor",
                table: "TbEmailFornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailProfissionalToProfissional",
                table: "TbEmailProfissional");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfissionalToHorasProfissional",
                table: "TbHorasProfissional");

            migrationBuilder.DropForeignKey(
                name: "FK_TarefasToHorasProfissional",
                table: "TbHorasProfissional");

            migrationBuilder.DropForeignKey(
                name: "FK_ClienteToProjeto",
                table: "TbProjeto");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfissionalToProjeto",
                table: "TbProjeto");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusProjetoToProjeto",
                table: "TbProjeto");

            migrationBuilder.DropForeignKey(
                name: "FK_TipoProjetoToProjeto",
                table: "TbProjeto");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjetoToTarefas",
                table: "TbTarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_ClienteToTelefoneCliente",
                table: "TbTelefoneCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_FornecedorToTelefoneFornecedor",
                table: "TbTelefoneFornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfissionalToTelefoneProfissional",
                table: "TbTelefoneProfissional");

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadeFederativaToCliente",
                table: "TbCliente",
                column: "UnidadeFederativaId",
                principalTable: "TbUnidadeFederativa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailClienteToCliente",
                table: "TbEmailCliente",
                column: "ClienteId",
                principalTable: "TbCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailFornecedorToFornecedor",
                table: "TbEmailFornecedor",
                column: "FornecedorId",
                principalTable: "TbFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailProfissionalToProfissional",
                table: "TbEmailProfissional",
                column: "ProfissionalId",
                principalTable: "TbProfissional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfissionalToHorasProfissional",
                table: "TbHorasProfissional",
                column: "ProfissionalId",
                principalTable: "TbProfissional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TarefasToHorasProfissional",
                table: "TbHorasProfissional",
                column: "TarefaId",
                principalTable: "TbTarefas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClienteToProjeto",
                table: "TbProjeto",
                column: "ClienteId",
                principalTable: "TbCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfissionalToProjeto",
                table: "TbProjeto",
                column: "ResponsavelId",
                principalTable: "TbProfissional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatusProjetoToProjeto",
                table: "TbProjeto",
                column: "StatusId",
                principalTable: "TbStatusProjeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoProjetoToProjeto",
                table: "TbProjeto",
                column: "TipoId",
                principalTable: "TbTipoProjeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjetoToTarefas",
                table: "TbTarefas",
                column: "ProjetoId",
                principalTable: "TbProjeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClienteToTelefoneCliente",
                table: "TbTelefoneCliente",
                column: "ClienteId",
                principalTable: "TbCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FornecedorToTelefoneFornecedor",
                table: "TbTelefoneFornecedor",
                column: "FornecedorId",
                principalTable: "TbFornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfissionalToTelefoneProfissional",
                table: "TbTelefoneProfissional",
                column: "ProfissionalId",
                principalTable: "TbProfissional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
