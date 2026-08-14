using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbFuncao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Observacao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbFuncao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbStatusProjeto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbStatusProjeto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbStatusTarefa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbStatusTarefa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbTipoProjeto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTipoProjeto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbTipoTelefone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTipoTelefone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbUnidadeFederativa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sigla = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbUnidadeFederativa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    NomeFantasia = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Cnpj = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    InscricaoMunicipal = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Cep = table.Column<string>(type: "varchar(255)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    UnidadeFederativaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnidadeFederativaToCliente",
                        column: x => x.UnidadeFederativaId,
                        principalTable: "TbUnidadeFederativa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TbFornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    NomeFantasia = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Cnpj = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    InscricaoMunicipal = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Cep = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Complemento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    UnidadeFederativaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbFornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnidadeFederativaToFornecedor",
                        column: x => x.UnidadeFederativaId,
                        principalTable: "TbUnidadeFederativa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbEmailCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    ContatoEmail = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbEmailCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailClienteToCliente",
                        column: x => x.ClienteId,
                        principalTable: "TbCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TbTelefoneCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroTelefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    NomeContato = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    TipoTelefoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WhatsApp = table.Column<bool>(type: "bit", nullable: false),
                    Telegram = table.Column<bool>(type: "bit", nullable: false),
                    IsPrincipal = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTelefoneCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteToTelefoneCliente",
                        column: x => x.ClienteId,
                        principalTable: "TbCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TipoTelefoneToTelefoneCliente",
                        column: x => x.TipoTelefoneId,
                        principalTable: "TbTipoTelefone",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbEmailFornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ContatoEmail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbEmailFornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailFornecedorToFornecedor",
                        column: x => x.FornecedorId,
                        principalTable: "TbFornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TbProfissional",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Rg = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nacionalidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    UfNaturalidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FuncaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cep = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    UnidadeFederativaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProfissionalTerceirizado = table.Column<bool>(type: "bit", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProfissional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FornecedorToProfissional",
                        column: x => x.FornecedorId,
                        principalTable: "TbFornecedor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FuncaoToProfissional",
                        column: x => x.FuncaoId,
                        principalTable: "TbFuncao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UnidadeFederativaToResidencia",
                        column: x => x.UnidadeFederativaId,
                        principalTable: "TbUnidadeFederativa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UnidadeFederativaToUfNaturalidade",
                        column: x => x.UfNaturalidadeId,
                        principalTable: "TbUnidadeFederativa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbTelefoneFornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroTelefone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    NomeContato = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TipoTelefoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WhatsApp = table.Column<bool>(type: "bit", nullable: false),
                    Telegram = table.Column<bool>(type: "bit", nullable: false),
                    IsPrincipal = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTelefoneFornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FornecedorToTelefoneFornecedor",
                        column: x => x.FornecedorId,
                        principalTable: "TbFornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TipoTelefoneToTelefoneFornecedor",
                        column: x => x.TipoTelefoneId,
                        principalTable: "TbTipoTelefone",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbEmailProfissional",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ContatoEmail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ProfissionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbEmailProfissional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailProfissionalToProfissional",
                        column: x => x.ProfissionalId,
                        principalTable: "TbProfissional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TbProjeto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Orçamento = table.Column<float>(type: "real", nullable: false),
                    QtdHorasEstimadas = table.Column<float>(type: "real", nullable: false),
                    ResponsavelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProjeto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteToProjeto",
                        column: x => x.ClienteId,
                        principalTable: "TbCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProfissionalToProjeto",
                        column: x => x.ResponsavelId,
                        principalTable: "TbProfissional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StatusProjetoToProjeto",
                        column: x => x.StatusId,
                        principalTable: "TbStatusProjeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TipoProjetoToProjeto",
                        column: x => x.TipoId,
                        principalTable: "TbTipoProjeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TbTelefoneProfissional",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfissionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroTelefone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    NomeContato = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TipoTelefoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WhatsApp = table.Column<bool>(type: "bit", nullable: false),
                    Telegram = table.Column<bool>(type: "bit", nullable: false),
                    IsPrincipal = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTelefoneProfissional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfissionalToTelefoneProfissional",
                        column: x => x.ProfissionalId,
                        principalTable: "TbProfissional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TipoTelefoneToTelefoneProfissional",
                        column: x => x.TipoTelefoneId,
                        principalTable: "TbTipoTelefone",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbTarefas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    ResponsavelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QtdHorasEstimadas = table.Column<float>(type: "real", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfissionalToTarefas",
                        column: x => x.ResponsavelId,
                        principalTable: "TbProfissional",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjetoToTarefas",
                        column: x => x.ProjetoId,
                        principalTable: "TbProjeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StatusTarefaToTarefas",
                        column: x => x.StatusId,
                        principalTable: "TbStatusTarefa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbComentarioTarefa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TarefaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfissionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comentario = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbComentarioTarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfissionalToComentarioTarefa",
                        column: x => x.ProfissionalId,
                        principalTable: "TbProfissional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TarefasToComentarioTarefa",
                        column: x => x.TarefaId,
                        principalTable: "TbTarefas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TbHorasProfissional",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TarefaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfissionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<double>(type: "float", nullable: false),
                    HoraFim = table.Column<double>(type: "float", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbHorasProfissional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfissionalToHorasProfissional",
                        column: x => x.ProfissionalId,
                        principalTable: "TbProfissional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TarefasToHorasProfissional",
                        column: x => x.TarefaId,
                        principalTable: "TbTarefas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbCliente_UnidadeFederativaId",
                table: "TbCliente",
                column: "UnidadeFederativaId");

            migrationBuilder.CreateIndex(
                name: "IX_TbComentarioTarefa_ProfissionalId",
                table: "TbComentarioTarefa",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_TbComentarioTarefa_TarefaId",
                table: "TbComentarioTarefa",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_TbEmailCliente_ClienteId",
                table: "TbEmailCliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TbEmailFornecedor_FornecedorId",
                table: "TbEmailFornecedor",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_TbEmailProfissional_ProfissionalId",
                table: "TbEmailProfissional",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_TbFornecedor_UnidadeFederativaId",
                table: "TbFornecedor",
                column: "UnidadeFederativaId");

            migrationBuilder.CreateIndex(
                name: "IX_TbHorasProfissional_ProfissionalId",
                table: "TbHorasProfissional",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_TbHorasProfissional_TarefaId",
                table: "TbHorasProfissional",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProfissional_FornecedorId",
                table: "TbProfissional",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProfissional_FuncaoId",
                table: "TbProfissional",
                column: "FuncaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProfissional_UfNaturalidadeId",
                table: "TbProfissional",
                column: "UfNaturalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProfissional_UnidadeFederativaId",
                table: "TbProfissional",
                column: "UnidadeFederativaId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProjeto_ClienteId",
                table: "TbProjeto",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProjeto_ResponsavelId",
                table: "TbProjeto",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProjeto_StatusId",
                table: "TbProjeto",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProjeto_TipoId",
                table: "TbProjeto",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_TbTarefas_ProjetoId",
                table: "TbTarefas",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_TbTarefas_ResponsavelId",
                table: "TbTarefas",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_TbTarefas_StatusId",
                table: "TbTarefas",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TbTelefoneCliente_ClienteId",
                table: "TbTelefoneCliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TbTelefoneCliente_TipoTelefoneId",
                table: "TbTelefoneCliente",
                column: "TipoTelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_TbTelefoneFornecedor_FornecedorId",
                table: "TbTelefoneFornecedor",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_TbTelefoneFornecedor_TipoTelefoneId",
                table: "TbTelefoneFornecedor",
                column: "TipoTelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_TbTelefoneProfissional_ProfissionalId",
                table: "TbTelefoneProfissional",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_TbTelefoneProfissional_TipoTelefoneId",
                table: "TbTelefoneProfissional",
                column: "TipoTelefoneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbComentarioTarefa");

            migrationBuilder.DropTable(
                name: "TbEmailCliente");

            migrationBuilder.DropTable(
                name: "TbEmailFornecedor");

            migrationBuilder.DropTable(
                name: "TbEmailProfissional");

            migrationBuilder.DropTable(
                name: "TbHorasProfissional");

            migrationBuilder.DropTable(
                name: "TbTelefoneCliente");

            migrationBuilder.DropTable(
                name: "TbTelefoneFornecedor");

            migrationBuilder.DropTable(
                name: "TbTelefoneProfissional");

            migrationBuilder.DropTable(
                name: "TbTarefas");

            migrationBuilder.DropTable(
                name: "TbTipoTelefone");

            migrationBuilder.DropTable(
                name: "TbProjeto");

            migrationBuilder.DropTable(
                name: "TbStatusTarefa");

            migrationBuilder.DropTable(
                name: "TbCliente");

            migrationBuilder.DropTable(
                name: "TbProfissional");

            migrationBuilder.DropTable(
                name: "TbStatusProjeto");

            migrationBuilder.DropTable(
                name: "TbTipoProjeto");

            migrationBuilder.DropTable(
                name: "TbFornecedor");

            migrationBuilder.DropTable(
                name: "TbFuncao");

            migrationBuilder.DropTable(
                name: "TbUnidadeFederativa");
        }
    }
}
