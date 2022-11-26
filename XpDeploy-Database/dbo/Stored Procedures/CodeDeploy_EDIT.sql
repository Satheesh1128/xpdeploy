CREATE PROCEDURE [dbo].[CodeDeploy_EDIT]
(      
	@ENV NVARCHAR(100),
	@Application NVARCHAR(100),	
	@CodeDeployName NVARCHAR(100) OUTPUT,
	@CodePipelineName NVARCHAR(100) OUTPUT,
	@S3 NVARCHAR(100) OUTPUT,
	@App_Spec NVARCHAR(MAX) OUTPUT,
	@IsActive NVARCHAR(100) OUTPUT,
	@HeaderText NVARCHAR(100) OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET @HeaderText = 'Modify CodeDeploy Details'
	SELECT
		@CodeDeployName = CodeDeployName,
		@CodePipelineName = CodePipelineName,
		@S3 = S3,
		@App_Spec = App_Spec,		
		@IsActive = CASE IsActive WHEN 1 THEN 'Active' ELSE 'InActive' END
	FROM CodeDeploy CD
	INNER JOIN ENVMaster EM WITH(NOLOCK) ON EM.ID = CD.ENVID
	INNER JOIN Applications A WITH(NOLOCK) ON CD.ApplicationID = A.ID
	WHERE EM.ENVName = @ENV
	AND A.ApplicationName = @Application
END


      

