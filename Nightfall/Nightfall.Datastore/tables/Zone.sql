CREATE TABLE [dbo].[Zone]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [FortitudeModifier] INT NULL DEFAULT 0, 
    [CourageModifier] INT NULL DEFAULT 0
)
