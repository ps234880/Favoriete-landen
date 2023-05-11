-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Gegenereerd op: 14 nov 2022 om 08:54
-- Serverversie: 5.7.36
-- PHP-versie: 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `favourite_countries`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `countries`
--

DROP TABLE IF EXISTS `countries`;
CREATE TABLE IF NOT EXISTS `countries` (
  `CountryID` int(11) NOT NULL AUTO_INCREMENT,
  `CountryName` varchar(30) NOT NULL,
  PRIMARY KEY (`CountryID`)
) ENGINE=InnoDB AUTO_INCREMENT=419 DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `countries`
--

INSERT INTO `countries` (`CountryID`, `CountryName`) VALUES
(204, 'Albania'),
(205, 'Algeria'),
(206, 'Andorra'),
(207, 'Angola'),
(208, 'Anguilla'),
(209, 'Antigua & Barbuda'),
(210, 'Argentina'),
(211, 'Armenia'),
(212, 'Australia'),
(213, 'Austria'),
(214, 'Azerbaijan'),
(215, 'Bahamas'),
(216, 'Bahrain'),
(217, 'Bangladesh'),
(218, 'Barbados'),
(219, 'Belarus'),
(220, 'Belgium'),
(221, 'Belize'),
(222, 'Benin'),
(223, 'Bermuda'),
(224, 'Bhutan'),
(225, 'Bolivia'),
(226, 'Bosnia & Herzegovina'),
(227, 'Botswana'),
(228, 'Brazil'),
(229, 'Brunei Darussalam'),
(230, 'Bulgaria'),
(231, 'Burkina Faso'),
(232, 'Myanmar/Burma'),
(233, 'Burundi'),
(234, 'Cambodia'),
(235, 'Cameroon'),
(236, 'Canada'),
(237, 'Cape Verde'),
(238, 'Cayman Islands'),
(239, 'Central African Republic'),
(240, 'Chad'),
(241, 'Chile'),
(242, 'China'),
(243, 'Colombia'),
(244, 'Comoros'),
(245, 'Congo'),
(246, 'Costa Rica'),
(247, 'Croatia'),
(248, 'Cuba'),
(249, 'Cyprus'),
(250, 'Czech Republic'),
(251, 'Denmark'),
(252, 'Djibouti'),
(253, 'Dominican Republic'),
(254, 'Dominica'),
(255, 'Ecuador'),
(256, 'Egypt'),
(257, 'El Salvador'),
(258, 'Equatorial Guinea'),
(259, 'Eritrea'),
(260, 'Estonia'),
(261, 'Ethiopia'),
(262, 'Fiji'),
(263, 'Finland'),
(264, 'France'),
(265, 'French Guiana'),
(266, 'Gabon'),
(267, 'Gambia'),
(268, 'Georgia'),
(269, 'Germany'),
(270, 'Ghana'),
(271, 'Great Britain'),
(272, 'Greece'),
(273, 'Grenada'),
(274, 'Guadeloupe'),
(275, 'Guatemala'),
(276, 'Guinea'),
(277, 'Guinea-Bissau'),
(278, 'Guyana'),
(279, 'Haiti'),
(280, 'Honduras'),
(281, 'Hungary'),
(282, 'Iceland'),
(283, 'India'),
(284, 'Indonesia'),
(285, 'Iran'),
(286, 'Iraq'),
(287, 'Italy'),
(288, 'Ivory Coast (Cote d\'Ivoire)'),
(289, 'Jamaica'),
(290, 'Japan'),
(291, 'Jordan'),
(292, 'Kazakhstan'),
(293, 'Kenya'),
(294, 'Kosovo'),
(295, 'Kuwait'),
(296, 'Kyrgyz Republic (Kyrgyzstan)'),
(297, 'Laos'),
(298, 'Latvia'),
(299, 'Lebanon'),
(300, 'Lesotho'),
(301, 'Liberia'),
(302, 'Libya'),
(303, 'Liechtenstein'),
(304, 'Italy'),
(305, 'Ivory Coast (Cote d\'Ivoire)'),
(306, 'Jamaica'),
(307, 'Japan'),
(308, 'Jordan'),
(309, 'Kazakhstan'),
(310, 'Kenya'),
(311, 'Kosovo'),
(312, 'Kuwait'),
(313, 'Kyrgyz Republic (Kyrgyzstan)'),
(314, 'Laos'),
(315, 'Latvia'),
(316, 'Lebanon'),
(317, 'Lesotho'),
(318, 'Liberia'),
(319, 'Libya'),
(320, 'Liechtenstein'),
(321, 'Lithuania'),
(322, 'Luxembourg'),
(323, 'Republic of Macedonia'),
(324, 'Madagascar'),
(325, 'Malawi'),
(326, 'Malaysia'),
(327, 'Maldives'),
(328, 'Mali'),
(329, 'Malta'),
(330, 'Martinique'),
(331, 'Mauritania'),
(332, 'Mauritius'),
(333, 'Mayotte'),
(334, 'Mexico'),
(335, 'Moldova, Republic of'),
(336, 'Monaco'),
(337, 'Mongolia'),
(338, 'Montenegro'),
(339, 'Montserrat'),
(340, 'Morocco'),
(341, 'Mozambique'),
(342, 'Namibia'),
(343, 'Nepal'),
(344, 'Netherlands'),
(345, 'New Zealand'),
(346, 'Nicaragua'),
(347, 'Niger'),
(348, 'Nigeria'),
(349, 'Norway'),
(350, 'Oman'),
(351, 'Pacific Islands'),
(352, 'Pakistan'),
(353, 'Panama'),
(354, 'Norway'),
(355, 'Oman'),
(356, 'Pacific Islands'),
(357, 'Pakistan'),
(358, 'Panama'),
(359, 'Papua New Guinea'),
(360, 'Paraguay'),
(361, 'Peru'),
(362, 'Philippines'),
(363, 'Poland'),
(364, 'Portugal'),
(365, 'Puerto Rico'),
(366, 'Qatar'),
(367, 'Reunion'),
(368, 'Romania'),
(369, 'Russian Federation'),
(370, 'Rwanda'),
(371, 'Saint Kitts and Nevis'),
(372, 'Saint Lucia'),
(373, 'Saint Vincent\'s & Grenadines'),
(374, 'Samoa'),
(375, 'Sao Tome and Principe'),
(376, 'Saudi Arabia'),
(377, 'Senegal'),
(378, 'Serbia'),
(379, 'Seychelles'),
(380, 'Sierra Leone'),
(381, 'Singapore'),
(382, 'Slovak Republic (Slovakia)'),
(383, 'Slovenia'),
(384, 'Solomon Islands'),
(385, 'Somalia'),
(386, 'South Africa'),
(387, 'South Sudan'),
(388, 'Spain'),
(389, 'Sri Lanka'),
(390, 'Sudan'),
(391, 'SuriCountryName'),
(392, 'Swaziland'),
(393, 'Sweden'),
(394, 'Switzerland'),
(395, 'Syria'),
(396, 'Tajikistan'),
(397, 'Tanzania'),
(398, 'Thailand'),
(399, 'Timor Leste'),
(400, 'Togo'),
(401, 'Trinidad & Tobago'),
(402, 'Tunisia'),
(403, 'Turkey'),
(404, 'Turkmenistan'),
(405, 'Turks & Caicos Islands'),
(406, 'Uganda'),
(407, 'Ukraine'),
(408, 'United Arab Emirates'),
(409, 'United States of America (USA)'),
(410, 'Uruguay'),
(411, 'Uzbekistan'),
(412, 'Venezuela'),
(413, 'Vietnam'),
(414, 'Virgin Islands (UK)'),
(415, 'Virgin Islands (US)'),
(416, 'Yemen'),
(417, 'Zambia'),
(418, 'Zimbabwe');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `customers`
--

