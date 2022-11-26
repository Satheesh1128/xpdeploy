CREATE TABLE [dbo].[IssueTracker] (
    [ID]               INT           IDENTITY (1, 1) NOT NULL,
    [EnvId]            INT           NOT NULL,
    [IssueSummary]     NVARCHAR (75) NULL,
    [ReportedDate]     DATETIME      NULL,
    [FAT/SIT]          DATETIME      NULL,
    [UAT]              DATETIME      NULL,
    [PRD]              DATETIME      NULL,
    [DevJira]          NVARCHAR (20) NULL,
    [DeployJira]       NVARCHAR (20) NULL,
    [CurrentStatus]    INT           NOT NULL,
    [Releasechange]    INT           NULL,
    [TicketStatus]     INT           NOT NULL,
    [Owner]            INT           NULL,
    [ModifiedDateTime] DATETIME      NULL,
    CONSTRAINT [FK_IssueTracker_CurrentStatus] FOREIGN KEY ([CurrentStatus]) REFERENCES [dbo].[ITStatus] ([Id]),
    CONSTRAINT [FK_IssueTracker_TicketStatus] FOREIGN KEY ([TicketStatus]) REFERENCES [dbo].[ITStatus] ([Id])
);

