IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [TbFuncao] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Descricao] varchar(500) NOT NULL,
    [Observacao] varchar(500) NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbFuncao] PRIMARY KEY ([Id])
);

CREATE TABLE [TbStatusProjeto] (
    [Id] uniqueidentifier NOT NULL,
    [Descricao] varchar(100) NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbStatusProjeto] PRIMARY KEY ([Id])
);

CREATE TABLE [TbStatusTarefa] (
    [Id] uniqueidentifier NOT NULL,
    [Descricao] varchar(100) NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbStatusTarefa] PRIMARY KEY ([Id])
);

CREATE TABLE [TbTipoProjeto] (
    [Id] uniqueidentifier NOT NULL,
    [Descricao] varchar(100) NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbTipoProjeto] PRIMARY KEY ([Id])
);

CREATE TABLE [TbTipoTelefone] (
    [Id] uniqueidentifier NOT NULL,
    [Descricao] varchar(100) NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbTipoTelefone] PRIMARY KEY ([Id])
);

CREATE TABLE [TbUnidadeFederativa] (
    [Id] uniqueidentifier NOT NULL,
    [Sigla] varchar(2) NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbUnidadeFederativa] PRIMARY KEY ([Id])
);

CREATE TABLE [TbCliente] (
    [Id] uniqueidentifier NOT NULL,
    [RazaoSocial] varchar(200) NOT NULL,
    [NomeFantasia] varchar(200) NULL,
    [Cnpj] varchar(14) NOT NULL,
    [InscricaoEstadual] varchar(20) NOT NULL,
    [InscricaoMunicipal] varchar(20) NOT NULL,
    [Logradouro] varchar(200) NOT NULL,
    [Numero] int NULL,
    [Cep] varchar(255) NOT NULL,
    [Complemento] varchar(100) NULL,
    [Bairro] varchar(100) NULL,
    [Cidade] varchar(100) NOT NULL,
    [UnidadeFederativaId] uniqueidentifier NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbCliente] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UnidadeFederativaToCliente] FOREIGN KEY ([UnidadeFederativaId]) REFERENCES [TbUnidadeFederativa] ([Id])
);

CREATE TABLE [TbFornecedor] (
    [Id] uniqueidentifier NOT NULL,
    [RazaoSocial] varchar(200) NOT NULL,
    [NomeFantasia] varchar(200) NULL,
    [Cnpj] varchar(14) NOT NULL,
    [InscricaoEstadual] varchar(20) NOT NULL,
    [InscricaoMunicipal] varchar(20) NOT NULL,
    [Logradouro] varchar(200) NOT NULL,
    [Numero] int NULL,
    [Cep] varchar(8) NOT NULL,
    [Complemento] varchar(100) NULL,
    [Bairro] varchar(100) NULL,
    [Cidade] varchar(100) NOT NULL,
    [UnidadeFederativaId] uniqueidentifier NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbFornecedor] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UnidadeFederativaToFornecedor] FOREIGN KEY ([UnidadeFederativaId]) REFERENCES [TbUnidadeFederativa] ([Id])
);

CREATE TABLE [TbEmailCliente] (
    [Id] uniqueidentifier NOT NULL,
    [Email] varchar(255) NOT NULL,
    [ContatoEmail] varchar(200) NOT NULL,
    [ClienteId] uniqueidentifier NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbEmailCliente] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EmailClienteToCliente] FOREIGN KEY ([ClienteId]) REFERENCES [TbCliente] ([Id])
);

CREATE TABLE [TbTelefoneCliente] (
    [Id] uniqueidentifier NOT NULL,
    [ClienteId] uniqueidentifier NOT NULL,
    [NumeroTelefone] varchar(20) NOT NULL,
    [NomeContato] varchar(200) NOT NULL,
    [TipoTelefoneId] uniqueidentifier NOT NULL,
    [WhatsApp] bit NOT NULL,
    [Telegram] bit NOT NULL,
    [IsPrincipal] bit NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbTelefoneCliente] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ClienteToTelefoneCliente] FOREIGN KEY ([ClienteId]) REFERENCES [TbCliente] ([Id]),
    CONSTRAINT [FK_TipoTelefoneToTelefoneCliente] FOREIGN KEY ([TipoTelefoneId]) REFERENCES [TbTipoTelefone] ([Id])
);

