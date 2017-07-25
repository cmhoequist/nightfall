CREATE TABLE [dbo].[HuntEffect]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [Description] VARCHAR(MAX) NOT NULL, 
    [HorrorId] INT NOT NULL, 
    CONSTRAINT [FK_Effect_Horror] FOREIGN KEY ([HorrorId]) REFERENCES [Horror]([Id])
)
