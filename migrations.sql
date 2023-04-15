IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Accounts] (
    [AccountID] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(50) NOT NULL,
    [isDeleted] bit NOT NULL,
    [isStaff] bit NOT NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY ([AccountID])
);
GO

CREATE TABLE [Districts] (
    [DistrictID] int NOT NULL IDENTITY,
    [DistrictName] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Districts] PRIMARY KEY ([DistrictID])
);
GO

CREATE TABLE [Roles] (
    [RoleID] int NOT NULL IDENTITY,
    [RoleName] nvarchar(15) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([RoleID])
);
GO

CREATE TABLE [Wards] (
    [WardId] int NOT NULL IDENTITY,
    [WardName] nvarchar(50) NOT NULL,
    [DistrictID] int NOT NULL,
    CONSTRAINT [PK_Wards] PRIMARY KEY ([WardId]),
    CONSTRAINT [FK_Wards_Districts_DistrictID] FOREIGN KEY ([DistrictID]) REFERENCES [Districts] ([DistrictID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Streets] (
    [StreetID] int NOT NULL IDENTITY,
    [StreetName] nvarchar(50) NOT NULL,
    [WardID] int NOT NULL,
    CONSTRAINT [PK_Streets] PRIMARY KEY ([StreetID]),
    CONSTRAINT [FK_Streets_Wards_WardID] FOREIGN KEY ([WardID]) REFERENCES [Wards] ([WardId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Addresses] (
    [AddressID] int NOT NULL IDENTITY,
    [NumberHouse] int NOT NULL,
    [StreetID] int NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY ([AddressID]),
    CONSTRAINT [FK_Addresses_Streets_StreetID] FOREIGN KEY ([StreetID]) REFERENCES [Streets] ([StreetID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Customers] (
    [CustomerID] int NOT NULL IDENTITY,
    [CustomerName] nvarchar(50) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [Gender] bit NOT NULL,
    [AddressID] int NOT NULL,
    [AccountID] int NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerID]),
    CONSTRAINT [FK_Customers_Accounts_AccountID] FOREIGN KEY ([AccountID]) REFERENCES [Accounts] ([AccountID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Customers_Addresses_AddressID] FOREIGN KEY ([AddressID]) REFERENCES [Addresses] ([AddressID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Staffs] (
    [StaffID] int NOT NULL IDENTITY,
    [StaffName] nvarchar(50) NOT NULL,
    [PhoneST] nvarchar(15) NOT NULL,
    [Gender] bit NOT NULL,
    [AccountID] int NOT NULL,
    [RoleID] int NOT NULL,
    [AddressID] int NOT NULL,
    CONSTRAINT [PK_Staffs] PRIMARY KEY ([StaffID]),
    CONSTRAINT [FK_Staffs_Accounts_AccountID] FOREIGN KEY ([AccountID]) REFERENCES [Accounts] ([AccountID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Staffs_Addresses_AddressID] FOREIGN KEY ([AddressID]) REFERENCES [Addresses] ([AddressID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Staffs_Roles_RoleID] FOREIGN KEY ([RoleID]) REFERENCES [Roles] ([RoleID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Addresses_StreetID] ON [Addresses] ([StreetID]);
GO

CREATE INDEX [IX_Customers_AccountID] ON [Customers] ([AccountID]);
GO

CREATE INDEX [IX_Customers_AddressID] ON [Customers] ([AddressID]);
GO

CREATE INDEX [IX_Staffs_AccountID] ON [Staffs] ([AccountID]);
GO

CREATE INDEX [IX_Staffs_AddressID] ON [Staffs] ([AddressID]);
GO

CREATE INDEX [IX_Staffs_RoleID] ON [Staffs] ([RoleID]);
GO

CREATE INDEX [IX_Streets_WardID] ON [Streets] ([WardID]);
GO

CREATE INDEX [IX_Wards_DistrictID] ON [Wards] ([DistrictID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230415031013_InitWeb_ver1', N'7.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Wards] DROP CONSTRAINT [FK_Wards_Districts_DistrictID];
GO

ALTER TABLE [Districts] DROP CONSTRAINT [PK_Districts];
GO

EXEC sp_rename N'[Districts]', N'District';
GO

ALTER TABLE [District] ADD CONSTRAINT [PK_District] PRIMARY KEY ([DistrictID]);
GO

CREATE TABLE [Categories] (
    [CategoryID] int NOT NULL IDENTITY,
    [CategoryName] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryID])
);
GO

CREATE TABLE [ImportOrders] (
    [ImportOrderID] int NOT NULL IDENTITY,
    [IOName] nvarchar(max) NOT NULL,
    [DateIO] datetime2 NOT NULL,
    [TMoneyIO] real NOT NULL,
    [StaffID] int NOT NULL,
    CONSTRAINT [PK_ImportOrders] PRIMARY KEY ([ImportOrderID]),
    CONSTRAINT [FK_ImportOrders_Staffs_StaffID] FOREIGN KEY ([StaffID]) REFERENCES [Staffs] ([StaffID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Measures] (
    [MeasureID] int NOT NULL IDENTITY,
    [MeasureName] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Measures] PRIMARY KEY ([MeasureID])
);
GO

CREATE TABLE [Orders] (
    [OrderID] int NOT NULL IDENTITY,
    [SaleDate] datetime2 NOT NULL,
    [Note] nvarchar(500) NOT NULL,
    [TotalMoney] real NOT NULL,
    [StatusOdr] nvarchar(50) NOT NULL,
    [StaffID] int NOT NULL,
    [CustomerID] int NOT NULL,
    [AddressID] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderID]),
    CONSTRAINT [FK_Orders_Addresses_AddressID] FOREIGN KEY ([AddressID]) REFERENCES [Addresses] ([AddressID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Orders_Customers_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [Customers] ([CustomerID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Orders_Staffs_StaffID] FOREIGN KEY ([StaffID]) REFERENCES [Staffs] ([StaffID]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Foods] (
    [FoodID] int NOT NULL IDENTITY,
    [FoodName] nvarchar(100) NOT NULL,
    [Quantity] int NOT NULL,
    [Price] real NOT NULL,
    [ImageFood] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [IsDeleted] bit NOT NULL,
    [CategoryID] int NOT NULL,
    CONSTRAINT [PK_Foods] PRIMARY KEY ([FoodID]),
    CONSTRAINT [FK_Foods_Categories_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [Categories] ([CategoryID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Ingredients] (
    [IngredientsId] int NOT NULL IDENTITY,
    [IngredientsName] nvarchar(200) NOT NULL,
    [IngredientsPrice] real NOT NULL,
    [IsDeleted] bit NOT NULL,
    [MeasureID] int NOT NULL,
    CONSTRAINT [PK_Ingredients] PRIMARY KEY ([IngredientsId]),
    CONSTRAINT [FK_Ingredients_Measures_MeasureID] FOREIGN KEY ([MeasureID]) REFERENCES [Measures] ([MeasureID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Carts] (
    [CustomerID] int NOT NULL,
    [FoodID] int NOT NULL,
    [Quantity] int NOT NULL,
    CONSTRAINT [PK_Carts] PRIMARY KEY ([CustomerID], [FoodID]),
    CONSTRAINT [FK_Carts_Customers_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [Customers] ([CustomerID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Carts_Foods_FoodID] FOREIGN KEY ([FoodID]) REFERENCES [Foods] ([FoodID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Order_Foods] (
    [OrderDetID] int NOT NULL,
    [FoodID] int NOT NULL,
    [OrdersOrderID] int NOT NULL,
    [QuantityOG] int NOT NULL,
    CONSTRAINT [PK_Order_Foods] PRIMARY KEY ([OrderDetID], [FoodID]),
    CONSTRAINT [FK_Order_Foods_Foods_FoodID] FOREIGN KEY ([FoodID]) REFERENCES [Foods] ([FoodID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Order_Foods_Orders_OrdersOrderID] FOREIGN KEY ([OrdersOrderID]) REFERENCES [Orders] ([OrderID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Reviews] (
    [ReviewID] int NOT NULL IDENTITY,
    [Star] int NOT NULL,
    [Content] nvarchar(max) NOT NULL,
    [Img] nvarchar(max) NOT NULL,
    [DateReview] datetime2 NOT NULL,
    [CustomerID] int NOT NULL,
    [FoodID] int NOT NULL,
    CONSTRAINT [PK_Reviews] PRIMARY KEY ([ReviewID]),
    CONSTRAINT [FK_Reviews_Customers_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [Customers] ([CustomerID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Reviews_Foods_FoodID] FOREIGN KEY ([FoodID]) REFERENCES [Foods] ([FoodID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Food_Ingredients] (
    [FoodID] int NOT NULL,
    [IngredientsId] int NOT NULL,
    [QuantityIG] int NOT NULL,
    CONSTRAINT [PK_Food_Ingredients] PRIMARY KEY ([FoodID], [IngredientsId]),
    CONSTRAINT [FK_Food_Ingredients_Foods_FoodID] FOREIGN KEY ([FoodID]) REFERENCES [Foods] ([FoodID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Food_Ingredients_Ingredients_IngredientsId] FOREIGN KEY ([IngredientsId]) REFERENCES [Ingredients] ([IngredientsId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ImportOrders_Ingredients] (
    [ImportOrderID] int NOT NULL IDENTITY,
    [IngredientsID] int NOT NULL,
    [QuantityIO] int NOT NULL,
    [PriceIO] real NOT NULL,
    CONSTRAINT [PK_ImportOrders_Ingredients] PRIMARY KEY ([ImportOrderID]),
    CONSTRAINT [FK_ImportOrders_Ingredients_Ingredients_IngredientsID] FOREIGN KEY ([IngredientsID]) REFERENCES [Ingredients] ([IngredientsId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Carts_FoodID] ON [Carts] ([FoodID]);
GO

CREATE INDEX [IX_Food_Ingredients_IngredientsId] ON [Food_Ingredients] ([IngredientsId]);
GO

CREATE INDEX [IX_Foods_CategoryID] ON [Foods] ([CategoryID]);
GO

CREATE INDEX [IX_ImportOrders_StaffID] ON [ImportOrders] ([StaffID]);
GO

CREATE INDEX [IX_ImportOrders_Ingredients_IngredientsID] ON [ImportOrders_Ingredients] ([IngredientsID]);
GO

CREATE INDEX [IX_Ingredients_MeasureID] ON [Ingredients] ([MeasureID]);
GO

CREATE INDEX [IX_Order_Foods_FoodID] ON [Order_Foods] ([FoodID]);
GO

CREATE INDEX [IX_Order_Foods_OrdersOrderID] ON [Order_Foods] ([OrdersOrderID]);
GO

CREATE INDEX [IX_Orders_AddressID] ON [Orders] ([AddressID]);
GO

CREATE INDEX [IX_Orders_CustomerID] ON [Orders] ([CustomerID]);
GO

CREATE INDEX [IX_Orders_StaffID] ON [Orders] ([StaffID]);
GO

CREATE INDEX [IX_Reviews_CustomerID] ON [Reviews] ([CustomerID]);
GO

CREATE INDEX [IX_Reviews_FoodID] ON [Reviews] ([FoodID]);
GO

ALTER TABLE [Wards] ADD CONSTRAINT [FK_Wards_District_DistrictID] FOREIGN KEY ([DistrictID]) REFERENCES [District] ([DistrictID]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230415081741_dbver1', N'7.0.5');
GO

COMMIT;
GO

