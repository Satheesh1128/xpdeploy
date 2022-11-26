
CREATE PROCEDURE [dbo].[Application_Version_Summary_SELECT]
(
@Action NVARCHAR(50) = NULL,
@Env NVARCHAR(50) = NULL,
@Application NVARCHAR(50) = NULL,
@Header  NVARCHAR(50) OUTPUT
)

AS
BEGIN

	SET NOCOUNT ON;
	SET @Header = 'Application Version'

SELECT * INTO #Version_Temp FROM [dbo].[Application_Version]

;WITH T1 AS
(
SELECT
	ROW_NUMBER() OVER(ORDER BY A.ApplicationName) AS SlNo,
	A.ApplicationName,
	[FAT_Version],
	[UAT_Version],
	[PRD_Version]
FROM [dbo].[#Version_Temp] VT
INNER JOIN Applications A WITH(NOLOCK) ON VT.ApplicationID = A.ID
INNER JOIN ENVMaster EM WITH(NOLOCK) ON EM.ID = VT.EnvID 
WHERE (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
AND EM.ENVName = 'HCCB'
),
T2 AS
(
SELECT
	ROW_NUMBER() OVER(ORDER BY A.ApplicationName) AS SlNo,
	A.ApplicationName,	
	[FAT_Version],
	[UAT_Version],
	[PRD_Version],
	[SAASDEMO_Version],
	[SAASPILOT_Version]
FROM [dbo].[#Version_Temp] VT
INNER JOIN Applications A WITH(NOLOCK) ON VT.ApplicationID = A.ID
INNER JOIN ENVMaster EM WITH(NOLOCK) ON EM.ID = VT.EnvID
WHERE (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
AND EM.ENVName = 'SAAS'
),
T3 AS
(
SELECT
	ROW_NUMBER() OVER(ORDER BY A.ApplicationName) AS SlNo,
	A.ApplicationName,	
	[FAT_Version],
	[UAT_Version],
	[PRD_Version],
	[DEMOV2_Version]
FROM [dbo].[#Version_Temp] VT
INNER JOIN Applications A WITH(NOLOCK) ON VT.ApplicationID = A.ID
INNER JOIN ENVMaster EM WITH(NOLOCK) ON EM.ID = VT.EnvID
WHERE (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
AND EM.ENVName = 'SAASV2'
),
T4 AS
(
SELECT
	ROW_NUMBER() OVER(ORDER BY A.ApplicationName) AS SlNo,
	A.ApplicationName,
	[FAT_Version],
	[UAT_Version],
	[PRD_Version],
	[TRI_Version]
FROM [dbo].[#Version_Temp] VT
INNER JOIN Applications A WITH(NOLOCK) ON VT.ApplicationID = A.ID
INNER JOIN ENVMaster EM WITH(NOLOCK) ON EM.ID = VT.EnvID
WHERE (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
AND EM.ENVName = 'CCI1'
)
SELECT
	A.ApplicationName,
	----SIT----
	T1.FAT_Version AS 'HCCB_FAT',
	T2.FAT_Version AS 'SAAS_SIT',
	T3.FAT_Version AS 'SAASV2_SIT',
	CASE WHEN T1.FAT_Version = T2.FAT_Version AND T1.FAT_Version = T3.FAT_Version THEN 'True' ELSE 'FALSE' END AS SIT_Comparison
	--T1.UAT_Version AS 'HCCB_UAT',
	--T2.UAT_Version AS 'SAAS_UAT',
	--T3.UAT_Version AS 'SAASV2_UAT',
	--T4.UAT_Version AS 'CCI_UAT',
	--CASE WHEN T1.UAT_Version = T2.UAT_Version AND T1.UAT_Version = T3.UAT_Version AND T1.UAT_Version = T4.UAT_Version THEN 'True' ELSE 'FALSE' END AS UAT_Comparison
FROM Applications A
LEFT OUTER JOIN T1 WITH(NOLOCK) ON A.ApplicationName = T1.ApplicationName
LEFT OUTER JOIN T2 WITH(NOLOCK) ON A.ApplicationName = T2.ApplicationName
LEFT OUTER JOIN T3 WITH(NOLOCK) ON A.ApplicationName = T3.ApplicationName
LEFT OUTER JOIN T4 WITH(NOLOCK) ON A.ApplicationName = T4.ApplicationName
ORDER BY ApplicationName


END
