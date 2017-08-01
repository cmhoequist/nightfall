CREATE TABLE [dbo].[ChampionAbility]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Description] VARCHAR(MAX) NOT NULL, 
    [ChampionId] INT NOT NULL, 
    [Tier] INT NULL DEFAULT 1, 
    CONSTRAINT [FK_Ability_Champion] FOREIGN KEY ([ChampionId]) REFERENCES [Champion]([Id])
)
