-- Procedure

CREATE PROCEDURE [dbo].[ApplicationList_EDIT] 
(
@ID INT,
@Application NVARCHAR(50) OUTPUT,
@Category1 NVARCHAR(50) OUTPUT,
@Category2 NVARCHAR(50) OUTPUT,
@Responsible NVARCHAR(50) OUTPUT,
@Version NVARCHAR(50) OUTPUT,
@HeaderText  NVARCHAR(50) OUTPUT
)

AS
BEGIN

	SET NOCOUNT ON;

	Set @HeaderText = 'Apps add/modify'

	SELECT
		@Application = ApplicationName,
		@Category1 = b.CategoryName,
		@Category2 = c.CategoryName,
		@Version = CASE VersionSupport WHEN '1' THEN 'V1' WHEN '2' THEN 'V2' ELSE 'Both' END, 
		@Responsible = UserName
	FROM Applications A
	LEFT OUTER JOIN AppCategory1 B WITH(NOLOCK) ON A.AppCategory1 = B.Category1ID
	LEFT OUTER JOIN AppCategory2 C WITH(NOLOCK) ON A.AppCategory2 = C.Category2ID
	INNER JOIN Users U WITH(NOLOCK) ON U.UserId = A.Responsible
	WHERE ID = @ID

END
