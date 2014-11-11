CREATE TABLE [dbo].[Comments]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [idQuestion] INT NOT NULL, 
    [text] NVARCHAR(MAX) NOT NULL, 
    [date] DATETIME NOT NULL, 
    [likes] INT NOT NULL DEFAULT 0, 
    [idSender] INT NOT NULL
)
