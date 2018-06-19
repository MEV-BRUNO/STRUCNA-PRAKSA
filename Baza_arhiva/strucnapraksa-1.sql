-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 18, 2018 at 06:25 PM
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
  `id_dnevnik` int(11) NOT NULL,
  `id_praksa` int(11) NOT NULL,
  `id_student` int(11) NOT NULL,
  `red_broj` int(11) NOT NULL,
  `datum` date NOT NULL,
  `naslov` varchar(255) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `opis` text CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=PAGE;

--
-- Dumping data for table `dnevnik_prakse`
--

INSERT INTO `dnevnik_prakse` (`id_dnevnik`, `id_praksa`, `id_student`, `red_broj`, `datum`, `naslov`, `opis`) VALUES
(10, 0, 3, 1, '2018-02-12', 'ASd', 'dddddddd'),
(11, 0, 3, 2, '2018-08-08', 'dsa', 'tzuuuuuuuuuuuu');

-- --------------------------------------------------------

--
-- Table structure for table `dokumenti`
--

CREATE TABLE `dokumenti` (
  `id_dokument` int(11) NOT NULL,
  `naziv` varchar(100) COLLATE utf8_croatian_ci NOT NULL,
  `put` text COLLATE utf8_croatian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_croatian_ci;

--
-- Dumping data for table `dokumenti`
--

INSERT INTO `dokumenti` (`id_dokument`, `naziv`, `put`) VALUES
(3, 'test.txt', 'E:\\strucnaPraksaBackup\\2dana\\strucnaPraksa\\STRUCNA-PRAKSA\\Strucna\\Strucna\\Uploads\\test.txt'),
(4, 'README.md', 'E:\\strucnaPraksaBackup\\2dana\\strucnaPraksa\\STRUCNA-PRAKSA\\Strucna\\Strucna\\Uploads\\README.md'),
(5, 'PAUP_Praksa.pdf', 'E:\\strucnaPraksaBackup\\2dana\\strucnaPraksa\\STRUCNA-PRAKSA\\Strucna\\Strucna\\Uploads\\PAUP_Praksa.pdf');

-- --------------------------------------------------------

--
-- Table structure for table `mentor`
--

CREATE TABLE `mentor` (
  `id_mentor` int(10) UNSIGNED ZEROFILL NOT NULL,
  `ime_prezime` varchar(100) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `email` varchar(30) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `lozinka` varchar(20) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `id_studij` int(11) NOT NULL,
  `password_reset` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `mentor`
--

INSERT INTO `mentor` (`id_mentor`, `ime_prezime`, `email`, `lozinka`, `id_studij`, `password_reset`) VALUES
(0000000001, 'Miljanko', 'milje@student.mev.hr', 'qqq', 0, NULL),
(0000000002, 'Mariiko Dajs', 'marinko@mentor.hr', 'asd', 0, NULL),
(0000000003, 'Miljenko Srdan', 'Srdan@mentor.hr', 'asd', 2, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `ocjena`
--

CREATE TABLE `ocjena` (
  `id_ocjena` int(11) NOT NULL,
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

CREATE TABLE `poduzece` (
  `id_poduzece` int(10) UNSIGNED NOT NULL,
  `naziv` varchar(60) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `adresa` varchar(100) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `grad` varchar(30) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `opis` text CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `kontakt_osoba` varchar(100) CHARACTER SET ucs2 COLLATE ucs2_croatian_ci NOT NULL,
  `tel` varchar(30) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `email` varchar(30) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `URL` text CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `poduzece`
--

INSERT INTO `poduzece` (`id_poduzece`, `naziv`, `adresa`, `grad`, `opis`, `kontakt_osoba`, `tel`, `email`, `URL`) VALUES
(1, 'Mirjana .NET', 'Ivana Žbulja 44', 'Sveta Marija', 'adasdasd', 'asdasd', '+385996929459', 'mustacmarko@yahoo.com', 'asdasdasd'),
(3, 'Cpp Croatia', 'udlj 44', 'casd', 'asdad', 'asdasd', '+385995040090', 'makomrc@gmail.com', 'asdasd'),
(4, 'Testing C# Limits', 'uljud 45', 'Zimski', 'dffffffffffff', 'Marko Is greatrwr', '+385995040090', 'mrc_72@hotmail.com', 'asssssssssss');

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

--
-- Dumping data for table `praksa`
--

INSERT INTO `praksa` (`id_praksa`, `id_studij`, `id_mentor`, `naziv`, `datum_od`, `datum_do`, `zavrsena`) VALUES
(8, 1, 1, 'Strucna praksa racunalstvo', '2018-02-12', '2018-07-30', 0);

-- --------------------------------------------------------

--
-- Table structure for table `praksa_student`
--

CREATE TABLE `praksa_student` (
  `id_praksastudent` int(11) NOT NULL,
  `id_praksa` int(11) NOT NULL,
  `id_student` int(11) NOT NULL,
  `id_poduzece` int(11) NOT NULL,
  `datum_od` date NOT NULL,
  `datum_do` date NOT NULL,
  `odobreno` tinyint(1) NOT NULL,
  `ocjena` int(2) NOT NULL
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
  `id_studnet` int(10) UNSIGNED ZEROFILL NOT NULL,
  `ime_prezime` varchar(100) CHARACTER SET utf16 COLLATE utf16_croatian_ci NOT NULL,
  `adresa` varchar(100) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `mob` varchar(30) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `email` varchar(30) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `lozinka` varchar(20) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `aktivacijski_link` text CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `aktivan` tinyint(1) NOT NULL,
  `id_studij` int(11) NOT NULL,
  `izvanredni` tinyint(1) NOT NULL,
  `password_reset` varchar(255) CHARACTER SET utf16 COLLATE utf16_croatian_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`id_studnet`, `ime_prezime`, `adresa`, `mob`, `email`, `lozinka`, `aktivacijski_link`, `aktivan`, `id_studij`, `izvanredni`, `password_reset`) VALUES
(0000000003, 'Marko Mustacio', 'Ivana Žbulja 44', '99623123123', 'mustacmarko@yahoo.com', 'qqq', '3f76368a-965d-4b36-b199-e5cb07ea8091', 1, 2, 0, NULL),
(0000000004, 'Ivan Mustac', 'Ivana Žbulja 44', '995040090', 'ivan.mustac@outlook.com', 'sssss', ' strucnapraksa.com/Login/Verifikacija/ac4a8476-c86e-4a69-af7a-c2d5c9651ecf', 0, 0, 1, NULL),
(0000000005, 'Marko Mustac', 'Ivana Žbulja 44', '996929459', 'musddsadtacmarko@yahoo.com', 'aaa', ' strucnapraksa.com/Login/Verifikacija/9b5e9220-fb0e-4c86-a710-ec88c2133931', 0, 0, 1, NULL),
(0000000006, 'asdasd asdasd as', '423sdfsdf sdf', '423423423', 'btlf3acc12@gmail.com', 'aaa', 'ffd81a47-5948-4841-80c7-32f190eb33d5', 1, 1, 0, NULL),
(0000000008, 'Nikola Kraljina', 'Trg Bana Kralja 4d', '0991256874', 'nikola.kralj@gmail.com', 'kralj', ' strucnapraksa.com/Login/Verifikacija/572c4883-fdef-47e8-b569-ac44bbc403b7', 1, 3, 0, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `studij`
--

CREATE TABLE `studij` (
  `id_studij` int(10) UNSIGNED NOT NULL,
  `naziv` varchar(100) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `studij`
--

INSERT INTO `studij` (`id_studij`, `naziv`) VALUES
(1, 'Računarstvo'),
(2, 'Menadžment'),
(3, 'Održivi Razvoj');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `dnevnik_prakse`
--
ALTER TABLE `dnevnik_prakse`
  ADD PRIMARY KEY (`id_dnevnik`);

--
-- Indexes for table `dokumenti`
--
ALTER TABLE `dokumenti`
  ADD PRIMARY KEY (`id_dokument`);

--
-- Indexes for table `mentor`
--
ALTER TABLE `mentor`
  ADD PRIMARY KEY (`id_mentor`);

--
-- Indexes for table `ocjena`
--
ALTER TABLE `ocjena`
  ADD PRIMARY KEY (`id_ocjena`);

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
-- Indexes for table `praksa_student`
--
ALTER TABLE `praksa_student`
  ADD PRIMARY KEY (`id_praksastudent`);

--
-- Indexes for table `student`
--
ALTER TABLE `student`
  ADD PRIMARY KEY (`id_studnet`);

--
-- Indexes for table `studij`
--
ALTER TABLE `studij`
  ADD PRIMARY KEY (`id_studij`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `dnevnik_prakse`
--
ALTER TABLE `dnevnik_prakse`
  MODIFY `id_dnevnik` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `dokumenti`
--
ALTER TABLE `dokumenti`
  MODIFY `id_dokument` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `mentor`
--
ALTER TABLE `mentor`
  MODIFY `id_mentor` int(10) UNSIGNED ZEROFILL NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `ocjena`
--
ALTER TABLE `ocjena`
  MODIFY `id_ocjena` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `poduzece`
--
ALTER TABLE `poduzece`
  MODIFY `id_poduzece` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `praksa`
--
ALTER TABLE `praksa`
  MODIFY `id_praksa` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `praksa_student`
--
ALTER TABLE `praksa_student`
  MODIFY `id_praksastudent` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `student`
--
ALTER TABLE `student`
  MODIFY `id_studnet` int(10) UNSIGNED ZEROFILL NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `studij`
--
ALTER TABLE `studij`
  MODIFY `id_studij` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
