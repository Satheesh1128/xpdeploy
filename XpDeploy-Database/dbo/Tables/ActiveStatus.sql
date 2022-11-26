CREATE TABLE [dbo].[ActiveStatus] (
    [Id]          NUMERIC (1)  NOT NULL,
    [Description] NVARCHAR (9) NOT NULL,
    [Test] NCHAR(10) NULL, 
    CONSTRAINT [PK_ActiveStatus_id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UC_Description] UNIQUE NONCLUSTERED ([Description] ASC)
);

