CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [nombre] NCHAR(10) NOT NULL, 
    [colegio] NCHAR(10) NULL, 
    [edad] NUMERIC(2) NOT NULL, 
    [password] NCHAR(10) NOT NULL
)
