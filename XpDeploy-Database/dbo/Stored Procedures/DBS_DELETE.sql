﻿CREATE PROCEDURE [dbo].[DBS_DELETE]
(      
	@ID NVARCHAR(100) = NULL
)
AS
BEGIN
	SET NOCOUNT ON;  
	
	DELETE FROM DBs WHERE DB_ID = @ID

END


      

