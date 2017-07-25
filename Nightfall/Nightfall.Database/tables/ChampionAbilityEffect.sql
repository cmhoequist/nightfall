CREATE TABLE [dbo].[ChampionAbilityEffect]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Description] VARCHAR(MAX) NOT NULL, 
    [AbilityId] INT NOT NULL, 
    CONSTRAINT [FK_Effect_Ability] FOREIGN KEY ([AbilityId]) REFERENCES [dbo].[Champion]([Id])
)
