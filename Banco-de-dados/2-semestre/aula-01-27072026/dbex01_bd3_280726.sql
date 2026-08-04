-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Tempo de geração: 28/07/2026 às 17:55
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
-- Banco de dados: `dbex01_bd3_280726`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_cliente`
--

DROP TABLE IF EXISTS `tb_cliente`;
CREATE TABLE IF NOT EXISTS `tb_cliente` (
  `ID_CLIENTE` int NOT NULL AUTO_INCREMENT,
  `NOME_CLIENTE` varchar(60) COLLATE utf8mb4_unicode_ci NOT NULL,
  `END_CLIENTE` varchar(120) COLLATE utf8mb4_unicode_ci NOT NULL,
  `UF` char(2) COLLATE utf8mb4_unicode_ci NOT NULL,
  `CPF_CLIENTE` char(14) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`ID_CLIENTE`),
  KEY `UF` (`UF`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `tb_cliente`
--

INSERT INTO `tb_cliente` (`ID_CLIENTE`, `NOME_CLIENTE`, `END_CLIENTE`, `UF`, `CPF_CLIENTE`) VALUES
(1, 'Ano Paulo', 'Rua Tibiriça', 'SP', '111.222.333-44'),
(2, 'Jaime tarantulo', 'Rua Gigante', 'MG', '333.444.555-77'),
(3, 'Roberto Barros', 'Rua do Limoeiro', 'RJ', '986.902.567-57'),
(4, 'Jaguaro', 'Rua Pindorama', 'MG', '513.352.324-44'),
(5, 'Janelso', 'Rua Tilenomelo', 'SP', '111.222.333-44');

-- --------------------------------------------------------

--
-- Estrutura para tabela `tb_estados`
--

DROP TABLE IF EXISTS `tb_estados`;
CREATE TABLE IF NOT EXISTS `tb_estados` (
  `UF` char(2) COLLATE utf8mb4_unicode_ci NOT NULL,
  `UF_DESC` varchar(35) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`UF`),
  UNIQUE KEY `UQUF_DESC` (`UF_DESC`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Despejando dados para a tabela `tb_estados`
--

INSERT INTO `tb_estados` (`UF`, `UF_DESC`) VALUES
('SP', 'São Paulo'),
('MG', 'Minas Gerais'),
('RJ', 'Rio de Janeiro');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
