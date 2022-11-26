
CREATE PROCEDURE [dbo].[Masters_SELECT] 
--(
--@Action NVARCHAR(50),
	@Masterselect NVARCHAR(50),
	@ENV NVARCHAR(50),
	@Search NVARCHAR(50),
	@ActiveStatus NVARCHAR(50),
	@Server NVARCHAR(50) = null,
	@Header1 Nvarchar(100) OUTPUT,
	@Header2 Nvarchar(100) OUTPUT,
	@Header3 Nvarchar(100) OUTPUT
--)

AS
BEGIN

	SET NOCOUNT ON;
	IF @ENV = '--Env--' SET @ENV = ''
	IF @Server = '--Server--' SET @Server = ''

	IF @Masterselect = 'Environments'

	BEGIN
		WITH T1 AS
		(
			SELECT
				EM.ID,
				EM.ENVName
			FROM ENVMaster EM WITH(NOLOCK)
			LEFT OUTER JOIN ActiveStatus A WITH(NOLOCK) ON EM.status = A.id
			WHERE (EM.ENVName =  @ENV OR ISNULL( @ENV, '') = '')
			AND (EM.ENVName like '%' + @Search + '%' OR ISNULL(@Search, '') = '')	
			AND A.Description = @ActiveStatus
		)

		SELECT * INTO #temp FROM T1
		SELECT * FROM #temp ORDER BY ID
		SELECT  @Header1 = 'Toltal Records -' + CONVERT(NVARCHAR,COUNT(*)) FROM ENVMaster
		SELECT @Header3 = 'Selected Records -' + CONVERT(NVARCHAR,COUNT(*)) FROM #temp 
	END

	IF @Masterselect = 'Clients'

	BEGIN
		WITH T1 AS
		(
		SELECT
			CM.ID,ENVName,
			CM.ClientName AS Clients
		FROM ClientMaster CM
		LEFT OUTER JOIN ENVMaster EM WITH(NOLOCK) ON CM.ENVID = EM.ID
		LEFT OUTER JOIN ActiveStatus A WITH(NOLOCK) ON CM.status = A.id
		WHERE (EM.ENVName =  @ENV OR ISNULL( @ENV, '') = '')
		AND (CM.ClientName like '%' + @Search + '%' OR ISNULL(@Search, '') = '')
		AND A.Description = @ActiveStatus
		)

		SELECT * INTO #temp1 FROM T1
		SELECT * FROM #temp1 ORDER BY ENVName,Clients
		SELECT  @Header1 = 'Toltal Records -' + CONVERT(NVARCHAR,COUNT(*)) FROM ClientMaster
		SELECT @Header3 = 'Selected Records -' + CONVERT(NVARCHAR,COUNT(*)) FROM #temp1
	END

	IF @Masterselect = 'Servers'

	BEGIN
		WITH T1 AS
		(
		SELECT
			SM.ID,
			--EM.ENVName,
			SM.ServerName		
		FROM ServerMaster SM
		--LEFT OUTER JOIN ENVMaster EM WITH(NOLOCK) ON SM.EnvId = EM.ID
		LEFT OUTER JOIN ActiveStatus A WITH(NOLOCK) ON SM.status = A.id
		--WHERE (EM.ENVName =  @ENV OR ISNULL( @ENV, '') = '')
		WHERE (SM.ServerName like '%' + @Search + '%' OR ISNULL(@Search, '') = '')
		AND (SM.ServerName =  @Server OR ISNULL( @Server, '') = '')
		AND A.Description = @ActiveStatus
		)

		SELECT * INTO #temp2 FROM T1
		SELECT * FROM #temp2 ORDER BY ID
		SELECT  @Header1 = 'Toltal Records -' + CONVERT(NVARCHAR,COUNT(*)) FROM ServerMaster
		SELECT @Header3 = 'Selected Records -' + CONVERT(NVARCHAR,COUNT(*)) FROM #temp2
	END

	IF @Masterselect = 'ServerList'

	BEGIN
		WITH T1 AS
		(
		SELECT
			ServerListID,
			EM.ENVName,
			SM.ServerName AS Servers,
			ServerListName AS ServerList
		FROM ServerList SL
		LEFT OUTER JOIN ServerMaster SM WITH(NOLOCK) ON SL.ServerID = SM.ID
		LEFT OUTER JOIN ENVMaster EM WITH(NOLOCK) ON EM.ID = SL.EnvId
		LEFT OUTER JOIN ActiveStatus A WITH(NOLOCK) ON SL.IsActive = A.id
		WHERE (EM.ENVName =  @ENV OR ISNULL( @ENV, '') = '')
		AND (SL.ServerListName like '%' + @Search + '%' OR ISNULL(@Search, '') = '')
		AND (SM.ServerName =  @Server OR ISNULL( @Server, '') = '')
		AND A.Description = @ActiveStatus
		)

		SELECT * INTO #temp3 FROM T1
		SELECT * FROM #temp3 ORDER BY ENVName,Servers,ServerList
		SELECT  @Header1 = 'Toltal Records -' + CONVERT(NVARCHAR,COUNT(*)) FROM ServerList
		SELECT @Header3 = 'Selected Records -' + CONVERT(NVARCHAR,COUNT(*)) FROM #temp3
		
	END

	END 