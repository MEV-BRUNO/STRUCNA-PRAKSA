-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 23, 2018 at 10:19 AM
-- Server version: 10.1.30-MariaDB
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `strucnapraksa`
--

-- --------------------------------------------------------

--
-- Table structure for table `dnevnik_prakse`
--

CREATE TABLE `dnevnik_prakse` (
  `id_praksa` int(11) NOT NULL,
  `id_student` int(11) NOT NULL,
  `red_broj` int(11) NOT NULL,
  `datum` date NOT NULL,
  `naslov` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `opis` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `dokumenti`
--

CREATE TABLE `dokumenti` (
  `id_dokument` int(10) UNSIGNED NOT NULL,
  `naziv` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `put` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `mentor`
--

CREATE TABLE `mentor` (
  `id_mentor` int(10) UNSIGNED NOT NULL,
  `ime+prezime` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `lozinka` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `id_studij` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `ocjena`
--

CREATE TABLE `ocjena` (
  `id_praksa` int(11) NOT NULL,
  `id_student` int(11) NOT NULL,
  `datum` date NOT NULL,
  `izvjesce_predano` tinyint(1) NOT NULL,
  `izvjsce_dokument` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `potvrda_predano` tinyint(1) NOT NULL,
  `potvrda_dokument` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `anketa_predano` tinyint(1) NOT NULL,
  `anketa_dokument` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `zahtjev_predano` tinyint(1) NOT NULL,
  `zahtjev_dokument` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `ocjena` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `poduzece`
--

CREATE TABLE `poduzece` (
  `id_poduzece` int(10) UNSIGNED NOT NULL,
  `naziv` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `adresa` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `grad` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `opis` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `kontakt_osoba` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `tel` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `URL` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `praksa`
--

CREATE TABLE `praksa` (
  `id_praksa` int(10) UNSIGNED NOT NULL,
  `id_studij` int(11) NOT NULL,
  `id_mentor` int(11) NOT NULL,
  `naziv` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `datum_od` date NOT NULL,
  `datum_do` date NOT NULL,
  `zavrsena` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `praksa_student`
--

CREATE TABLE `praksa_student` (
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

CREATE TABLE `prijava` (
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

CREATE TABLE `student` (
  `id_studnet` int(10) UNSIGNED NOT NULL,
  `ime+prezime` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `adresa` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `mob` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `lozinka` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `aktivacijski_link` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `aktivan` tinyint(1) NOT NULL,
  `id_studij` int(11) NOT NULL,
  `izvanredni` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `studij`
--

CREATE TABLE `studij` (
  `id_studij` int(10) UNSIGNED NOT NULL,
  `naziv` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `dokumenti`
--
ALTER TABLE `dokumenti`
  ADD PRIMARY KEY (`id_dokument`);

--
-- Indexes for table `mentor`
--
ALTER TABLE `mentor`
  ADD PRIMARY KEY (`id_mentor`),
  ADD UNIQUE KEY `mentor_email_unique` (`email`);

--
-- Indexes for table `poduzece`
--
ALTER TABLE `poduzece`
  ADD PRIMARY KEY (`id_poduzece`);

--
-- Indexes for table `praksa`
--
ALTER TABLE `praksa`
  ADD PRIMARY KEY (`id_praksa`);

--
-- Indexes for table `student`
--
ALTER TABLE `student`
  ADD PRIMARY KEY (`id_studnet`),
  ADD UNIQUE KEY `student_email_unique` (`email`);

--
-- Indexes for table `studij`
--
ALTER TABLE `studij`
  ADD PRIMARY KEY (`id_studij`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `dokumenti`
--
ALTER TABLE `dokumenti`
  MODIFY `id_dokument` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `mentor`
--
ALTER TABLE `mentor`
  MODIFY `id_mentor` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `poduzece`
--
ALTER TABLE `poduzece`
  MODIFY `id_poduzece` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `praksa`
--
ALTER TABLE `praksa`
  MODIFY `id_praksa` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `student`
--
ALTER TABLE `student`
  MODIFY `id_studnet` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `studij`
--
ALTER TABLE `studij`
  MODIFY `id_studij` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
