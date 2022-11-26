-- Procedure
CREATE PROCEDURE [dbo].[CodeDeploy_UPDATE]
(      
	@ENV NVARCHAR(100),
	@Application NVARCHAR(100),	
	@CodeDeployName NVARCHAR(100),
	@CodePipelineName NVARCHAR(100),
	@S3 NVARCHAR(100),
	@App_Spec NVARCHAR(MAX),
	@IsActive NVARCHAR(100)
)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE CD SET
		 CodeDeployName = CASE @CodeDeployName WHEN '' THEN NULL ELSE @CodeDeployName END,
		 CodePipelineName = CASE @CodePipelineName WHEN '' THEN NULL ELSE @CodePipelineName END,
		 S3 = @S3,
		 App_Spec = @App_Spec,		
		 IsActive = CASE @IsActive WHEN 'Active' THEN '1' ELSE '0' END
	FROM CodeDeploy CD
	INNER JOIN ENVMaster EM WITH(NOLOCK) ON EM.ID = CD.ENVID
	INNER JOIN Applications A WITH(NOLOCK) ON CD.ApplicationID = A.ID
	WHERE EM.ENVName = @ENV
	AND A.ApplicationName = @Application
END


      

