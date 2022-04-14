CREATE TABLE `Brands` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `PathImage` longtext CHARACTER SET utf8mb4 NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `ModifiedAt` datetime(6) NULL,
    `DeletedAt` datetime(6) NULL,
    CONSTRAINT `PK_Brands` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Categories` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `ModifiedAt` datetime(6) NULL,
    `DeletedAt` datetime(6) NULL,
    CONSTRAINT `PK_Categories` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Items` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Sku` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Slug` longtext CHARACTER SET utf8mb4 NOT NULL,
    `PathImage` longtext CHARACTER SET utf8mb4 NULL,
    `Description` longtext CHARACTER SET utf8mb4 NULL,
    `Price` decimal(65,30) NOT NULL,
    `Weight` int NOT NULL,
    `IsActive` tinyint NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `ModifiedAt` datetime(6) NULL,
    `DeletedAt` datetime(6) NULL,
    `BrandsId` int NULL,
    `CategoriId` int NULL,
    CONSTRAINT `PK_Items` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Items_Brands_BrandsId` FOREIGN KEY (`BrandsId`) REFERENCES `Brands` (`Id`),
    CONSTRAINT `FK_Items_Categories_CategoriId` FOREIGN KEY (`CategoriId`) REFERENCES `Categories` (`Id`)
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_Items_BrandsId` ON `Items` (`BrandsId`);

CREATE INDEX `IX_Items_CategoriId` ON `Items` (`CategoriId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220414034212_CreateItems', '6.0.3');



ALTER TABLE `Items` ADD `SatuanId` int NULL;

CREATE TABLE `Satuans` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Value` int NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `ModifiedAt` datetime(6) NULL,
    `DeletedAt` datetime(6) NULL,
    CONSTRAINT `PK_Satuans` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_Items_SatuanId` ON `Items` (`SatuanId`);

ALTER TABLE `Items` ADD CONSTRAINT `FK_Items_Satuans_SatuanId` FOREIGN KEY (`SatuanId`) REFERENCES `Satuans` (`Id`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220414035006_CreateSatuan', '6.0.3');




CREATE TABLE `Payments` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `CodePayment` longtext CHARACTER SET utf8mb4 NULL,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `PathImage` longtext CHARACTER SET utf8mb4 NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `ModifiedAt` datetime(6) NULL,
    `DeletedAt` datetime(6) NULL,
    CONSTRAINT `PK_Payments` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `StatusOrders` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `ModifiedAt` datetime(6) NULL,
    `DeletedAt` datetime(6) NULL,
    CONSTRAINT `PK_StatusOrders` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `StatusPayments` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `ModifiedAt` datetime(6) NULL,
    `DeletedAt` datetime(6) NULL,
    CONSTRAINT `PK_StatusPayments` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Transactions` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `CodeTransaction` longtext CHARACTER SET utf8mb4 NULL,
    `SubTotal` decimal(65,30) NOT NULL,
    `Disc` decimal(65,30) NOT NULL,
    `PPN` decimal(65,30) NOT NULL,
    `GrandTotal` decimal(65,30) NOT NULL,
    `Customers` int NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `ModifiedAt` datetime(6) NULL,
    `DeletedAt` datetime(6) NULL,
    `PaymentId` int NULL,
    `StatusOrderId` int NULL,
    `StatusPaymentId` int NULL,
    `UsersId` int NULL,
    CONSTRAINT `PK_Transactions` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Transactions_Payments_PaymentId` FOREIGN KEY (`PaymentId`) REFERENCES `Payments` (`Id`),
    CONSTRAINT `FK_Transactions_StatusOrders_StatusOrderId` FOREIGN KEY (`StatusOrderId`) REFERENCES `StatusOrders` (`Id`),
    CONSTRAINT `FK_Transactions_StatusPayments_StatusPaymentId` FOREIGN KEY (`StatusPaymentId`) REFERENCES `StatusPayments` (`Id`),
    CONSTRAINT `FK_Transactions_Users_UsersId` FOREIGN KEY (`UsersId`) REFERENCES `Users` (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `TransactionDetails` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Price` decimal(65,30) NOT NULL,
    `LotCode` longtext CHARACTER SET utf8mb4 NULL,
    `Qty` int NOT NULL,
    `CreatedAt` datetime(6) NOT NULL,
    `ModifiedAt` datetime(6) NULL,
    `DeletedAt` datetime(6) NULL,
    `TransactionId` int NULL,
    CONSTRAINT `PK_TransactionDetails` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_TransactionDetails_Transactions_TransactionId` FOREIGN KEY (`TransactionId`) REFERENCES `Transactions` (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `ItemTransactionDetail` (
    `ItemsId` int NOT NULL,
    `TransactionDetailsId` int NOT NULL,
    CONSTRAINT `PK_ItemTransactionDetail` PRIMARY KEY (`ItemsId`, `TransactionDetailsId`),
    CONSTRAINT `FK_ItemTransactionDetail_Items_ItemsId` FOREIGN KEY (`ItemsId`) REFERENCES `Items` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_ItemTransactionDetail_TransactionDetails_TransactionDetailsId` FOREIGN KEY (`TransactionDetailsId`) REFERENCES `TransactionDetails` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_ItemTransactionDetail_TransactionDetailsId` ON `ItemTransactionDetail` (`TransactionDetailsId`);

CREATE INDEX `IX_TransactionDetails_TransactionId` ON `TransactionDetails` (`TransactionId`);

CREATE INDEX `IX_Transactions_PaymentId` ON `Transactions` (`PaymentId`);

CREATE INDEX `IX_Transactions_StatusOrderId` ON `Transactions` (`StatusOrderId`);

CREATE INDEX `IX_Transactions_StatusPaymentId` ON `Transactions` (`StatusPaymentId`);

CREATE INDEX `IX_Transactions_UsersId` ON `Transactions` (`UsersId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220414045228_CreateTransaction', '6.0.3');