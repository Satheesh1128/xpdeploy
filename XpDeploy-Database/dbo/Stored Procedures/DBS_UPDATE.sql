CREATE PROCEDURE [dbo].[DBS_UPDATE]
(      
	@ID NVARCHAR(100),
	@Userid NVARCHAR(100),
	@ENV NVARCHAR(100),
	@DMS NVARCHAR(100),
	@CENTRAL Nvarchar(100),
	@RT60 Nvarchar(100),
	@SELFIE Nvarchar(100),
	@Version Nvarchar(100),
	@Server Nvarchar(100),
	@Status Nvarchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ENVID INT,@IsActive INT
	SELECT @ENVID = ID FROM ENVMaster WHERE ENVName = @ENV

	IF @Status = 'Active' SET @Status = '1'
	IF @Status = 'InActive' SET @Status = '2'

	IF @ID IS NOT NULL OR @ID <> ''	
	  
	UPDATE DBs SET
		ENV = @ENVID,
		DMS = @DMS,
		CENTRAL = @CENTRAL,
		RT60 = @RT60,
		SELFIE = @SELFIE,
		UserId = @Userid,
		Version = @Version,
		Server = @Server,
		IsActive = @Status
	WHERE DB_ID = @ID

	

	IF @ID = ''

		INSERT INTO DBs
		(
			ENV,
			DMS,
			Central,
			RT60,
			Selfie,
			UserId,
			Version,
			Server,
			IsActive
		)
		VALUES
		(
			@ENVID,
			@DMS,
			@Central,
			@RT60,
			@Selfie,
			@Userid,
			@Version,
			@Server,
			@Status
		)
	
END



      

