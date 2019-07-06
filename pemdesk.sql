-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jul 05, 2019 at 12:39 PM
-- Server version: 10.1.9-MariaDB
-- PHP Version: 7.0.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pemdesk`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `idadmin` int(11) NOT NULL,
  `username` varchar(32) NOT NULL,
  `password` varchar(32) NOT NULL,
  `name` varchar(32) NOT NULL,
  `photo` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`idadmin`, `username`, `password`, `name`, `photo`) VALUES
(1, 'admin', 'admin', 'Administrator', 'C:\\Users\\Near\\Documents\\Visual Studio 2013\\Projects\\ProjectUAS\\ProjectUAS\\bin\\Debug\\img/admin.png');

-- --------------------------------------------------------

--
-- Table structure for table `materi`
--

CREATE TABLE `materi` (
  `idmateri` int(11) NOT NULL,
  `title` varchar(100) NOT NULL,
  `path` text NOT NULL,
  `idadmin` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `materi`
--

INSERT INTO `materi` (`idmateri`, `title`, `path`, `idadmin`) VALUES
(1, 'Komponen Visual Studio', 'C:\\Users\\Near\\Documents\\Visual Studio 2013\\Projects\\ProjectUAS\\ProjectUAS\\bin\\Debug\\materi\\Komponen Visual Basic.pdf', 1),
(2, 'Type Data dan Deklarasi Variabel', 'C:\\Users\\Near\\Documents\\Visual Studio 2013\\Projects\\ProjectUAS\\ProjectUAS\\bin\\Debug\\materi\\Type Data & Deklarasi Variabel.pdf', 1),
(3, 'Operator Logika dan Operator Perhitungan', 'C:\\Users\\Near\\Documents\\Visual Studio 2013\\Projects\\ProjectUAS\\ProjectUAS\\bin\\Debug\\materi\\Operator Logika & Operator Perhitungan.pdf', 1),
(4, 'Membuat Modul Koneksi Database MySQL', 'C:\\Users\\Near\\Documents\\Visual Studio 2013\\Projects\\ProjectUAS\\ProjectUAS\\bin\\Debug\\materi\\Koneksi Database MySQL.pdf', 1);

-- --------------------------------------------------------

--
-- Table structure for table `quiz`
--

CREATE TABLE `quiz` (
  `idquiz` int(11) NOT NULL,
  `soal` text NOT NULL,
  `option1` text NOT NULL,
  `option2` text NOT NULL,
  `option3` text NOT NULL,
  `answer` text NOT NULL,
  `idadmin` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `quiz`
--

INSERT INTO `quiz` (`idquiz`, `soal`, `option1`, `option2`, `option3`, `answer`, `idadmin`) VALUES
(1, 'Sebuah komponen untuk membuat tombol yang dapat berganti antara On dan Off adalah ...', 'ComboBox', 'RadioButton', 'TextBox', 'RadioButton', 1),
(2, 'Suatu event yang digunakan untuk mengganti karakter password menjadi karakter yang diinginkan seperti *, #, $ dll adalah..', 'PasswordChanger', 'PasswordString', 'PasswordChar', 'PasswordChar', 1),
(3, 'Yang bukan termasuk komponen dalam Visual Studio adalah...', 'CrowBar', 'RichTextBox', 'ProgressBar', 'CrowBar', 1),
(4, 'Yang bukan termasuk operator logika dalam Visual Studio', 'And', 'Mod', 'Or', 'Mod', 1),
(5, 'Tipe data yang digunakan untuk meyimpan nilai tanggal, bulan, dan tahun. Kisaran tipe data ini antara 1 januari 100 s/d 31 Desember 9999. ', 'Decimal', 'Date', 'String', 'Date', 1),
(6, 'Cara pendeklarasian variabel yang benar di Visual Studio', '$Nama_Siswa = "String";', 'Var Nama_Siswa = String;', 'Dim Nama_Siswa as String ', 'Dim Nama_Siswa as String ', 1),
(7, 'Dalam mendeklarasikan suatu variable di Visual Studio, perlu beberapa hal yang tidak dibolehkan dalam pendeklarasian, kecuali', 'Ttidak boleh menggunakan spasi', 'Tidak boleh menggunakan karakter khusus ', 'Tidak boleh menggunakan huruf kapital', 'Tidak boleh menggunakan huruf kapital', 1);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `iduser` int(11) NOT NULL,
  `username` varchar(30) NOT NULL,
  `password` varchar(30) NOT NULL,
  `name` varchar(30) NOT NULL,
  `nohp` varchar(13) NOT NULL,
  `photo` text NOT NULL,
  `idadmin` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`iduser`, `username`, `password`, `name`, `nohp`, `photo`, `idadmin`) VALUES
(1, 'Dimas', '1', 'Dimas Galang Ramadhan', '081311484664', 'D:\\« Tugas »\\Kuliah\\Semester III\\Desain Web\\Near\\1-4~2.png', 1),
(2, 'Asri', '1', 'Asri Astuti', '083863766492', 'C:\\Users\\Near\\Documents\\Visual Studio 2013\\Projects\\ProjectUAS\\ProjectUAS\\bin\\Debug\\img/user.png', 1),
(3, 'Yoga', '1', 'Yoga Putra Jaya', '085712089970', 'C:\\Users\\Near\\Documents\\Visual Studio 2013\\Projects\\ProjectUAS\\ProjectUAS\\bin\\Debug\\img/user.png', 1),
(4, 'Sigit', '123', 'Sigit Priyoga', '-', 'C:\\Users\\Near\\Documents\\Visual Studio 2013\\Projects\\ProjectUAS\\ProjectUAS\\bin\\Debug\\img/user.png', 1),
(8, 'coba', '1', 'Test', '-', 'C:\\Users\\Near\\Documents\\Visual Studio 2013\\Projects\\ProjectUAS\\ProjectUAS\\bin\\Debug\\img/user.png', 1);

-- --------------------------------------------------------

--
-- Table structure for table `user_materi`
--

CREATE TABLE `user_materi` (
  `iduser` int(11) NOT NULL,
  `idmateri` int(11) NOT NULL,
  `status` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user_materi`
