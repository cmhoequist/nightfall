CREATE TABLE [dbo].[Cell]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Color] VARCHAR(7) NULL DEFAULT '#ffffff', 
    [MapId] INT NOT NULL, 
	[CoordinateId] INT NOT NULL,
    CONSTRAINT [FK_Cell_Map] FOREIGN KEY ([MapId]) REFERENCES [dbo].[Map]([Id]),
	CONSTRAINT [FK_Cell_Coordinate] FOREIGN KEY ([CoordinateId]) REFERENCES [Coordinate]([Id])
)
