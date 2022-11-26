CREATE TABLE [dbo].[ClientMaster] (
    [ID]         INT           NOT NULL,
    [ENVID]      INT           NOT NULL,
    [ClientName] NVARCHAR (50) NULL,
    [Status]     NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_ClientMaster_ID] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ENVID_ENVMaster_ID] FOREIGN KEY ([ENVID]) REFERENCES [dbo].[ENVMaster] ([ID]),
    CONSTRAINT [UC_ClientName] UNIQUE NONCLUSTERED ([ClientName] ASC)
);

