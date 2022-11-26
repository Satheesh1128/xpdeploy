-- Procedure

CREATE PROCEDURE [dbo].[ApplicationList_Add] 
(
@ID INT,
@Application NVARCHAR(50),
@Category1 NVARCHAR(50),
@Category2 NVARCHAR(50),
@Responsible NVARCHAR(50),
@Version NVARCHAR(50)
)

AS
BEGIN

	SET NOCOUNT ON;
	DECLARE @ResponsibleID INT
	
	 SET @Category1 = (SELECT DISTINCT Category1ID FROM AppCategory1 WHERE CategoryName = @Category1)
	 SET @Category2 = (SELECT DISTINCT Category2ID FROM AppCategory2 WHERE CategoryName = @Category2 AND Category1ID = @Category1)
	 SET @ResponsibleID = (SELECT UserId FROM Users WHERE UserName = @Responsible)

	IF @ID > 0

	UPDATE Applications SET
		ApplicationName = @Application,
		AppCategory1 = @Category1,
		AppCategory2 = @Category2,
		VersionSupport = CASE @Version WHEN 'V1' THEN '1' WHEN 'V2' THEN '2' ELSE '3' END, 
		Responsible = @ResponsibleID
	WHERE ID = @ID

	ELSE

		INSERT INTO Applications 
		(
			ApplicationName,
			AppCategory1,
			AppCategory2,
			VersionSupport,
			Responsible
		)
		VALUES
		(
			@Application,
			@Category1,
			@Category2,
			CASE @Version WHEN 'V1' THEN '1' WHEN 'V2' THEN '2' ELSE '3' END,
			@ResponsibleID
		)

END
