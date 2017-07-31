CREATE TABLE [dbo].[ColorScheme]
(
	[PrimaryColor] VARCHAR(7) NOT NULL PRIMARY KEY, 
    [LightAccent] VARCHAR(7) NOT NULL, 
    [DarkAccent] VARCHAR(7) NOT NULL, 
    [LightComplement] VARCHAR(7) NOT NULL, 
    [DarkComplement] VARCHAR(7) NOT NULL
)
