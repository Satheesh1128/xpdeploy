
CREATE PROCEDURE [dbo].[Application_Version_SELECT]
(
@Action NVARCHAR(50),
@Env NVARCHAR(50),
@Application NVARCHAR(50),
@Header  NVARCHAR(50) OUTPUT
)

AS
BEGIN

	SET NOCOUNT ON;
	SET @Header = 'Application Version'

SELECT * INTO #Version_Temp FROM [dbo].[Application_Version]

IF @Env = 'HCCB'

SELECT
	ROW_NUMBER() OVER(ORDER BY A.ApplicationName) AS SlNo,
	A.ApplicationName,
	[FAT_Version],
	[UAT_Version],
	[PRD_Version]
	--[TRI_Version]
FROM [dbo].[#Version_Temp] VT
INNER JOIN Applications A WITH(NOLOCK) ON VT.ApplicationID = A.ID
INNER JOIN ENVMaster EM WITH(NOLOCK) ON EM.ID = VT.EnvID 
WHERE (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
AND EM.ENVName = @Env

ELSE IF @Env = 'SAAS'

SELECT
	ROW_NUMBER() OVER(ORDER BY A.ApplicationName) AS SlNo,
	A.ApplicationName,	
	[FAT_Version] AS [SIT_Version],
	[UAT_Version],
	[PRD_Version],
	[SAASDEMO_Version],
	[SAASPILOT_Version]
FROM [dbo].[#Version_Temp] VT
INNER JOIN Applications A WITH(NOLOCK) ON VT.ApplicationID = A.ID
INNER JOIN ENVMaster EM WITH(NOLOCK) ON EM.ID = VT.EnvID
WHERE (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
AND EM.ENVName = @Env

ELSE IF @Env = 'SAASV2'

SELECT
	ROW_NUMBER() OVER(ORDER BY A.ApplicationName) AS SlNo,
	A.ApplicationName,	
	[FAT_Version] AS [SIT_Version],
	[UAT_Version],
	[PRD_Version],
	[DEMOV2_Version],
	[SAASDEMO_Version],
	[SAASPILOT_Version]
FROM [dbo].[#Version_Temp] VT
INNER JOIN Applications A WITH(NOLOCK) ON VT.ApplicationID = A.ID
INNER JOIN ENVMaster EM WITH(NOLOCK) ON EM.ID = VT.EnvID
WHERE (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
AND EM.ENVName = @Env

ELSE IF @Env = 'CCI'

SELECT
	ROW_NUMBER() OVER(ORDER BY A.ApplicationName) AS SlNo,
	A.ApplicationName,
	[UAT_Version],
	[PRD_Version]
FROM [dbo].[#Version_Temp] VT
INNER JOIN Applications A WITH(NOLOCK) ON VT.ApplicationID = A.ID
INNER JOIN ENVMaster EM WITH(NOLOCK) ON EM.ID = VT.EnvID
WHERE (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
AND EM.ENVName = @Env

ELSE

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
AND EM.ENVName = @Env


END
