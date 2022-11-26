CREATE TABLE [dbo].[CodeDeploy] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [ENVID]            INT            NULL,
    [ApplicationID]    INT            NULL,
    [CodeDeployName]   NVARCHAR (500) NULL,
    [CodePipelineName] NVARCHAR (500) NULL,
    [S3]               NVARCHAR (500) NULL,
    [App_Spec]         NVARCHAR (MAX) NULL,
    [IsActive]         INT            CONSTRAINT [DF_CodeDeploy_IsActive] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CodeDeploy_ID] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ApplicationID_Applications_ID] FOREIGN KEY ([ApplicationID]) REFERENCES [dbo].[Applications] ([ID]),
    CONSTRAINT [FK1_ENVID_ENVMaster_ID] FOREIGN KEY ([ENVID]) REFERENCES [dbo].[ENVMaster] ([ID]),
    CONSTRAINT [UC_ENVID_ApplicationID] UNIQUE NONCLUSTERED ([ENVID] ASC, [ApplicationID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UC_CodeDeployName]
    ON [dbo].[CodeDeploy]([ENVID] ASC, [CodeDeployName] ASC) WHERE ([CodeDeployName] IS NOT NULL);


GO
CREATE UNIQUE NONCLUSTERED INDEX [UC_CodePipelineName]
    ON [dbo].[CodeDeploy]([ENVID] ASC, [CodePipelineName] ASC) WHERE ([CodePipelineName] IS NOT NULL);

