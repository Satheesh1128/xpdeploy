CREATE TABLE [dbo].[ServerMaster] (
    [ID]         INT           NOT NULL,
    [ServerName] NVARCHAR (50) NOT NULL,
    [Status]     NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_ServerMaster_ID] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UC_ServerName] UNIQUE NONCLUSTERED ([ServerName] ASC)
);

