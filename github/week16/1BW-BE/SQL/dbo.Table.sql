CREATE TABLE [dbo].[Products]
(
    [ProductId] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(300) NOT NULL, 
    [Price] DECIMAL(18, 2) NOT NULL, 
    [Img] NVARCHAR(MAX) NULL, 
    [Img_2] NVARCHAR(MAX) NULL, 
    [Img_3] NVARCHAR(MAX) NULL, 
    [Brand] NVARCHAR(50) NOT NULL, 
    [Seller] NVARCHAR(50) NOT NULL, 
    [Available] BIT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [Rating] TINYINT NOT NULL
);