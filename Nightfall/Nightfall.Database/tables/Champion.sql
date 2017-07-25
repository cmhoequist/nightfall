CREATE TABLE [dbo].[Champion]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(50) NOT NULL, 
    [Courage] INT NULL DEFAULT 0, 
    [Fortitude] INT NULL DEFAULT 0, 
    [Color] VARCHAR(7) NULL DEFAULT '#000000', 
    [XpCount] INT NULL DEFAULT 0, 
    [NativeZoneId] INT NOT NULL ,
	[CoordinateId] INT NOT NULL ,
	CONSTRAINT [FK_Champion_Zone] FOREIGN KEY ([NativeZoneId]) REFERENCES [Zone]([Id]),
	CONSTRAINT [FK_Champion_Coordinate] FOREIGN KEY ([CoordinateId]) REFERENCES [Coordinate]([Id])
)