CREATE TABLE [TbEmailFornecedor] (
    [Id] uniqueidentifier NOT NULL,
    [Email] varchar(200) NOT NULL,
    [ContatoEmail] varchar(100) NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbEmailFornecedor] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EmailFornecedorToFornecedor] FOREIGN KEY ([FornecedorId]) REFERENCES [TbFornecedor] ([Id])
);

CREATE TABLE [TbProfissional] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Cpf] varchar(11) NOT NULL,
    [Rg] varchar(12) NULL,
    [DataNascimento] datetime2 NOT NULL,
    [Nacionalidade] varchar(100) NULL,
    [UfNaturalidadeId] uniqueidentifier NULL,
    [FuncaoId] uniqueidentifier NULL,
    [Cep] varchar(8) NOT NULL,
    [Logradouro] varchar(200) NOT NULL,
    [Numero] int NULL,
    [Complemento] varchar(100) NULL,
    [Cidade] varchar(100) NULL,
    [Bairro] varchar(100) NULL,
    [UnidadeFederativaId] uniqueidentifier NULL,
    [ProfissionalTerceirizado] bit NOT NULL,
    [FornecedorId] uniqueidentifier NULL,
    [Foto] varbinary(max) NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbProfissional] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_FornecedorToProfissional] FOREIGN KEY ([FornecedorId]) REFERENCES [TbFornecedor] ([Id]),
    CONSTRAINT [FK_FuncaoToProfissional] FOREIGN KEY ([FuncaoId]) REFERENCES [TbFuncao] ([Id]),
    CONSTRAINT [FK_UnidadeFederativaToResidencia] FOREIGN KEY ([UnidadeFederativaId]) REFERENCES [TbUnidadeFederativa] ([Id]),
    CONSTRAINT [FK_UnidadeFederativaToUfNaturalidade] FOREIGN KEY ([UfNaturalidadeId]) REFERENCES [TbUnidadeFederativa] ([Id])
);

CREATE TABLE [TbTelefoneFornecedor] (
    [Id] uniqueidentifier NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    [NumeroTelefone] varchar(15) NOT NULL,
    [NomeContato] varchar(100) NOT NULL,
    [TipoTelefoneId] uniqueidentifier NOT NULL,
    [WhatsApp] bit NOT NULL,
    [Telegram] bit NOT NULL,
    [IsPrincipal] bit NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbTelefoneFornecedor] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_FornecedorToTelefoneFornecedor] FOREIGN KEY ([FornecedorId]) REFERENCES [TbFornecedor] ([Id]),
    CONSTRAINT [FK_TipoTelefoneToTelefoneFornecedor] FOREIGN KEY ([TipoTelefoneId]) REFERENCES [TbTipoTelefone] ([Id])
);

CREATE TABLE [TbEmailProfissional] (
    [Id] uniqueidentifier NOT NULL,
    [Email] varchar(200) NOT NULL,
    [ContatoEmail] varchar(100) NOT NULL,
    [ProfissionalId] uniqueidentifier NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbEmailProfissional] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EmailProfissionalToProfissional] FOREIGN KEY ([ProfissionalId]) REFERENCES [TbProfissional] ([Id])
);

CREATE TABLE [TbProjeto] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Descricao] varchar(1000) NOT NULL,
    [DataInicio] datetime2 NOT NULL,
    [DataFim] datetime2 NOT NULL,
    [ClienteId] uniqueidentifier NOT NULL,
    [StatusId] uniqueidentifier NOT NULL,
    [TipoId] uniqueidentifier NOT NULL,
    [Orçamento] real NOT NULL,
    [QtdHorasEstimadas] real NOT NULL,
    [ResponsavelId] uniqueidentifier NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbProjeto] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ClienteToProjeto] FOREIGN KEY ([ClienteId]) REFERENCES [TbCliente] ([Id]),
    CONSTRAINT [FK_ProfissionalToProjeto] FOREIGN KEY ([ResponsavelId]) REFERENCES [TbProfissional] ([Id]),
    CONSTRAINT [FK_StatusProjetoToProjeto] FOREIGN KEY ([StatusId]) REFERENCES [TbStatusProjeto] ([Id]),
    CONSTRAINT [FK_TipoProjetoToProjeto] FOREIGN KEY ([TipoId]) REFERENCES [TbTipoProjeto] ([Id])
);

