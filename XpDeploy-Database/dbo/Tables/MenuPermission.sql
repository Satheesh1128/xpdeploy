CREATE TABLE [dbo].[MenuPermission] (
    [ID]       INT IDENTITY (1, 1) NOT NULL,
    [RoleId]   INT NOT NULL,
    [MenuId]   INT NOT NULL,
    [isactive] INT NOT NULL,
    CONSTRAINT [PK_MenuPermission_ID] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_MenuId_MenuMaster_ID] FOREIGN KEY ([MenuId]) REFERENCES [dbo].[MenuMaster] ([Id]),
    CONSTRAINT [FK_RoleId_RoleMaster_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[RoleMaster] ([RoleID])
);

