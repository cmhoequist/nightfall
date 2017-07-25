CREATE TABLE [dbo].[TokenToCoordinate]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [TokenId] INT NOT NULL, 
    [CoordinateId] INT NOT NULL, 
    CONSTRAINT [FK_Bridge_Token] FOREIGN KEY ([TokenId]) REFERENCES [Token]([Id]), 
    CONSTRAINT [FK_Bridge_Coordinate] FOREIGN KEY ([CoordinateId]) REFERENCES [Coordinate]([Id])
)
