
CREATE PROCEDURE [dbo].[DBs_SELECT]
(
@RoleID int,
@RoleName Nvarchar(100),
@UserName Nvarchar(100),
@DBNameSearch Nvarchar(100),
@Action Nvarchar(100),
@ActiveStatus Nvarchar(100),

@ENV Nvarchar(100),
@BindENVLists Nvarchar(100),
@Owner Nvarchar(100),
@Version Nvarchar(100),

@Header1 Nvarchar(100) OUTPUT,
@Header2 Nvarchar(100) OUTPUT,
@Header3 Nvarchar(100) OUTPUT
)

AS
BEGIN

	SET NOCOUNT ON;
	

	DECLARE @DMS int,@CENTRAL int,@RT60 int,@SELFIE int,@TotalDBs int
	DECLARE @DMS1 int,@CENTRAL1 int,@RT601 int,@SELFIE1 int,@TotalDBs1 int
	DECLARE @DMSt int,@CENTRALt int,@RT60t int,@SELFIEt int

	DECLARE @TotalSelectedDBs int

	
	SELECT @DMS = COUNT(Distinct DMS) FROM DBs WHERE IsActive = 1 AND DMS IS NOT NULL AND DMS <> ''
	SELECT @CENTRAL = COUNT(Distinct CENTRAL) FROM DBs WHERE IsActive = 1 AND CENTRAL IS NOT NULL AND CENTRAL <> ''
	SELECT @RT60 = COUNT(Distinct RT60) FROM DBs WHERE IsActive = 1 AND RT60 IS NOT NULL AND RT60 <> ''
	SELECT @SELFIE = COUNT(Distinct SELFIE) FROM DBs WHERE IsActive = 1 AND SELFIE IS NOT NULL AND SELFIE <> ''
	SET @TotalDBs = sum(@DMS+@CENTRAL+@RT60+@SELFIE)

	SELECT @DMS1 = COUNT(Distinct DMS) FROM DBs WHERE IsActive = 2 AND DMS IS NOT NULL AND DMS <> ''
	SELECT @CENTRAL1 = COUNT(Distinct CENTRAL) FROM DBs WHERE IsActive = 2 AND CENTRAL IS NOT NULL AND CENTRAL <> ''
	SELECT @RT601 = COUNT(Distinct RT60) FROM DBs WHERE IsActive = 2 AND RT60 IS NOT NULL AND RT60 <> ''
	SELECT @SELFIE1 = COUNT(Distinct SELFIE) FROM DBs WHERE IsActive = 2 AND SELFIE IS NOT NULL AND SELFIE <> ''
	SET @TotalDBs1 = sum(@DMS1+@CENTRAL1+@RT601+@SELFIE1)

	--SET @Header = 'Over All Total Live DBs - ' + CONVERT(NVARCHAR,@TotalDBs)

	IF @ENV = '--Env--' SET @ENV = ''
	IF @Version = '--Version--' SET @Version = ''
	IF @BindENVLists = '--Server--' SET @BindENVLists = ''
	IF @Owner = '--Owner--' SET @Owner = ''
	
	;WITH T1 AS
	(
		SELECT
			DB_ID,
			EM.ENVName AS ENV,
			DMS,
			Central,
			RT60,
			Selfie
		FROM DBs 
		LEFT OUTER JOIN ActiveStatus A WITH(NOLOCK) ON DBS.IsActive = A.ID
		LEFT OUTER JOIN Users U WITH(NOLOCK) ON DBS.UserId = U.UserId
		LEFT OUTER JOIN ENVMaster EM WITH(NOLOCK) ON DBS.ENV = EM.ID
		WHERE (EM.ENVName =  @ENV OR ISNULL( @ENV, '') = '')
		AND (Version =  @Version OR ISNULL( @Version, '') = '')
		AND (Server =  @BindENVLists OR ISNULL( @BindENVLists, '') = '')
		AND (U.UserName =  @Owner OR ISNULL( @Owner, '') = '')
		AND A.Description = @ActiveStatus
		AND (
		(DBs.DMS like '%' + @DBNameSearch + '%' OR ISNULL(@DBNameSearch, '') = '') OR 
		(DBs.Central like '%' + @DBNameSearch + '%' OR ISNULL(@DBNameSearch, '') = '') OR 
		(DBs.RT60 like '%' + @DBNameSearch + '%' OR ISNULL(@DBNameSearch, '') = '') OR
		(DBs.Selfie like '%' + @DBNameSearch + '%' OR ISNULL(@DBNameSearch, '') = '')
		)
		
		)
		
		SELECT * INTO #temp FROM T1 ORDER BY ENV;
		SELECT * FROM #temp
		SELECT @DMSt = COUNT(Distinct DMS) FROM #temp WHERE DMS IS NOT NULL AND DMS <> '';
		SELECT @CENTRALt = COUNT(Distinct Central) FROM #temp WHERE Central IS NOT NULL AND Central <> '';
		SELECT @RT60t = COUNT(Distinct RT60) FROM #temp WHERE RT60 IS NOT NULL AND RT60 <> '';
		SELECT @SELFIEt = COUNT(Distinct Selfie) FROM #temp WHERE Selfie IS NOT NULL AND Selfie <> '';

		SET @TotalSelectedDBs =	sum(@DMSt+@CENTRALt+@RT60t+@SELFIEt)

		SET @Header1 = 'DB Live - ' + CONVERT(NVARCHAR,@TotalDBs) 
		SET @Header2 = 'Inactive - ' + CONVERT(NVARCHAR,@TotalDBs1)
		SET @Header3 = 'Selected - ' + CONVERT(NVARCHAR,@TotalSelectedDBs)
		
					
END
	

	
    



