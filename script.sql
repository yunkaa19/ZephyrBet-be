CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

START TRANSACTION;

CREATE TABLE `User` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Discriminator` longtext NOT NULL,
    `Name` longtext NULL,
    `Surname` longtext NULL,
    PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230419212207_Initial', '7.0.5');

COMMIT;

