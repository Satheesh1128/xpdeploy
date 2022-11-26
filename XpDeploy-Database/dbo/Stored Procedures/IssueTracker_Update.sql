CREATE PROCEDURE [dbo].[IssueTracker_Update]
(      
	@ID NVARCHAR(100),
	@ENV NVARCHAR(100),
	@CurrentStatus NVARCHAR(100),	
	@IssueSummary NVARCHAR(100),
	@TicketStatus Nvarchar(100),
	@ReportedDate Nvarchar(100),
	@SITFAT Nvarchar(100),
	@UAT nvarchar(100),
	@PRD nvarchar(100),
	
	@ReleaseChange Nvarchar(100),
	@DevJira Nvarchar(100),
	@DeployJira Nvarchar(100),
	@Owner Nvarchar(100)
)
AS 
BEGIN
	SET NOCOUNT ON;

	DECLARE @EnvId INT
	DECLARE @ownerId INT
	DECLARE @CurrentStatusId INT
	DECLARE @TicketStatusId INT
	DECLARE @ReleaseChangeId INT

	SELECT @EnvId = ID FROM ENVMaster WHERE ENVName = @ENV
	SELECT @ownerId = UserId FROM Users WHERE Name = @Owner

	SELECT @CurrentStatusId = ID FROM  ITStatus WHERE Status = @CurrentStatus
	SELECT @TicketStatusId = ID FROM  ITStatus WHERE Status = @TicketStatus
	SELECT @ReleaseChangeId = ID FROM  ITStatus WHERE Status = @ReleaseChange

	--select @CurrentStatusId
	--SELECT @TicketStatusId

	IF @ID > 0

	UPDATE IssueTracker SET
		CurrentStatus = @CurrentStatusId,
		IssueSummary = @IssueSummary,		
		TicketStatus = @TicketStatusId,
		ReportedDate = @ReportedDate,
		[FAT/SIT] = @SITFAT,
		UAT = @UAT,
		PRD = @PRD,
		ReleaseChange = @ReleaseChangeId,
		DevJira = @DevJira,
		DeployJira = @DeployJira,
		Owner = @ownerId
	WHERE ID = @ID

	ELSE

	INSERT INTO IssueTracker 
	(
		EnvId,
		IssueSummary,
		ReportedDate,
		[FAT/SIT],
		UAT,
		PRD,
		DevJira,
		DeployJira,
		CurrentStatus,
		Releasechange,
		TicketStatus,
		Owner,
		ModifiedDateTime
	)
	VALUES
	(
		@EnvId,
		@IssueSummary,
		@ReportedDate,
		@SITFAT,
		@UAT,
		@PRD,
		@DevJira,
		@DeployJira,
		@CurrentStatusId,
		@ReleaseChangeId,
		@TicketStatusId,
		@ownerId,
		GETDATE()
	)
END


      

