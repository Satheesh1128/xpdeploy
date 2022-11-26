CREATE PROCEDURE [dbo].[Users_Edit]
(      
	@USERID NVARCHAR(100),
	@Name NVARCHAR(100) OUTPUT,	
	@UserName NVARCHAR(100) OUTPUT,
	@RoleName NVARCHAR(100) OUTPUT,
	@Password NVARCHAR(100) OUTPUT,
	@ActiveStatus NVARCHAR(100) OUTPUT,
	@Email NVARCHAR(100) OUTPUT,
	@HeaderText NVARCHAR(100) OUTPUT
	
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET @HeaderText  = 'Modify User Details'

	--SELECT * FROM users
	
SELECT 
	@USERID = UserId,
	@RoleName = RM.RoleName,
	@Name = Name,
	@UserName = UserName,
	@Password = Password,
	@Email = Email
FROM Users U
LEFT OUTER JOIN RoleMaster RM WITH(NOLOCK) ON U.RoleID = RM.RoleID
LEFT OUTER JOIN ActiveStatus ACS WITH(NOLOCK) ON U.Status = ACS.Id
WHERE UserId = @USERID
END
