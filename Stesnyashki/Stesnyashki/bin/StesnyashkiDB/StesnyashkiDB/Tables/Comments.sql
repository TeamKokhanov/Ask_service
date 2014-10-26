CREATE TABLE [dbo].[Comments]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [idQuestion] INT NOT NULL, 
    [text] NVARCHAR(MAX) NOT NULL, 
    [date] DATETIME NOT NULL, 
    [likes] NCHAR(10) NULL, 
    [idSender] INT NOT NULL
)
