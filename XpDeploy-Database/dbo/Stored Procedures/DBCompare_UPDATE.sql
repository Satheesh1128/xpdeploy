


--Check Output
--DECLARE	@return_value int,
--		@selectcolumn1 nvarchar(100)
--EXEC	[dbo].[Attendance_Take]	@atdDate = N'12-Jan-2017',@atdclass = N'I',@atdsec = N'A',@selectcolumn1 = @selectcolumn1 OUTPUT


CREATE PROCEDURE [dbo].[DBCompare_UPDATE]
	-- Add the parameters for the stored procedure here
	--(
	--@Owner NVARCHAR(MAX)
	--)

AS
BEGIN
		

BEGIN TRY

		
    BEGIN TRANSACTION


UPDATE C SET UserId = DBS.UserId FROM dbcomparison C
INNER JOIN DBS WITH(NOLOCK) ON C.DB_ID = DBS.DB_ID

UPDATE C SET C.Difference = L.Difference,C.[Diff-Verified] = L.[Diff-Verified] FROM dbcomparison C
INNER JOIN dbcomparison_LOG L WITH(NOLOCK) ON C.DB_ID = L.DB_ID AND C.CreatedDate = L.CreatedDate

TRUNCATE TABLE dbcomparison_log

    COMMIT TRANSACTION
END TRY
BEGIN CATCH

    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION

		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE()
		DECLARE @ErrorSeverity INT = ERROR_SEVERITY()
		DECLARE @ErrorState INT = ERROR_STATE()
		
		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH


END



