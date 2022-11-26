CREATE TABLE [dbo].[MenuMaster] (
    [Id]             INT            NOT NULL,
    [MenuURL]        VARCHAR (50)   NOT NULL,
    [MenuName]       VARCHAR (100)  NOT NULL,
    [ParentMenuName] NVARCHAR (100) NOT NULL,
    [WebMaster]      NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_MenuMaster_ID] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UC_MenuName] UNIQUE NONCLUSTERED ([MenuName] ASC),
    CONSTRAINT [UC_MenuURL] UNIQUE NONCLUSTERED ([MenuURL] ASC)
);

