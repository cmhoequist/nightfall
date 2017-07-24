CREATE TABLE [dbo].[ZoneEffect]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Type] VARCHAR(50) NOT NULL, 
    [Description] VARCHAR(MAX) NOT NULL, 
    [ZoneId] INT NOT NULL, 
    CONSTRAINT [FK_Effect_Ability] FOREIGN KEY ([ZoneId]) REFERENCES [dbo].[Zone]([Id])
)
