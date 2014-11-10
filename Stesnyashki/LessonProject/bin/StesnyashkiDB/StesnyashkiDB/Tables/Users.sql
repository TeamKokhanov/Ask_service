CREATE TABLE [dbo].[Users]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [email] VARCHAR(50) NOT NULL, 
    [password] NVARCHAR(50) NOT NULL, 
    [name] NVARCHAR(50) NOT NULL, 
    [surname] NVARCHAR(50) NOT NULL, 
    [age] INT NOT NULL, 
    [sex] BIT NOT NULL, 
    [country] NVARCHAR(50) NULL, 
    [friendList] NVARCHAR(MAX) NULL, 
    [followList] NVARCHAR(MAX) NULL
)
