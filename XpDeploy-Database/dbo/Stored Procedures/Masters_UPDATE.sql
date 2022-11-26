CREATE PROCEDURE [dbo].[Masters_UPDATE]
(      
	@ID NVARCHAR(100),
	@Masterselect NVARCHAR(50),
	@Userid NVARCHAR(100),
	@ENV NVARCHAR(100),
	@ENVTB NVARCHAR(100),
	@Clients NVARCHAR(100),
	@ServerName NVARCHAR(100),
	@ServerListName NVARCHAR(100),
	@ServerNameDD NVARCHAR(100),
	@ActiveStatus NVARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ENVID INT,@IsActive INT,@Serverid INT
	SELECT @ENVID = ID FROM ENVMaster WHERE ENVName = @ENV
	SELECT @Serverid = ID FROM ServerMaster WHERE ServerName = @ServerNameDD
	SELECT @IsActive = Id FROM ActiveStatus WHERE Description=@ActiveStatus

	IF @Masterselect = 'Environments'

	BEGIN

		IF @ID IS NOT NULL OR @ID <> ''
			BEGIN
				UPDATE EM SET
					ENVName = @ENVTB,
					Status = @IsActive
				FROM ENVMaster EM
				WHERE EM.ID = @ID
			END

		IF @ID = ''
			BEGIN
				INSERT INTO ENVMaster
				(
					ID,
					ENVName,
					Status
				)
				VALUES
				(
					(SELECT MAX(ID)+1 FROM ENVMaster),
					@ENVTB,
					@IsActive
				)
			END
	END

	IF @Masterselect = 'Clients'

	BEGIN

		IF @ID IS NOT NULL OR @ID <> ''
			BEGIN
				UPDATE CM SET
					ENVID = @ENVID,
					ClientName = @Clients,
					Status = @IsActive
				FROM ClientMaster CM
				LEFT OUTER JOIN ENVMaster EM WITH(NOLOCK) ON EM.ID = CM.ENVID
				WHERE CM.ID = @ID
			END

		IF @ID = ''
			BEGIN
				INSERT INTO ClientMaster
				(
					ID,
					ENVID,
					ClientName,
					Status
				)
				VALUES
				(
					(SELECT MAX(ID)+1 FROM ClientMaster),
					@ENVID,
					@Clients,
					@IsActive
				)
			END
	END

	IF @Masterselect = 'Servers'

	BEGIN

		IF @ID IS NOT NULL OR @ID <> ''
			BEGIN
				UPDATE SM SET
					--ENVID = @ENVID,
					ServerName = @ServerName,
					Status = @IsActive
				FROM ServerMaster SM
				--LEFT OUTER JOIN ENVMaster EM WITH(NOLOCK) ON SM.EnvId = EM.ID
				WHERE SM.ID = @ID
			END

		IF @ID = ''
			BEGIN
				INSERT INTO ServerMaster
				(
					ID,
					ServerName,
					--EnvId,
					Status
				)
				VALUES
				(
					(SELECT MAX(ID)+1 FROM ServerMaster),
					@ServerName,
					--@ENVID,
					@IsActive
				)
			END
	END

	IF @Masterselect = 'ServerList'

	BEGIN

		IF @ID IS NOT NULL OR @ID <> ''
			BEGIN
				UPDATE SL SET
					ServerID = @Serverid,
					ServerListName = @ServerListName,
					IsActive = @IsActive,
					EnvId = @ENVID
				FROM ServerList SL
				--LEFT OUTER JOIN ServerMaster SM WITH(NOLOCK) ON SL.ServerID = SM.ID
				LEFT OUTER JOIN ENVMaster EM WITH(NOLOCK) ON EM.ID = SL.EnvId
				WHERE SL.ServerListID = @ID
			END

		IF @ID = ''
			BEGIN
				INSERT INTO ServerList
				(
					ServerID,
					ServerListID,
					ServerListName,
					IsActive,
					EnvId
				)
				VALUES
				(
					@Serverid,
					(SELECT MAX(ServerListID)+1 FROM ServerList),
					@ServerListName,
					@IsActive,
					@ENVID
				)
			END
	END

END



      

