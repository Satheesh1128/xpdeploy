
CREATE PROCEDURE [dbo].[ReleaseTracker_SELECT] 
(
@Action NVARCHAR(50),
@ENV NVARCHAR(50),
@Client NVARCHAR(50),
@Application NVARCHAR(50),
@ReleasePending NVARCHAR(50),
@JiraSearch NVARCHAR(50),
@Header  NVARCHAR(50) OUTPUT
)

AS
BEGIN

	SET NOCOUNT ON;
	DECLARE @UATReleasePending NVARCHAR(100)
	DECLARE @PRDReleasePending NVARCHAR(100)

	SET @Header = 'Release Tracker'

	IF @ReleasePending = 'UATRelease' SET @UATReleasePending = 0
	IF @ReleasePending = 'PRDRelease' SET @PRDReleasePending = 0

	IF @Application = 'XnappSyncService' SET @Application ='Xnapp Sync+ Processing Service'
	IF @Application = 'XnappProcessingService_Download' SET @Application ='Xnapp Sync+ Processing Service'
	IF @Application = 'XnappProcessingService_Upload' SET @Application ='Xnapp Sync+ Processing Service'
	



	IF @ReleasePending = 'PRDRelease'

	BEGIN

	IF @ENV = 'CCI'

		SELECT
			ID,
			ENVName AS ENVName,
			ApplicationName,
			Version,
			UAT,
			PRD,
			Config,
			[Rollback],
			CASE WHEN @Action = 'ExportData' THEN REPLACE (Jira, ',','<br />' ) ELSE '<a href="' +Jira+'"'+'target="_blank">'+REPLACE (Jira, ',','<br />' )+'</a>' END AS Jira
		FROM
		[vwReleaseTracker_SELECT]
	WHERE (ApplicationName = @Application OR ISNULL(@Application, '') = '')
	AND UAT IS NOT NULL AND UAT <> ''
	AND (ISNULL(CONVERT(NVARCHAR,PRD),0) = @PRDReleasePending OR ISNULL(@PRDReleasePending, '') = '')
	AND (Jira like '%' + @JiraSearch + '%' OR ISNULL(@JiraSearch, '') = '')	
	AND ENVName = @ENV	
	ORDER BY ID DESC

	ELSE IF @ENV = 'Training'

		SELECT
			ID,
			ENVName,
			ApplicationName,
			Version,
			TRI,
			CASE WHEN @Action = 'ExportData' THEN REPLACE (Jira, ',','<br />' ) ELSE '<a href="' +Jira+'"'+'target="_blank">'+REPLACE (Jira, ',','<br />' )+'</a>' END AS Jira
		FROM
		[vwReleaseTracker_SELECT]
	WHERE (ApplicationName = @Application OR ISNULL(@Application, '') = '')
	AND UAT IS NOT NULL AND UAT <> ''
	AND (ISNULL(CONVERT(NVARCHAR,PRD),0) = @PRDReleasePending OR ISNULL(@PRDReleasePending, '') = '')
	AND (Jira like '%' + @JiraSearch + '%' OR ISNULL(@JiraSearch, '') = '')	
	AND ENVName = @ENV	
	ORDER BY ID DESC

	ELSE IF @ENV = 'DEMO'

		SELECT
			ID,
			ENVName,
			ApplicationName,
			Version,
			DEMO,
			CASE WHEN @Action = 'ExportData' THEN REPLACE (Jira, ',','<br />' ) ELSE '<a href="' +Jira+'"'+'target="_blank">'+REPLACE (Jira, ',','<br />' )+'</a>' END AS Jira
		FROM
		[vwReleaseTracker_SELECT]
	WHERE (ApplicationName = @Application OR ISNULL(@Application, '') = '')
	AND UAT IS NOT NULL AND UAT <> ''
	AND (ISNULL(CONVERT(NVARCHAR,PRD),0) = @PRDReleasePending OR ISNULL(@PRDReleasePending, '') = '')
	AND (Jira like '%' + @JiraSearch + '%' OR ISNULL(@JiraSearch, '') = '')	
	AND ENVName = @ENV	
	ORDER BY ID DESC

	ELSE IF @ENV = 'DEMOV2'

		SELECT
			ID,
			ENVName,
			ApplicationName,
			Version,
			DEMOV2,
			Config,
			[Rollback],
			CASE WHEN @Action = 'ExportData' THEN REPLACE (Jira, ',','<br />' ) ELSE '<a href="' +Jira+'"'+'target="_blank">'+REPLACE (Jira, ',','<br />' )+'</a>' END AS Jira
		FROM
		[vwReleaseTracker_SELECT]
	WHERE (ApplicationName = @Application OR ISNULL(@Application, '') = '')
	AND UAT IS NOT NULL AND UAT <> ''
	AND (ISNULL(CONVERT(NVARCHAR,PRD),0) = @PRDReleasePending OR ISNULL(@PRDReleasePending, '') = '')
	AND (Jira like '%' + @JiraSearch + '%' OR ISNULL(@JiraSearch, '') = '')
	AND ENVName = @ENV	
	ORDER BY ID DESC

	ELSE

		SELECT
			ID,
			ENVName,
			ApplicationName,
			Version,
			FAT,
			UAT,
			PRD,
			Config,
			[Rollback],
			CASE WHEN @Action = 'ExportData' THEN REPLACE (Jira, ',','<br />' ) ELSE '<a href="' +Jira+'"'+'target="_blank">'+REPLACE (Jira, ',','<br />' )+'</a>' END AS Jira
		FROM
		[vwReleaseTracker_SELECT]
	WHERE (ApplicationName = @Application OR ISNULL(@Application, '') = '')
	AND UAT IS NOT NULL AND UAT <> ''
	AND (ISNULL(CONVERT(NVARCHAR,PRD),0) = @PRDReleasePending OR ISNULL(@PRDReleasePending, '') = '')
	AND (Jira like '%' + @JiraSearch + '%' OR ISNULL(@JiraSearch, '') = '')	
	AND ENVName = @ENV	
	ORDER BY ID DESC

	END

	ELSE

	BEGIN

	IF @ENV = 'CCI'

		SELECT
			ID,
			ENVName,
			ApplicationName,
			Version,
			UAT,
			PRD,
			Config,
			[Rollback],
			CASE WHEN @Action = 'ExportData' THEN REPLACE (Jira, ',','<br />' ) ELSE '<a href="' +Jira+'"'+'target="_blank">'+REPLACE (Jira, ',','<br />' )+'</a>' END AS Jira
		FROM
		[vwReleaseTracker_SELECT]
	WHERE (ApplicationName = @Application OR ISNULL(@Application, '') = '')
	AND (ISNULL(CONVERT(NVARCHAR,UAT),0) = @UATReleasePending OR ISNULL(@UATReleasePending, '') = '')
	AND (ISNULL(CONVERT(NVARCHAR,PRD),0) = @PRDReleasePending OR ISNULL(@PRDReleasePending, '') = '')
	AND (Jira like '%' + @JiraSearch + '%' OR ISNULL(@JiraSearch, '') = '')
	AND ENVName = @ENV	
	ORDER BY ID DESC

	ELSE IF @ENV = 'Training'

		SELECT
			ID,
			ENVName,
			ApplicationName,
			Version,
			TRI,
			CASE WHEN @Action = 'ExportData' THEN REPLACE (Jira, ',','<br />' ) ELSE '<a href="' +Jira+'"'+'target="_blank">'+REPLACE (Jira, ',','<br />' )+'</a>' END AS Jira
		FROM
		[vwReleaseTracker_SELECT]
	WHERE (ApplicationName = @Application OR ISNULL(@Application, '') = '')
	AND (ISNULL(CONVERT(NVARCHAR,UAT),0) = @UATReleasePending OR ISNULL(@UATReleasePending, '') = '')
	AND (ISNULL(CONVERT(NVARCHAR,PRD),0) = @PRDReleasePending OR ISNULL(@PRDReleasePending, '') = '')
	AND (Jira like '%' + @JiraSearch + '%' OR ISNULL(@JiraSearch, '') = '')
	AND ENVName = @ENV	
	ORDER BY ID DESC

	ELSE IF @ENV = 'DEMO'

		SELECT
			ID,
			ENVName,
			ApplicationName,
			Version,
			DEMO,
			CASE WHEN @Action = 'ExportData' THEN REPLACE (Jira, ',','<br />' ) ELSE '<a href="' +Jira+'"'+'target="_blank">'+REPLACE (Jira, ',','<br />' )+'</a>' END AS Jira
		FROM
		[vwReleaseTracker_SELECT]
	WHERE (ApplicationName = @Application OR ISNULL(@Application, '') = '')
	AND (ISNULL(CONVERT(NVARCHAR,UAT),0) = @UATReleasePending OR ISNULL(@UATReleasePending, '') = '')
	AND (ISNULL(CONVERT(NVARCHAR,PRD),0) = @PRDReleasePending OR ISNULL(@PRDReleasePending, '') = '')
	AND (Jira like '%' + @JiraSearch + '%' OR ISNULL(@JiraSearch, '') = '')	
	AND ENVName = @ENV	
	ORDER BY ID DESC

	ELSE IF @ENV = 'DEMOV2'

		SELECT
			ID,
			ENVName,
			ApplicationName,
			Version,
			DEMOV2,
			CASE WHEN @Action = 'ExportData' THEN REPLACE (Jira, ',','<br />' ) ELSE '<a href="' +Jira+'"'+'target="_blank">'+REPLACE (Jira, ',','<br />' )+'</a>' END AS Jira
		FROM
		[vwReleaseTracker_SELECT]
	WHERE (ApplicationName = @Application OR ISNULL(@Application, '') = '')
	AND (ISNULL(CONVERT(NVARCHAR,UAT),0) = @UATReleasePending OR ISNULL(@UATReleasePending, '') = '')
	AND (ISNULL(CONVERT(NVARCHAR,PRD),0) = @PRDReleasePending OR ISNULL(@PRDReleasePending, '') = '')
	AND (Jira like '%' + @JiraSearch + '%' OR ISNULL(@JiraSearch, '') = '')	
	AND ENVName = @ENV	
	ORDER BY ID DESC

	ELSE

		SELECT
			ID,
			ENVName,
			ApplicationName,
			Version,
			FAT,
			UAT,
			PRD,
			Config,
			[Rollback],
			CASE WHEN @Action = 'ExportData' THEN REPLACE (Jira, ',','<br />' ) ELSE '<a href="' +Jira+'"'+'target="_blank">'+REPLACE (Jira, ',','<br />' )+'</a>' END AS Jira
		FROM
		[vwReleaseTracker_SELECT]
	WHERE (ApplicationName = @Application OR ISNULL(@Application, '') = '')
	AND (ISNULL(CONVERT(NVARCHAR,UAT),0) = @UATReleasePending OR ISNULL(@UATReleasePending, '') = '')
	AND (ISNULL(CONVERT(NVARCHAR,PRD),0) = @PRDReleasePending OR ISNULL(@PRDReleasePending, '') = '')
	AND (Jira like '%' + @JiraSearch + '%' OR ISNULL(@JiraSearch, '') = '')	
	AND ENVName = @ENV	
	ORDER BY ID DESC

	END

END
