CREATE PROCEDURE [dbo].[DBS_EDIT]
(      
	@ID NVARCHAR(100) = NULL,
	@ENV NVARCHAR(100) OUTPUT,
	@DMS NVARCHAR(100) OUTPUT,
	@CENTRAL Nvarchar(100) OUTPUT,
	@RT60 Nvarchar(100) OUTPUT,
	@SELFIE Nvarchar(100) OUTPUT,
	@Version Nvarchar(100) OUTPUT,
	@Server Nvarchar(100) OUTPUT,
	@Status Nvarchar(100) OUTPUT,
	@HeaderText Nvarchar(100) OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET @HeaderText = 'Modify Release Tracker'
	SELECT
		@ENV = EM.ENVName,
		@DMS = DMS,
		@CENTRAL = Central,
		@RT60 = RT60,
		@SELFIE = Selfie,
		@Version = Version,
		@Server = Server,
		@Status = CASE IsActive WHEN 1 THEN 'Active' ELSE 'InActive' END
	FROM DBS
	LEFT OUTER JOIN ENVMaster EM WITH(NOLOCK) ON DBs.ENV = EM.ID
	WHERE DB_ID = @ID
END


      

