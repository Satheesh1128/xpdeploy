
CREATE PROCEDURE [dbo].[User_OtpValidate]
      @Username NVARCHAR(20),
      @Password NVARCHAR(20),
      @OTP INT =null,
      @RoleId NVARCHAR(100) OUTPUT,
      @Class NVARCHAR(100) OUTPUT,
      @Section NVARCHAR(100) OUTPUT
AS
BEGIN
      SET NOCOUNT ON;
      DECLARE @UserId INT, @LastLoginDate DATETIME
      DECLARE @OtpTime INT
      
     
      SELECT @UserId = UserId, @LastLoginDate = LastLoginDate,@RoleId = RoleId
      FROM Users WHERE Username = @Username AND [Password] = @Password
	  --AND OTP = @OTP AND ISNULL((datediff(minute, LastLoginDate, GETDATE())),0) <= 15
      
      --SELECT @Class = Class,@Section = Section FROM StudentMaster WHERE Code = @Username
     
      IF @UserId IS NOT NULL
      
            --IF NOT EXISTS(SELECT UserId FROM UserActivation WHERE UserId = @UserId)
            BEGIN
                  UPDATE Users
                  SET LastLoginDate = GETDATE(),
                  OTP = RIGHT(SYSDATETIME(),4),
                  OTPStatus = 0
                  WHERE UserId = @UserId
                  SELECT @UserId [UserId] -- User Valid
            END
            ELSE
      BEGIN
            SELECT -1 -- User invalid.
      END
END

