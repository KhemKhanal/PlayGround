CREATE TABLE [dbo].[Persons]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARBINARY(50) NOT NULL, 
    [Email] NCHAR(50) NOT NULL, 
    [Age] INT NOT NULL, 
    [Password] NCHAR(50) NOT NULL
)
