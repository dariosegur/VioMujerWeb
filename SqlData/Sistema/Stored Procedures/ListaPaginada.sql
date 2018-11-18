
-- =============================================
-- Author:		Dario Segura
-- Create date: 2017-11-12
-- Description:	SP para paginación
-- =============================================
create PROCEDURE [Sistema].[ListaPaginada]
	@OrderBy AS NVARCHAR(MAX)=NULL,
	@Descendente AS bit=0,
	@nRegPerPage AS INTEGER=10, -- Numero de registros por página
	@nPage AS INTEGER = 1, --Numero de pagina a mostrar iniciando en 1
	@Filtro AS NVARCHAR(MAX)=NULL, -- Where de la tabla
	@View AS VARCHAR(MAX),
	@Campos AS VARCHAR(MAX),
	@CampoOrderBy AS VARCHAR(MAX)
AS
BEGIN
	--DECLARE @View AS VARCHAR(MAX) = 'Seguridad.View_Usuarios';
	--DECLARE @Campos AS VARCHAR(MAX) = '[UserId],[Activo],[FechaCreacion],[FechaModificacion],[Nombres],[Apellidos],[Login]';

	DECLARE @sqlCmdCountReg AS NVARCHAR(MAX) = 'Select COUNT(*) from '+@View+' @WHERE';
	DECLARE @sqlCmd AS NVARCHAR(MAX) = 'SELECT TOP @nRegPerPage *,(T.TotalReg/@nRegPerPage)+(IIF(T.TotalReg%@nRegPerPage=0,0,1)) AS TotalPages from (Select '+@Campos+',ROW_NUMBER() OVER (@ORDERBY) AS Indice,(@sqlCmdCountReg) AS TotalReg from '+@View+' @WHERE) T WHERE T.Indice>=@StartIndex';
	DECLARE @OrderBySelect AS NVARCHAR(MAx);
	DECLARE @StartIndex AS INTEGER;
	DECLARE @nReg AS INTEGER=0;

	--Configura el Order by
	SET @OrderBySelect = COALESCE(' Order By '+@OrderBy+IIF(@Descendente=1,' DESC',' ASC'),' Order By '+@CampoOrderBy);
	--Encuentra el indice del primer registro a mostrar
	SET @StartIndex = (@nPage*@nRegPerPage) - @nRegPerPage + 1;
	--Aplica filtro al contador
	SET @sqlCmdCountReg = REPLACE(@sqlCmdCountReg, '@WHERE',IIF(@Filtro IS NULL,'','WHERE '+@Filtro));

	--Aplica el order by
	SET @sqlCmd = REPLACE(@sqlCmd, '@ORDERBY',@OrderBySelect);
	--Aplica Maximo de registros
	SET @sqlCmd = REPLACE(@sqlCmd, '@nRegPerPage',@nRegPerPage);
	--Aplica numero de pagina	
	SET @sqlCmd = REPLACE(@sqlCmd, '@StartIndex',@StartIndex);
	--Aplica filtro
	SET @sqlCmd = REPLACE(@sqlCmd, '@WHERE',IIF(@Filtro IS NULL,'','WHERE '+@Filtro));
	--Aplica filtro para total de registros
	SET @sqlCmd = REPLACE(@sqlCmd, '@sqlCmdCountReg',@sqlCmdCountReg);


	print @sqlCmd
	EXECUTE sp_executesql @statement=@sqlCmd;
	
END