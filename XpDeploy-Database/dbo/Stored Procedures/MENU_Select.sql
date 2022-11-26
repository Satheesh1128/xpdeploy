CREATE PROCEDURE [dbo].[MENU_Select] 
(
@RoleID int,
@webmaster NVARCHAR(MAX),
@ParentMenuName1 NVARCHAR(MAX), 
@ParentMenuName2 NVARCHAR(MAX),
@ParentMenuName3 NVARCHAR(MAX),
@ParentMenuName4 NVARCHAR(MAX),
@PSM1 NVARCHAR(MAX)  OUTPUT,
@PSM2 NVARCHAR(MAX)  OUTPUT,
@PSM3 NVARCHAR(MAX)  OUTPUT,
@PSM4 NVARCHAR(MAX)  OUTPUT
)

AS
BEGIN
  SET NOCOUNT ON;
  
	DECLARE @str VARCHAR(MAX)
	DECLARE @strFooter VARCHAR(MAX)
	DECLARE @str1 VARCHAR(MAX)
	DECLARE @Application VARCHAR(MAX)
	DECLARE @str1Footer VARCHAR(MAX)
	DECLARE @strLinks VARCHAR(MAX)
	DECLARE @str2 VARCHAR(MAX)
	DECLARE @str3 VARCHAR(MAX)
	DECLARE @str4 VARCHAR(MAX)
	DECLARE @AtdRes VARCHAR(MAX)
	DECLARE @AtdResFooter VARCHAR(MAX)


--M1 Start
SELECT @str = coalesce(@str + ' ', '') + a.T1 FROM (SELECT '<li><a href="'+MenuURL+'"'+'>'+MenuName+'</a></li>' as T1 from MenuMaster WHERE ParentMenuName = @ParentMenuName1 and webmaster = @webmaster and ID in (select MenuId from MenuPermission where isactive =1 and RoleID = @RoleID)) a
select @PSM1 = @str

--M2 Start
SELECT @str2 = coalesce(@str2 + ' ', '') + a.T1 FROM (SELECT '<li><a href="'+MenuURL+'"'+'>'+MenuName+'</a></li>' as T1 from MenuMaster WHERE ParentMenuName = @ParentMenuName2 and webmaster = @webmaster and ID in (select MenuId from MenuPermission where isactive =1 and RoleID = @RoleID)) a
select @PSM2 = @str2

--M3 Start
SELECT @str3 = coalesce(@str3 + ' ', '') + a.T1 FROM (SELECT '<li><a href="'+MenuURL+'"'+'>'+MenuName+'</a></li>' as T1 from MenuMaster WHERE ParentMenuName = @ParentMenuName3 and webmaster = @webmaster and ID in (select MenuId from MenuPermission where isactive =1 and RoleID = @RoleID)) a
select @PSM3 = @str3

--M4 Start
SELECT @str4 = coalesce(@str4 + ' ', '') + a.T1 FROM (SELECT '<li><a href="'+MenuURL+'"'+'>'+MenuName+'</a></li>' as T1 from MenuMaster WHERE ParentMenuName = @ParentMenuName4 and webmaster = @webmaster and ID in (select MenuId from MenuPermission where isactive =1 and RoleID = @RoleID)) a
select @PSM4 = @str4



END


