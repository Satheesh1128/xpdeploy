CREATE PROCEDURE [dbo].[ReleaseTracker_EDIT]
(      
	@ID NVARCHAR(100) = NULL,
	@ENV NVARCHAR(100) OUTPUT,
	@Application NVARCHAR(100) OUTPUT,
	@HeaderText Nvarchar(100) OUTPUT,
	@Version Nvarchar(100) OUTPUT,
	@FATSIT Nvarchar(100) OUTPUT,
	@UAT nvarchar(100) OUTPUT,
	@PRD nvarchar(100) OUTPUT,
	@TRI nvarchar(100) OUTPUT,
	@DEMOV2 nvarchar(100) OUTPUT,
	@DEMO nvarchar(100) OUTPUT,
	@PILOT nvarchar(100) OUTPUT,
	@AppDependency Nvarchar(100) OUTPUT,
	@Reason Nvarchar(max) OUTPUT,
	@Config Nvarchar(100) OUTPUT,
	@Rollback Nvarchar(100) OUTPUT,
	@Jira Nvarchar(100) OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET @HeaderText = 'Modify Release Tracker'
	SELECT	
		@Application = ApplicationName,
		@ENV = EM.ENVName,
		@Version = Version,		

		@FATSIT = REPLACE(CONVERT(NVARCHAR,[FAT/SIT], 106), ' ', '-'),
		@UAT = REPLACE(CONVERT(NVARCHAR,UAT, 106), ' ', '-'),
		@PRD = REPLACE(CONVERT(NVARCHAR,PRD, 106), ' ', '-'),
		@TRI = REPLACE(CONVERT(NVARCHAR,TRI, 106), ' ', '-'),
		@DEMOV2 = REPLACE(CONVERT(NVARCHAR,DEMOV2, 106), ' ', '-'),
		@DEMO = REPLACE(CONVERT(NVARCHAR,DEMO, 106), ' ', '-'),
		@PILOT = REPLACE(CONVERT(NVARCHAR,PILOT, 106), ' ', '-'),

		@AppDependency = AppDependency,
		@Reason = Reason,
		@Config = Configchanges,
		@Rollback = [Rollback],
		@Jira = Jira
	FROM ReleaseTracker RT
	LEFT OUTER JOIN Applications AP WITH(NOLOCK) ON RT.ApplicationID = AP.ID
	INNER JOIN ENVMaster EM WITH(NOLOCK) ON RT.EnvId = EM.ID
	WHERE RT.ID = @ID
END


      

