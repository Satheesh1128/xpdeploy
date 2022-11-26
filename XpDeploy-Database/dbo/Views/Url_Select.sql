




-- View
CREATE VIEW [dbo].[Url_Select]
AS

	SELECT		
		EM.ENVName,
		CM.ClientName,
		A.ApplicationName,
		--'<a href="' +HCCBFAT+'"'+'target="_blank">'+HCCBFAT+'</a>' AS HCCBFAT,
		--'<a href="' +HCCBUAT+'"'+'target="_blank">'+HCCBUAT+'</a>' AS HCCBUAT,
		--'<a href="' +HCCBPRD+'"'+'target="_blank">'+HCCBPRD+'</a>' AS HCCBPRD,		
		'<a href="' +SAASSIT+'"'+'target="_blank">'+SAASSIT+'</a>' AS SAASSIT,
		'<a href="' +SAASUAT+'"'+'target="_blank">'+SAASUAT+'</a>' AS SAASUAT,
		'<a href="' +SAASPRD+'"'+'target="_blank">'+SAASPRD+'</a>' AS SAASPRD,
		'<a href="' +SAASPILOT+'"'+'target="_blank">'+SAASPILOT+'</a>' AS SAASPILOT,
		'<a href="' +SAASDEMO+'"'+'target="_blank">'+SAASDEMO+'</a>' AS SAASDEMO,
		'<a href="' +SITV2+'"'+'target="_blank">'+SITV2+'</a>' AS SITV2,
		'<a href="' +UATV2+'"'+'target="_blank">'+UATV2+'</a>' AS UATV2,
		'<a href="' +PRDV2+'"'+'target="_blank">'+PRDV2+'</a>' AS PRDV2,
		'<a href="' +DEMOV2+'"'+'target="_blank">'+DEMOV2+'</a>' AS DEMOV2,
		'<a href="' +TRAINING+'"'+'target="_blank">'+TRAINING+'</a>' AS TRAINING
	FROM Urls U
	INNER JOIN ClientMaster CM WITH(NOLOCK) ON U.ClientID = CM.ID
	INNER JOIN ENVMaster EM WITH(NOLOCK) ON CM.ENVID = EM.ID
	INNER JOIN Applications A WITH(NOLOCK) ON U.ApplicationID = A.ID
	--WHERE (EM.ENVName = @ENV OR ISNULL(@ENV, '') = '')
	--AND (CM.ClientName = @Client OR ISNULL(@Client, '') = '')
	--AND (A.ApplicationName = @Application OR ISNULL(@Application, '') = '')