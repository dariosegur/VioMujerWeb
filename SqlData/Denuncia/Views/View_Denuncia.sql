

CREATE VIEW [Denuncia].[View_Denuncia]
AS
SELECT      Denuncia.Denuncia.DenunciaId, Denuncia.Denuncia.CiudadId, Denuncia.Denuncia.FechaReporte, Denuncia.Denuncia.Descripcion, Denuncia.Denuncia.Direccion, Denuncia.Denuncia.Longitud, Denuncia.Denuncia.Latitud, 
                         Sistema.Ciudad.Nombre AS Ciudad, Sistema.Ciudad.DepartamentoId, Sistema.Departamento.Nombre AS Departamento, Denuncia.AtendidoPor as AtendidoPorId, Seguridad.Usuario.Login as AtendidoPor
						 ,0 AS TotalPages, 0 AS TotalReg
FROM        Denuncia.Denuncia 
			LEFT OUTER JOIN Sistema.Ciudad ON Sistema.Ciudad.CiudadId = Denuncia.Denuncia.CiudadId 
			LEFT OUTER JOIN Sistema.Departamento ON Sistema.Departamento.DepartamentoId = Sistema.Ciudad.DepartamentoId
			LEFT OUTER JOIN Seguridad.Usuario ON Denuncia.AtendidoPor=Seguridad.Usuario.UsuarioId
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'Denuncia', @level1type = N'VIEW', @level1name = N'View_Denuncia';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Denuncia (Denuncia)"
            Begin Extent = 
               Top = 62
               Left = 36
               Bottom = 309
               Right = 206
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ciudad (Sistema)"
            Begin Extent = 
               Top = 168
               Left = 397
               Bottom = 307
               Right = 572
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Departamento (Sistema)"
            Begin Extent = 
               Top = 142
               Left = 736
               Bottom = 265
               Right = 911
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'Denuncia', @level1type = N'VIEW', @level1name = N'View_Denuncia';

