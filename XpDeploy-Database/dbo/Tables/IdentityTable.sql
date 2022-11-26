CREATE TABLE [dbo].[IdentityTable] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [Codedeploy1]   NVARCHAR (500) NULL,
    [Codedeploy2]   NVARCHAR (500) NULL,
    [Codedeploy3]   NVARCHAR (500) NULL,
    [Codedeploy4]   NVARCHAR (500) NULL,
    [Codedeploy5]   NVARCHAR (500) NULL,
    [Codedeploy6]   NVARCHAR (500) NULL,
    [CodePipeline1] NVARCHAR (500) NULL,
    [CodePipeline2] NVARCHAR (500) NULL,
    [CodePipeline3] NVARCHAR (500) NULL,
    [CodePipeline4] NVARCHAR (500) NULL,
    [CodePipeline5] NVARCHAR (500) NULL,
    [CodePipeline6] NVARCHAR (500) NULL,
    [S3_1]          NVARCHAR (500) NULL,
    [S3_2]          NVARCHAR (500) NULL,
    [S3_3]          NVARCHAR (500) NULL,
    [S3_4]          NVARCHAR (500) NULL,
    [S3_5]          NVARCHAR (500) NULL,
    [S3_6]          NVARCHAR (500) NULL,
    CONSTRAINT [PK_IdentityTable_ID] PRIMARY KEY CLUSTERED ([ID] ASC)
);

