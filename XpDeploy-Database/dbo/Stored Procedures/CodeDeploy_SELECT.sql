
CREATE PROCEDURE [dbo].[CodeDeploy_SELECT] 
(
@Action NVARCHAR(50),
@ENV NVARCHAR(50),
@Client NVARCHAR(50),
@Application NVARCHAR(50),
@ActiveStatus NVARCHAR(50),
@Header  NVARCHAR(50) OUTPUT
)

AS
BEGIN

	SET NOCOUNT ON;
	SET @Header = 'Code Deploy'

	INSERT INTO CodeDeploy (ENVID,ApplicationID,CodeDeployName,CodePipelineName,S3,App_Spec,IsActive)
	SELECT EM.ID,A.ID,NULL,NULL,'','',0 FROM Applications A 
	CROSS JOIN ENVMaster EM
	WHERE ENVName = @ENV
	AND A.ID NOT IN
	(SELECT ApplicationID FROM CodeDeploy WHERE ENVID = EM.ID)


	IF @ENV = 'HCCB'

	WITH HCCB AS
	(
	SELECT
		ApplicationId,	
		CASE WHEN @Action = 'ExportData' THEN CodeDeployName ELSE '<a href="'+CodeDeploy1+''+CodeDeployName+'"'+'target="_blank">'+CodeDeployName+'</a>' END AS CodeDeploy,
		CASE WHEN @Action = 'ExportData' THEN CodePipelineName ELSE '<a href="'+CodePipeline1+''+CodePipelineName+ '/view?''"'+'target="_blank">'+CodePipelineName+'</a>' END AS CodePipeline,
		CASE WHEN @Action = 'ExportData' THEN S3 ELSE '<a href="'+IT.S3_1+''+CD.S3+ '.zip?''"'+'target="_blank">'+CD.S3+'</a>' END AS S3,		
		CASE WHEN @Action = 'ExportData' THEN App_Spec ELSE REPLACE (App_Spec , ',','<br />' ) END AS App_Spec
	FROM CodeDeploy CD WITH(NOLOCK)
	INNER JOIN ENVMaster EM WITH(NOLOCK) ON EM.ID = CD.ENVID
	CROSS JOIN IdentityTable IT
	WHERE ENVName = @ENV
	AND (IsActive = CASE ''+@ActiveStatus+'' WHEN 'Active' THEN '1' ELSE '0' END OR ISNULL(CASE ''+@ActiveStatus+'' WHEN 'Active' THEN '1' ELSE '0' END, '') = '')
	)
	SELECT
		ROW_NUMBER() OVER(ORDER BY CodeDeploy DESC) AS SlNo,
		ApplicationName,
		CodeDeploy,
		CodePipeline,
		S3,
		App_Spec
	FROM Applications A
	INNER JOIN HCCB WITH(NOLOCK) ON HCCB.ApplicationID = A.ID
	WHERE (ApplicationName = @Application OR ISNULL(@Application, '') = '')
	

	IF @ENV = 'SAAS'

	WITH SAAS AS
	(
	SELECT
		ApplicationId,	
		CASE WHEN @Action = 'ExportData' THEN CodeDeployName ELSE '<a href="'+CodeDeploy2+''+CodeDeployName+'"'+'target="_blank">'+CodeDeployName+'</a>' END AS CodeDeploy,
		CASE WHEN @Action = 'ExportData' THEN CodePipelineName ELSE '<a href="'+CodePipeline2+''+CodePipelineName+ '/view?''"'+'target="_blank">'+CodePipelineName+'</a>' END AS CodePipeline,
		CASE WHEN @Action = 'ExportData' THEN S3 ELSE '<a href="'+IT.S3_2+''+CD.S3+ '.zip?''"'+'target="_blank">'+CD.S3+'</a>' END AS S3,		
		CASE WHEN @Action = 'ExportData' THEN App_Spec ELSE REPLACE (App_Spec , ',','<br />' ) END AS App_Spec
	FROM CodeDeploy CD WITH(NOLOCK)
	INNER JOIN ENVMaster EM WITH(NOLOCK) ON EM.ID = CD.ENVID
	CROSS JOIN IdentityTable IT
	WHERE ENVName = @ENV
	AND (IsActive = CASE ''+@ActiveStatus+'' WHEN 'Active' THEN '1' ELSE '0' END OR ISNULL(CASE ''+@ActiveStatus+'' WHEN 'Active' THEN '1' ELSE '0' END, '') = '')
	)
	SELECT
		ROW_NUMBER() OVER(ORDER BY CodeDeploy DESC) AS SlNo,
		ApplicationName,
		CodeDeploy,
		CodePipeline,
		S3,
		App_Spec
	FROM Applications A
	INNER JOIN SAAS WITH(NOLOCK) ON SAAS.ApplicationID = A.ID
	WHERE (ApplicationName = @Application OR ISNULL(@Application, '') = '')

	IF @ENV = 'SAASV2'

	WITH V2 AS
	(
	SELECT
		ApplicationId,	
		CASE WHEN @Action = 'ExportData' THEN CodeDeployName ELSE '<a href="'+CodeDeploy3+''+CodeDeployName+'"'+'target="_blank">'+CodeDeployName+'</a>' END AS CodeDeploy,
		CASE WHEN @Action = 'ExportData' THEN CodePipelineName ELSE '<a href="'+CodePipeline3+''+CodePipelineName+ '/view?''"'+'target="_blank">'+CodePipelineName+'</a>' END AS CodePipeline,
		CASE WHEN @Action = 'ExportData' THEN S3 ELSE '<a href="'+IT.S3_3+''+CD.S3+ '.zip?''"'+'target="_blank">'+CD.S3+'</a>' END AS S3,		
		CASE WHEN @Action = 'ExportData' THEN App_Spec ELSE REPLACE (App_Spec , ',','<br />' ) END AS App_Spec
	FROM CodeDeploy CD WITH(NOLOCK)
	INNER JOIN ENVMaster EM  WITH(NOLOCK) ON EM.ID = CD.ENVID
	CROSS JOIN IdentityTable IT
	WHERE ENVName = @ENV
	AND (IsActive = CASE ''+@ActiveStatus+'' WHEN 'Active' THEN '1' ELSE '0' END OR ISNULL(CASE ''+@ActiveStatus+'' WHEN 'Active' THEN '1' ELSE '0' END, '') = '')
	)
	SELECT
		ROW_NUMBER() OVER(ORDER BY CodeDeploy DESC) AS SlNo,
		ApplicationName,
		CodeDeploy,
		CodePipeline,
		S3,
		App_Spec
	FROM Applications A
	INNER JOIN V2 WITH(NOLOCK) ON V2.ApplicationID = A.ID
	WHERE (ApplicationName = @Application OR ISNULL(@Application, '') = '')

