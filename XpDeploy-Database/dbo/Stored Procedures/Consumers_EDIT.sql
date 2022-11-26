﻿CREATE PROCEDURE [dbo].[Consumers_EDIT]
(      
	--@ID NVARCHAR(100),
	--@Client NVARCHAR(100),
	@Server NVARCHAR(100),
	@Application NVARCHAR(100),	
	
	@HCCBAPP2 NVARCHAR(100) OUTPUT,
	@HCCBAPP3 NVARCHAR(100) OUTPUT,
	@HCCBAPP4 NVARCHAR(100) OUTPUT,
	@HCCBAPP5 NVARCHAR(100) OUTPUT,
	@HCCBAPP6 NVARCHAR(100) OUTPUT,
	@SAASAPP4 NVARCHAR(100) OUTPUT,
	@SAASAPP5 NVARCHAR(100) OUTPUT,
	@SAASAPP6 NVARCHAR(100) OUTPUT,
	@HCCBFAT NVARCHAR(100) OUTPUT,
	@HCCBUAT NVARCHAR(100) OUTPUT,
	@SAASSIT NVARCHAR(100) OUTPUT,
	@SAASUAT NVARCHAR(100) OUTPUT,
	@SITV2APP NVARCHAR(100) OUTPUT,
	@UATV2APP NVARCHAR(100) OUTPUT,
	@PRDV2APP1 NVARCHAR(100) OUTPUT,
	@SAASPILOT NVARCHAR(100) OUTPUT,
	@SAASDEMO NVARCHAR(100) OUTPUT,
	@DEMOV2 NVARCHAR(100) OUTPUT,
	@TRAINING NVARCHAR(100) OUTPUT,
	@IsActive NVARCHAR(100) OUTPUT,

	@HeaderText NVARCHAR(100) OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET @HeaderText = 'Modify Urls Details'
	--SELECT * FROM CONSUMERS
	SELECT	
		@Application = A.ApplicationName,
		@Server = SM.ServerName,
		@HCCBAPP2 = HCCBAPP2,
		@HCCBAPP3 = HCCBAPP3,
		@HCCBAPP4 = HCCBAPP4,
		@HCCBAPP5 = HCCBAPP5,
		@HCCBAPP6 = HCCBAPP6,
		@SAASAPP4 = SAASAPP4,
		@SAASAPP5 = SAASAPP5,
		@SAASAPP6 = SAASAPP6,
		@HCCBFAT = HCCBFAT,
		@HCCBUAT = HCCBUAT,
		@SAASSIT = SAASSIT,
		@SAASUAT = SAASUAT,
		@SITV2APP = SITV2APP,
		@UATV2APP = UATV2APP,
		@PRDV2APP1 = PRDV2APP1,
		@SAASPILOT = SAASPILOT,
		@SAASDEMO = SAASDEMO,
		@DEMOV2 = DEMOV2,
		@TRAINING = TRAINING,
		@IsActive = CASE C.IsActive WHEN 1 THEN 'Active' ELSE 'InActive' END
	FROM Consumers C
	INNER JOIN ServerMaster SM WITH(NOLOCK) ON C.ServerID = sm.ID
	INNER JOIN Applications A WITH(NOLOCK) ON C.ApplicationID = A.ID
	WHERE SM.ServerName = @Server
	AND A.ApplicationName = @Application
END


      
