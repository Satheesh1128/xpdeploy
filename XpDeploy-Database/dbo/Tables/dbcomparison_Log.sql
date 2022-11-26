CREATE TABLE [dbo].[dbcomparison_Log] (
    [DB_ID]            INT           NOT NULL,
    [SourceDB]         NVARCHAR (50) NOT NULL,
    [UserId]           INT           NULL,
    [TargetDB]         NVARCHAR (50) NOT NULL,
    [Difference]       NVARCHAR (50) NOT NULL,
    [CreatedDate]      DATE          NOT NULL,
    [ModifiedDateTIme] DATETIME      NOT NULL,
    [Diff-Verified]    NVARCHAR (50) NOT NULL,
    CONSTRAINT [UC_dbcomparison_Log] UNIQUE NONCLUSTERED ([DB_ID] ASC, [TargetDB] ASC, [CreatedDate] ASC)
);

