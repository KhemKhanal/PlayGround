CREATE TABLE [dbo].[Persons] (
    [Id]       INT            NOT NULL,
    [Name]     VARBINARY (50) NOT NULL,
    [Email]    NCHAR (50)     NOT NULL,
    [Age]      INT            NOT NULL,
    [Password] NCHAR (50)     NOT NULL,
    [Country] NCHAR(50) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

