CREATE TABLE [dbo].[Coordinate]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [XValue] INT NOT NULL, 
    [YValue] INT NOT NULL, 
    [ZValue] INT NOT NULL, 
    [ZoneId] INT NOT NULL,
	CONSTRAINT [FK_Coordinate_Zone] FOREIGN KEY ([ZoneId]) REFERENCES [Zone]([Id])
)
