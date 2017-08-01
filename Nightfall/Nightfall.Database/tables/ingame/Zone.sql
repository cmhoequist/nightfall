﻿CREATE TABLE [dbo].[Zone]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(50) NOT NULL, 
    [GameId] INT NOT NULL, 
    CONSTRAINT [FK_Zone_Game] FOREIGN KEY ([GameId]) REFERENCES [Game]([Id])
)