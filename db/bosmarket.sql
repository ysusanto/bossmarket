-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.4.21-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dumping structure for table bossmarket.refreshtoken
CREATE TABLE IF NOT EXISTS `refreshtoken` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Token` longtext NOT NULL,
  `Expires` datetime(6) NOT NULL,
  `Created` datetime(6) NOT NULL,
  `CreatedByIp` longtext NOT NULL,
  `Revoked` datetime(6) DEFAULT NULL,
  `RevokedByIp` longtext NOT NULL,
  `ReplacedByToken` longtext NOT NULL,
  `ReasonRevoked` longtext NOT NULL,
  `UsersId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_RefreshToken_UsersId` (`UsersId`),
  CONSTRAINT `FK_RefreshToken_Users_UsersId` FOREIGN KEY (`UsersId`) REFERENCES `users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Dumping data for table bossmarket.refreshtoken: ~0 rows (approximately)
DELETE FROM `refreshtoken`;
/*!40000 ALTER TABLE `refreshtoken` DISABLE KEYS */;
/*!40000 ALTER TABLE `refreshtoken` ENABLE KEYS */;

-- Dumping structure for table bossmarket.users
CREATE TABLE IF NOT EXISTS `users` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Username` longtext NOT NULL,
  `PasswordHash` longtext NOT NULL,
  `Email` longtext NOT NULL,
  `Role` int(11) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `DeletedAt` datetime(6) DEFAULT NULL,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Dumping data for table bossmarket.users: ~0 rows (approximately)
DELETE FROM `users`;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

-- Dumping structure for table bossmarket.__efmigrationshistory
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Dumping data for table bossmarket.__efmigrationshistory: ~2 rows (approximately)
DELETE FROM `__efmigrationshistory`;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20220324034447_Initial', '6.0.3'),
	('20220407034726_InitTable', '6.0.3'),
	('20220407040530_CreateUser', '6.0.3');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
