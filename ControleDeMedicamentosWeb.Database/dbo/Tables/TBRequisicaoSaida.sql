CREATE TABLE [dbo].[TBRequisicaoSaida] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [PacienteId] UNIQUEIDENTIFIER NOT NULL
);
GO

ALTER TABLE [dbo].[TBRequisicaoSaida]
    ADD CONSTRAINT [FK_RequisicaoSaida_TBRequisicao] FOREIGN KEY ([Id]) REFERENCES [dbo].[TBRequisicao] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [dbo].[TBRequisicaoSaida]
    ADD CONSTRAINT [FK_TBRequisicaoSaida_TBPaciente] FOREIGN KEY ([PacienteId]) REFERENCES [dbo].[TbPaciente] ([Id]);
GO

ALTER TABLE [dbo].[TBRequisicaoSaida]
    ADD CONSTRAINT [PK_TBRequisicaoSaida] PRIMARY KEY CLUSTERED ([Id] ASC);
GO

