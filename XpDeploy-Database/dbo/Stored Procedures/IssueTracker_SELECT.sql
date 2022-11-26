
CREATE PROCEDURE [dbo].[IssueTracker_SELECT] 
(
@Action NVARCHAR(100),
@ENV NVARCHAR(100),
@Owner NVARCHAR(100),
@CurrentStatus NVARCHAR(100),
@TicketStatus NVARCHAR(100),
@Search NVARCHAR(100),
@Header  NVARCHAR(100) OUTPUT
)

AS
BEGIN
--select * from IssueTracker
	SET NOCOUNT ON;

	SET @Header = 'HCCB Issue Tracker'
	--SELECT * FROM IssueTracker
	IF @CurrentStatus='--CurrentStatus--' SET @CurrentStatus = ''
	IF @TicketStatus='--TicketStatus--' SET @TicketStatus = ''
	IF @Owner='--Owner--' SET @Owner = ''

	IF @Action = 'ExportData'

		SELECT
			IT.ID,
			ITS1.Status AS TicketStatus,
			IssueSummary,
			--EM.ENVName,
			--u.Name AS [Reported-By],
			REPLACE(CONVERT(NVARCHAR,ReportedDate, 106), ' ', '-') AS ReportedDate,
			REPLACE(CONVERT(NVARCHAR,[FAT/SIT], 106), ' ', '-') AS [FAT],
			REPLACE(CONVERT(NVARCHAR,UAT, 106), ' ', '-') AS UAT,
			REPLACE(CONVERT(NVARCHAR,PRD, 106), ' ', '-') AS PRD,
			--Releasechange,
			ITS2.Status AS Releasechange,
			ITS.Status AS CurrentStatus,
			REPLACE ('https://xlerate.atlassian.net/browse/'+DevJira+'', ',','<br />' ) AS DevJira,
			REPLACE ('https://xlerate.atlassian.net/browse/'+DeployJira+'', ',','<br />' ) AS DeployJira								
		FROM
		IssueTracker IT
		INNER JOIN ENVMaster EM WITH(NOLOCK) ON IT.EnvId = EM.ID
		INNER JOIN Users U WITH(NOLOCK) ON IT.Owner = u.UserId
		INNER JOIN ITStatus ITS WITH(NOLOCK) ON ITS.ID = IT.CurrentStatus
		INNER JOIN ITStatus ITS1 WITH(NOLOCK) ON ITS1.ID = IT.TicketStatus
		LEFT OUTER JOIN ITStatus ITS2 WITH(NOLOCK) ON ITS2.ID = IT.Releasechange
		WHERE (ITS.Status = @CurrentStatus OR ISNULL(@CurrentStatus, '') = '')
		AND (ITS1.Status = @TicketStatus OR ISNULL(@TicketStatus, '') = '')
		AND (u.Name = @Owner OR ISNULL(@Owner, '') = '')
		AND (IssueSummary like '%' + @Search + '%' OR ISNULL(@Search, '') = '')	
		AND ENVName = @ENV	
		ORDER BY IT.TicketStatus ASC

	IF  @TicketStatus='Closed'

		SELECT
			IT.ID,
			ITS1.Status AS TicketStatus,
			IssueSummary,
			--EM.ENVName,
			--u.Name AS [Reported-By],
			REPLACE(CONVERT(NVARCHAR,ReportedDate, 106), ' ', '-') AS ReportedDate,
			REPLACE(CONVERT(NVARCHAR,[FAT/SIT], 106), ' ', '-') AS [FAT],
			REPLACE(CONVERT(NVARCHAR,UAT, 106), ' ', '-') AS UAT,
			REPLACE(CONVERT(NVARCHAR,PRD, 106), ' ', '-') AS PRD,
			--Releasechange,
			ITS2.Status AS Releasechange,
			ITS.Status AS CurrentStatus,
			'<a href="' +'https://xlerate.atlassian.net/browse/'+DevJira+''+'"'+'target="_blank">'+REPLACE (DevJira, ',','<br />' )+'</a>'  AS DevJira,
			'<a href="' +'https://xlerate.atlassian.net/browse/'+DeployJira+''+'"'+'target="_blank">'+REPLACE (DeployJira, ',','<br />' )+'</a>'  AS DeployJira								
		FROM
		IssueTracker IT
		INNER JOIN ENVMaster EM WITH(NOLOCK) ON IT.EnvId = EM.ID
		INNER JOIN Users U WITH(NOLOCK) ON IT.Owner = u.UserId
		INNER JOIN ITStatus ITS WITH(NOLOCK) ON ITS.ID = IT.CurrentStatus
		INNER JOIN ITStatus ITS1 WITH(NOLOCK) ON ITS1.ID = IT.TicketStatus
		LEFT OUTER JOIN ITStatus ITS2 WITH(NOLOCK) ON ITS2.ID = IT.Releasechange
		WHERE (ITS.Status = @CurrentStatus OR ISNULL(@CurrentStatus, '') = '')
		AND (ITS1.Status = @TicketStatus OR ISNULL(@TicketStatus, '') = '')
		AND (u.Name = @Owner OR ISNULL(@Owner, '') = '')
		AND (IssueSummary like '%' + @Search + '%' OR ISNULL(@Search, '') = '')	
		AND ENVName = @ENV	
		AND TicketStatus=6
		ORDER BY IT.TicketStatus ASC

		ELSE 

		SELECT
			IT.ID,
			ITS1.Status AS TicketStatus,
			IssueSummary,
			--EM.ENVName,
			--u.Name AS [Reported-By],
			REPLACE(CONVERT(NVARCHAR,ReportedDate, 106), ' ', '-') AS ReportedDate,
			REPLACE(CONVERT(NVARCHAR,[FAT/SIT], 106), ' ', '-') AS [FAT],
			REPLACE(CONVERT(NVARCHAR,UAT, 106), ' ', '-') AS UAT,
			REPLACE(CONVERT(NVARCHAR,PRD, 106), ' ', '-') AS PRD,
			--Releasechange,
			ITS2.Status AS Releasechange,
			ITS.Status AS CurrentStatus,
			'<a href="' +'https://xlerate.atlassian.net/browse/'+DevJira+''+'"'+'target="_blank">'+REPLACE (DevJira, ',','<br />' )+'</a>'  AS DevJira,
			'<a href="' +'https://xlerate.atlassian.net/browse/'+DeployJira+''+'"'+'target="_blank">'+REPLACE (DeployJira, ',','<br />' )+'</a>'  AS DeployJira								
		FROM
		IssueTracker IT
		INNER JOIN ENVMaster EM WITH(NOLOCK) ON IT.EnvId = EM.ID
		INNER JOIN Users U WITH(NOLOCK) ON IT.Owner = u.UserId
		INNER JOIN ITStatus ITS WITH(NOLOCK) ON ITS.ID = IT.CurrentStatus
		INNER JOIN ITStatus ITS1 WITH(NOLOCK) ON ITS1.ID = IT.TicketStatus
		LEFT OUTER JOIN ITStatus ITS2 WITH(NOLOCK) ON ITS2.ID = IT.Releasechange
		WHERE (ITS.Status = @CurrentStatus OR ISNULL(@CurrentStatus, '') = '')
		AND (ITS1.Status = @TicketStatus OR ISNULL(@TicketStatus, '') = '')
		AND (u.Name = @Owner OR ISNULL(@Owner, '') = '')
		AND (IssueSummary like '%' + @Search + '%' OR ISNULL(@Search, '') = '')	
		AND ENVName = @ENV	
		AND TicketStatus<>6
		ORDER BY IT.TicketStatus ASC


END
