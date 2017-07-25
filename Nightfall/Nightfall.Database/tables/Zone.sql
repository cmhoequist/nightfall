CREATE TABLE [dbo].[Zone]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(50) NOT NULL, 
    [CourageModifier] INT NULL DEFAULT 0, 
    [FortitudeModifier] INT NULL DEFAULT 0
)
