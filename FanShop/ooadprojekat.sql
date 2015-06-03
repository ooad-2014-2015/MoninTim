-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jun 03, 2015 at 06:36 PM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `ooadprojekat`
--

-- --------------------------------------------------------

--
-- Table structure for table `arhiva`
--

CREATE TABLE IF NOT EXISTS `arhiva` (
  `id` int(11) NOT NULL,
  `kolicina` int(11) NOT NULL,
  `datum` date NOT NULL,
  `tip` char(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `arhiva`
--

INSERT INTO `arhiva` (`id`, `kolicina`, `datum`, `tip`) VALUES
(31, 3, '2015-05-22', 'd'),
(53, 10, '2015-05-22', 'k'),
(29, 1, '2015-05-22', 'd'),
(30, 1, '2015-05-22', 'd'),
(31, 1, '2015-05-22', 'd'),
(32, 1, '2015-05-22', 'd');

-- --------------------------------------------------------

--
-- Table structure for table `dresovi`
--

CREATE TABLE IF NOT EXISTS `dresovi` (
  `id` int(11) NOT NULL,
  `velicine` varchar(32) NOT NULL DEFAULT 'S-M-L-XL-XXL-',
  `slika` varchar(120) NOT NULL,
  `cijena` decimal(10,0) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `dresovi`
--

INSERT INTO `dresovi` (`id`, `velicine`, `slika`, `cijena`) VALUES
(28, 'S-M-L-XL-XXL-', 'dresovi\\1.jpg', '20'),
(29, 'S-M-L-XL-XXL-', 'dresovi\\2.jpg', '25'),
(30, 'S-M-L-XL-XXL-', 'dresovi\\4.jpeg', '30'),
(31, 'S-M-L-XL-XXL-', 'dresovi\\5.jpg', '35'),
(32, 'S-M-L-XL-XXL-', 'dresovi\\6.jpg', '25'),
(33, 'S-M-L-XL-XXL-', 'dresovi\\7.jpg', '21'),
(34, 'S-M-L-XL-XXL-', 'dresovi\\8.jpeg', '15'),
(56, 'S-M-L-XL-XXL-', 'C:\\Users\\avukas\\Desktop\\monin\\MoninTim\\FanShop\\FanShop\\dresovi\\1.jpg', '15'),
(57, 'S-M-L-XL-XXL-', 'C:\\Users\\avukas\\Desktop\\monin\\MoninTim\\FanShop\\FanShop\\dresovi\\7.jpg', '3'),
(58, 'S-M-L-XL-XXL-', 'C:\\Users\\avukas\\Desktop\\monin\\MoninTim\\FanShop\\FanShop\\dresovi\\1.jpg', '17'),
(59, 'S-M-L-XL-XXL-', 'C:\\Users\\avukas\\Desktop\\monin\\MoninTim\\FanShop\\FanShop\\dresovi\\6.jpg', '19'),
(61, 'S-M-L-XL-XXL-', 'C:\\Users\\avukas\\Desktop\\monin\\MoninTim\\FanShop\\FanShop\\salovi\\1.jpg', '20'),
(62, 'S-M-L-XL-XXL-', 'C:\\Users\\avukas\\Desktop\\monin\\MoninTim\\FanShop\\FanShop\\salovi\\1.jpg', '10'),
(63, 'S-M-L-XL-XXL-', 'C:\\Users\\avukas\\Desktop\\monin\\MoninTim\\FanShop\\FanShop\\salovi\\2.jpg', '10'),
(64, 'S-M-L-XL-XXL-', 'dresovi\\1.jpg', '10');

-- --------------------------------------------------------

--
-- Table structure for table `kape`
--

CREATE TABLE IF NOT EXISTS `kape` (
  `id` int(11) NOT NULL,
  `slika` varchar(120) NOT NULL,
  `velicine` varchar(32) NOT NULL DEFAULT 'S-M-L-XL-',
  `cijena` decimal(10,0) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kape`
--

INSERT INTO `kape` (`id`, `slika`, `velicine`, `cijena`) VALUES
(47, 'kape\\1.jpg', 'S-M-L-XL-', '10'),
(48, 'kape\\2.jpg', 'S-M-L-XL-', '10'),
(49, 'kape\\3.jpg', 'S-M-L-XL-', '10'),
(50, 'kape\\3.jpg', 'S-M-L-XL-', '10'),
(51, 'kape\\5.png', 'S-M-L-XL-', '10'),
(52, 'kape\\6.jpg', 'S-M-L-XL-', '10'),
(53, 'kape\\7.jpg', 'S-M-L-XL-', '10');

-- --------------------------------------------------------

--
-- Table structure for table `katalog`
--

CREATE TABLE IF NOT EXISTS `katalog` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `tip` varchar(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=65 ;

--
-- Dumping data for table `katalog`
--

INSERT INTO `katalog` (`id`, `tip`) VALUES
(28, 'd'),
(29, 'd'),
(30, 'd'),
(31, 'd'),
(32, 'd'),
(33, 'd'),
(34, 'd'),
(35, 's'),
(36, 's'),
(37, 's'),
(38, 's'),
(39, 'p'),
(40, 'p'),
(41, 'p'),
(42, 'p'),
(43, 'p'),
(44, 'p'),
(45, 'p'),
(46, 'p'),
(47, 'k'),
(48, 'k'),
(49, 'k'),
(50, 'k'),
(51, 'k'),
(52, 'k'),
(53, 'k'),
(56, 'd'),
(57, 'd'),
(58, 'd'),
(59, 'd'),
(60, 's'),
(61, 'd'),
(62, 'd'),
(63, 'd'),
(64, 'd');

-- --------------------------------------------------------

--
-- Table structure for table `korisnici`
--

CREATE TABLE IF NOT EXISTS `korisnici` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(32) NOT NULL,
  `password` varchar(32) NOT NULL,
  `email` varchar(64) NOT NULL,
  `adresa` varchar(100) NOT NULL,
  `broj_telefona` varchar(12) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `korisnici`
--

INSERT INTO `korisnici` (`id`, `username`, `password`, `email`, `adresa`, `broj_telefona`) VALUES
(3, 'avukas', 'password', 'ad@jajd.com', 'kladjljf', '062527258'),
(4, 'adk', 'kakkdkkf', 'ad@lafkl.xom', 'mkafn,g', '062145754'),
(5, 'klldal', 'lamldfm', 'klam@la.clm', 'ladjljflj', '062547785');

-- --------------------------------------------------------

--
-- Table structure for table `log`
--

CREATE TABLE IF NOT EXISTS `log` (
  `id` int(11) NOT NULL,
  `akcija` varchar(250) NOT NULL,
  `datum` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `log`
--

INSERT INTO `log` (`id`, `akcija`, `datum`) VALUES
(1, 'Obrisao/la artikal sa ID-om 7', '2015-05-21'),
(1, 'Unio/la privjesak sa ID-om 9', '2015-05-21'),
(1, 'Obrisao/la artikal sa ID-om 9', '2015-05-21'),
(1, 'Unio/la dres sa ID-om 10', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 11', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 12', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 13', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 14', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 18', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 19', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 20', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 21', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 22', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 23', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 24', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 25', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 26', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 27', '2015-05-22'),
(1, 'Obrisao/la artikal sa ID-om 27', '2015-05-22'),
(1, 'Obrisao/la artikal sa ID-om 26', '2015-05-22'),
(1, 'Obrisao/la artikal sa ID-om 25', '2015-05-22'),
(1, 'Obrisao/la artikal sa ID-om 4', '2015-05-22'),
(1, 'Obrisao/la artikal sa ID-om 8', '2015-05-22'),
(1, 'Obrisao/la artikal sa ID-om 24', '2015-05-22'),
(1, 'Obrisao/la artikal sa ID-om 23', '2015-05-22'),
(1, 'Obrisao/la artikal sa ID-om 22', '2015-05-22'),
(1, 'Obrisao/la artikal sa ID-om 21', '2015-05-22'),
(1, 'Obrisao/la artikal sa ID-om 5', '2015-05-22'),
(1, 'Obrisao/la artikal sa ID-om 6', '2015-05-22'),
(1, 'Obrisao/la artikal sa ID-om 10', '2015-05-22'),
(1, 'Obrisao/la artikal sa ID-om 18', '2015-05-22'),
(1, 'Obrisao/la artikal sa ID-om 19', '2015-05-22'),
(1, 'Obrisao/la artikal sa ID-om 20', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 28', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 29', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 30', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 31', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 32', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 33', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 34', '2015-05-22'),
(1, 'Unio/la sal sa ID-om 35', '2015-05-22'),
(1, 'Unio/la sal sa ID-om 36', '2015-05-22'),
(1, 'Unio/la sal sa ID-om 37', '2015-05-22'),
(1, 'Unio/la sal sa ID-om 38', '2015-05-22'),
(1, 'Unio/la privjesak sa ID-om 39', '2015-05-22'),
(1, 'Unio/la privjesak sa ID-om 40', '2015-05-22'),
(1, 'Unio/la privjesak sa ID-om 41', '2015-05-22'),
(1, 'Unio/la privjesak sa ID-om 42', '2015-05-22'),
(1, 'Unio/la privjesak sa ID-om 43', '2015-05-22'),
(1, 'Unio/la privjesak sa ID-om 44', '2015-05-22'),
(1, 'Unio/la privjesak sa ID-om 45', '2015-05-22'),
(1, 'Unio/la privjesak sa ID-om 46', '2015-05-22'),
(1, 'Unio/la kapu sa ID-om 47', '2015-05-22'),
(1, 'Unio/la kapu sa ID-om 48', '2015-05-22'),
(1, 'Unio/la kapu sa ID-om 49', '2015-05-22'),
(1, 'Unio/la kapu sa ID-om 50', '2015-05-22'),
(1, 'Unio/la kapu sa ID-om 51', '2015-05-22'),
(1, 'Unio/la kapu sa ID-om 52', '2015-05-22'),
(1, 'Unio/la kapu sa ID-om 53', '2015-05-22'),
(1, 'Unio/la dres sa ID-om 54', '2015-05-24'),
(1, 'Unio/la dres sa ID-om 55', '2015-05-24'),
(1, 'Unio/la dres sa ID-om 56', '2015-05-24'),
(1, 'Unio/la dres sa ID-om 57', '2015-05-24'),
(1, 'Unio/la dres sa ID-om 58', '2015-05-24'),
(1, 'Unio/la dres sa ID-om 59', '2015-05-24'),
(1, 'Unio/la sal sa ID-om 60', '2015-05-24'),
(1, 'Unio/la dres sa ID-om 61', '2015-05-24'),
(1, 'Unio/la dres sa ID-om 62', '2015-05-24'),
(1, 'Unio/la dres sa ID-om 63', '2015-05-24'),
(1, 'Unio/la dres sa ID-om 64', '2015-05-24');

-- --------------------------------------------------------

--
-- Table structure for table `privjesci`
--

CREATE TABLE IF NOT EXISTS `privjesci` (
  `id` int(11) NOT NULL,
  `slika` varchar(120) NOT NULL,
  `cijena` decimal(10,0) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `privjesci`
--

INSERT INTO `privjesci` (`id`, `slika`, `cijena`) VALUES
(39, 'privjesci\\1.jpg', '5'),
(40, 'privjesci\\2.jpg', '5'),
(41, 'privjesci\\3.jpg', '5'),
(42, 'privjesci\\4.jpg', '5'),
(43, 'privjesci\\5.jpg', '5'),
(44, 'privjesci\\6.jpg', '5'),
(45, 'privjesci\\7.jpg', '6'),
(46, 'privjesci\\8.jpg', '5');

-- --------------------------------------------------------

--
-- Table structure for table `salovi`
--

CREATE TABLE IF NOT EXISTS `salovi` (
  `id` int(11) NOT NULL,
  `slika` varchar(120) NOT NULL,
  `cijena` decimal(10,0) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `salovi`
--

INSERT INTO `salovi` (`id`, `slika`, `cijena`) VALUES
(35, 'salovi\\1.jpg', '20'),
(36, 'salovi\\2.jpg', '20'),
(37, 'salovi\\3.jpg', '15'),
(38, 'salovi\\4.jpg', '11'),
(60, 'C:\\Users\\avukas\\Desktop\\monin\\MoninTim\\FanShop\\FanShop\\salovi\\2.jpg', '10');

-- --------------------------------------------------------

--
-- Table structure for table `uposlenici`
--

CREATE TABLE IF NOT EXISTS `uposlenici` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(32) DEFAULT NULL,
  `password` varchar(32) NOT NULL DEFAULT 'a',
  `ime_prezime` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `uposlenici`
--

INSERT INTO `uposlenici` (`id`, `username`, `password`, `ime_prezime`) VALUES
(1, 'test', 'test', ''),
(2, 'admin', 'admin', '');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
