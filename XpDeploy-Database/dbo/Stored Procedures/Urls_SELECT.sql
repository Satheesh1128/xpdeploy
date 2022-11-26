-- Procedure

CREATE PROCEDURE [dbo].[Urls_SELECT] 
(
@Action NVARCHAR(50),
@ENV NVARCHAR(50),
@Client NVARCHAR(50),
@ServerName NVARCHAR(50),
@Application NVARCHAR(50),
@ActiveStatus NVARCHAR(50),
@Header  NVARCHAR(100) OUTPUT
)

AS
BEGIN

	SET NOCOUNT ON;
	DECLARE @ActiveAppCount nvarchar(50)
	DECLARE @InActiveAppCount nvarchar(50)


	
	
	
	SELECT 
			 IsActive,COUNT(*) AS AppCount INTO #AppCount	  
		FROM Urls U
		INNER JOIN ClientMaster CM WITH(NOLOCK) ON U.ClientID = CM.ID
		INNER JOIN ENVMaster EM WITH(NOLOCK) ON CM.ENVID = EM.ID
		INNER JOIN Applications A WITH(NOLOCK) ON U.ApplicationID = A.ID		
		WHERE (EM.ENVName = @ENV OR ISNULL(@ENV, '') = '')
		AND (CM.ClientName = @Client OR ISNULL(@Client, '') = '')
		GROUP BY IsActive
	
	SELECT @ActiveAppCount = AppCount FROM #AppCount WHERE IsActive = 1;
	SELECT @InActiveAppCount = AppCount  FROM #AppCount WHERE IsActive = 0;




	SET @Header = 'App Urls - ' + 'Active - ' + COALESCE(@ActiveAppCount,'0') + '  InActive - ' + COALESCE(@InActiveAppCount,'0')

	

	----Insert Missing Data----

	INSERT INTO URLS 
	( 
	ApplicationID,
	ClientId,
	IsActive
	)

	SELECT A.ID,CM.ID,0 FROM Applications A
	LEFT OUTER JOIN AppCategory2 AC2 WITH(NOLOCK) ON A.AppCategory2 = AC2.Category2ID
	CROSS JOIN ClientMaster CM WITH(NOLOCK)
	WHERE AC2.CategoryName IN ('Web','WebService')
	AND CM.ClientName = @Client
	AND A.ID NOT IN 
	(SELECT ApplicationID FROM Urls U
	INNER JOIN ClientMaster CM WITH(NOLOCK) ON U.ClientId = CM.ID
	WHERE CM.ClientName = @Client)

	------------Temporary Update--------

	--UPDATE U SET AppName = A.ApplicationName,ClientName = cm.ClientName from urls u
	--INNER JOIN ClientMaster CM WITH(NOLOCK) ON U.ClientID = CM.ID
	--INNER JOIN Applications A ON u.ApplicationID = A.ID

	--UPDATE U SET U.ClientName = CM.ClientName FROM Urls U
	--LEFT OUTER JOIN ClientMaster CM WITH(NOLOCK) ON U.ClientId = CM.ID

	-------------------------------------

		--IF @ENV = 'HCCB'

		--SELECT
		--	  ROW_NUMBER() OVER(ORDER BY ApplicationName) AS SlNo,
		--	  [ApplicationName],
		--	  CASE WHEN @Action = 'ExportData' THEN REPLACE (U.Url1 , ',','' ) ELSE '<a href="' +U.Url1+'"'+'target="_blank">'+REPLACE (U.Url1 , ',','<br />' )+'</a>' END AS [FAT/SIT],
		--	  CASE WHEN @Action = 'ExportData' THEN REPLACE (U.Url2 , ',','' ) ELSE '<a href="' +U.Url2+'"'+'target="_blank">'+REPLACE (U.Url2 , ',','<br />' )+'</a>' END AS UAT,
		--	  CASE WHEN @Action = 'ExportData' THEN REPLACE (U.Url3 , ',','' ) ELSE '<a href="' +U.Url3+'"'+'target="_blank">'+REPLACE (U.Url3 , ',','<br />' )+'</a>' END AS PRD			  
		--FROM Urls U
		--INNER JOIN ClientMaster CM WITH(NOLOCK) ON U.ClientID = CM.ID
		--INNER JOIN ENVMaster EM WITH(NOLOCK) ON CM.ENVID = EM.ID
		--INNER JOIN Applications A WITH(NOLOCK) ON U.ApplicationID = A.ID
		--WHERE (EM.ENVName = @ENV OR ISNULL(@ENV, '') = '')
		--AND (CM.ClientName = @Client OR ISNULL(@Client, '') = '')
		--AND (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
		--AND (U.IsActive = CASE @ActiveStatus WHEN 'Active' THEN '1' ELSE '0' END OR ISNULL(CASE @ActiveStatus WHEN 'Active' THEN '1' ELSE '0' END, '') = '')

		--IF @ENV = 'SAAS'

		

		--SELECT
		--	  ROW_NUMBER() OVER(ORDER BY ApplicationName) AS SlNo,
		--	  [ApplicationName],
		--	  CASE WHEN @Action = 'ExportData' THEN REPLACE (U.SAASSIT , ',','' ) ELSE '<a href="' +U.SAASSIT+'"'+'target="_blank">'+REPLACE (U.SAASSIT , ',','<br />' )+'</a>' END AS SAASSIT,
		--	  CASE WHEN @Action = 'ExportData' THEN REPLACE (U.SAASUAT , ',','' ) ELSE '<a href="' +U.SAASUAT+'"'+'target="_blank">'+REPLACE (U.SAASUAT , ',','<br />' )+'</a>' END AS SAASUAT,
		--	  CASE WHEN @Action = 'ExportData' THEN REPLACE (U.SAASPRD , ',','' ) ELSE '<a href="' +U.SAASPRD+'"'+'target="_blank">'+REPLACE (U.SAASPRD , ',','<br />' )+'</a>' END AS SAASPRD
		--FROM Urls U
		--INNER JOIN ClientMaster CM WITH(NOLOCK) ON U.ClientID = CM.ID
		--INNER JOIN ENVMaster EM WITH(NOLOCK) ON CM.ENVID = EM.ID
		--INNER JOIN Applications A WITH(NOLOCK) ON U.ApplicationID = A.ID
		--WHERE (EM.ENVName = @ENV OR ISNULL(@ENV, '') = '')
		--AND (CM.ClientName = @Client OR ISNULL(@Client, '') = '')
		--AND (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
		--AND (U.IsActive = CASE @ActiveStatus WHEN 'Active' THEN '1' ELSE '0' END OR ISNULL(CASE @ActiveStatus WHEN 'Active' THEN '1' ELSE '0' END, '') = '')

		--IF @ENV = 'SAASV2'

		--SELECT
		--	  ROW_NUMBER() OVER(ORDER BY ApplicationName) AS SlNo,
		--	  [ApplicationName],
		--	  CASE WHEN @Action = 'ExportData' THEN REPLACE (SITV2 , ',','' ) ELSE '<a href="' +SITV2+'"'+'target="_blank">'+REPLACE (SITV2 , ',','<br />' )+'</a>' END AS SITV2,
		--	  CASE WHEN @Action = 'ExportData' THEN REPLACE (UATV2 , ',','' ) ELSE '<a href="' +UATV2+'"'+'target="_blank">'+REPLACE (UATV2 , ',','<br />' )+'</a>' END AS UATV2,
		--	  CASE WHEN @Action = 'ExportData' THEN REPLACE (PRDV2 , ',','' ) ELSE '<a href="' +PRDV2+'"'+'target="_blank">'+REPLACE (PRDV2 , ',','<br />' )+'</a>' END AS PRDV2
		--FROM Urls U
		--INNER JOIN ClientMaster CM WITH(NOLOCK) ON U.ClientID = CM.ID
		--INNER JOIN ENVMaster EM WITH(NOLOCK) ON CM.ENVID = EM.ID
		--INNER JOIN Applications A WITH(NOLOCK) ON U.ApplicationID = A.ID
		--WHERE (EM.ENVName = @ENV OR ISNULL(@ENV, '') = '')
		--AND (CM.ClientName = @Client OR ISNULL(@Client, '') = '')
		--AND (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
		--AND (U.IsActive = CASE @ActiveStatus WHEN 'Active' THEN '1' ELSE '0' END OR ISNULL(CASE @ActiveStatus WHEN 'Active' THEN '1' ELSE '0' END, '') = '')

		--IF @ENV = 'PILOT'

		--SELECT
		--	  ROW_NUMBER() OVER(ORDER BY ApplicationName) AS SlNo,
		--	  [ApplicationName],
		--	  CASE WHEN @Action = 'ExportData' THEN REPLACE (U.SAASPILOT , ',','' ) ELSE '<a href="' +U.SAASPILOT+'"'+'target="_blank">'+REPLACE (U.SAASPILOT , ',','<br />' )+'</a>' END AS SAASPILOT
		--FROM Urls U
		--INNER JOIN ClientMaster CM WITH(NOLOCK) ON U.ClientID = CM.ID
		--INNER JOIN ENVMaster EM WITH(NOLOCK) ON CM.ENVID = EM.ID
		--INNER JOIN Applications A WITH(NOLOCK) ON U.ApplicationID = A.ID
		--WHERE (EM.ENVName = @ENV OR ISNULL(@ENV, '') = '')
		--AND (CM.ClientName = @Client OR ISNULL(@Client, '') = '')
		--AND (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
		--AND (U.IsActive = CASE @ActiveStatus WHEN 'Active' THEN '1' ELSE '0' END OR ISNULL(CASE @ActiveStatus WHEN 'Active' THEN '1' ELSE '0' END, '') = '')

		IF @ENV = 'DEMO'

		SELECT
			  ROW_NUMBER() OVER(ORDER BY ApplicationName) AS SlNo,
			  [ApplicationName],
			  CASE WHEN @Action = 'ExportData' THEN REPLACE (U.Url1 , ',','' ) ELSE '<a href="' +U.Url1+'"'+'target="_blank">'+REPLACE (U.Url1 , ',','<br />' )+'</a>' END AS SAASDEMO,
			  CASE WHEN @Action = 'ExportData' THEN REPLACE (U.Url2 , ',','' ) ELSE '<a href="' +U.Url2+'"'+'target="_blank">'+REPLACE (U.Url2 , ',','<br />' )+'</a>' END AS DEMOV2
		FROM Urls U
		INNER JOIN ClientMaster CM WITH(NOLOCK) ON U.ClientID = CM.ID
		INNER JOIN ENVMaster EM WITH(NOLOCK) ON CM.ENVID = EM.ID
		INNER JOIN Applications A WITH(NOLOCK) ON U.ApplicationID = A.ID
		WHERE (EM.ENVName = @ENV OR ISNULL(@ENV, '') = '')
		AND (CM.ClientName = @Client OR ISNULL(@Client, '') = '')
		AND (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
		AND (U.IsActive = CASE @ActiveStatus WHEN 'Active' THEN '1' ELSE '0' END OR ISNULL(CASE @ActiveStatus WHEN 'Active' THEN '1' ELSE '0' END, '') = '')

		IF @ENV = 'PILOT'

		SELECT
			  ROW_NUMBER() OVER(ORDER BY ApplicationName) AS SlNo,
			  [ApplicationName],
			  CASE WHEN @Action = 'ExportData' THEN REPLACE (U.Url1 , ',','' ) ELSE '<a href="' +U.Url1+'"'+'target="_blank">'+REPLACE (U.Url1 , ',','<br />' )+'</a>' END AS PILOT
		FROM Urls U
		INNER JOIN ClientMaster CM WITH(NOLOCK) ON U.ClientID = CM.ID
		INNER JOIN ENVMaster EM WITH(NOLOCK) ON CM.ENVID = EM.ID
		INNER JOIN Applications A WITH(NOLOCK) ON U.ApplicationID = A.ID
		WHERE (EM.ENVName = @ENV OR ISNULL(@ENV, '') = '')
		AND (CM.ClientName = @Client OR ISNULL(@Client, '') = '')
		AND (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
		AND (U.IsActive = CASE @ActiveStatus WHEN 'Active' THEN '1' ELSE '0' END OR ISNULL(CASE @ActiveStatus WHEN 'Active' THEN '1' ELSE '0' END, '') = '')

		
		IF @ENV = 'Training'

		SELECT
			  ROW_NUMBER() OVER(ORDER BY ApplicationName) AS SlNo,
			  [ApplicationName],
			  CASE WHEN @Action = 'ExportData' THEN REPLACE (U.Url1 , ',','' ) ELSE '<a href="' +U.Url1+'"'+'target="_blank">'+REPLACE (U.Url1 , ',','<br />' )+'</a>' END AS Training
		FROM Urls U
		INNER JOIN ClientMaster CM WITH(NOLOCK) ON U.ClientID = CM.ID
		INNER JOIN ENVMaster EM WITH(NOLOCK) ON CM.ENVID = EM.ID
		INNER JOIN Applications A WITH(NOLOCK) ON U.ApplicationID = A.ID
		WHERE (EM.ENVName = @ENV OR ISNULL(@ENV, '') = '')
		AND (CM.ClientName = @Client OR ISNULL(@Client, '') = '')
		AND (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
		AND (U.IsActive = CASE @ActiveStatus WHEN 'Active' THEN '1' ELSE '0' END OR ISNULL(CASE @ActiveStatus WHEN 'Active' THEN '1' ELSE '0' END, '') = '')

		ELSE
				SELECT
			  ROW_NUMBER() OVER(ORDER BY ApplicationName) AS SlNo,
			  [ApplicationName],
			  CASE WHEN @Action = 'ExportData' THEN REPLACE (U.Url1 , ',','' ) ELSE '<a href="' +U.Url1+'"'+'target="_blank">'+REPLACE (U.Url1 , ',','<br />' )+'</a>' END AS [FAT/SIT],
			  CASE WHEN @Action = 'ExportData' THEN REPLACE (U.Url2 , ',','' ) ELSE '<a href="' +U.Url2+'"'+'target="_blank">'+REPLACE (U.Url2 , ',','<br />' )+'</a>' END AS UAT,
			  CASE WHEN @Action = 'ExportData' THEN REPLACE (U.Url3 , ',','' ) ELSE '<a href="' +U.Url3+'"'+'target="_blank">'+REPLACE (U.Url3 , ',','<br />' )+'</a>' END AS PRD			  
		FROM Urls U
		INNER JOIN ClientMaster CM WITH(NOLOCK) ON U.ClientID = CM.ID
		INNER JOIN ENVMaster EM WITH(NOLOCK) ON CM.ENVID = EM.ID
		INNER JOIN Applications A WITH(NOLOCK) ON U.ApplicationID = A.ID
		WHERE (EM.ENVName = @ENV OR ISNULL(@ENV, '') = '')
		AND (CM.ClientName = @Client OR ISNULL(@Client, '') = '')
		AND (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
		AND (U.IsActive = CASE @ActiveStatus WHEN 'Active' THEN '1' ELSE '0' END OR ISNULL(CASE @ActiveStatus WHEN 'Active' THEN '1' ELSE '0' END, '') = '')

	END
