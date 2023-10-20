-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema petlifedb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema petlifedb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `petlifedb` DEFAULT CHARACTER SET utf8mb4 ;
USE `petlifedb` ;

-- -----------------------------------------------------
-- Table `petlifedb`.`cliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `petlifedb`.`cliente` (
  `clienteId` INT(11) NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `dataNascimento` DATE NULL,
  `status` TINYINT NULL,
  PRIMARY KEY (`clienteId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `petlifedb`.`PetWalker`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `petlifedb`.`PetWalker` (
  `petWalkerId` INT(11) NOT NULL AUTO_INCREMENT,
  `clienteId` INT(11) NOT NULL,
  `rg` INT(11) NOT NULL,
  `cpf` INT(11) NOT NULL,
  `fotoRgFrontal` VARCHAR(100) NOT NULL,
  `fotoRgTraseira` VARCHAR(100) NOT NULL,
  `fotoCpfFrontal` VARCHAR(100) NOT NULL,
  `fotoCpfTraseira` VARCHAR(100) NOT NULL,
  `fotoPessoal` VARCHAR(100) NOT NULL,
  `fotoPessoalRg` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`petWalkerId`),
  INDEX `fk_clienteParceiro_cliente1_idx` (`clienteId`),
  CONSTRAINT `fk_clienteParceiro_cliente1`
    FOREIGN KEY (`clienteId`)
    REFERENCES `petlifedb`.`cliente` (`clienteId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `petlifedb`.`email`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `petlifedb`.`email` (
  `emailId` INT(11) NOT NULL AUTO_INCREMENT,
  `clienteId` INT(11) NOT NULL,
  `email` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`emailId`),
  INDEX `fk_email_cliente1_idx` (`clienteId`),
  CONSTRAINT `fk_email_cliente1`
    FOREIGN KEY (`clienteId`)
    REFERENCES `petlifedb`.`cliente` (`clienteId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `petlifedb`.`estado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `petlifedb`.`estado` (
  `estado` VARCHAR(2) NOT NULL,
  PRIMARY KEY (`estado`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `petlifedb`.`cidade`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `petlifedb`.`cidade` (
  `cidadeId` INT NOT NULL AUTO_INCREMENT,
  `estadoId` VARCHAR(2) NOT NULL,
  `nomeCidade` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`cidadeId`),
  INDEX `fk_cidade_estado1_idx` (`estadoId`),
  CONSTRAINT `fk_cidade_estado1`
    FOREIGN KEY (`estadoId`)
    REFERENCES `petlifedb`.`estado` (`estado`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `petlifedb`.`endereco`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `petlifedb`.`endereco` (
  `enderecoId` INT(11) NOT NULL AUTO_INCREMENT,
  `clienteId` INT(11) NOT NULL,
  `cidadeId` INT NOT NULL,
  `rua` VARCHAR(50) NOT NULL,
  `numero` INT(11) NOT NULL,
  `cep` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`enderecoId`),
  INDEX `fk_endereco_cliente1_idx` (`clienteId`) ,
  INDEX `fk_endereco_cidade1_idx` (`cidadeId`) ,
  CONSTRAINT `fk_endereco_cliente1`
    FOREIGN KEY (`clienteId`)
    REFERENCES `petlifedb`.`cliente` (`clienteId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_endereco_cidade1`
    FOREIGN KEY (`cidadeId`)
    REFERENCES `petlifedb`.`cidade` (`cidadeId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `petlifedb`.`pet`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `petlifedb`.`pet` (
  `petId` INT(11) NOT NULL AUTO_INCREMENT,
  `clienteId` INT(11) NOT NULL,
  `nome` VARCHAR(50) NOT NULL,
  `rg` VARCHAR(45) NULL DEFAULT NULL,
  `idade` INT(11) NOT NULL,
  `peso` FLOAT NULL DEFAULT NULL,
  `porte` VARCHAR(20) NOT NULL,
  `raca` VARCHAR(30) NOT NULL,
  `observacao` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`petId`),
  INDEX `fk_pet_cliente_idx` (`clienteId`) ,
  CONSTRAINT `fk_pet_cliente`
    FOREIGN KEY (`clienteId`)
    REFERENCES `petlifedb`.`cliente` (`clienteId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `petlifedb`.`rastreador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `petlifedb`.`rastreador` (
  `rastreadorId` INT(11) NOT NULL AUTO_INCREMENT,
  `clienteId` INT(11) NOT NULL,
  `identificador` VARCHAR(50) NOT NULL,
  `dataRecolhida` DATETIME NOT NULL,
  `latitude` VARCHAR(50) NOT NULL,
  `longitude` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`rastreadorId`),
  INDEX `fk_rastreador_cliente1_idx` (`clienteId`),
  CONSTRAINT `fk_rastreador_cliente1`
    FOREIGN KEY (`clienteId`)
    REFERENCES `petlifedb`.`cliente` (`clienteId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `petlifedb`.`telefone`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `petlifedb`.`telefone` (
  `telefoneId` INT(11) NOT NULL AUTO_INCREMENT,
  `clienteId` INT(11) NOT NULL,
  `telefone` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`telefoneId`),
  INDEX `fk_telefone_cliente1_idx` (`clienteId`) ,
  CONSTRAINT `fk_telefone_cliente1`
    FOREIGN KEY (`clienteId`)
    REFERENCES `petlifedb`.`cliente` (`clienteId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `petlifedb`.`alimentador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `petlifedb`.`alimentador` (
  `alimentadorId` INT NOT NULL AUTO_INCREMENT,
  `clienteId` INT(11) NOT NULL,
  `identificador` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`alimentadorId`),
  INDEX `fk_alimentador_cliente_idx` (`clienteId`),
  CONSTRAINT `fk_alimentador_cliente`
    FOREIGN KEY (`clienteId`)
    REFERENCES `petlifedb`.`cliente` (`clienteId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `petlifedb`.`dadosRecebidos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `petlifedb`.`dadosRecebidos` (
  `dadosRecebidosId` INT NOT NULL AUTO_INCREMENT,
  `horaRecolhida` DATETIME NULL,
  `qtdConsumidaAgua` FLOAT NULL,
  `qtdConsumidaRacao` FLOAT NULL,
  `alimentadorId` INT NOT NULL,
  PRIMARY KEY (`dadosRecebidosId`),
  INDEX `fk_dadosRecebidos_alimentador1_idx` (`alimentadorId`),
  CONSTRAINT `fk_dadosRecebidos_alimentador1`
    FOREIGN KEY (`alimentadorId`)
    REFERENCES `petlifedb`.`alimentador` (`alimentadorId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `petlifedb`.`horarios`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `petlifedb`.`horarios` (
  `horariosId` INT NOT NULL AUTO_INCREMENT,
  `alimentadorId` INT NOT NULL,
  `horario` VARCHAR(15) NULL,
  `quantidadeDespejar` FLOAT NULL,
  PRIMARY KEY (`horariosId`),
  INDEX `fk_horarios_alimentador1_idx` (`alimentadorId`),
  CONSTRAINT `fk_horarios_alimentador1`
    FOREIGN KEY (`alimentadorId`)
    REFERENCES `petlifedb`.`alimentador` (`alimentadorId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `petlifedb`.`login`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `petlifedb`.`login` (
  `loginId` INT NOT NULL AUTO_INCREMENT,
  `clienteId` INT(11) NOT NULL,
  `emailId` INT(11) NOT NULL,
  `senha` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`loginId`),
  INDEX `fk_login_cliente1_idx` (`clienteId`),
  INDEX `fk_login_email1_idx` (`emailId`),
  CONSTRAINT `fk_login_cliente1`
    FOREIGN KEY (`clienteId`)
    REFERENCES `petlifedb`.`cliente` (`clienteId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_login_email1`
    FOREIGN KEY (`emailId`)
    REFERENCES `petlifedb`.`email` (`emailId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `petlifedb`.`caminhada`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `petlifedb`.`caminhada` (
  `caminhadaId` INT NOT NULL AUTO_INCREMENT,
  `clienteId` INT(11) NOT NULL,
  `petWalkerId` INT(11) NOT NULL,
  `dataCaminhada` DATETIME NOT NULL,
  `duracao` VARCHAR(45) NOT NULL,
  INDEX `fk_cliente_has_PetWalker_PetWalker1_idx` (`petWalkerId`),
  INDEX `fk_cliente_has_PetWalker_cliente1_idx` (`clienteId`),
  PRIMARY KEY (`caminhadaId`),
  CONSTRAINT `fk_cliente_has_PetWalker_cliente1`
    FOREIGN KEY (`clienteId`)
    REFERENCES `petlifedb`.`cliente` (`clienteId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_cliente_has_PetWalker_PetWalker1`
    FOREIGN KEY (`petWalkerId`)
    REFERENCES `petlifedb`.`PetWalker` (`petWalkerId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


-- -----------------------------------------------------
-- Table `petlifedb`.`pet_caminhada`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `petlifedb`.`pet_caminhada` (
  `pet_caminhadaId` INT NOT NULL AUTO_INCREMENT,
  `petId` INT(11) NOT NULL,
  `caminhadaId` INT NOT NULL,
  INDEX `fk_pet_has_caminhada_caminhada1_idx` (`caminhadaId`),
  INDEX `fk_pet_has_caminhada_pet1_idx` (`petId`),
  PRIMARY KEY (`pet_caminhadaId`),
  CONSTRAINT `fk_pet_has_caminhada_pet1`
    FOREIGN KEY (`petId`)
    REFERENCES `petlifedb`.`pet` (`petId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_pet_has_caminhada_caminhada1`
    FOREIGN KEY (`caminhadaId`)
    REFERENCES `petlifedb`.`caminhada` (`caminhadaId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
