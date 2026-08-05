-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Tempo de geração: 26/06/2026 às 11:14
-- Versão do servidor: 8.4.7
-- Versão do PHP: 8.3.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `petshop_db`
--
CREATE DATABASE IF NOT EXISTS `petshop_db` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `petshop_db`;

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_consulta`
--

DROP TABLE IF EXISTS `tb_consulta`;
CREATE TABLE IF NOT EXISTS `tb_consulta` (
  `id_consulta` int NOT NULL AUTO_INCREMENT,
  `cod_pet` int NOT NULL,
  `data_consulta` date NOT NULL,
  `prescricao_consulta` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id_consulta`),
  KEY `cod_pet` (`cod_pet`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_fale_conosco`
--

DROP TABLE IF EXISTS `tb_fale_conosco`;
CREATE TABLE IF NOT EXISTS `tb_fale_conosco` (
  `id_fale` int NOT NULL AUTO_INCREMENT,
  `nome_fale` varchar(80) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `email_fale` varchar(80) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `msg_fale` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `resposta_fale` enum('V','F') CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id_fale`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_pet`
--

DROP TABLE IF EXISTS `tb_pet`;
CREATE TABLE IF NOT EXISTS `tb_pet` (
  `cod_pet` int NOT NULL AUTO_INCREMENT,
  `cpf_tutor` char(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `nascimento_pet` date DEFAULT NULL,
  `genero_pet` enum('M','F') CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `raca_pet` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `foto_pet` blob,
  `nome_pet` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `especie_pet` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`cod_pet`),
  KEY `cpf_tutor` (`cpf_tutor`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_servicos`
--

DROP TABLE IF EXISTS `tb_servicos`;
CREATE TABLE IF NOT EXISTS `tb_servicos` (
  `id_servico` int NOT NULL AUTO_INCREMENT,
  `cod_pet` int NOT NULL,
  `tipo_servico` enum('banho','tosa') CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `data_servico` date NOT NULL,
  `valor_servico` decimal(6,2) NOT NULL,
  PRIMARY KEY (`id_servico`),
  KEY `cod_pet` (`cod_pet`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_tutor`
--

DROP TABLE IF EXISTS `tb_tutor`;
CREATE TABLE IF NOT EXISTS `tb_tutor` (
  `cpf_tutor` char(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `nome_tutor` varchar(80) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `celular_tutor` char(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `email_tutor` varchar(80) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`cpf_tutor`),
  UNIQUE KEY `cpf_tutor` (`cpf_tutor`),
  UNIQUE KEY `celular_tutor` (`celular_tutor`),
  UNIQUE KEY `email_tutor` (`email_tutor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `tb_consulta`
--
ALTER TABLE `tb_consulta`
  ADD CONSTRAINT `tb_consulta_ibfk_1` FOREIGN KEY (`cod_pet`) REFERENCES `tb_pet` (`cod_pet`) ON DELETE CASCADE;

--
-- Restrições para tabelas `tb_pet`
--
ALTER TABLE `tb_pet`
  ADD CONSTRAINT `tb_pet_ibfk_1` FOREIGN KEY (`cpf_tutor`) REFERENCES `tb_tutor` (`cpf_tutor`) ON DELETE CASCADE;

--
-- Restrições para tabelas `tb_servicos`
--
ALTER TABLE `tb_servicos`
  ADD CONSTRAINT `tb_servicos_ibfk_1` FOREIGN KEY (`cod_pet`) REFERENCES `tb_pet` (`cod_pet`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
