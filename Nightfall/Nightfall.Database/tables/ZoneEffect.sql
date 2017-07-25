CREATE TABLE [dbo].[ZoneEffect]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(0,1), 
    [Description] VARCHAR(MAX) NOT NULL, 
    [ZoneId] INT NOT NULL, 
    CONSTRAINT [FK_Effect_Zone] FOREIGN KEY ([ZoneId]) REFERENCES [dbo].[Zone]([Id])
)
