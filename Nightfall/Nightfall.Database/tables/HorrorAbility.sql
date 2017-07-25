CREATE TABLE [dbo].[HorrorAbility]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Description] VARCHAR(MAX) NOT NULL, 
    [HorrorId] INT NOT NULL
	CONSTRAINT [FK_Ability_Horror] FOREIGN KEY ([HorrorId]) REFERENCES [dbo].[Horror]([Id])
)
