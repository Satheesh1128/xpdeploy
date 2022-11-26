CREATE TABLE [dbo].[RoleMaster] (
    [RoleID]   INT           NOT NULL,
    [RoleName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_RoleMaster_ID] PRIMARY KEY CLUSTERED ([RoleID] ASC),
    CONSTRAINT [UC_RoleName] UNIQUE NONCLUSTERED ([RoleName] ASC)
);

