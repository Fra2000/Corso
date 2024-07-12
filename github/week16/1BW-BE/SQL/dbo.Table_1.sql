CREATE TABLE [dbo].[Comments]
(
    [CommentsId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(200) NOT NULL, 
    [ProductId] INT NOT NULL,
    [CommentDate] DATETIME NOT NULL,
    CONSTRAINT FK_CProduct FOREIGN KEY (ProductId) REFERENCES [dbo].[Products](ProductId)
); 