CREATE TABLE [TbTelefoneProfissional] (
    [Id] uniqueidentifier NOT NULL,
    [ProfissionalId] uniqueidentifier NOT NULL,
    [NumeroTelefone] varchar(15) NOT NULL,
    [NomeContato] varchar(100) NOT NULL,
    [TipoTelefoneId] uniqueidentifier NOT NULL,
    [WhatsApp] bit NOT NULL,
    [Telegram] bit NOT NULL,
    [IsPrincipal] bit NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbTelefoneProfissional] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProfissionalToTelefoneProfissional] FOREIGN KEY ([ProfissionalId]) REFERENCES [TbProfissional] ([Id]),
    CONSTRAINT [FK_TipoTelefoneToTelefoneProfissional] FOREIGN KEY ([TipoTelefoneId]) REFERENCES [TbTipoTelefone] ([Id])
);

CREATE TABLE [TbTarefas] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Descricao] varchar(1000) NOT NULL,
    [ResponsavelId] uniqueidentifier NULL,
    [DataInicio] datetime2 NOT NULL,
    [DataFim] datetime2 NULL,
    [QtdHorasEstimadas] real NOT NULL,
    [StatusId] uniqueidentifier NULL,
    [ProjetoId] uniqueidentifier NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbTarefas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProfissionalToTarefas] FOREIGN KEY ([ResponsavelId]) REFERENCES [TbProfissional] ([Id]),
    CONSTRAINT [FK_ProjetoToTarefas] FOREIGN KEY ([ProjetoId]) REFERENCES [TbProjeto] ([Id]),
    CONSTRAINT [FK_StatusTarefaToTarefas] FOREIGN KEY ([StatusId]) REFERENCES [TbStatusTarefa] ([Id])
);

CREATE TABLE [TbComentarioTarefa] (
    [Id] uniqueidentifier NOT NULL,
    [TarefaId] uniqueidentifier NOT NULL,
    [ProfissionalId] uniqueidentifier NOT NULL,
    [Comentario] varchar(1000) NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbComentarioTarefa] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProfissionalToComentarioTarefa] FOREIGN KEY ([ProfissionalId]) REFERENCES [TbProfissional] ([Id]),
    CONSTRAINT [FK_TarefasToComentarioTarefa] FOREIGN KEY ([TarefaId]) REFERENCES [TbTarefas] ([Id])
);

CREATE TABLE [TbHorasProfissional] (
    [Id] uniqueidentifier NOT NULL,
    [TarefaId] uniqueidentifier NOT NULL,
    [ProfissionalId] uniqueidentifier NOT NULL,
    [Data] datetime2 NOT NULL,
    [HoraInicio] float NOT NULL,
    [HoraFim] float NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    [DataAtualizacao] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    [UsuarioCriacao] uniqueidentifier NOT NULL,
    [UsuarioAlteracao] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_TbHorasProfissional] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProfissionalToHorasProfissional] FOREIGN KEY ([ProfissionalId]) REFERENCES [TbProfissional] ([Id]),
    CONSTRAINT [FK_TarefasToHorasProfissional] FOREIGN KEY ([TarefaId]) REFERENCES [TbTarefas] ([Id])
);

CREATE INDEX [IX_TbCliente_UnidadeFederativaId] ON [TbCliente] ([UnidadeFederativaId]);

CREATE INDEX [IX_TbComentarioTarefa_ProfissionalId] ON [TbComentarioTarefa] ([ProfissionalId]);

CREATE INDEX [IX_TbComentarioTarefa_TarefaId] ON [TbComentarioTarefa] ([TarefaId]);

CREATE INDEX [IX_TbEmailCliente_ClienteId] ON [TbEmailCliente] ([ClienteId]);

CREATE INDEX [IX_TbEmailFornecedor_FornecedorId] ON [TbEmailFornecedor] ([FornecedorId]);

CREATE INDEX [IX_TbEmailProfissional_ProfissionalId] ON [TbEmailProfissional] ([ProfissionalId]);

