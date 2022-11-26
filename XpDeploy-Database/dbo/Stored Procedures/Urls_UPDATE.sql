CREATE PROCEDURE [dbo].[Urls_UPDATE]
(      
	--@ID NVARCHAR(100),
	@Client NVARCHAR(100),
	@Application NVARCHAR(100),
	@Url1 Nvarchar(100),
	@Url2 nvarchar(100),
	@Url3 nvarchar(100),

	@IsActive Nvarchar(100)
)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE U SET
		 U.Url1 = @Url1,
		 U.Url2 = @Url2,
		 U.Url3 = @Url3,
		 U.IsActive= CASE @IsActive WHEN 'Active' THEN '1' ELSE '0' END 
	FROM URLS U
	INNER JOIN Applications A WITH(NOLOCK) ON U.ApplicationID = A.ID
	INNER JOIN ClientMaster CM WITH(NOLOCK) ON U.ClientId = CM.ID
	WHERE CM.ClientName = @Client
	AND A.ApplicationName = @Application
END


      

