CREATE TABLE [dbo].[ReleaseTracker] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [EnvId]            INT            NOT NULL,
    [ApplicationID]    INT            NULL,
    [Version]          NVARCHAR (20)  NULL,
    [FAT/SIT]          DATETIME       NULL,
    [UAT]              DATETIME       NULL,
    [PRD]              DATETIME       NULL,
    [TRI]              DATETIME       NULL,
    [DEMOV2]           DATETIME       NULL,
    [DEMO]             DATETIME       NULL,
    [PILOT]            DATETIME       NULL,
    [AppDependency]    NVARCHAR (MAX) NULL,
    [Jira]             NVARCHAR (500) NULL,
    [ConfigChanges]    NVARCHAR (1)   NULL,
    [Rollback]         NVARCHAR (1)   NULL,
    [Reason]           NVARCHAR (MAX) NULL,
    [ModifiedDateTime] DATETIME       NULL,
    CONSTRAINT [PK_ReleaseTracker_ID] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ReleaseTracker_ApplicationID] FOREIGN KEY ([ApplicationID]) REFERENCES [dbo].[Applications] ([ID])
);

