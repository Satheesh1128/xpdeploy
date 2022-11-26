CREATE TABLE [dbo].[AppCategory1] (
    [Category1ID]  INT           IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_AppCategory1] PRIMARY KEY CLUSTERED ([Category1ID] ASC),
    CONSTRAINT [UC_AppCategory1_CategoryName] UNIQUE NONCLUSTERED ([CategoryName] ASC)
);

