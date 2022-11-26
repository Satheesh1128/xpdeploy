CREATE PROCEDURE [dbo].[ReleaseTracker_DELETE]
(      
	@ID NVARCHAR(100) = NULL
)
AS
BEGIN
	SET NOCOUNT ON;  
	
	DELETE FROM ReleaseTracker WHERE ID = @ID

END


      

