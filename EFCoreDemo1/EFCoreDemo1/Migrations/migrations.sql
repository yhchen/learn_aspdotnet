CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `T_Books` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Title` longtext CHARACTER SET utf8mb4 NULL,
    `PubTime` datetime(6) NOT NULL,
    `Price` double NOT NULL,
    CONSTRAINT `PK_T_Books` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `T_Person` (
    `Id` bigint NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Age` int NOT NULL,
    CONSTRAINT `PK_T_Person` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240819045513_InitialCreate', '7.0.20');

COMMIT;

START TRANSACTION;

ALTER TABLE `T_Person` ADD `BirthPlace` longtext CHARACTER SET utf8mb4 NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240819045940_UpdatePersonBirtiPlace', '7.0.20');

COMMIT;

START TRANSACTION;

UPDATE `T_Books` SET `Title` = ''
WHERE `Title` IS NULL;
SELECT ROW_COUNT();


ALTER TABLE `T_Books` MODIFY COLUMN `Title` varchar(50) CHARACTER SET utf8mb4 NOT NULL COMMENT '标题';

ALTER TABLE `T_Books` MODIFY COLUMN `PubTime` datetime(6) NOT NULL COMMENT '发布日期';

ALTER TABLE `T_Books` MODIFY COLUMN `Price` double NOT NULL COMMENT '价格';

ALTER TABLE `T_Books` MODIFY COLUMN `Id` bigint NOT NULL AUTO_INCREMENT COMMENT '主键';

ALTER TABLE `T_Books` ADD `AuthName` varchar(50) CHARACTER SET utf8mb4 NOT NULL DEFAULT '' COMMENT '作者名';

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240819050549_UpdateBooks', '7.0.20');

COMMIT;

START TRANSACTION;

CREATE UNIQUE INDEX `IX_T_Books_Title` ON `T_Books` (`Title`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240819052011_BookTitlePrimaryKey', '7.0.20');

COMMIT;

START TRANSACTION;

UPDATE `T_Person` SET `Name` = ''
WHERE `Name` IS NULL;
SELECT ROW_COUNT();


ALTER TABLE `T_Person` MODIFY COLUMN `Name` longtext CHARACTER SET utf8mb4 NOT NULL COMMENT '名字';

ALTER TABLE `T_Person` MODIFY COLUMN `BirthPlace` longtext CHARACTER SET utf8mb4 NOT NULL COMMENT '出生地';

ALTER TABLE `T_Person` MODIFY COLUMN `Age` int NOT NULL COMMENT '年龄';

ALTER TABLE `T_Person` MODIFY COLUMN `Id` bigint NOT NULL AUTO_INCREMENT COMMENT '主键';

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240819062245_PersonAddComment', '7.0.20');

COMMIT;

START TRANSACTION;

ALTER TABLE `T_Person` COMMENT '角色表';

ALTER TABLE `T_Books` COMMENT '书本表';

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240819062403_TableComment', '7.0.20');

COMMIT;