--

INSERT INTO `user_materi` (`iduser`, `idmateri`, `status`) VALUES
(1, 1, 'Mempelajari'),
(2, 1, 'Mempelajari'),
(1, 1, 'Mempelajari'),
(1, 2, 'Mempelajari'),
(1, 3, 'Mempelajari'),
(2, 2, 'Mempelajari');

-- --------------------------------------------------------

--
-- Table structure for table `user_quiz`
--

CREATE TABLE `user_quiz` (
  `iduser` int(11) NOT NULL,
  `idquiz` int(11) NOT NULL,
  `status` varchar(20) NOT NULL,
  `answer` varchar(100) NOT NULL,
  `optionuser` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user_quiz`
--

INSERT INTO `user_quiz` (`iduser`, `idquiz`, `status`, `answer`, `optionuser`) VALUES
(3, 1, 'Benar', '', ''),
(1, 1, 'Salah', 'RADIOBUTTON', 'TextBox'),
(1, 1, 'Benar', 'RADIOBUTTON', 'RadioButton'),
(1, 2, 'Salah', 'PASSWORDCHAR', 'PasswordChanger'),
(1, 5, 'Benar', 'Date', 'Date'),
(1, 2, 'Benar', 'PasswordChar', 'PasswordChar'),
(1, 1, 'Benar', 'RadioButton', 'RadioButton'),
(1, 5, 'Benar', 'Date', 'Date'),
(1, 3, 'Benar', 'CrowBar', 'CrowBar'),
(1, 1, 'Salah', 'RadioButton', 'TextBox'),
(1, 4, 'Benar', 'Mod', 'Mod'),
(2, 5, 'Benar', 'Date', 'Date'),
(2, 6, 'Salah', 'Dim Nama_Siswa as String ', 'Var Nama_Siswa = String;');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`idadmin`);

--
-- Indexes for table `materi`
--
ALTER TABLE `materi`
  ADD PRIMARY KEY (`idmateri`),
  ADD KEY `idadmin` (`idadmin`);

--
-- Indexes for table `quiz`
--
ALTER TABLE `quiz`
  ADD PRIMARY KEY (`idquiz`),
  ADD KEY `idadmin` (`idadmin`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`iduser`),
  ADD KEY `idadmin` (`idadmin`);

--
-- Indexes for table `user_materi`
--
ALTER TABLE `user_materi`
  ADD KEY `iduser` (`iduser`),
  ADD KEY `idmateri` (`idmateri`);

--
-- Indexes for table `user_quiz`
--
ALTER TABLE `user_quiz`
  ADD KEY `iduser` (`iduser`),
  ADD KEY `idquiz` (`idquiz`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `idadmin` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `materi`
--
ALTER TABLE `materi`
  MODIFY `idmateri` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `quiz`
--
ALTER TABLE `quiz`
  MODIFY `idquiz` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `iduser` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `materi`
--
ALTER TABLE `materi`
  ADD CONSTRAINT `materi_ibk` FOREIGN KEY (`idadmin`) REFERENCES `admin` (`idadmin`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `quiz`
--
ALTER TABLE `quiz`
  ADD CONSTRAINT `quiz_ibk` FOREIGN KEY (`idadmin`) REFERENCES `admin` (`idadmin`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `user_ibk` FOREIGN KEY (`idadmin`) REFERENCES `admin` (`idadmin`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `user_materi`
--
ALTER TABLE `user_materi`
  ADD CONSTRAINT `user_materi_ibk` FOREIGN KEY (`iduser`) REFERENCES `user` (`iduser`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `user_materi_ibk2` FOREIGN KEY (`idmateri`) REFERENCES `materi` (`idmateri`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `user_quiz`
--
ALTER TABLE `user_quiz`
  ADD CONSTRAINT `user_quiz_ibfk` FOREIGN KEY (`iduser`) REFERENCES `user` (`iduser`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `user_quiz_ibfk2` FOREIGN KEY (`idquiz`) REFERENCES `quiz` (`idquiz`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
