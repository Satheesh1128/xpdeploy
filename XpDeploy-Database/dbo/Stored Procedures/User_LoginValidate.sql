
CREATE PROCEDURE [dbo].[User_LoginValidate]
      @Username NVARCHAR(20),
      @Password NVARCHAR(200),      
      @RoleId NVARCHAR(100) OUTPUT,
      @Class NVARCHAR(100) OUTPUT,
      @Section NVARCHAR(100) OUTPUT,
	  @Medium NVARCHAR(100) OUTPUT,
      @Phonenumber NVARCHAR(10) OUTPUT,
      @OTP NVARCHAR(10) OUTPUT,
	  @Changepassword NVARCHAR(10) OUTPUT,
	  @UserId NVARCHAR(10) OUTPUT
AS
BEGIN
      SET NOCOUNT ON;
      DECLARE @LastLoginDate DATETIME
     
      SELECT @UserId = UserId, @LastLoginDate = LastLoginDate,@RoleID = RoleId,@Changepassword = Changepassword--,@Phonenumber = FatherMobile
      FROM Users WHERE Username = @Username AND Password = @Password AND Status = 1

      IF @UserId IS NOT NULL
      
            --IF NOT EXISTS(SELECT UserId FROM UserActivation WHERE UserId = @UserId)
            BEGIN
                  UPDATE Users
                  SET LastLoginDate = GETDATE(),
                  OTP = RIGHT(SYSDATETIME(),4),
                  OTPStatus = 1
                  WHERE UserId = @UserId
                  SELECT @UserId [UserId] -- User Valid
                  SET @OTP = (SELECT OTP FROM Users WHERE UserId = @UserId)
            END
            ELSE
      BEGIN
            SELECT -1 -- User invalid.
      END
END

