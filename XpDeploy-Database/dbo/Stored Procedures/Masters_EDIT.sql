CREATE PROCEDURE [dbo].[Masters_EDIT]
(      
	@ID NVARCHAR(100) = NULL,
	@Masterselect NVARCHAR(100),
	@ENV NVARCHAR(100) OUTPUT,
	@ActiveStatus NVARCHAR(50) OUTPUT,
	@Clients NVARCHAR(100) OUTPUT,
	@Server NVARCHAR(100) OUTPUT,
	@Serverlist NVARCHAR(100) OUTPUT,
	@HeaderText Nvarchar(100) OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;
	IF @Masterselect = 'Environments'
	BEGIN  
	SET @HeaderText = 'Add/Modify ENVs'
		SELECT
			@ENV = EM.ENVName,
			@ActiveStatus = A.Description
		FROM ENVMaster EM WITH(NOLOCK)
		LEFT OUTER JOIN ActiveStatus A WITH(NOLOCK) ON EM.status = A.id
		WHERE EM.ID = @ID
	END

	IF @Masterselect = 'Clients' 
	BEGIN  
	SET @HeaderText = 'Add/Modify Clients'
		SELECT
			@ENV = EM.ENVName,
			@Clients = ClientName,
			@ActiveStatus = A.Description
		FROM ClientMaster CM
		LEFT OUTER JOIN ENVMaster EM WITH(NOLOCK) ON EM.ID = CM.ENVID
		LEFT OUTER JOIN ActiveStatus A WITH(NOLOCK) ON CM.status = A.id
		WHERE CM.ID = @ID
	END 

	IF @Masterselect = 'Servers'

	BEGIN  
	SET @HeaderText = 'Add/Modify Servers'
		SELECT
			@Server = ServerName,
			@ActiveStatus = A.Description
		FROM ServerMaster SM
		LEFT OUTER JOIN ActiveStatus A WITH(NOLOCK) ON SM.status = A.id
		WHERE SM.ID = @ID
	END 

	IF @Masterselect = 'ServerList'
	
	BEGIN  
	SET @HeaderText = 'Add/Modify ServerList'
		SELECT
			@ENV = EM.ENVName,
			@Server = ServerName,
			@Serverlist = SL.ServerListName,
			@ActiveStatus = A.Description
		FROM ServerList SL
		LEFT OUTER JOIN ServerMaster SM WITH(NOLOCK) ON SL.ServerID = SM.ID
		LEFT OUTER JOIN ENVMaster EM WITH(NOLOCK) ON EM.ID = SL.EnvId
		LEFT OUTER JOIN ActiveStatus A WITH(NOLOCK) ON SL.IsActive = A.id
		WHERE SL.ServerListID = @ID
	END  
END


      

