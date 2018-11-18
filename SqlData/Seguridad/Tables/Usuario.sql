CREATE TABLE [Seguridad].[Usuario] (
    [UsuarioId]         BIGINT       IDENTITY (1, 1) NOT NULL,
    [Login]             VARCHAR (50) NOT NULL,
    [Contrasena]        VARCHAR (50) NOT NULL,
    [FechaCreacion]     DATETIME     NOT NULL,
    [FechaModificado]   DATETIME     NULL,
    [FechaUltimoAcceso] DATETIME     NULL,
    [Activo]            BIT          NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([UsuarioId] ASC)
);

