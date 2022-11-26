CREATE TABLE [dbo].[Error] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [error]            NVARCHAR (MAX) NULL,
    [ErrorPage]        NVARCHAR (MAX) NULL,
    [ErrorFunction]    NVARCHAR (MAX) NULL,
    [Modifieddatetime] DATETIME       NULL
);

