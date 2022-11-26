CREATE PROCEDURE [dbo].[ReleaseTracker_UPDATE]
(      
	@ID NVARCHAR(100),
	@ENV NVARCHAR(100),
	@Client NVARCHAR(100),
	@Application NVARCHAR(100),	
	@Version NVARCHAR(100),

	@SITFAT DATETIME,
	@UAT DATETIME,
	@PRD DATETIME,
	@TRI DATETIME,

	@DEMOV2 DATETIME,
	@DEMO DATETIME,
	@PILOT DATETIME,

	@AppDependency NVARCHAR(100),
	@Reason Nvarchar(max),
	@Config Nvarchar(100),
	@Rollback Nvarchar(100),
	@Jira NVARCHAR(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ENVID INT,@ApplicationID INT
	SELECT @ENVID = ID FROM ENVMaster WHERE ENVName = @ENV
	SELECT @ApplicationID = ID FROM Applications WHERE ApplicationName = @Application

	IF @SITFAT = REPLACE(CONVERT(NVARCHAR,GETDATE(), 106), ' ', '-') SET @SITFAT = GETDATE()
	IF @UAT = REPLACE(CONVERT(NVARCHAR,GETDATE(), 106), ' ', '-') SET @UAT = GETDATE()
	IF @PRD = REPLACE(CONVERT(NVARCHAR,GETDATE(), 106), ' ', '-') SET @PRD = GETDATE()
	IF @TRI = REPLACE(CONVERT(NVARCHAR,GETDATE(), 106), ' ', '-') SET @TRI = GETDATE()

	IF @DEMOV2 = REPLACE(CONVERT(NVARCHAR,GETDATE(), 106), ' ', '-') SET @DEMOV2 = GETDATE()

	IF @DEMO = REPLACE(CONVERT(NVARCHAR,GETDATE(), 106), ' ', '-') SET @DEMO = GETDATE()
	IF @PILOT = REPLACE(CONVERT(NVARCHAR,GETDATE(), 106), ' ', '-') SET @PILOT = GETDATE()

	IF @ID > 0


	  
	UPDATE ReleaseTracker SET
		EnvId = @ENVID,
		ApplicationID = @ApplicationID,
		Version = @Version,
		[FAT/SIT] = @SITFAT,
		UAT = @UAT,
		PRD = @PRD,
		TRI = @TRI,

		DEMOV2 = @DEMOV2,
		DEMO = @DEMO,
		PILOT = @PILOT,

		AppDependency = @AppDependency,
		Reason = @Reason,
		Configchanges = @Config,
		[Rollback] = @Rollback,
		Jira = @Jira,
		ModifiedDateTime = GETDATE()
	WHERE ID = @ID

	ELSE

		INSERT INTO ReleaseTracker 
	(
		
		ApplicationID,
		EnvId,
		Version,
		[FAT/SIT],
		UAT,
		PRD,
		TRI,
		DEMOV2,
		DEMO,
		PILOT,
		AppDependency,
		Reason,
		Configchanges,
		[Rollback],
		Jira,
		ModifiedDateTime
	)
	VALUES
	(
		
		@ApplicationID,
		@ENVID,
		@Version,
		@SITFAT,
		@UAT,
		@PRD,
		@TRI,
		@DEMOV2,
		@DEMO,
		@PILOT,
		@AppDependency,
		@Reason,
		@Config,
		@Rollback,
		@Jira,
		GETDATE()
	)
END




      

