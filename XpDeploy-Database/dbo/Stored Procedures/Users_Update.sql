-- Procedure
CREATE PROCEDURE [dbo].[Users_Update]
(      
	@ID NVARCHAR(100),
	@UserName NVARCHAR(100),
	@Name NVARCHAR(100),
	@Password NVARCHAR(100),
	@Email NVARCHAR(100),
	@RoleName NVARCHAR(100),
	@StatusName NVARCHAR(100)
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @RoleID INT
	DECLARE @Status INT
	
	SELECT @RoleID = RoleID FROM RoleMaster WHERE RoleName = @RoleName
	SELECT @Status = Id FROM ActiveStatus WHERE Description = @StatusName

IF @ID > 0
	UPDATE U SET	
		Name = @Name,
		UserName = @UserName,
		Password = @Password,
		Email = @Email,
		ModifiedDateTime = GETDATE(),
		RoleID = @RoleID,
		Status = @Status
		--Changepassword = 0
	FROM Users U
	--INNER JOIN ActiveStatus S WITH(NOLOCK) ON S.Id = U.Status
	WHERE UserId = @ID
	--AND s.Description = @StatusName
ELSE

	INSERT INTO Users 
	(
		Name,
		UserName,
		Password,
		CreatedDate,
		ModifiedDateTime,
		RoleID,
		Status,
		Email
	)
	VALUES
	(
		@Name,
		@UserName,
		@Password,
		GETDATE(),
		GETDATE(),
		@RoleID,
		@Status,
		@Email
	)

END


      
