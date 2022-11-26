CREATE PROCEDURE [dbo].[ApplicationList_DELETE]
(      
	@ID NVARCHAR(100)
)
AS
BEGIN
	SET NOCOUNT ON;  
		
	DELETE FROM Applications WHERE ID = @ID

END


      

