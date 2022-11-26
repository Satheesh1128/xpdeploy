CREATE TABLE [dbo].[DataBaseCompare] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [Client]         NVARCHAR (50) NOT NULL,
    [Env]            NVARCHAR (50) NOT NULL,
    [SourceDatabase] NVARCHAR (50) NOT NULL,
    [TargetDataBase] NVARCHAR (50) NOT NULL
);

