CREATE TABLE [Sistema].[Ciudad] (
    [CiudadId]       BIGINT       NOT NULL,
    [Nombre]         VARCHAR (50) NOT NULL,
    [DepartamentoId] BIGINT       NOT NULL,
    CONSTRAINT [PK_Ciudad] PRIMARY KEY CLUSTERED ([CiudadId] ASC),
    CONSTRAINT [FK_Ciudad_Departamento] FOREIGN KEY ([DepartamentoId]) REFERENCES [Sistema].[Departamento] ([DepartamentoId])
);