IF @ENV = 'CCI'

	WITH CCI1 AS
	(
	SELECT
		ApplicationId,	
		CASE WHEN @Action = 'ExportData' THEN CodeDeployName ELSE '<a href="'+CodeDeploy4+''+CodeDeployName+'"'+'target="_blank">'+CodeDeployName+'</a>' END AS CodeDeploy,
		CASE WHEN @Action = 'ExportData' THEN CodePipelineName ELSE '<a href="'+CodePipeline4+''+CodePipelineName+ '/view?''"'+'target="_blank">'+CodePipelineName+'</a>' END AS CodePipeline,
		CASE WHEN @Action = 'ExportData' THEN S3 ELSE '<a href="'+IT.S3_4+''+CD.S3+ '.zip?''"'+'target="_blank">'+CD.S3+'</a>' END AS S3,		
		CASE WHEN @Action = 'ExportData' THEN App_Spec ELSE REPLACE (App_Spec , ',','<br />' ) END AS App_Spec
	FROM CodeDeploy CD WITH(NOLOCK)
	INNER JOIN ENVMaster EM  WITH(NOLOCK) ON EM.ID = CD.ENVID
	CROSS JOIN IdentityTable IT
	WHERE ENVName = @ENV
	AND (IsActive = CASE ''+@ActiveStatus+'' WHEN 'Active' THEN '1' ELSE '0' END OR ISNULL(CASE ''+@ActiveStatus+'' WHEN 'Active' THEN '1' ELSE '0' END, '') = '')
	)
	SELECT
		ROW_NUMBER() OVER(ORDER BY CodeDeploy DESC) AS SlNo,
		ApplicationName,
		CodeDeploy,
		CodePipeline,
		S3,
		App_Spec
	FROM Applications A
	INNER JOIN CCI1 WITH(NOLOCK) ON CCI1.ApplicationID = A.ID
	WHERE (ApplicationName = @Application OR ISNULL(@Application, '') = '')


