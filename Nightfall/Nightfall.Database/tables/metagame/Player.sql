CREATE TABLE [dbo].[Player]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(50) NOT NULL, 
    [ChampionId] INT NOT NULL, 
    [ZoneId] INT NOT NULL, 
    [GameId] INT NOT NULL, 
    [CellId] INT NOT NULL, 
    CONSTRAINT [FK_Player_Game] FOREIGN KEY ([GameId]) REFERENCES [Game]([Id])
)
