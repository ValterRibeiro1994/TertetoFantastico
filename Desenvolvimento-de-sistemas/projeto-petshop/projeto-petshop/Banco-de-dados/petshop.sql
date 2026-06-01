-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Tempo de geração: 01/06/2026 às 18:18
-- Versão do servidor: 8.3.0
-- Versão do PHP: 8.2.18

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
CREATE DATABASE IF NOT EXISTS `petshop_db` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE `petshop_db`;

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_consulta`
--

DROP TABLE IF EXISTS `tb_consulta`;
CREATE TABLE IF NOT EXISTS `tb_consulta` (
  `cod_pet` int NOT NULL,
  `data_consulta` date NOT NULL,
  `prescricao_consulta` text NOT NULL,
  KEY `cod_pet` (`cod_pet`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Despejando dados para a tabela `tb_consulta`
--

INSERT INTO `tb_consulta` (`cod_pet`, `data_consulta`, `prescricao_consulta`) VALUES
(1, '2026-06-01', 'Cachorro com excesso de gostosura igual o tutor'),
(2, '2019-11-24', 'Sacrificado'),
(3, '2024-08-23', 'Excesso de velhice, ronca demais, cataratas, dedao direito menor');

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_pet`
--

DROP TABLE IF EXISTS `tb_pet`;
CREATE TABLE IF NOT EXISTS `tb_pet` (
  `cod_pet` int NOT NULL AUTO_INCREMENT,
  `cpf_tutor` char(11) NOT NULL,
  `nascimento_pet` date DEFAULT NULL,
  `genero_pet` enum('M','F') NOT NULL,
  `raca_pet` varchar(30) NOT NULL,
  `foto_pet` blob,
  `nome_pet` varchar(30) NOT NULL,
  `especie_pet` varchar(30) NOT NULL,
  PRIMARY KEY (`cod_pet`),
  KEY `cpf_tutor` (`cpf_tutor`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Despejando dados para a tabela `tb_pet`
--

INSERT INTO `tb_pet` (`cod_pet`, `cpf_tutor`, `nascimento_pet`, `genero_pet`, `raca_pet`, `foto_pet`, `nome_pet`, `especie_pet`) VALUES
(4, '07845179913', '2025-10-13', 'M', 'vira-lata', NULL, 'caramelo', 'cachorro'),
(5, '56123460854', '2024-02-21', 'M', 'yorkshire', NULL, 'paçoca', 'cachorro'),
(6, '58225745906', '2015-07-30', 'F', 'poddle', NULL, 'veinha', 'cachorro');

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_servicos`
--

DROP TABLE IF EXISTS `tb_servicos`;
CREATE TABLE IF NOT EXISTS `tb_servicos` (
  `cod_pet` int NOT NULL,
  `tipo_servico` enum('banho','tosa') NOT NULL,
  `data_servico` date NOT NULL,
  `valor_servico` decimal(6,2) NOT NULL,
  KEY `cod_pet` (`cod_pet`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Despejando dados para a tabela `tb_servicos`
--

INSERT INTO `tb_servicos` (`cod_pet`, `tipo_servico`, `data_servico`, `valor_servico`) VALUES
(1, 'banho', '2026-06-01', 20.50),
(2, 'tosa', '2025-05-31', 54.99),
(3, 'banho', '2026-01-25', 115.70);

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_tutor`
--

DROP TABLE IF EXISTS `tb_tutor`;
CREATE TABLE IF NOT EXISTS `tb_tutor` (
  `cpf_tutor` char(11) NOT NULL,
  `nome_tutor` varchar(80) NOT NULL,
  `celular_tutor` char(11) NOT NULL,
  `email_tutor` varchar(80) NOT NULL,
  PRIMARY KEY (`cpf_tutor`),
  UNIQUE KEY `cpf_tutor` (`cpf_tutor`),
  UNIQUE KEY `celular_tutor` (`celular_tutor`),
  UNIQUE KEY `email_tutor` (`email_tutor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Despejando dados para a tabela `tb_tutor`
--

INSERT INTO `tb_tutor` (`cpf_tutor`, `nome_tutor`, `celular_tutor`, `email_tutor`) VALUES
('07845179913', 'Valter Tertuliano', '16994030287', 'valtertert@gmail.com'),
('56123460854', 'Felipe Rodrigo', '11977818235', 'felipereidelas@gmail.com'),
('58225745906', 'Lucas Braz', '11944517587', 'lucasubraz@gmail.com');

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `tb_consulta`
--
ALTER TABLE `tb_consulta`
  ADD CONSTRAINT `tb_consulta_ibfk_1` FOREIGN KEY (`cod_pet`) REFERENCES `tb_pet` (`cod_pet`);

--
-- Restrições para tabelas `tb_pet`
--
ALTER TABLE `tb_pet`
  ADD CONSTRAINT `tb_pet_ibfk_1` FOREIGN KEY (`cpf_tutor`) REFERENCES `tb_tutor` (`cpf_tutor`);

--
-- Restrições para tabelas `tb_servicos`
--
ALTER TABLE `tb_servicos`
  ADD CONSTRAINT `tb_servicos_ibfk_1` FOREIGN KEY (`cod_pet`) REFERENCES `tb_pet` (`cod_pet`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
