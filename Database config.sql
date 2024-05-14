-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema sql_app
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema sql_app
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `sql_app` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `sql_app` ;

-- -----------------------------------------------------
-- Table `sql_app`.`clients`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sql_app`.`clients` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `NIP` VARCHAR(45) NOT NULL,
  `Name` VARCHAR(100) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `sql_app`.`packages`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sql_app`.`packages` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `PackageNumber` INT NOT NULL,
  `IdWatermeter` INT NOT NULL,
  `CreationDate` DATETIME NOT NULL,
  `Client` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `IdWatermeter_UNIQUE` (`IdWatermeter` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `sql_app`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sql_app`.`users` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Login` VARCHAR(50) NOT NULL,
  `Password` VARCHAR(100) NOT NULL,
  `Name` VARCHAR(45) NOT NULL,
  `Surname` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `sql_app`.`watermeters`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sql_app`.`watermeters` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `SerialNumber` VARCHAR(50) NOT NULL,
  `Name` VARCHAR(100) NOT NULL,
  `Worker` INT NOT NULL,
  `IdInPackage` INT NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `SerialNumber_UNIQUE` (`SerialNumber` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `sql_app`.`wmnames`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `sql_app`.`wmnames` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `WatermeterName` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
