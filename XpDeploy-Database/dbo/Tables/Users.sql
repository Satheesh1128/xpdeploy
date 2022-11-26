CREATE TABLE [dbo].[Users] (
    [UserId]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (30)  NULL,
    [UserName]         NVARCHAR (30)  NOT NULL,
    [Password]         NVARCHAR (200) NOT NULL,
    [Email]            NVARCHAR (200) NULL,
    [CreatedDate]      DATETIME       NOT NULL,
    [LastLoginDate]    DATETIME       NULL,
    [OTP]              INT            NULL,
    [OTPStatus]        INT            NULL,
    [ModifiedDateTime] DATETIME       NULL,
    [RoleID]           INT            NULL,
    [Status]           FLOAT (53)     NOT NULL,
    [Changepassword]   INT            CONSTRAINT [DF_Users_Changepassword] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_UserId] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [UC_UserName] UNIQUE NONCLUSTERED ([UserName] ASC)
);

