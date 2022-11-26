CREATE TABLE [dbo].[AppCategory2] (
    [Category1ID]  INT           NOT NULL,
    [Category2ID]  INT           IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Category1ID_Category2ID] PRIMARY KEY CLUSTERED ([Category1ID] ASC, [Category2ID] ASC),
    CONSTRAINT [FK_Category1ID_AppCategory2] FOREIGN KEY ([Category1ID]) REFERENCES [dbo].[AppCategory1] ([Category1ID]),
    CONSTRAINT [UC_AppCategory2_Category1ID_Category2ID] UNIQUE NONCLUSTERED ([Category1ID] ASC, [Category2ID] ASC),
    CONSTRAINT [UC_Category1ID_AppCategory2] UNIQUE NONCLUSTERED ([Category1ID] ASC, [CategoryName] ASC)
);

