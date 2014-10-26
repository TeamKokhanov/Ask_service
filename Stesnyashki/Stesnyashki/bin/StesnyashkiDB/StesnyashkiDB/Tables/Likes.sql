CREATE TABLE [dbo].[Likes]
(
	[idQuestion] INT NOT NULL , 
    [idComment] INT NOT NULL, 
    [idUser] INT NOT NULL    
    PRIMARY KEY ([idQuestion],[idComment],[idUser] )
)
