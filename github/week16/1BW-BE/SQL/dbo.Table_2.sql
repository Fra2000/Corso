CREATE TABLE [dbo].[Cart]
(
    [CartId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductId] INT NOT NULL, 
    [Quantity] INT NOT NULL,
    [Date] DATETIME2 NOT NULL,
    CONSTRAINT FK_Product FOREIGN KEY (ProductId) REFERENCES [dbo].[Products](ProductId)
);