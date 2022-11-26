CREATE PROCEDURE [dbo].[Account_Create]
(
@AccountName NVARCHAR(30),
@ErrorCode NVARCHAR(500) OUTPUT
)
AS
BEGIN
--EXEC Account_Create 'CCI'
	SET NOCOUNT ON;
	 
	BEGIN TRANSACTION;

	BEGIN TRY

	DECLARE @ENVID INT
	DECLARE @ServerMasterID INT
	DECLARE @ServerMasterID1 INT

	SELECT @ENVID = ISNULL(MAX(ID),0)+1 FROM ENVMaster
	--INSERT INTO ENVMaster VALUES (@ENVID,@AccountName)

	--SELECT * FROM ServerMaster
	
	SELECT @ServerMasterID = ISNULL(MAX(ID),0)+1 FROM ServerMaster
	--INSERT INTO ServerMaster(ID,ServerName,EnvId) VALUES (@ServerMasterID,'NONPRD',@ENVID)
	
	SELECT @ServerMasterID1 = ISNULL(MAX(ID),0)+1 FROM ServerMaster
	--INSERT INTO ServerMaster(ID,ServerName,EnvId) VALUES (@ServerMasterID1,'PRD',@ENVID)

	---ClientMaster--
	DECLARE @ClientID INT
	SELECT @ClientID = ISNULL( MAX(ID)+1,0) FROM ClientMaster
	--INSERT INTO ClientMaster VALUES (@ClientID,@ENVID,@AccountName);

	COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		SET @ErrorCode ='Error: ' + CAST(ERROR_MESSAGE() AS NVARCHAR(MAX));
	END CATCH;


--	UPDATE ReleaseTracker SET FAT_RD=SAASSIT_RD,UAT_RD=SAASUAT_RD,PRD_RD=SAASPRD WHERE EnvId = 2
--UPDATE ReleaseTracker SET FAT_RD=SITV2_RD,UAT_RD=UATV2_RD,PRD_RD=PRDV2_RD WHERE EnvId = 3
	

--	delete from ENVMaster where ENVName='CCI'
--	delete from ClientMaster where ENVID IN (SELECT ID from ENVMaster where ENVName='CCI')
--	delete from Urls where ClientId IN (SELECT ID from ClientMaster where ClientName='CCI')
--	delete from ServerMaster where ENVID IN (SELECT ID from ENVMaster where ENVName='CCI')
--delete from CodeDeploy where ENVID IN (SELECT ID from ENVMaster where ENVName='CCI')
--SELECT * FROM Urls


----Rename Column

END