-- =============================================
-- Author:		Dario Segura
-- Create date: 2016-05-01
-- Description:	SP para listas de usuarios
-- =============================================
CREATE PROCEDURE [Denuncia].[DenunciaList]
	@OrderBy AS NVARCHAR(MAX)=NULL,
	@Descendente AS bit=0,
	@nRegPerPage AS INTEGER=10, -- Numero de registros por página
	@nPage AS INTEGER = 1, --Numero de pagina a mostrar iniciando en 1
	@Filtro AS NVARCHAR(MAX)=NULL -- Where de la tabla
AS
BEGIN
	DECLARE @View AS VARCHAR(MAX) = 'Denuncia.View_Denuncia';
	DECLARE @Campos AS VARCHAR(MAX) = '
	DenunciaId,CiudadId,FechaReporte,Descripcion,Direccion,Longitud,Latitud,Ciudad,DepartamentoId,Departamento,AtendidoPorId,AtendidoPor
	';
	DECLARE @CampoOrderBy AS VARCHAR(MAX)= 'DenunciaId';
	EXEC  Sistema.ListaPaginada @OrderBy=@OrderBy, @Descendente=@Descendente, @nRegPerPage= @nRegPerPage ,@nPage = @nPage, @Filtro=@Filtro, @View=@View, @Campos=@Campos,@CampoOrderBy=@CampoOrderBy
	
END