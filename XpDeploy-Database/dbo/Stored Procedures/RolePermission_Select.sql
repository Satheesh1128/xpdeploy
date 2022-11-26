
CREATE PROCEDURE [dbo].[RolePermission_Select]
(
@RoleID int,
@Module Nvarchar(100),
@ActionSave Nvarchar(100),
@ActionAdd Nvarchar(100),
@ActionEdit Nvarchar(100),
@ActionDelete Nvarchar(100),
@Save Nvarchar(100) OUTPUT,
@Add Nvarchar(100) OUTPUT,
@Edit Nvarchar(100) OUTPUT,
@Delete Nvarchar(100) OUTPUT
)

AS
BEGIN

	SET NOCOUNT ON;

	SET @Save = (SELECT COUNT(*) 
	FROM RolePermission WHERE Module = @Module AND Action = @ActionSave AND RoleID = @RoleID AND IsEnabled =1)
	
	SET @Add = (SELECT COUNT(*)
	FROM RolePermission WHERE Module = @Module AND Action = @ActionAdd AND RoleID = @RoleID AND IsEnabled =1)
	
	SET @Edit =(SELECT COUNT(*)
	FROM RolePermission WHERE Module = @Module AND Action = @ActionEdit AND RoleID = @RoleID AND IsEnabled =1)
	
	SET @Delete = (SELECT COUNT(*)
	FROM RolePermission WHERE Module = @Module AND Action = @ActionDelete AND RoleID = @RoleID AND IsEnabled =1)
		
					
END
	

	
    



