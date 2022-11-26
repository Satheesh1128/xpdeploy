CREATE PROCEDURE [dbo].[UE_Edit]
(      
	@USERID NVARCHAR(100),
	@Name NVARCHAR(100) OUTPUT,	
	@UserName NVARCHAR(100) OUTPUT,
	@Password NVARCHAR(100) OUTPUT,
	@ActiveStatus NVARCHAR(100) OUTPUT,
	@Email NVARCHAR(100) OUTPUT,
	@HeaderText NVARCHAR(100) OUTPUT
	
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET @HeaderText  = 'Modify User Details'

	--SELECT * FROM HTSMaster
	
SELECT 
	@USERID = UserId,
	@Name = Name,
	@UserName = UserName,
	@Password = Password,
	@Email = Email
FROM Users 
WHERE UserId = @USERID
END
