﻿CREATE TABLE [dbo].[ENVMasterList] (
    [ENVListID]   INT            IDENTITY (1, 1) NOT NULL,
    [ENVListName] NVARCHAR (100) NULL,
    CONSTRAINT [PK_ENVMasterList] PRIMARY KEY CLUSTERED ([ENVListID] ASC)
);

