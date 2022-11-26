CREATE PROCEDURE [dbo].[Masters_DELETE]
(      
	@ID NVARCHAR(100) = NULL,
	@Masterselect NVARCHAR(100)
)
AS
BEGIN
	SET NOCOUNT ON;  
		
		IF @Masterselect = 'Environments'

			BEGIN
				DELETE FROM ENVMaster WHERE ID = @ID
			END

		IF @Masterselect = 'Clients'

			BEGIN
				DELETE FROM ClientMaster WHERE ID = @ID
			END

		IF @Masterselect = 'Servers'

			BEGIN
				DELETE FROM ServerMaster WHERE ID = @ID
			END

		IF @Masterselect = 'ServerList'

			BEGIN
				DELETE FROM ServerList WHERE ServerListID = @ID
			END

END


      

