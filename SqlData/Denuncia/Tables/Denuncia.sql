CREATE TABLE [Denuncia].[Denuncia] (
    [DenunciaId]   BIGINT          IDENTITY (1, 1) NOT NULL,
    [CiudadId]     BIGINT          NOT NULL,
    [FechaReporte] DATETIME        NOT NULL,
    [Descripcion]  VARCHAR (1024)  NULL,
    [Direccion]    VARCHAR (1024)  NULL,
    [Longitud]     DECIMAL (18, 8) NULL,
    [Latitud]      DECIMAL (18, 8) NULL,
    [AtendidoPor]  BIGINT          NULL,
    CONSTRAINT [PK_Denuncia] PRIMARY KEY CLUSTERED ([DenunciaId] ASC),
    CONSTRAINT [FK_Denuncia_Ciudad] FOREIGN KEY ([CiudadId]) REFERENCES [Sistema].[Ciudad] ([CiudadId]),
    CONSTRAINT [FK_Denuncia_Usuario] FOREIGN KEY ([AtendidoPor]) REFERENCES [Seguridad].[Usuario] ([UsuarioId])
);

