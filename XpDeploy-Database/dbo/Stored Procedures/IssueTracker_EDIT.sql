CREATE PROCEDURE [dbo].[IssueTracker_EDIT]
(      
	@ID NVARCHAR(100) = NULL,
	@ENV NVARCHAR(100) OUTPUT,
	@CurrentStatus NVARCHAR(100) OUTPUT,	
	@IssueSummary NVARCHAR(100) OUTPUT,
	@TicketStatus Nvarchar(100) OUTPUT,
	@ReportedDate Nvarchar(100) OUTPUT,
	@FATSIT Nvarchar(100) OUTPUT,
	@UAT nvarchar(100) OUTPUT,
	@PRD nvarchar(100) OUTPUT,
	
	@ReleaseChange Nvarchar(100) OUTPUT,
	@DevJira Nvarchar(100) OUTPUT,
	@DeployJira Nvarchar(100) OUTPUT,
	@Owner Nvarchar(100) OUTPUT,
	@HeaderText Nvarchar(100) OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET @HeaderText = 'Modify Release Tracker'
	SELECT	
		@ENV = EM.ENVName,
		@CurrentStatus = ITS.Status,
		@IssueSummary = IssueSummary,		
		@TicketStatus = ITS1.Status,
		@ReportedDate = REPLACE(CONVERT(NVARCHAR,ReportedDate, 106), ' ', '-'),
		@FATSIT = REPLACE(CONVERT(NVARCHAR,[FAT/SIT], 106), ' ', '-'),
		@UAT = REPLACE(CONVERT(NVARCHAR,UAT, 106), ' ', '-'),
		@PRD = REPLACE(CONVERT(NVARCHAR,PRD, 106), ' ', '-'),
		@ReleaseChange = ITS2.Status,
		@DevJira = DevJira,
		@DeployJira = DeployJira,
		@Owner = u.Name
	FROM IssueTracker IT
	INNER JOIN ENVMaster EM WITH(NOLOCK) ON IT.EnvId = EM.ID
	INNER JOIN ITStatus ITS WITH(NOLOCK) ON ITS.ID = IT.CurrentStatus
	INNER JOIN ITStatus ITS1 WITH(NOLOCK) ON ITS1.ID = IT.TicketStatus
	LEFT OUTER JOIN ITStatus ITS2 WITH(NOLOCK) ON ITS2.ID = IT.Releasechange
	INNER JOIN Users U WITH(NOLOCK) ON IT.Owner = u.UserId
	WHERE IT.ID = @ID
END


      

