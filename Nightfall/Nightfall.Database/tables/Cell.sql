CREATE TABLE [dbo].[Cell]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [Color] VARCHAR(7) NULL DEFAULT '#ffffff', 
    [MapId] INT NULL , 
	[CoordinateId] INT NULL DEFAULT 1,
    CONSTRAINT [FK_Cell_Map] FOREIGN KEY ([MapId]) REFERENCES [dbo].[Map]([Id]),
	CONSTRAINT [FK_Cell_Coordinate] FOREIGN KEY ([CoordinateId]) REFERENCES [Coordinate]([Id])
)
