CREATE TABLE [dbo].[Urls] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL,
    [ApplicationID] INT           NULL,
    [ClientId]      INT           NULL,
    [IsActive]      INT           CONSTRAINT [DF_Urls_IsActive] DEFAULT ((1)) NOT NULL,
    [Url1]          VARCHAR (200) NULL,
    [Url2]          VARCHAR (200) NULL,
    [Url3]          VARCHAR (200) NULL,
    [SAASSIT]       VARCHAR (200) NULL,
    [SAASUAT]       VARCHAR (200) NULL,
    [SAASPRD]       VARCHAR (200) NULL,
    [SAASPILOT]     VARCHAR (200) NULL,
    [SAASDEMO]      VARCHAR (200) NULL,
    [SITV2]         VARCHAR (200) NULL,
    [UATV2]         VARCHAR (200) NULL,
    [PRDV2]         VARCHAR (200) NULL,
    [DEMOV2]        VARCHAR (200) NULL,
    [TRAINING]      VARCHAR (200) NULL,
    CONSTRAINT [PK_Urls_ID] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Applications_Id] FOREIGN KEY ([ApplicationID]) REFERENCES [dbo].[Applications] ([ID]),
    CONSTRAINT [FK_Urls_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[ClientMaster] ([ID])
);

