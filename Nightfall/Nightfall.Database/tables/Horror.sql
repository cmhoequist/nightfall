CREATE TABLE [dbo].[Horror]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NCHAR(10) NULL, 
    [Menace] INT NULL DEFAULT 0, 
    [NativeZoneId] INT NOT NULL, 
    CONSTRAINT [FK_Horror_Zone] FOREIGN KEY ([NativeZoneId]) REFERENCES [Zone]([Id])
)
