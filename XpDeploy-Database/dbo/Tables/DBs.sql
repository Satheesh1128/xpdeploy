CREATE TABLE [dbo].[DBs] (
    [DB_ID]                  INT           IDENTITY (1, 1) NOT NULL,
    [ENV]                    INT           NULL,
    [Version]                NVARCHAR (30) NOT NULL,
    [Server]                 NVARCHAR (30) NOT NULL,
    [DMS_Compare_Source]     NVARCHAR (30) NULL,
    [DMS]                    NVARCHAR (30) NULL,
    [Central_Compare_Source] NVARCHAR (30) NULL,
    [Central]                NVARCHAR (30) NULL,
    [RT60_Compare_Source]    NVARCHAR (30) NULL,
    [RT60]                   NVARCHAR (30) NULL,
    [Selfie_Compare_Source]  NVARCHAR (30) NULL,
    [Selfie]                 NVARCHAR (30) NULL,
    [IsActive]               INT           NOT NULL,
    [UserId]                 INT           NOT NULL,
    CONSTRAINT [FK_ENVMaster_DBs] FOREIGN KEY ([ENV]) REFERENCES [dbo].[ENVMaster] ([ID])
);

