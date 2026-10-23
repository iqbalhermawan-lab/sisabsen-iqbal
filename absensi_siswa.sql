-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 16, 2026 at 10:56 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `absensi_siswa`
--

-- --------------------------------------------------------

--
-- Table structure for table `absensi`
--

CREATE TABLE `absensi` (
  `id_absensi` int(11) NOT NULL,
  `tanggal` date NOT NULL,
  `id_kelas` int(11) NOT NULL,
  `jam_pelajaran` varchar(50) NOT NULL,
  `id_siswa` int(11) NOT NULL,
  `keterangan` enum('Hadir','Izin','Sakit','Alpa') NOT NULL DEFAULT 'Hadir',
  `id_guru` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `absensi`
--

INSERT INTO `absensi` (`id_absensi`, `tanggal`, `id_kelas`, `jam_pelajaran`, `id_siswa`, `keterangan`, `id_guru`) VALUES
(21, '2026-09-25', 2, 'Jam Ke-01', 6, 'Sakit', 13),
(22, '2026-09-25', 2, 'Jam Ke-01', 7, 'Hadir', 13),
(23, '2026-09-25', 2, 'Jam Ke-01', 8, 'Hadir', 13),
(24, '2026-09-25', 2, 'Jam Ke-01', 9, 'Izin', 13),
(25, '2026-09-25', 2, 'Jam Ke-01', 10, 'Hadir', 13),
(26, '2026-10-16', 13, 'Jam ke-02', 57, 'Hadir', 13),
(27, '2026-10-16', 13, 'Jam ke-02', 58, 'Sakit', 13),
(28, '2026-10-16', 13, 'Jam ke-02', 59, 'Hadir', 13),
(29, '2026-10-16', 13, 'Jam ke-02', 60, 'Sakit', 13),
(30, '2026-10-16', 13, 'Jam ke-02', 61, 'Hadir', 13),
(31, '2026-10-16', 13, 'Jam ke-03', 57, 'Hadir', 13),
(32, '2026-10-16', 13, 'Jam ke-03', 58, 'Sakit', 13),
(33, '2026-10-16', 13, 'Jam ke-03', 59, 'Hadir', 13),
(34, '2026-10-16', 13, 'Jam ke-03', 60, 'Sakit', 13),
(35, '2026-10-16', 13, 'Jam ke-03', 61, 'Hadir', 13);

-- --------------------------------------------------------

--
-- Table structure for table `absensi_kegiatan`
--

CREATE TABLE `absensi_kegiatan` (
  `id_absen_kegiatan` int(11) NOT NULL,
  `tanggal` date NOT NULL,
  `nama_kegiatan` varchar(100) NOT NULL,
  `id_kelas` int(11) NOT NULL,
  `id_siswa` int(11) NOT NULL,
  `keterangan` enum('Hadir','Izin','Sakit','Alpa') NOT NULL DEFAULT 'Hadir',
  `id_guru` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `absensi_kegiatan`
--

INSERT INTO `absensi_kegiatan` (`id_absen_kegiatan`, `tanggal`, `nama_kegiatan`, `id_kelas`, `id_siswa`, `keterangan`, `id_guru`) VALUES
(1, '2026-09-10', 'Lomba 17an', 2, 6, 'Hadir', 2),
(2, '2026-09-10', 'Lomba 17an', 2, 7, 'Izin', 2),
(3, '2026-09-10', 'Lomba 17an', 2, 8, 'Hadir', 2),
(4, '2026-09-10', 'Lomba 17an', 2, 9, 'Hadir', 2),
(5, '2026-09-10', 'Lomba 17an', 2, 10, 'Sakit', 2),
(6, '2026-10-16', 'hari pramuka', 5, 11, 'Izin', 5),
(7, '2026-10-16', 'hari pramuka', 5, 12, 'Hadir', 5),
(8, '2026-10-16', 'hari pramuka', 5, 13, 'Izin', 5),
(9, '2026-10-16', 'hari pramuka', 5, 14, 'Hadir', 5),
(10, '2026-10-16', 'hari pramuka', 5, 15, 'Hadir', 5);

-- --------------------------------------------------------

--
-- Table structure for table `guru`
--

CREATE TABLE `guru` (
  `id_guru` int(11) NOT NULL,
  `nip` varchar(20) NOT NULL,
  `nama_guru` varchar(255) NOT NULL,
  `id_user` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `guru`
--

INSERT INTO `guru` (`id_guru`, `nip`, `nama_guru`, `id_user`) VALUES
(1, '202601012005011001', 'Ahmad Fauzi', 2),
(2, '202601022008012002', 'Siti Aminah', 3),
(3, '202603032010011003', 'Budi Santoso', 5),
(4, '202604042012022004', 'Dewi Lestari', 6),
(5, '202605052014031005', 'Eko Prasetyo', 7),
(6, '202606062015042006', 'Fitri Handayani', 8),
(7, '202607072016051007', 'Gunawan', 9),
(8, '202608082018062008', 'Sri Rahmawati', 10),
(9, '202609092019071009', 'Irfan Hakim', 11),
(10, '202610102020081010', 'Joko', 12),
(11, '202611112021092011', 'Kartika Sari', 13),
(12, '202612122022101012', 'Lukman', 14),
(13, '202613102912830906', 'Tri Aditya', 15);

-- --------------------------------------------------------

--
-- Table structure for table `kelas`
--

CREATE TABLE `kelas` (
  `id_kelas` int(11) NOT NULL,
  `tingkat` varchar(5) NOT NULL,
  `nama_kelas` varchar(30) NOT NULL,
  `id_guru` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `kelas`
--

INSERT INTO `kelas` (`id_kelas`, `tingkat`, `nama_kelas`, `id_guru`) VALUES
(1, 'X', 'X IPA 1', 1),
(2, 'X', 'X IPA 2', 2),
(3, 'X', 'X IPS 1', 3),
(4, 'X', 'X IPS 2', 4),
(5, 'XI', 'XI IPA 1', 5),
(6, 'XI', 'XI IPA 2', 6),
(7, 'XI', 'XI IPS 1', 7),
(9, 'XI', 'XI IPS 2', 8),
(10, 'XII', 'XII IPA 1', 9),
(11, 'XII', 'XII IPA 2', 10),
(12, 'XII', 'XII IPS 1', 11),
(13, 'XII', 'XII IPS 2', 12);

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

CREATE TABLE `roles` (
  `id_role` int(11) NOT NULL,
  `role` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`id_role`, `role`) VALUES
(1, 'admin'),
(2, 'wali kelas'),
(3, 'guru');

-- --------------------------------------------------------

--
-- Table structure for table `siswa`
--

CREATE TABLE `siswa` (
  `id_siswa` int(11) NOT NULL,
  `nis` varchar(10) NOT NULL,
  `nama` varchar(255) NOT NULL,
  `jenis_kelamin` varchar(10) NOT NULL,
  `id_kelas` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `siswa`
--

INSERT INTO `siswa` (`id_siswa`, `nis`, `nama`, `jenis_kelamin`, `id_kelas`) VALUES
(1, '10101', 'Aditya Pratama', 'L', 1),
(2, '10102', 'Bella Safitri', 'P', 1),
(3, '10103', 'Candra Wijaya', 'L', 1),
(4, '10104', 'Dinda Kirana', 'P', 1),
(5, '10105', 'Fajar Nugroho', 'L', 1),
(6, '10201', 'Ghina Maulida', 'P', 2),
(7, '10202', 'Haikal Alfarizi', 'L', 2),
(8, '10203', 'Indah Permata', 'P', 2),
(9, '10204', 'Jefri Al Buchori', 'L', 2),
(10, '10205', 'Kirana Larasati', 'P', 2),
(11, '11101', 'M. Rizki Ramadhan', 'L', 5),
(12, '11102', 'Nabila Zahra', 'P', 5),
(13, '11103', 'Oscar Pratama', 'L', 5),
(14, '11104', 'Putri Aulia', 'P', 5),
(15, '11105', 'Qoriah Nurul', 'P', 5),
(16, '11201', 'Rafi Ahmad', 'L', 6),
(18, '11202', 'Salsabila Putri', 'P', 6),
(19, '11203', 'Tegar Saputra', 'L', 6),
(20, '11204', 'Utami Dewi', 'P', 6),
(21, '11205', 'Vian Mahendra', 'L', 6),
(22, '12101', 'Wahyu Hidayat', 'L', 10),
(23, '12102', 'Xenia Aurelia', 'P', 10),
(24, '12103', 'Yoga Pratama', 'L', 10),
(25, '12104', 'Zaskia Mecca', 'P', 10),
(26, '12105', 'Achmad Zaki', 'L', 10),
(27, '12201', 'Bayu Setiawan', 'L', 11),
(28, '12202', 'Citra Melati', 'P', 11),
(29, '12203', 'Dimas Anggara', 'L', 11),
(30, '12204', 'Erlina Salsabila', 'P', 11),
(31, '12205', 'Farhan Maulana', 'L', 11),
(32, '13101', 'Gilang Ramadhan', 'L', 3),
(33, '13102', 'Hesti Wulandari', 'P', 3),
(34, '13103', 'Iqbal Maulana', 'L', 3),
(35, '13104', 'Jihan Aulia', 'P', 3),
(36, '13105', 'Kevin Sanjaya', 'L', 3),
(37, '13201', 'Lesti Kejora', 'P', 4),
(38, '13202', 'Muhammad Alwi', 'L', 4),
(39, '13203', 'Nadia Maharani', 'P', 4),
(40, '13204', 'Oky Setiawan', 'L', 4),
(41, '13205', 'Ratu Bilqis', 'P', 4),
(42, '14101', 'Rendy Septian', 'L', 7),
(43, '14102', 'Siska Amanda', 'P', 7),
(44, '14103', 'Tristan Alif', 'L', 7),
(45, '14104', 'Viona Sapitri', 'P', 7),
(46, '14105', 'Wildan Al Farisi', 'L', 7),
(47, '14201', 'Yasmin Nurul', 'P', 9),
(48, '14202', 'Zidan Ramadhan', 'L', 9),
(49, '14203', 'Annisa Rahma', 'P', 9),
(50, '14204', 'Bintang Pamungkas', 'L', 9),
(51, '14205', 'Cika Lestari', 'P', 9),
(52, '15101', 'Danishwara Putra', 'L', 12),
(53, '15102', 'Elvira Natasya', 'P', 12),
(54, '15103', 'Fikri Haikal', 'L', 12),
(55, '15104', 'Gitaloka Arum', 'P', 12),
(56, '15105', 'Hafizh Al Ghifari', 'L', 12),
(57, '15201', 'Intan Nuraini', 'P', 13),
(58, '15202', 'Jalu Pamungkas', 'L', 13),
(59, '15203', 'Kayla Zahra', 'P', 13),
(60, '15204', 'Lutfi Hakim', 'L', 13),
(61, '15205', 'Maya Sofa', 'P', 13);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id_user` int(11) NOT NULL,
  `username` varchar(20) NOT NULL,
  `password` varchar(255) NOT NULL,
  `id_role` int(11) NOT NULL,
  `nama` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id_user`, `username`, `password`, `id_role`, `nama`) VALUES
(1, 'admin1', '$2a$11$F4ktwyPGUMQ4iHPNu/9S.u9zZO2s2jEHstmNlIQbCBWtRgbVe7jDa', 1, 'Iqbal'),
(2, 'user1', '$2a$11$aKG/xHuI/tSMdT5KdCWofeWwCqfGC8pGfheUWsi4zWLBsIagn1Ute', 2, 'ibam1'),
(3, 'user2', '$2a$11$l/FAhySao20APD15DyJwjeizjuEc1XuGCD6MpsqzdXfjAvzR7kQ/y', 2, 'ibam2'),
(5, 'user3', '$2a$11$Td8CXDflxP5wAbODbnmDX.azbMiTiPA7/gKE9jNeKV/8mYai41JgG', 2, 'ibam3'),
(6, 'user4', '$2a$11$0JLkOgdxRx/hGKA7/uJZoe5RWkjCdkDDdGflOzby7of1gNfOb8o8q', 2, 'ibam4'),
(7, 'user5', '$2a$11$QE81MlsSsAysvsXnAoAqseCRz8cW8d9pOWBtXB3c/cynQeSEkaiIu', 2, 'ibam5'),
(8, 'user6', '$2a$11$HipGnCk0EMftfx4iigg/wuwnabhKqL7zwyLDWFhxCWSJ8keQ8LQ3u', 2, 'ibam6'),
(9, 'user7', '$2a$11$I7i0LAd0sxtohsTY2L6gC.ZAMAEo5sxlDo7vpB0nw59swMow4DnTq', 2, 'ibam7'),
(10, 'user8', '$2a$11$jAgff0b8S22VNsINWLL..u0bKW1Xic7Emq57rKHGRDcCd/Xcquho6', 2, 'ibam8'),
(11, 'user9', '$2a$11$6U//PUAdfyAIsbPboeKQwey0YpneIChSxav9dKmbtHwr.JWAe0MTm', 2, 'ibam9'),
(12, 'user10', '$2a$11$Mn8.moZDwRzEtIFxqJR89OG899VEXLFfMCG4EN4HQUdSynjBiv8S6', 2, 'ibam10'),
(13, 'user11', '$2a$11$29Kowz.rLBDgl/mKykG5LefId66TS307ctPc5f0vT9PVppv9BiDua', 2, 'ibam11'),
(14, 'user12', '$2a$11$l6rR5yuxIGhLF57uemIZ9.iruaMPs7NuORVh40A5gz11gUD/fUEWm', 2, 'ibam12'),
(15, 'guru1', '$2a$11$vPam.YSB4qplLTOfA.ZHNu8NFrJUZCD/mK8T/Iy.DNTA5OufZcwNW', 3, 'ibam13');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `absensi`
--
ALTER TABLE `absensi`
  ADD PRIMARY KEY (`id_absensi`),
  ADD KEY `id_kelas` (`id_kelas`),
  ADD KEY `id_siswa` (`id_siswa`),
  ADD KEY `id_guru` (`id_guru`);

--
-- Indexes for table `absensi_kegiatan`
--
ALTER TABLE `absensi_kegiatan`
  ADD PRIMARY KEY (`id_absen_kegiatan`),
  ADD KEY `id_kelas` (`id_kelas`),
  ADD KEY `id_siswa` (`id_siswa`),
  ADD KEY `id_guru` (`id_guru`);

--
-- Indexes for table `guru`
--
ALTER TABLE `guru`
  ADD PRIMARY KEY (`id_guru`),
  ADD KEY `id_user` (`id_user`);

--
-- Indexes for table `kelas`
--
ALTER TABLE `kelas`
  ADD PRIMARY KEY (`id_kelas`),
  ADD KEY `fk_kelas_guru` (`id_guru`);

--
-- Indexes for table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`id_role`);

--
-- Indexes for table `siswa`
--
ALTER TABLE `siswa`
  ADD PRIMARY KEY (`id_siswa`),
  ADD UNIQUE KEY `nis` (`nis`),
  ADD KEY `fk_siswa_kelas` (`id_kelas`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id_user`),
  ADD KEY `id_role` (`id_role`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `absensi`
--
ALTER TABLE `absensi`
  MODIFY `id_absensi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT for table `absensi_kegiatan`
--
ALTER TABLE `absensi_kegiatan`
  MODIFY `id_absen_kegiatan` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `guru`
--
ALTER TABLE `guru`
  MODIFY `id_guru` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `kelas`
--
ALTER TABLE `kelas`
  MODIFY `id_kelas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `roles`
--
ALTER TABLE `roles`
  MODIFY `id_role` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `siswa`
--
ALTER TABLE `siswa`
  MODIFY `id_siswa` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=62;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id_user` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `absensi`
--
ALTER TABLE `absensi`
  ADD CONSTRAINT `fk_absensi_guru` FOREIGN KEY (`id_guru`) REFERENCES `guru` (`id_guru`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_absensi_kelas` FOREIGN KEY (`id_kelas`) REFERENCES `kelas` (`id_kelas`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_absensi_siswa` FOREIGN KEY (`id_siswa`) REFERENCES `siswa` (`id_siswa`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `absensi_kegiatan`
--
ALTER TABLE `absensi_kegiatan`
  ADD CONSTRAINT `absensi_kegiatan_ibfk_1` FOREIGN KEY (`id_kelas`) REFERENCES `kelas` (`id_kelas`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `absensi_kegiatan_ibfk_2` FOREIGN KEY (`id_siswa`) REFERENCES `siswa` (`id_siswa`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `absensi_kegiatan_ibfk_3` FOREIGN KEY (`id_guru`) REFERENCES `guru` (`id_guru`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `guru`
--
ALTER TABLE `guru`
  ADD CONSTRAINT `fk_guru_user` FOREIGN KEY (`id_user`) REFERENCES `users` (`id_user`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `kelas`
--
ALTER TABLE `kelas`
  ADD CONSTRAINT `fk_kelas_guru` FOREIGN KEY (`id_guru`) REFERENCES `guru` (`id_guru`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `siswa`
--
ALTER TABLE `siswa`
  ADD CONSTRAINT `fk_siswa_kelas` FOREIGN KEY (`id_kelas`) REFERENCES `kelas` (`id_kelas`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`id_role`) REFERENCES `roles` (`id_role`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
