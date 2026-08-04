-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Tempo de geração: 04/08/2026 às 17:51
-- Versão do servidor: 9.1.0
-- Versão do PHP: 8.3.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `dbex03_bd3_040826`
--
CREATE DATABASE IF NOT EXISTS `dbex03_bd3_040826` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `dbex03_bd3_040826`;

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_aluno`
--
-- Criação: 04/08/2026 às 17:13
-- Última atualização: 04/08/2026 às 16:59
--

DROP TABLE IF EXISTS `tb_aluno`;
CREATE TABLE IF NOT EXISTS `tb_aluno` (
  `mat_aluno` int NOT NULL,
  `nome_aluno` varchar(60) COLLATE utf8mb4_unicode_ci NOT NULL,
  `nota_aluno` decimal(3,1) NOT NULL,
  `status_aluno` varchar(35) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`mat_aluno`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `tb_aluno`
--

INSERT INTO `tb_aluno` (`mat_aluno`, `nome_aluno`, `nota_aluno`, `status_aluno`) VALUES
(1312, 'Ana Paula', 4.5, 'Reprovado'),
(1313, 'João', 6.8, 'Recuperação'),
(1314, 'Igor', 7.3, 'Aprovado'),
(1315, 'Júlia', 8.0, 'Aprovado');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
