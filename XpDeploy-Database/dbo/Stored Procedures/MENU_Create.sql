CREATE PROCEDURE [dbo].[MENU_Create] 
(
@MenuURL  NVARCHAR(MAX),
@MenuName  NVARCHAR(MAX),
@ParentMenuName  NVARCHAR(MAX)
)
--EXEC [MENU_Create] 'dbs','Databases','M2'
AS
BEGIN
  SET NOCOUNT ON;
  
  DECLARE @id int

  SELECT @id = MAX(Id)+1 FROM MenuMaster

  INSERT INTO MenuMaster VALUES (@id,@MenuURL,@MenuName,@ParentMenuName,'APP')

  INSERT INTO MenuPermission 
  SELECT RM.RoleID,MM.Id,CASE WHEN RM.RoleName = 'Admin' THEN 1 ELSE 0 END FROM MenuMaster MM
  CROSS JOIN RoleMaster RM
  LEFT OUTER JOIN MenuPermission MP WITH(NOLOCK) ON MP.MenuId = MM.Id AND MP.RoleId = RM.RoleID
  WHERE MP.ID IS NULL

END


