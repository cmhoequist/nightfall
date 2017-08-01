CREATE TABLE [dbo].[Champion]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(50) NOT NULL, 
    [CourageExpression] VARCHAR(100) NULL DEFAULT '1', 
    [FortitudeExpression] VARCHAR(100) NULL DEFAULT '1', 
    [ColorSchemeId] INT NOT NULL , 
    [XpCount] INT NULL DEFAULT 0, 
	[Sigil] VARCHAR(50) NULL DEFAULT 'None', 
    CONSTRAINT [FK_Champion_Color] FOREIGN KEY ([ColorSchemeId]) REFERENCES [ColorScheme](Id)
)
