CREATE TABLE [dbo].[Questions]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [idSender] INT NULL, 
    [idReciever] INT NOT NULL, 
    [qText] NVARCHAR(MAX) NOT NULL, 
    [qDate] DATETIME NOT NULL, 
    [aText] NVARCHAR(MAX) NULL, 
    [aDate] DATETIME NULL, 
    [likes] INT NULL
)
