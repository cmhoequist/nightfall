CREATE TABLE [dbo].[Token]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Type] VARCHAR(50) NOT NULL, 
    [CoordinateId] INT NULL DEFAULT 1, 
    CONSTRAINT [FK_Token_Coordinate] FOREIGN KEY ([CoordinateId]) REFERENCES [Coordinate]([Id])
)
