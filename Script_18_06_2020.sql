CREATE DATABASE  IF NOT EXISTS `studiepunten` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `studiepunten`;
-- MySQL dump 10.13  Distrib 8.0.12, for Win64 (x86_64)
--
-- Host: localhost    Database: studiepunten
-- ------------------------------------------------------
-- Server version	8.0.12

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `student` (
  `IDGebruiker` int(11) NOT NULL AUTO_INCREMENT,
  `Naam` longtext NOT NULL,
  `Wachtwoord` tinytext NOT NULL,
  `Punten` int(11) NOT NULL,
  `FKStudiejaar` int(11) DEFAULT NULL,
  PRIMARY KEY (`IDGebruiker`),
  KEY `FKNaarStudie_idx` (`FKStudiejaar`),
  CONSTRAINT `FKNaarStudiejaar` FOREIGN KEY (`FKStudiejaar`) REFERENCES `studiejaar` (`idstudiejaar`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student`
--

LOCK TABLES `student` WRITE;
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` VALUES (1,'Arne','1456',120,1),(2,'Jeroen','1234',60,NULL),(3,'Mats','7423',87,NULL),(4,'Pieter-Jan','5412',66,NULL),(5,'Zjef','9453',60,NULL),(6,'Brik','7536',52,NULL),(7,'Laura','1675',22,NULL),(8,'Jolien','9243',87,NULL),(9,'Ferre','1111',120,NULL),(10,'Gilles','2647',98,NULL),(11,'Siebe','5544',103,NULL),(12,'Arne','123',0,NULL),(13,'Arne Sips','123',0,NULL),(14,'Sops','5',0,NULL),(15,'Arne','124',0,NULL),(16,'Zjef','123',0,NULL),(17,'Test','1',0,NULL),(18,'Zjef','Zjef123',0,NULL);
/*!40000 ALTER TABLE `student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student_has_studierichting`
--

DROP TABLE IF EXISTS `student_has_studierichting`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `student_has_studierichting` (
  `idStudentVolgtRichting` int(11) NOT NULL AUTO_INCREMENT,
  `fkStudent` int(11) NOT NULL,
  `fkStudierichting` int(11) NOT NULL,
  `startDatum` datetime DEFAULT NULL,
  `eindDatum` datetime DEFAULT NULL,
  PRIMARY KEY (`idStudentVolgtRichting`),
  KEY `fk_Student_has_Studierichting_Studierichting1_idx` (`fkStudierichting`),
  KEY `fk_Student_has_Studierichting_Student1_idx` (`fkStudent`),
  CONSTRAINT `fk_Student_has_Studierichting_Student1` FOREIGN KEY (`fkStudent`) REFERENCES `student` (`idgebruiker`),
  CONSTRAINT `fk_Student_has_Studierichting_Studierichting1` FOREIGN KEY (`fkStudierichting`) REFERENCES `studierichting` (`idstudierichting`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student_has_studierichting`
--

LOCK TABLES `student_has_studierichting` WRITE;
/*!40000 ALTER TABLE `student_has_studierichting` DISABLE KEYS */;
INSERT INTO `student_has_studierichting` VALUES (1,1,1,NULL,NULL),(2,2,7,NULL,NULL),(3,3,6,NULL,NULL),(4,4,5,NULL,NULL),(5,5,5,NULL,NULL),(6,6,3,NULL,NULL),(7,7,9,NULL,NULL),(8,8,11,NULL,NULL),(9,9,2,NULL,NULL),(10,10,8,NULL,NULL),(11,11,4,NULL,NULL),(12,12,6,NULL,NULL),(13,13,7,NULL,NULL),(14,14,2,NULL,NULL);
/*!40000 ALTER TABLE `student_has_studierichting` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `studiejaar`
--

DROP TABLE IF EXISTS `studiejaar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `studiejaar` (
  `IDStudiejaar` int(11) NOT NULL AUTO_INCREMENT,
  `Naam` longtext NOT NULL,
  `FKStudierichting` int(11) NOT NULL,
  `FKStudent` int(11) NOT NULL,
  PRIMARY KEY (`IDStudiejaar`,`FKStudierichting`),
  KEY `fk_Studiejaar_Studierichting1_idx` (`FKStudierichting`),
  KEY `FKNaarStudent_idx` (`FKStudent`),
  CONSTRAINT `fk_Studiejaar_Studierichting1` FOREIGN KEY (`FKStudierichting`) REFERENCES `studierichting` (`idstudierichting`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `studiejaar`
--

LOCK TABLES `studiejaar` WRITE;
/*!40000 ALTER TABLE `studiejaar` DISABLE KEYS */;
INSERT INTO `studiejaar` VALUES (1,'Eerste Jaar - Algemeen',1,0),(2,'Tweede Jaar - Hardware',1,0),(3,'Tweede Jaar - App Development',1,0),(4,'Tweede Jaar - Netwerken',1,0),(5,'Derde Jaar - Hardware',1,0),(6,'Derde Jaar - App Development',1,0),(7,'Derde Jaar - Netwerken',1,0),(8,'Eerste Jaar',2,0),(9,'Tweede Jaar',2,0),(10,'Derde Jaar',2,0),(11,'Eerste Jaar',3,0),(12,'Tweede Jaar',3,0),(13,'Derde Jaar',3,0),(14,'Eerste Jaar',4,0),(15,'Tweede Jaar',4,0),(16,'Derde Jaar',4,0),(17,'Eerste Jaar',5,0),(18,'Tweede Jaar',5,0),(19,'Derde Jaar',5,0),(20,'Eerste Jaar',6,0),(21,'Tweede Jaar',6,0),(22,'Derde Jaar',6,0),(23,'Eerste Jaar',7,0),(24,'Tweede Jaar',7,0),(25,'Derde Jaar',7,0),(26,'Eerste Jaar',8,0),(27,'Tweede Jaar',8,0),(28,'Derde Jaar',8,0),(29,'Eerste Jaar',9,0),(30,'Tweede Jaar',9,0),(31,'Derde Jaar',9,0),(32,'Eerste Jaar',10,0),(33,'Tweede Jaar',10,0),(34,'Derde Jaar',10,0),(35,'Eerste Jaar',11,0),(36,'Tweede Jaar',11,14),(37,'Derde Jaar',11,0);
/*!40000 ALTER TABLE `studiejaar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `studierichting`
--

DROP TABLE IF EXISTS `studierichting`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `studierichting` (
  `IDStudierichting` int(11) NOT NULL AUTO_INCREMENT,
  `Naam` longtext NOT NULL,
  `Jaren` int(11) NOT NULL,
  PRIMARY KEY (`IDStudierichting`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `studierichting`
--

LOCK TABLES `studierichting` WRITE;
/*!40000 ALTER TABLE `studierichting` DISABLE KEYS */;
INSERT INTO `studierichting` VALUES (1,'Bachelor Informatica',3),(2,'Bachelor Biowetenschappen',4),(3,'Bachelor Economische Wetenschappen',3),(4,'Bachelor Fysica en Sterrenkunde',5),(5,'Bachelor Handelswetenschappen',3),(6,'Bachelor Ingenieurswetenschappen Architectuur',4),(7,'Bachelor Musicologie ',2),(8,'Bachelor Onderwijskunde',5),(9,'Bachelor Rechten',4),(10,'Bachelor Sociologie',3),(11,'Bachelor Wiskunde',3);
/*!40000 ALTER TABLE `studierichting` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vak`
--

DROP TABLE IF EXISTS `vak`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `vak` (
  `IDVak` int(11) NOT NULL AUTO_INCREMENT,
  `Naam` longtext NOT NULL,
  `Lesuren` int(11) NOT NULL,
  `Punten` int(11) NOT NULL,
  PRIMARY KEY (`IDVak`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vak`
--

LOCK TABLES `vak` WRITE;
/*!40000 ALTER TABLE `vak` DISABLE KEYS */;
INSERT INTO `vak` VALUES (1,'Wiskunde',5,20),(2,'Frans',2,8),(3,'Netwerken',7,30),(4,'Programmeren',5,25),(5,'Engels',3,15),(6,'Spaans',2,8),(7,'Duits',2,6),(8,'Geschiedenis',3,14),(9,'Fysica',2,9),(10,'Chemie',1,3),(11,'Biologie',2,10),(12,'Italiaans',5,40),(13,'Wiskunde',8,40);
/*!40000 ALTER TABLE `vak` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vak_has_student`
--

DROP TABLE IF EXISTS `vak_has_student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `vak_has_student` (
  `FKVak` int(11) NOT NULL,
  `FKStudent` int(11) NOT NULL,
  PRIMARY KEY (`FKVak`,`FKStudent`),
  KEY `fk_Vak_has_Student_Student1_idx` (`FKStudent`),
  KEY `fk_Vak_has_Student_Vak_idx` (`FKVak`),
  CONSTRAINT `fk_Vak_has_Student_Student1` FOREIGN KEY (`FKStudent`) REFERENCES `student` (`idgebruiker`),
  CONSTRAINT `fk_Vak_has_Student_Vak` FOREIGN KEY (`FKVak`) REFERENCES `vak` (`idvak`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vak_has_student`
--

LOCK TABLES `vak_has_student` WRITE;
/*!40000 ALTER TABLE `vak_has_student` DISABLE KEYS */;
INSERT INTO `vak_has_student` VALUES (1,1),(5,1),(7,1),(1,2),(2,2),(3,2),(4,2),(7,2),(8,2),(10,2),(11,2),(5,3),(6,3),(7,3),(11,3),(2,4),(3,4),(4,4),(8,4),(9,4),(10,4),(1,5),(4,5),(5,5),(7,5),(1,6),(2,6),(3,6),(4,6),(6,6),(8,6),(11,6),(2,7),(3,7),(4,7),(5,7),(7,7),(4,8),(5,8),(6,8),(8,8),(9,8),(1,9),(3,9),(4,9),(5,9),(9,9),(2,10),(4,10),(5,10),(9,10),(10,10),(2,11),(3,11),(5,11),(6,11),(11,11),(9,17),(1,18),(2,18),(6,18),(7,18);
/*!40000 ALTER TABLE `vak_has_student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vak_has_studiejaar`
--

DROP TABLE IF EXISTS `vak_has_studiejaar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `vak_has_studiejaar` (
  `FKVak` int(11) NOT NULL,
  `FKStudiejaar` int(11) NOT NULL,
  PRIMARY KEY (`FKVak`,`FKStudiejaar`),
  KEY `fk_Vak_has_Studiejaar_Studiejaar1_idx` (`FKStudiejaar`),
  KEY `fk_Vak_has_Studiejaar_Vak1_idx` (`FKVak`),
  CONSTRAINT `fk_Vak_has_Studiejaar_Studiejaar1` FOREIGN KEY (`FKStudiejaar`) REFERENCES `studiejaar` (`idstudiejaar`),
  CONSTRAINT `fk_Vak_has_Studiejaar_Vak1` FOREIGN KEY (`FKVak`) REFERENCES `vak` (`idvak`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vak_has_studiejaar`
--

LOCK TABLES `vak_has_studiejaar` WRITE;
/*!40000 ALTER TABLE `vak_has_studiejaar` DISABLE KEYS */;
INSERT INTO `vak_has_studiejaar` VALUES (6,1),(7,2),(3,3),(4,4),(1,5),(11,6),(2,7),(9,8),(5,9),(8,10),(10,11);
/*!40000 ALTER TABLE `vak_has_studiejaar` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-18  8:54:44
