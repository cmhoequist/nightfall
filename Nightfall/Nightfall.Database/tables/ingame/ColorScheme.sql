CREATE TABLE [dbo].[ColorScheme]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [LightAccent] VARCHAR(7) NOT NULL, 
    [DarkAccent] VARCHAR(7) NOT NULL, 
    [LightComplement] VARCHAR(7) NOT NULL, 
    [DarkComplement] VARCHAR(7) NOT NULL, 
    [PrimaryColor] VARCHAR(7) NOT NULL, 
    [Name] VARCHAR(50) NOT NULL
)