DROP TABLE IF EXISTS `customers`;
CREATE TABLE IF NOT EXISTS `customers` (
  `CustomerID` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerName` varchar(30) NOT NULL,
  PRIMARY KEY (`CustomerID`)
) ENGINE=InnoDB AUTO_INCREMENT=59 DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `customers`
--

INSERT INTO `customers` (`CustomerID`, `CustomerName`) VALUES
(51, 'Naam Een'),
(52, 'Naam Twee'),
(53, 'Naam Drie');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `favourite_countries`
--

DROP TABLE IF EXISTS `favourite_countries`;
CREATE TABLE IF NOT EXISTS `favourite_countries` (
  `FavouriteCountryID` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerID` int(11) NOT NULL,
  `CountryID` int(11) NOT NULL,
  PRIMARY KEY (`FavouriteCountryID`),
  KEY `CustomerID` (`CustomerID`,`CountryID`),
  KEY `favourite_countries_ibfk_1` (`CountryID`)
) ENGINE=InnoDB AUTO_INCREMENT=95 DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `favourite_countries`
--

INSERT INTO `favourite_countries` (`FavouriteCountryID`, `CustomerID`, `CountryID`) VALUES
(89, 51, 204),
(90, 51, 205),
(91, 51, 206),
(94, 52, 205),
(93, 52, 206),
(92, 52, 207),
(87, 53, 204),
(88, 53, 206);

--
-- Beperkingen voor geëxporteerde tabellen
--

--
-- Beperkingen voor tabel `favourite_countries`
--
ALTER TABLE `favourite_countries`
  ADD CONSTRAINT `favourite_countries_ibfk_1` FOREIGN KEY (`CountryID`) REFERENCES `countries` (`CountryID`) ON DELETE CASCADE,
  ADD CONSTRAINT `favourite_countries_ibfk_2` FOREIGN KEY (`CustomerID`) REFERENCES `customers` (`CustomerID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
