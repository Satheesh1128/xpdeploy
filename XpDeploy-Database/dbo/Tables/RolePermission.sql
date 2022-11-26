CREATE TABLE [dbo].[RolePermission] (
    [RoleId]    INT           NULL,
    [Module]    NVARCHAR (50) NULL,
    [Action]    NVARCHAR (50) NULL,
    [IsEnabled] INT           NULL,
    CONSTRAINT [UC_RolePermission] UNIQUE NONCLUSTERED ([RoleId] ASC, [Module] ASC, [Action] ASC, [IsEnabled] ASC),
    CONSTRAINT [UC_RolePermission1] UNIQUE NONCLUSTERED ([RoleId] ASC, [Module] ASC, [Action] ASC)
);

