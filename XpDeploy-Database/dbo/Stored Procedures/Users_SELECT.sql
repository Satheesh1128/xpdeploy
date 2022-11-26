
CREATE PROCEDURE [dbo].[Users_SELECT]
(
@RoleID int,
@RoleName Nvarchar(100),
@UserName Nvarchar(100),
@SearchUserName Nvarchar(100),
@Action Nvarchar(100),
@ActiveStatus Nvarchar(100),
@Header Nvarchar(100) OUTPUT
)

AS
BEGIN

	SET NOCOUNT ON;
	SET @Header = 'UserList'
	
		SELECT
			UserId,
			Name,
			UserName as UN1,
			RM.RoleName,
			Email
		FROM Users U
		LEFT OUTER JOIN RoleMaster RM WITH(NOLOCK) ON U.RoleID = RM.RoleID
		LEFT OUTER JOIN ActiveStatus ACS WITH(NOLOCK) ON U.Status = ACS.Id
		WHERE (U.Name like '%' + @SearchUserName + '%' OR ISNULL(@SearchUserName, '') = '')
		--AND (ACS.Description like '%' + @ActiveStatus + '%' OR ISNULL(@ActiveStatus, '') = '')
		AND ACS.Description = @ActiveStatus
		AND (RM.RoleName like '%' + @RoleName + '%' OR ISNULL(@RoleName, '') = '')
					
END
	

	
    



