USE master;
GO

IF DB_ID(N'InventoryPractical8') IS NULL
    CREATE DATABASE InventoryPractical8;
GO

USE InventoryPractical8;
GO

IF OBJECT_ID(N'dbo.Products', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Products (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(80) NOT NULL,
        Category NVARCHAR(50) NOT NULL,
        Quantity INT NOT NULL CHECK (Quantity BETWEEN 0 AND 1000000),
        Price DECIMAL(18,2) NOT NULL CHECK (Price BETWEEN 0.01 AND 9999999.99)
    );
END;
GO
