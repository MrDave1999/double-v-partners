/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

CREATE DATABASE IF NOT EXISTS `double-partners` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;
USE `double-partners`;

DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `get_persons`()
BEGIN
  SELECT
  FullName,
  FullDocument,
  Email,
  DATE_FORMAT(CreatedAt, '%Y-%m-%d %h:%i:%s %p') CreatedAt 
  FROM person;
END//
DELIMITER ;

CREATE TABLE IF NOT EXISTS `person` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Names` longtext DEFAULT NULL,
  `LastNames` longtext DEFAULT NULL,
  `FullName` longtext DEFAULT NULL,
  `Document` longtext DEFAULT NULL,
  `DocumentType` enum('CC.','PA.') NOT NULL,
  `FullDocument` longtext DEFAULT NULL,
  `Email` longtext DEFAULT NULL,
  `CreatedAt` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*!40000 ALTER TABLE `person` DISABLE KEYS */;
INSERT INTO `person` (`Id`, `Names`, `LastNames`, `FullName`, `Document`, `DocumentType`, `FullDocument`, `Email`, `CreatedAt`) VALUES
	(1, 'David Sebastián', 'Román Amariles', 'Román Amariles David Sebastián', '1126564742', 'CC.', 'CC. 1126564742', 'daveseva2010@hotmail.es', '2023-11-17 20:19:34.000000');
/*!40000 ALTER TABLE `person` ENABLE KEYS */;

CREATE TABLE IF NOT EXISTS `user` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) DEFAULT NULL,
  `Password` varchar(64) DEFAULT NULL,
  `CreatedAt` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_User_Name` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`Id`, `Name`, `Password`, `CreatedAt`) VALUES
	(1, 'MrDave1999', '$2a$11$4n28.a/72mLUOIWfrHWsi.r78IblJ0FrCZohS1XUwLrYcRrrT7eQu', '2023-11-17 20:19:34.000000');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20231118011934_InitialCreate', '7.0.2');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
