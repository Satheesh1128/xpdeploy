CREATE PROCEDURE [dbo].[Urls_EDIT]
(      
	--@ID NVARCHAR(100),
	@Client NVARCHAR(100),
	@Application NVARCHAR(100),
	@HeaderText Nvarchar(100) OUTPUT,
	@Url1 Nvarchar(100) OUTPUT,
	@Url2 nvarchar(100) OUTPUT,
	@Url3 nvarchar(100) OUTPUT,

	@IsActive Nvarchar(100) OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET @HeaderText = 'Modify Urls Details'

	SELECT	
		@Application = A.ApplicationName,
		@Client = CM.ClientName,	

		@Url1 =  U.Url1,
		@Url2 = U.Url2,
		@Url3 = U.Url3,
		@IsActive = CASE U.IsActive WHEN 1 THEN 'Active' ELSE 'InActive' END
	FROM URLS U
	INNER JOIN Applications A WITH(NOLOCK) ON U.ApplicationID = A.ID
	INNER JOIN ClientMaster CM WITH(NOLOCK) ON U.ClientId = CM.ID
	WHERE CM.ClientName = @Client
	AND A.ApplicationName = @Application
END


      

