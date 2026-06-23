CREATE TABLE [dbo].[TbPaciente] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [Nome]      NVARCHAR (100)   NOT NULL,
    [Telefone]  NVARCHAR (15)    NOT NULL,
    [Cpf]       NVARCHAR (14)    NOT NULL,
    [CartaoSUS] NVARCHAR (20)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

