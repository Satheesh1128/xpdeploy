

--Check Output
--DECLARE	@return_value int,
--		@selectcolumn1 nvarchar(100)
--EXEC	[dbo].[Attendance_Take]	@atdDate = N'12-Jan-2017',@atdclass = N'I',@atdsec = N'A',@selectcolumn1 = @selectcolumn1 OUTPUT


CREATE PROCEDURE [dbo].[DBCompare_SELECT]
	-- Add the parameters for the stored procedure here
(
@FromDate DATE,
@CreatedDate DATE,
@ENV Nvarchar(100),
@Owner Nvarchar(100),
@Server Nvarchar(100),
@DBDiff Nvarchar(100),
@Header  NVARCHAR(70) OUTPUT
)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	DECLARE @Count nvarchar(100)

	IF @ENV = '--Env--' SET @ENV = ''
	IF @Owner = '--Owner--' SET @Owner = ''
	IF @Server = '--Server--' SET @Server = ''
	IF @DBDiff = '--DBDiff--' SET @DBDiff = ''

DECLARE @GETDATE DATE = GETDATE()
DECLARE @TodaysInsertCount INT

SET @TodaysInsertCount = (SELECT count(*) FROM dbcomparison where CreatedDate = convert(varchar,GETDATE()))
IF  @TodaysInsertCount = 0

BEGIN 

WITH T1 AS
(
SELECT [DB_ID],DMS_Compare_Source AS SourceDB ,DMS AS TargetDB FROM DBs
WHERE DMS <> '' AND IsActive = 1
UNION
SELECT [DB_ID],Central_Compare_Source AS SourceDB ,Central AS TargetDB FROM DBs
WHERE Central <> '' AND IsActive = 1
UNION
SELECT [DB_ID],RT60_Compare_Source AS SourceDB ,RT60 AS TargetDB FROM DBs
WHERE RT60 <> '' AND IsActive = 1
UNION
SELECT [DB_ID],Selfie_Compare_Source AS SourceDB ,Selfie AS TargetDB FROM DBs
WHERE Selfie <> '' AND IsActive = 1
)
INSERT INTO dbcomparison ([DB_ID],SourceDB,TargetDB,Difference,CreatedDate,ModifiedDateTIme,[Diff-Verified])
SELECT [DB_ID],SourceDB,TargetDB,'Not Compared',@GETDATE,@GETDATE,'' FROM T1

--UPDATE C SET UserId = DBS.UserId FROM dbcomparison C
--INNER JOIN DBS WITH(NOLOCK) ON C.DB_ID = DBS.DB_ID

END

SELECT * FROM dbcomparison DC
inner join DBs WITH(NOLOCK) ON DC.DB_ID = DBS.DB_ID
inner join Users U WITH(NOLOCK) ON DBs.UserId = U.UserId
WHERE  DC.CreatedDate BETWEEN @FromDate AND @CreatedDate
AND (ENV =  @ENV OR ISNULL( @ENV, '') = '')
AND (UserName =  @Owner OR ISNULL( @Owner, '') = '')
AND (Server =  @Server OR ISNULL( @Server, '') = '')
AND (Difference =  @DBDiff OR ISNULL( @DBDiff, '') = '')
ORDER BY TargetDB,SourceDB

SELECT @Count = COUNT(*) FROM dbcomparison DC
inner join DBs WITH(NOLOCK) ON DC.DB_ID = DBS.DB_ID
inner join Users U WITH(NOLOCK) ON DBs.UserId = U.UserId
WHERE  DC.CreatedDate BETWEEN @FromDate AND @CreatedDate
AND (ENV =  @ENV OR ISNULL( @ENV, '') = '')
AND (UserName =  @Owner OR ISNULL( @Owner, '') = '')
AND (Server =  @Server OR ISNULL( @Server, '') = '')
AND (Difference =  @DBDiff OR ISNULL( @DBDiff, '') = '')

SET @Header = 'Database Comparison Status     '+'Total DB''s Selected: ' + @Count

END