CREATE INDEX [IX_TbFornecedor_UnidadeFederativaId] ON [TbFornecedor] ([UnidadeFederativaId]);

CREATE INDEX [IX_TbHorasProfissional_ProfissionalId] ON [TbHorasProfissional] ([ProfissionalId]);

CREATE INDEX [IX_TbHorasProfissional_TarefaId] ON [TbHorasProfissional] ([TarefaId]);

CREATE INDEX [IX_TbProfissional_FornecedorId] ON [TbProfissional] ([FornecedorId]);

CREATE INDEX [IX_TbProfissional_FuncaoId] ON [TbProfissional] ([FuncaoId]);

CREATE INDEX [IX_TbProfissional_UfNaturalidadeId] ON [TbProfissional] ([UfNaturalidadeId]);

CREATE INDEX [IX_TbProfissional_UnidadeFederativaId] ON [TbProfissional] ([UnidadeFederativaId]);

CREATE INDEX [IX_TbProjeto_ClienteId] ON [TbProjeto] ([ClienteId]);

CREATE INDEX [IX_TbProjeto_ResponsavelId] ON [TbProjeto] ([ResponsavelId]);

CREATE INDEX [IX_TbProjeto_StatusId] ON [TbProjeto] ([StatusId]);

CREATE INDEX [IX_TbProjeto_TipoId] ON [TbProjeto] ([TipoId]);

CREATE INDEX [IX_TbTarefas_ProjetoId] ON [TbTarefas] ([ProjetoId]);

CREATE INDEX [IX_TbTarefas_ResponsavelId] ON [TbTarefas] ([ResponsavelId]);

CREATE INDEX [IX_TbTarefas_StatusId] ON [TbTarefas] ([StatusId]);

CREATE INDEX [IX_TbTelefoneCliente_ClienteId] ON [TbTelefoneCliente] ([ClienteId]);

CREATE INDEX [IX_TbTelefoneCliente_TipoTelefoneId] ON [TbTelefoneCliente] ([TipoTelefoneId]);

CREATE INDEX [IX_TbTelefoneFornecedor_FornecedorId] ON [TbTelefoneFornecedor] ([FornecedorId]);

CREATE INDEX [IX_TbTelefoneFornecedor_TipoTelefoneId] ON [TbTelefoneFornecedor] ([TipoTelefoneId]);

CREATE INDEX [IX_TbTelefoneProfissional_ProfissionalId] ON [TbTelefoneProfissional] ([ProfissionalId]);

