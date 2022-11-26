







-- View
CREATE VIEW [dbo].[Application_Version]
AS
WITH RD AS
(
SELECT
EnvId,
ApplicationID,
MAX([FAT/SIT]) AS [SIT/FAT],
MAX(UAT) AS UAT,
MAX(PRD) AS PRD,
MAX(TRI) AS TRI,
MAX(DEMOV2) AS DEMOV2,
MAX(DEMO) AS DEMO,
MAX(PILOT) AS PILOT
FROM ReleaseTracker
WHERE Version <> ''
GROUP BY EnvId,ApplicationID
),
FAT AS
(
SELECT RD.EnvId,RT.ApplicationID,MAX(Version) AS FAT_Version FROM ReleaseTracker RT
INNER JOIN RD ON RT.ApplicationID = RD.ApplicationID AND RT.[FAT/SIT] = RD.[SIT/FAT] AND RT.EnvId = RD.EnvId
GROUP BY RD.EnvId,RT.ApplicationID
),
UAT AS
(
SELECT RD.EnvId,RT.ApplicationID,MAX(Version) AS UAT_Version FROM ReleaseTracker RT
INNER JOIN RD ON RT.ApplicationID = RD.ApplicationID AND RT.UAT = RD.UAT AND RT.EnvId = RD.EnvId
GROUP BY RD.EnvId,RT.ApplicationID
),
PRD AS
(
SELECT RD.EnvId,RT.ApplicationID,MAX(Version) AS PRD_Version FROM ReleaseTracker RT
INNER JOIN RD ON RT.ApplicationID = RD.ApplicationID AND RT.PRD = RD.PRD AND RT.EnvId = RD.EnvId
GROUP BY RD.EnvId,RT.ApplicationID
),
TRI AS
(
SELECT RD.EnvId,RT.ApplicationID,MAX(Version) AS TRI_Version FROM ReleaseTracker RT
INNER JOIN RD ON RT.ApplicationID = RD.ApplicationID AND RT.TRI = RD.TRI AND RT.EnvId = RD.EnvId
GROUP BY RD.EnvId,RT.ApplicationID
),
DEMOV2 AS
(
SELECT RD.EnvId,RT.ApplicationID,MAX(Version) AS DEMOV2_Version FROM ReleaseTracker RT
INNER JOIN RD ON RT.ApplicationID = RD.ApplicationID AND RT.DEMOV2 = RD.DEMOV2 AND RT.EnvId = RD.EnvId
GROUP BY RD.EnvId,RT.ApplicationID
),
SAASDEMO AS
(
SELECT RD.EnvId,RT.ApplicationID,MAX(Version) AS SAASDEMO_Version FROM ReleaseTracker RT
INNER JOIN RD ON RT.ApplicationID = RD.ApplicationID AND RT.DEMO = RD.DEMO AND RT.EnvId = RD.EnvId
GROUP BY RD.EnvId,RT.ApplicationID
),
SAASPILOT AS
(
SELECT RD.EnvId,RT.ApplicationID,MAX(Version) AS SAASPILOT_Version FROM ReleaseTracker RT
INNER JOIN RD ON RT.ApplicationID = RD.ApplicationID AND RT.PILOT = RD.PILOT AND RT.EnvId = RD.EnvId
GROUP BY RD.EnvId,RT.ApplicationID
) 

SELECT
DISTINCT
RD.EnvId,
RD.ApplicationID,
FAT_Version,
UAT_Version,
PRD_Version,
TRI_Version,
DEMOV2_Version,
SAASDEMO_Version,
SAASPILOT_Version
FROM RD
LEFT OUTER JOIN FAT WITH(NOLOCK) ON RD.ApplicationID = FAT.ApplicationID AND RD.EnvId = FAT.EnvId
LEFT OUTER JOIN UAT WITH(NOLOCK) ON RD.ApplicationID = UAT.ApplicationID AND RD.EnvId = UAT.EnvId
LEFT OUTER JOIN PRD WITH(NOLOCK) ON RD.ApplicationID = PRD.ApplicationID AND RD.EnvId = PRD.EnvId
LEFT OUTER JOIN TRI WITH(NOLOCK) ON RD.ApplicationID = TRI.ApplicationID AND RD.EnvId = TRI.EnvId
LEFT OUTER JOIN DEMOV2 WITH(NOLOCK) ON RD.ApplicationID = DEMOV2.ApplicationID AND RD.EnvId = DEMOV2.EnvId
LEFT OUTER JOIN SAASDEMO WITH(NOLOCK) ON RD.ApplicationID = SAASDEMO.ApplicationID AND RD.EnvId = SAASDEMO.EnvId
LEFT OUTER JOIN SAASPILOT WITH(NOLOCK) ON RD.ApplicationID = SAASPILOT.ApplicationID AND RD.EnvId = SAASPILOT.EnvId






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
         Begin Table = "Applications"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 220
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Application_Version';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'Application_Version';

