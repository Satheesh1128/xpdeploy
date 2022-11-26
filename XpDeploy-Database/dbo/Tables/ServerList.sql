CREATE TABLE [dbo].[ServerList] (
    [ServerID]       INT           NULL,
    [ServerListID]   INT           NOT NULL,
    [ServerListName] NVARCHAR (50) NULL,
    [IsActive]       INT           CONSTRAINT [DF__ServerLis__IsAct__25FC62E4] DEFAULT ((0)) NOT NULL,
    [EnvId]          INT           NOT NULL,
    [Consumer]       INT           NULL,
    CONSTRAINT [PK_ServerListID] PRIMARY KEY CLUSTERED ([ServerListID] ASC),
    CONSTRAINT [FK_ID] FOREIGN KEY ([ServerID]) REFERENCES [dbo].[ServerMaster] ([ID]),
    CONSTRAINT [UC_ServerListName] UNIQUE NONCLUSTERED ([ServerListName] ASC)
);