CREATE INDEX [IX_TbTelefoneProfissional_TipoTelefoneId] ON [TbTelefoneProfissional] ([TipoTelefoneId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260406161013_InitialCreate', N'10.0.5');

COMMIT;
GO

BEGIN TRANSACTION;
ALTER TABLE [TbComentarioTarefa] DROP CONSTRAINT [FK_ProfissionalToComentarioTarefa];

ALTER TABLE [TbComentarioTarefa] DROP CONSTRAINT [FK_TarefasToComentarioTarefa];

ALTER TABLE [TbComentarioTarefa] ADD CONSTRAINT [FK_ProfissionalToComentarioTarefa] FOREIGN KEY ([ProfissionalId]) REFERENCES [TbProfissional] ([Id]);

ALTER TABLE [TbComentarioTarefa] ADD CONSTRAINT [FK_TarefasToComentarioTarefa] FOREIGN KEY ([TarefaId]) REFERENCES [TbTarefas] ([Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260406161137_AddGuidFkAndNoCascade', N'10.0.5');

COMMIT;
GO

BEGIN TRANSACTION;
ALTER TABLE [TbCliente] DROP CONSTRAINT [FK_UnidadeFederativaToCliente];

ALTER TABLE [TbEmailCliente] DROP CONSTRAINT [FK_EmailClienteToCliente];

ALTER TABLE [TbEmailFornecedor] DROP CONSTRAINT [FK_EmailFornecedorToFornecedor];

ALTER TABLE [TbEmailProfissional] DROP CONSTRAINT [FK_EmailProfissionalToProfissional];

ALTER TABLE [TbHorasProfissional] DROP CONSTRAINT [FK_ProfissionalToHorasProfissional];

ALTER TABLE [TbHorasProfissional] DROP CONSTRAINT [FK_TarefasToHorasProfissional];

ALTER TABLE [TbProjeto] DROP CONSTRAINT [FK_ClienteToProjeto];

ALTER TABLE [TbProjeto] DROP CONSTRAINT [FK_ProfissionalToProjeto];

ALTER TABLE [TbProjeto] DROP CONSTRAINT [FK_StatusProjetoToProjeto];

ALTER TABLE [TbProjeto] DROP CONSTRAINT [FK_TipoProjetoToProjeto];

ALTER TABLE [TbTarefas] DROP CONSTRAINT [FK_ProjetoToTarefas];

ALTER TABLE [TbTelefoneCliente] DROP CONSTRAINT [FK_ClienteToTelefoneCliente];

ALTER TABLE [TbTelefoneFornecedor] DROP CONSTRAINT [FK_FornecedorToTelefoneFornecedor];

ALTER TABLE [TbTelefoneProfissional] DROP CONSTRAINT [FK_ProfissionalToTelefoneProfissional];

ALTER TABLE [TbCliente] ADD CONSTRAINT [FK_UnidadeFederativaToCliente] FOREIGN KEY ([UnidadeFederativaId]) REFERENCES [TbUnidadeFederativa] ([Id]);

ALTER TABLE [TbEmailCliente] ADD CONSTRAINT [FK_EmailClienteToCliente] FOREIGN KEY ([ClienteId]) REFERENCES [TbCliente] ([Id]);

ALTER TABLE [TbEmailFornecedor] ADD CONSTRAINT [FK_EmailFornecedorToFornecedor] FOREIGN KEY ([FornecedorId]) REFERENCES [TbFornecedor] ([Id]);

ALTER TABLE [TbEmailProfissional] ADD CONSTRAINT [FK_EmailProfissionalToProfissional] FOREIGN KEY ([ProfissionalId]) REFERENCES [TbProfissional] ([Id]);

ALTER TABLE [TbHorasProfissional] ADD CONSTRAINT [FK_ProfissionalToHorasProfissional] FOREIGN KEY ([ProfissionalId]) REFERENCES [TbProfissional] ([Id]);

ALTER TABLE [TbHorasProfissional] ADD CONSTRAINT [FK_TarefasToHorasProfissional] FOREIGN KEY ([TarefaId]) REFERENCES [TbTarefas] ([Id]);

ALTER TABLE [TbProjeto] ADD CONSTRAINT [FK_ClienteToProjeto] FOREIGN KEY ([ClienteId]) REFERENCES [TbCliente] ([Id]);

ALTER TABLE [TbProjeto] ADD CONSTRAINT [FK_ProfissionalToProjeto] FOREIGN KEY ([ResponsavelId]) REFERENCES [TbProfissional] ([Id]);

ALTER TABLE [TbProjeto] ADD CONSTRAINT [FK_StatusProjetoToProjeto] FOREIGN KEY ([StatusId]) REFERENCES [TbStatusProjeto] ([Id]);

ALTER TABLE [TbProjeto] ADD CONSTRAINT [FK_TipoProjetoToProjeto] FOREIGN KEY ([TipoId]) REFERENCES [TbTipoProjeto] ([Id]);

ALTER TABLE [TbTarefas] ADD CONSTRAINT [FK_ProjetoToTarefas] FOREIGN KEY ([ProjetoId]) REFERENCES [TbProjeto] ([Id]);

ALTER TABLE [TbTelefoneCliente] ADD CONSTRAINT [FK_ClienteToTelefoneCliente] FOREIGN KEY ([ClienteId]) REFERENCES [TbCliente] ([Id]);

ALTER TABLE [TbTelefoneFornecedor] ADD CONSTRAINT [FK_FornecedorToTelefoneFornecedor] FOREIGN KEY ([FornecedorId]) REFERENCES [TbFornecedor] ([Id]);

ALTER TABLE [TbTelefoneProfissional] ADD CONSTRAINT [FK_ProfissionalToTelefoneProfissional] FOREIGN KEY ([ProfissionalId]) REFERENCES [TbProfissional] ([Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260406161230_NoCascadeGlobal', N'10.0.5');

COMMIT;
GO