IF @ENV = 'CCV'

	WITH CCV AS
	(
	SELECT
		ApplicationId,	
		CASE WHEN @Action = 'ExportData' THEN CodeDeployName ELSE '<a href="'+CodeDeploy4+''+CodeDeployName+'"'+'target="_blank">'+CodeDeployName+'</a>' END AS CodeDeploy,
		CASE WHEN @Action = 'ExportData' THEN CodePipelineName ELSE '<a href="'+CodePipeline4+''+CodePipelineName+ '/view?''"'+'target="_blank">'+CodePipelineName+'</a>' END AS CodePipeline,
		CASE WHEN @Action = 'ExportData' THEN S3 ELSE '<a href="'+IT.S3_4+''+CD.S3+ '.zip?''"'+'target="_blank">'+CD.S3+'</a>' END AS S3,		
		CASE WHEN @Action = 'ExportData' THEN App_Spec ELSE REPLACE (App_Spec , ',','<br />' ) END AS App_Spec
	FROM CodeDeploy CD WITH(NOLOCK)
	INNER JOIN ENVMaster EM  WITH(NOLOCK) ON EM.ID = CD.ENVID
	CROSS JOIN IdentityTable IT
	WHERE ENVName = @ENV
	AND (IsActive = CASE ''+@ActiveStatus+'' WHEN 'Active' THEN '1' ELSE '0' END OR ISNULL(CASE ''+@ActiveStatus+'' WHEN 'Active' THEN '1' ELSE '0' END, '') = '')
	)
	SELECT
		ROW_NUMBER() OVER(ORDER BY CodeDeploy DESC) AS SlNo,
		ApplicationName,
		CodeDeploy,
		CodePipeline,
		S3,
		App_Spec
	FROM Applications A
	INNER JOIN CCV WITH(NOLOCK) ON CCV.ApplicationID = A.ID
	WHERE (ApplicationName = @Application OR ISNULL(@Application, '') = '')

IF @ENV = 'UL'

	WITH UL AS
	(
	SELECT
		ApplicationId,	
		CASE WHEN @Action = 'ExportData' THEN CodeDeployName ELSE '<a href="'+CodeDeploy4+''+CodeDeployName+'"'+'target="_blank">'+CodeDeployName+'</a>' END AS CodeDeploy,
		CASE WHEN @Action = 'ExportData' THEN CodePipelineName ELSE '<a href="'+CodePipeline4+''+CodePipelineName+ '/view?''"'+'target="_blank">'+CodePipelineName+'</a>' END AS CodePipeline,
		CASE WHEN @Action = 'ExportData' THEN S3 ELSE '<a href="'+IT.S3_4+''+CD.S3+ '.zip?''"'+'target="_blank">'+CD.S3+'</a>' END AS S3,		
		CASE WHEN @Action = 'ExportData' THEN App_Spec ELSE REPLACE (App_Spec , ',','<br />' ) END AS App_Spec
	FROM CodeDeploy CD WITH(NOLOCK)
	INNER JOIN ENVMaster EM  WITH(NOLOCK) ON EM.ID = CD.ENVID
	CROSS JOIN IdentityTable IT
	WHERE ENVName = @ENV
	AND (IsActive = CASE ''+@ActiveStatus+'' WHEN 'Active' THEN '1' ELSE '0' END OR ISNULL(CASE ''+@ActiveStatus+'' WHEN 'Active' THEN '1' ELSE '0' END, '') = '')
	)
	SELECT
		ROW_NUMBER() OVER(ORDER BY CodeDeploy DESC) AS SlNo,
		ApplicationName,
		CodeDeploy,
		CodePipeline,
		S3,
		App_Spec
	FROM Applications A
	INNER JOIN UL WITH(NOLOCK) ON UL.ApplicationID = A.ID
	WHERE (ApplicationName = @Application OR ISNULL(@Application, '') = '')

	END
