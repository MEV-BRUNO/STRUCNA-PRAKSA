-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Apr 23, 2018 at 07:55 PM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `strucna_praksa`
--

-- --------------------------------------------------------

--
-- Table structure for table `dnevnik_prakse`
--

CREATE TABLE IF NOT EXISTS `dnevnik_prakse` (
  `id_praksa` int(11) NOT NULL,
  `id_student` int(11) NOT NULL,
  `red_broj` int(11) NOT NULL,
  `datum` date NOT NULL,
  `naslov` varchar(255) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `opis` text CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `dokumenti`
--

CREATE TABLE IF NOT EXISTS `dokumenti` (
  `id_dokument` int(11) NOT NULL AUTO_INCREMENT,
  `naziv` varchar(100) COLLATE utf8_croatian_ci NOT NULL,
  `put` text COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_dokument`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `mentor`
--

CREATE TABLE IF NOT EXISTS `mentor` (
  `id_mentor` int(10) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `ime_prezime` varchar(100) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `email` varchar(30) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `lozinka` varchar(20) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `id_studij` int(11) NOT NULL,
  PRIMARY KEY (`id_mentor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `ocjena`
--

CREATE TABLE IF NOT EXISTS `ocjena` (
  `id_praksa` int(11) NOT NULL,
  `id_student` int(11) NOT NULL,
  `datum` date NOT NULL,
  `izvjesce_predano` tinyint(1) NOT NULL,
  `izvjsce_dokument` varchar(255) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `potvrda_predano` tinyint(1) NOT NULL,
  `potvrda_dokument` varchar(255) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `anketa_predano` tinyint(1) NOT NULL,
  `anketa_dokument` varchar(255) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `zahtjev_predano` tinyint(1) NOT NULL,
  `zahtjev_dokument` varchar(100) CHARACTER SET ucs2 COLLATE ucs2_croatian_ci NOT NULL,
  `ocjena` varchar(255) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `poduzece`
--

CREATE TABLE IF NOT EXISTS `poduzece` (
  `id_poduzece` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `naziv` varchar(60) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `adresa` varchar(100) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `grad` varchar(30) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `opis` text CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `kontakt_osoba` varchar(100) CHARACTER SET ucs2 COLLATE ucs2_croatian_ci NOT NULL,
  `tel` varchar(30) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `email` varchar(30) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `URL` text CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_poduzece`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `praksa`
--

CREATE TABLE IF NOT EXISTS `praksa` (
  `id_praksa` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `id_studij` int(11) NOT NULL,
  `id_mentor` int(11) NOT NULL,
  `naziv` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `datum_od` date NOT NULL,
  `datum_do` date NOT NULL,
  `zavrsena` tinyint(1) NOT NULL,
  PRIMARY KEY (`id_praksa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `praksa_student`
--

CREATE TABLE IF NOT EXISTS `praksa_student` (
  `id_praksa` int(11) NOT NULL,
  `id_student` int(11) NOT NULL,
  `id_poduzece` int(11) NOT NULL,
  `datum_od` date NOT NULL,
  `datum_do` date NOT NULL,
  `odobreno` tinyint(1) NOT NULL,
  `ocjena` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `prijava`
--

CREATE TABLE IF NOT EXISTS `prijava` (
  `id_praksa` int(11) NOT NULL,
  `id_student` int(11) NOT NULL,
  `datum` date NOT NULL,
  `id_poduzece` int(11) NOT NULL,
  `odobreno` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

CREATE TABLE IF NOT EXISTS `student` (
  `id_studnet` int(10) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `ime_prezime` varchar(100) CHARACTER SET utf16 COLLATE utf16_croatian_ci NOT NULL,
  `adresa` varchar(100) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `mob` varchar(30) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `email` varchar(30) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `lozinka` varchar(20) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `aktivacijski_link` text CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `aktivan` tinyint(1) NOT NULL,
  `id_studij` int(11) NOT NULL,
  `izvanredni` tinyint(1) NOT NULL,
  PRIMARY KEY (`id_studnet`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `studij`
--

CREATE TABLE IF NOT EXISTS `studij` (
  `id_studij` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `naziv` varchar(100) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  PRIMARY KEY (`id_studij`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=1 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
