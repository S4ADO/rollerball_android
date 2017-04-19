-- phpMyAdmin SQL Dump
-- version 4.0.10.14
-- http://www.phpmyadmin.net
--
-- Host: localhost:3306
-- Generation Time: Mar 17, 2017 at 06:12 AM
-- Server version: 10.0.27-MariaDB-cll-lve
-- PHP Version: 5.4.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `rollerb3_bb`
--

-- --------------------------------------------------------

--
-- Table structure for table `accounts`
--

CREATE TABLE IF NOT EXISTS `accounts` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(30) NOT NULL,
  `email` varchar(50) NOT NULL,
  `password` char(128) NOT NULL,
  `salt` char(128) NOT NULL,
  `gameswon` int(11) NOT NULL DEFAULT '0',
  `gameslost` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=14 ;

--
-- Dumping data for table `accounts`
--

INSERT INTO `accounts` (`id`, `username`, `email`, `password`, `salt`, `gameswon`, `gameslost`) VALUES
(2, 'TeST', 'test@test.com', '2848f9788560b7430bc87e899e9b3f6cb87067962ec22effa745e3dcd46de8f7a7794ac141997710c47b267d66409c0a85640c217a6aa0137635ec2ba3802532', '1653c47996b8f7aa7dc8914b31da9635133ddc787d094e4620214ad37c4d8bb216cea6d72cca4d812a70bc061e799b3c94025a56b0c02670f6dfc8c9a16d4ad8', 0, 0),
(3, 'hello', 'abx@live.com', 'f13c297d4097b17ac875532391443d3c7a693bb81d1cc433e659aec93936fc5be5be60fbc602ecb3b528e63c36781135a6bf1a9c87be7cddb6312d3a2a47c833', 'f81eb2c1ad26a5b193cb47598365654f5f3608c8f67e5ca809535006b4fbb09a714dcf7c3319e0b2264bbd1bfb9e90df5c991dab2ef6b54550a590443686bf74', 0, 0),
(4, 'test123', 'test@test123.com', '4212406434ada2d544b5aca5de24aae2d125f30efd4a347fb3e4e0825cf3d57daa91bb0585d33290843f64586ec78256e7744cb6c27d960da78679e739e3106c', '24e872484e337e148c385ae04c094c2a023186efd0cb79d84dee51efa07f2c9dd4ece16356ad266bf3353f1f542ac34b2d8c44a52110591861271f0d68376040', 0, 0),
(5, 'ABCDEF', 'abc@live.com', 'e66251cb87ebeac84c8436d4e97673e6934beb73b56eacd61826ad20bd7f36c44867b93f8060e3933d0c9e1d6c8e06b840a4b88d3bbe30ada57aedbc179f9bb6', 'be62b0c82bc4ec102fa0107d91416cefac9d7fd724028d2e219831559ce865acb8e64e74be5a9058ced9ec428c31860165f336f88a34febaad06fa3e7ba62713', 0, 0),
(6, 'rollervall', 'u1555162@hud.ac.uk', '280ac4634fd5bd7ec65bfd429772304c9d63a8439592d247a9e112b4dc594212880d155842e2b2867c8f93b4fe9a38b8e52934b0ebfc1c84abf25b8348015e7b', 'dd25dc1965d5ed16956e845d7d09e6705d2bf2bc330bd6655d6f5d24e41fe1a6f5505921a484823aef7c4823333154a4634704f0bcc8608ee5bed000175f0d1a', 0, 0),
(7, 'Saad', 'saadmusejee@live.com', 'a48b6aa295cc2be850e3cc49ab72c31ffbe6486e6d746e1530f3224141281e5cc0ff8b4404b3b1ec5edde33e40965f2539c01a2ea9259611939c623e909bdf9a', '38bb4bbc71640c39f50b59967f85833b7e677b16d160a4c8649d14072292475da1171413193b2dee4612bae1fec782746ee39a2f01d8e7ea9ef474514e316683', 0, 0),
(11, 'sfsdfds', 'asaadmdsusejee@live.com', 'f94697b955b24d3133a4ee338b04fa0132e9c644ffab1f8bc6234509a4d7e35a2b818ab4c3fb89821f8f8e71f28965f41512aa50379b739dbca09c71ebe07b39', 'cfdf844fada535544c63aec5e1a37eb288c4cae75b369116e2e3714b26b862ec1ccb53663a58b36e92aeed9a4fa3b91f76bc315a3463278be3ee5a9916e8dc25', 0, 0),
(12, 'TestFinal', 'testfinal@test.com', '0b13fe31f18baff15bd38b35ea7e8c95d56d39e77338b483c092b415e4de6132550912c087251314a23b730e4c7440903107ef93c8ff84139163cbe65ef926df', '41377f774d5b41b27338945eb5efc0bf5c243a6b55b78b9c3e60a5742276b162193e08677bca96d58f1e3737b6d2e476e71bd0192ecd5cf4809f3bd66785bedd', 0, 0),
(13, 'Aneta', 'anetathelazyfuck@hotmail.com', '192f3563e5fac7c320b606f916c75e723365c85c567ea47bc7977a02930b0a7bc9ba0af11abc3b066374fa3db273da2c16de4bf8631744c0f1521dabc4e89457', '393bfddde0a937a2af946ff355518e886f8f497da8723d69b6d3853e142ca61efb710a0ee8c73f7a938c8043fd0e6c8ab616577966d1c808e4abb2666c371df1', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `login_attempts`
--

CREATE TABLE IF NOT EXISTS `login_attempts` (
  `user_id` int(11) NOT NULL,
  `time` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `login_attempts`
--

INSERT INTO `login_attempts` (`user_id`, `time`) VALUES
(1, '2017-03-15 07:45:59'),
(1, '2017-03-15 07:46:09'),
(1, '2017-03-15 07:46:16'),
(1, '2017-03-15 07:46:24');

-- --------------------------------------------------------

--
-- Table structure for table `uses`
--

CREATE TABLE IF NOT EXISTS `uses` (
  `userid` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(100) NOT NULL,
  `money` int(11) NOT NULL DEFAULT '5000',
  `highscore` int(11) NOT NULL DEFAULT '0',
  `PointsIncrease` int(11) NOT NULL DEFAULT '0',
  `Invincibility` int(11) NOT NULL DEFAULT '0',
  `DoubleJump` int(11) NOT NULL DEFAULT '0',
  `Barracades` int(11) NOT NULL DEFAULT '0',
  `Magnet` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`userid`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=14 ;

--
-- Dumping data for table `uses`
--

INSERT INTO `uses` (`userid`, `email`, `money`, `highscore`, `PointsIncrease`, `Invincibility`, `DoubleJump`, `Barracades`, `Magnet`) VALUES
(2, 'test@test.com', 5000, 500, 0, 0, 1, 0, 0),
(3, 'abx@live.com', 5000, 200, 0, 0, 1, 0, 0),
(4, 'test@test123.com', 5000, 70, 0, 0, 1, 0, 0),
(5, 'abc@live.com', 5000, 36, 0, 0, 1, 0, 0),
(6, 'u1555162@hud.ac.uk', 5000, 29, 0, 0, 1, 0, 0),
(7, 'saadmusejee@live.com', 8006, 35, 1, 8, 3, 1, 1),
(8, 'sfsdifhsdfnud@idhfsidfhsd.com', 5000, 2, 0, 0, 1, 0, 0),
(9, 'adfnsdkfhsdb@dnidsuds.com', 5000, 0, 0, 0, 0, 0, 0),
(10, 'saadmdsusejee@live.com', 5000, 0, 0, 0, 0, 0, 0),
(12, 'testfinal@test.com', 5000, 0, 0, 0, 0, 0, 0),
(13, 'anetathelazyfuck@hotmail.com', 490959, 146, 15, 16, 16, 18, 17);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
