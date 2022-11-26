


CREATE FUNCTION [dbo].[fnReleasePendingTracker_HCCB] 
(	

)
RETURNS TABLE 
AS
RETURN 
(
SELECT
	ApplicationName AS Application,
	Version,
	[FAT/SIT] AS FAT_Release,
	UAT AS UAT_Release,
	PRD AS PRD_Release,
	CASE 
	WHEN [FAT/SIT] > UAT THEN 'Fat contains additional release with same version compared to UAT'
	WHEN UAT > PRD THEN 'UAT contains additional release with same version compared to PRD'
	ELSE '' END AS 'ReleaseDifference',
	Jira 
FROM ReleaseTracker RT
INNER JOIN Applications A WITH(NOLOCK) ON RT.ApplicationID = A.ID
WHERE EnvId = 1 and (PRD is null or uat is null or [FAT/SIT] > UAT or UAT > PRD)
)


