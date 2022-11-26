-- Procedure

CREATE PROCEDURE [dbo].[ApplicationList_SELECT] 
(
@Action NVARCHAR(50),
@AppCategory2 NVARCHAR(50),
@AppCategory1 NVARCHAR(50),
@Application NVARCHAR(50),
@ServerName NVARCHAR(50),
@ActiveStatus NVARCHAR(50),
@Responsible NVARCHAR(100),
@Search NVARCHAR(100),

@Header1 Nvarchar(100) OUTPUT,
@Header2 Nvarchar(100) OUTPUT,
@Header3 Nvarchar(100) OUTPUT
)

AS
BEGIN

	SET NOCOUNT ON;

	IF @Responsible = '--Owner--' SET @Responsible = ''
	IF @AppCategory1 = '--Category1--' SET @AppCategory1 = ''
	IF @AppCategory2 = '--Category2--' SET @AppCategory2 = ''

	SET  @Header1 = (SELECT 'Xnapp Total Apps - ' + convert(nvarchar,COUNT(*)) FROM Applications)

	SELECT
	ROW_NUMBER() OVER(ORDER BY B.CategoryName,C.CategoryName) AS SlNo,
	ID,
	ApplicationName,
	B.CategoryName AS Category1,
	C.CategoryName AS Category2,
	UserName AS Responsible
	FROM Applications A
	INNER JOIN AppCategory1 B WITH(NOLOCK) ON A.AppCategory1 = B.Category1ID
	INNER JOIN AppCategory2 C WITH(NOLOCK) ON A.AppCategory2 = C.Category2ID
	INNER JOIN Users U WITH(NOLOCK) ON U.UserId = A.Responsible
	WHERE (C.CategoryName = @AppCategory2 OR ISNULL(@AppCategory2, '') = '')
	AND (B.CategoryName = @AppCategory1 OR ISNULL(@AppCategory1, '') = '')
	AND (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
	--AND (A.Responsible = @Responsible OR ISNULL(@Responsible, '') = '')
	AND (U.UserName = @Responsible OR ISNULL(@Responsible, '') = '')
	AND (A.ApplicationName like '%' + @Search + '%' OR ISNULL(@Search, '') = '')
	

	SET  @Header3 = (
	SELECT 'Selected Apps - ' + convert(nvarchar,COUNT(*))
	FROM Applications A
	INNER JOIN AppCategory1 B WITH(NOLOCK) ON A.AppCategory1 = B.Category1ID
	INNER JOIN AppCategory2 C WITH(NOLOCK) ON A.AppCategory2 = C.Category2ID
	INNER JOIN Users U WITH(NOLOCK) ON U.UserId = A.Responsible
	WHERE (C.CategoryName = @AppCategory2 OR ISNULL(@AppCategory2, '') = '')
	AND (B.CategoryName = @AppCategory1 OR ISNULL(@AppCategory1, '') = '')
	AND (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')
	--AND (A.Responsible = @Responsible OR ISNULL(@Responsible, '') = '')
	AND (U.UserName = @Responsible OR ISNULL(@Responsible, '') = '')
	AND (A.ApplicationName like '%' + @Search + '%' OR ISNULL(@Search, '') = '')
	)	
	
		

	END
