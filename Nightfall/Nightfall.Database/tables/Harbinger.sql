CREATE TABLE [dbo].[Harbinger]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [NativeZoneId] INT NOT NULL, 
    [HorrorId] INT NOT NULL,
	CONSTRAINT [FK_Harbinger_Horror] FOREIGN KEY ([HorrorId]) REFERENCES [Horror]([Id]),
	CONSTRAINT [FK_Harbinger_Zone] FOREIGN KEY ([NativeZoneId]) REFERENCES [Zone]([Id])
)
