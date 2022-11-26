CREATE TABLE [dbo].[Applications] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [ApplicationName] NVARCHAR (50) NOT NULL,
    [AppCategory2]    INT           NOT NULL,
    [AppCategory1]    INT           NOT NULL,
    [VersionSupport]  INT           NOT NULL,
    [Responsible]     INT           NULL,
    CONSTRAINT [PK_ID] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Category1ID_Applications] FOREIGN KEY ([AppCategory1]) REFERENCES [dbo].[AppCategory1] ([Category1ID]),
    CONSTRAINT [FK_UserId] FOREIGN KEY ([Responsible]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [UC_ApplicationName_AppCategory1_AppCategory2] UNIQUE NONCLUSTERED ([ApplicationName] ASC, [AppCategory1] ASC, [AppCategory2] ASC),
    CONSTRAINT [UC_Applications_ApplicationName] UNIQUE NONCLUSTERED ([ApplicationName] ASC)
);

