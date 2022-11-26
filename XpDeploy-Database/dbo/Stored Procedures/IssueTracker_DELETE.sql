CREATE PROCEDURE [dbo].[IssueTracker_DELETE]
(      
	@ID NVARCHAR(100) = NULL
)
AS
BEGIN
	SET NOCOUNT ON;  
	
	DELETE FROM IssueTracker WHERE ID = @ID

END


      

