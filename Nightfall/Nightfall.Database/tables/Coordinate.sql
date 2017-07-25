﻿CREATE TABLE [dbo].[Coordinate]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [Xvalue] INT NOT NULL, 
    [Yvalue] INT NOT NULL, 
    [Zvalue] INT NOT NULL, 
    [ZoneId] INT NOT NULL,
	CONSTRAINT [FK_Coordinate_Zone] FOREIGN KEY ([ZoneId]) REFERENCES [Zone]([Id])
)
