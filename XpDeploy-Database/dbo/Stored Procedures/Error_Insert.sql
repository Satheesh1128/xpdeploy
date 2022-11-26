CREATE PROCEDURE [dbo].[Error_Insert] 

(  
      @Exmessage NVARCHAR(100),
      @Errorpage nvarchar(50),
      @Errorfunction nvarchar(max))

AS
BEGIN

	SET NOCOUNT ON;

INSERT INTO error
(
error,
ErrorPage,
ErrorFunction,
Modifieddatetime
) 
VALUES 
(
@Exmessage,
@Errorpage,
@Errorfunction,
getdate()
)

END

