-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATe PROCEDURE [Seguridad].[Autenticar]
	@Login as VARCHAR(MAX),
	@PassWord as VARCHAR(MAX)
AS
BEGIN
	Select * from Seguridad.Usuario u
	where u.Login=@Login and u.Activo=1 and u.Contrasena=@PassWord
END