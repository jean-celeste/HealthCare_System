CREATE DATABASE  IF NOT EXISTS `books_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `books_db`;

-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: books_db
-- ------------------------------------------------------
-- Server version	8.0.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `authors`
--

DROP TABLE IF EXISTS `authors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `authors` (
  `author_id` int NOT NULL AUTO_INCREMENT,
  `author_name` varchar(100) NOT NULL,
  `author_country` varchar(100) DEFAULT NULL,
  `birth_date` date DEFAULT NULL,
  `bio` text,
  PRIMARY KEY (`author_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `authors`
--

LOCK TABLES `authors` WRITE;
/*!40000 ALTER TABLE `authors` DISABLE KEYS */;
INSERT INTO `authors` VALUES (1,'J.K. Rowling','United Kingdoms','1965-07-31','J.K. Rowling is a British author, best known for her Harry Potter series.'),(2,'Stephen King','United States','1947-09-21','Stephen King is an American author known for his horror, supernatural fiction, suspense, crime, science-fiction, and fantasy novels.'),(3,'Agatha Christie','United Kingdom','1890-09-15','Agatha Christie was an English writer known for her detective novels and short story collections.'),(4,'George R.R. Martin','United States','1948-09-20','George R.R. Martin is an American author best known for his epic fantasy series, A Song of Ice and Fire, which was adapted into the HBO series Game of Thrones.'),(5,'Haruki Murakami','Japan','1949-01-12','Haruki Murakami is a Japanese writer known for his novels and short stories, which blend elements of realism and surrealism.'),(6,'Lewis Carroll','United Kingdom','1832-01-27','Lewis Carroll was an English writer best known for his children\'s fiction, particularly Alice\'s Adventures in Wonderland and its sequel Through the Looking-Glass.'),(7,'Roald Dahl','United Kingdom','1916-09-13','Roald Dahl was a British novelist, short-story writer, poet, screenwriter, and wartime fighter pilot, best known for his children\'s books, including Charlie and the Chocolate Factory, Matilda, The BFG, and James and the Giant Peach.'),(8,'Theodor Seuss Geisel','United States','1904-03-02','Theodor Seuss Geisel, known as Dr. Seuss, was an American children\'s author, political cartoonist, illustrator, poet, animator, and filmmaker. He is best known for his work writing and illustrating more than 60 books under the pen name Dr. Seuss.'),(9,'Jane Austen','United Kingdom','1775-12-16','Jane Austen was an English novelist known primarily for her six major novels, which interpret, critique and comment upon the British landed gentry at the end of the 18th century.'),(10,'Leo Tolstoy','Russia','1828-09-09','Leo Tolstoy was a Russian writer who is regarded as one of the greatest authors of all time. He is best known for his novels War and Peace and Anna Karenina.');
/*!40000 ALTER TABLE `authors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `book_authors`
--

DROP TABLE IF EXISTS `book_authors`;
/*!50001 DROP VIEW IF EXISTS `book_authors`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `book_authors` AS SELECT 
 1 AS `book_id`,
 1 AS `book_title`,
 1 AS `author_name`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `book_categories`
--

DROP TABLE IF EXISTS `book_categories`;
/*!50001 DROP VIEW IF EXISTS `book_categories`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `book_categories` AS SELECT 
 1 AS `book_id`,
 1 AS `book_title`,
 1 AS `category_name`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `books`
--

DROP TABLE IF EXISTS `books`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `books` (
  `book_id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(255) NOT NULL,
  `author_id` int DEFAULT NULL,
  `publisher_id` int DEFAULT NULL,
  `category_id` int DEFAULT NULL,
  `publish_date` date DEFAULT NULL,
  `price` decimal(10,2) DEFAULT NULL,
  `copies` int DEFAULT NULL,
  PRIMARY KEY (`book_id`),
  KEY `author_id_idx` (`author_id`),
  KEY `publisher_id_idx` (`publisher_id`),
  KEY `category_idx` (`category_id`),
  CONSTRAINT `author_id` FOREIGN KEY (`author_id`) REFERENCES `authors` (`author_id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `category_id` FOREIGN KEY (`category_id`) REFERENCES `categories` (`category_id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `publisher_id` FOREIGN KEY (`publisher_id`) REFERENCES `publishers` (`publisher_id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `books`
--

LOCK TABLES `books` WRITE;
/*!40000 ALTER TABLE `books` DISABLE KEYS */;
INSERT INTO `books` VALUES (1,'Harry Potter and the Philosopher\'s Stone',1,1,1,'1997-06-26',375.00,7),(2,'The Shining',2,2,2,'1977-01-28',200.00,6),(3,'Murder on the Orient Express',3,3,5,'1934-01-01',150.00,8),(4,'A Game of Thrones',4,4,1,'1996-08-06',380.00,8),(5,'Norwegian Wood',5,5,6,'1987-09-04',250.00,4),(6,'Alice\'s Adventures in Wonderland',6,6,3,'1865-11-26',180.00,7),(7,'Charlie and the Chocolate Factory',7,7,3,'1964-10-01',200.00,6),(8,'The Cat in the Hat',8,8,3,'1957-03-12',150.00,9),(9,'Pride and Prejudice',9,9,4,'1813-01-28',220.00,9),(10,'War and Peace',10,10,4,'1869-01-01',200.00,10);
/*!40000 ALTER TABLE `books` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `category_id` int NOT NULL AUTO_INCREMENT,
  `category_name` varchar(100) NOT NULL,
  PRIMARY KEY (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'Fantasy'),(2,'Horror'),(3,'Children\'s Literature'),(4,'Classic Literature'),(5,'Mystery'),(6,'Literary Fiction');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer_balance`
--

DROP TABLE IF EXISTS `customer_balance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer_balance` (
  `id` int NOT NULL AUTO_INCREMENT,
  `customer_id` int NOT NULL,
  `customer_name` varchar(100) NOT NULL,
  `balance` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`,`customer_id`),
  KEY `customer_id_idx` (`customer_id`),
  CONSTRAINT `customer_id` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`)
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer_balance`
--

LOCK TABLES `customer_balance` WRITE;
/*!40000 ALTER TABLE `customer_balance` DISABLE KEYS */;
INSERT INTO `customer_balance` VALUES (5,5,'Blaster Silonga',200.00),(7,7,'Chito Miranda',180.00),(8,8,'Rob Deniel',380.00),(9,9,'Paul McCartney',200.00),(27,18,'Johny Depp',200.00),(34,30,'ayra',180.00),(35,31,'Bamboo Manalac',200.00),(37,33,'Ayra',380.00),(38,34,'kim',250.00),(39,35,'kim celeste',250.00),(40,36,'Ely Buendia',250.00),(41,37,'Kim',380.00),(42,38,'Tommy',200.00),(43,39,'jhong',220.00);
/*!40000 ALTER TABLE `customer_balance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customers` (
  `customer_id` int NOT NULL AUTO_INCREMENT,
  `customer_name` varchar(100) NOT NULL,
  `email` varchar(255) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `borrowed_books` int DEFAULT NULL,
  `date_borrowed` datetime DEFAULT NULL,
  `paid` varchar(45) DEFAULT NULL,
  `returned` varchar(45) DEFAULT 'no',
  PRIMARY KEY (`customer_id`),
  KEY `borrowed_books_idx` (`borrowed_books`),
  CONSTRAINT `borrowed_books` FOREIGN KEY (`borrowed_books`) REFERENCES `books` (`book_id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (1,'Bella','bellap@gmail.com','0912831723712','Alley',7,'2024-04-13 22:17:39','No','No'),(2,'Bamboo Manalac','bamboo@example.com','09123124125','Taguig',2,'2024-04-13 17:27:42','No','No'),(3,'jae','jae@gmail,com','0912312312',',lmnlsdf',4,'2024-04-13 17:27:42','No','No'),(4,'Unique Salonga','unique@example.com','9102312412','Manila, Philippines',1,'2024-04-13 17:27:42','Yes','No'),(5,'Blaster Silonga','blaster@example.com','+639296543210','Quezon City, Philippines',7,'2024-04-13 17:27:42','No','No'),(6,'Zild Benitez','zild@example.com','+639287654321','Pasig City, Philippines',5,'2024-04-13 17:27:42','Yes','No'),(7,'Chito Miranda','chito@example.com','+639178945612','Mandaluyong City, Philippines',6,'2024-04-13 17:27:42','No','No'),(8,'Rob Deniel','rob@example.com','+639199876543','Makati City, Philippines',4,'2024-04-11 17:27:42','No','No'),(9,'Paul McCartney','paul@example.com','+448765432198','Liverpool, United Kingdom',10,'2024-04-13 17:27:42','No','No'),(11,'Jean Carlo Celeste','jeanC@gmail.com','0912834127','Legazpi',8,'2024-03-08 01:00:00','No','No'),(17,'Ayra Napay','ayra@gmail.com','0912371283','Naga',7,'2024-02-22 00:00:00','Yes','Yes'),(18,'Johny Depp','johmy@example.com','09123123','Legazpi',7,'2024-04-13 17:27:42','No','No'),(24,'Johny Depp','johmy@example.com','09123123','Legazpi',7,'2024-04-13 17:27:42','Yes','Yes'),(27,'sample this','sampl@sampe,com','09123125125','Naga',3,'2024-03-07 00:00:00','Yes','No'),(30,'ayra','a@gmailcom','01241424','naga',6,'2024-03-08 00:00:00','No','No'),(31,'Bamboo Manalac','bamboo@example.com','+639156789012','Taguig City, Philippines',2,'2024-03-08 00:00:00','No','No'),(32,'Jamil Cervano','jamil@gmail.com','09128312312','Naga City',5,'2024-03-08 00:00:00','Yes','Yes'),(33,'Ayra','lynayranapay@gmail.com','09876543210','Naga City',4,'2024-03-17 00:00:00','No','No'),(34,'kim','asldkalsd','092138123712','Naga',5,'2024-03-25 00:00:00','No','No'),(35,'kim celeste','asldkalsd','092138123712','Naga City',5,'2024-03-19 00:00:00','No','No'),(36,'Ely Buendia','ely@example.com','0912412515','Naga City, Philippines',5,'2024-04-12 00:00:00','No','No'),(37,'Kim','kim@gmail.com','0912374865108','Naga City4',4,'2024-04-13 00:00:00','No','No'),(38,'Tommy','shelby@gmail.com','091238172312','Bermingham',2,'2024-04-13 17:08:11','No','No'),(39,'jhong','jonsdgsg','09887654321','Naga',9,'2024-04-13 17:24:42','No','No'),(40,'Jerome','jerome@gmail.com','09128317231','Naga',8,'2024-04-15 23:33:17','Yes','Yes'),(41,'Junmar Perez','example@gmail,com','0912312312','Naga City',2,'2024-04-17 20:06:32','Yes','No');
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `decrement_copies` AFTER INSERT ON `customers` FOR EACH ROW BEGIN
    UPDATE books
    SET copies = copies - 1
    WHERE book_id = NEW.borrowed_books;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `insert_customer_balance` AFTER INSERT ON `customers` FOR EACH ROW BEGIN
    INSERT INTO customer_balance (customer_id, customer_name, balance)
    SELECT NEW.customer_id, NEW.customer_name, b.price AS balance
    FROM books b
    WHERE b.book_id = NEW.borrowed_books;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `delete_customer_balance` AFTER UPDATE ON `customers` FOR EACH ROW BEGIN
    IF NEW.paid = 'yes' THEN
        DELETE FROM customer_balance
        WHERE customer_id = NEW.customer_id;
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `update_book_copies` BEFORE DELETE ON `customers` FOR EACH ROW BEGIN
    IF OLD.returned = 'yes' AND OLD.paid = 'yes' THEN
        -- Variable to store the book_id of the returned book
        SET @book_id_deleted = (SELECT borrowed_books FROM customers WHERE customer_id = OLD.customer_id);
        
        -- Update the copies count of the returned book
        UPDATE books
        SET copies = copies + 1
        WHERE book_id = @book_id_deleted;
        
	ELSE
		-- if returned is 'no' deletion will not take place
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Cannot delete customer record until the book is returned and paid.';
    END IF;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Temporary view structure for view `most_borrowed_books`
--

DROP TABLE IF EXISTS `most_borrowed_books`;
/*!50001 DROP VIEW IF EXISTS `most_borrowed_books`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `most_borrowed_books` AS SELECT 
 1 AS `book_id`,
 1 AS `book_title`,
 1 AS `borrowed_count`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `publishers`
--

DROP TABLE IF EXISTS `publishers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `publishers` (
  `publisher_id` int NOT NULL AUTO_INCREMENT,
  `publisher_name` varchar(100) NOT NULL,
  `publisher_address` varchar(255) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`publisher_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `publishers`
--

LOCK TABLES `publishers` WRITE;
/*!40000 ALTER TABLE `publishers` DISABLE KEYS */;
INSERT INTO `publishers` VALUES (1,'Bloomsbury Publishing','50 Bedford Square, London, United Kingdom','info@bloomsbury.com','+44 (0)20 7631 5600'),(2,'Doubleday','1745 Broadway, New York, NY, United States','info@doubleday.com','+1-800-223-1244'),(3,'Collins Crime Club','London, United Kingdom','info@harpercollins.com','+44 (0) 20 8307 4430'),(4,'Bantam Books','1745 Broadway, New York, NY, United States','customerservice@randomhouse.com','+1-800-726-0600'),(5,'Kodansha','Tokyo, Japan','info@kodansha.co.jp','+81-3-3440-0141'),(6,'Macmillan Publishers','London, United Kingdom','info@macmillan.com','+44 020 7014 6000'),(7,'Jonathan Cape','London, United Kingdom','enquiries@vintage-books.co.uk','+44 (0) 20 7840 8400'),(8,'Random House','1745 Broadway, New York, NY, United States','customerservice@randomhouse.com','+1-800-726-0600'),(9,'Penguin Classics','80 Strand, London, United Kingdom','info@penguinrandomhouse.co.uk','+44 (0) 20 7139 3000'),(10,'The Russian Messenger','Saint Petersburg, Russia','info@russianmessenger.com','+7 (812) 314-5421');
/*!40000 ALTER TABLE `publishers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'admin','admin@gmail.com','admin','pass'),(2,'admin1 ','admin1@gmail.com','admin1','admin'),(5,'Jean Celeste','celestecarljean17@gmail.com','jean_c','admin123'),(6,'Ayra Napay','lynayranapay@gmail.com','ayra','ayra'),(7,'Jean ','jean','Jean','jean'),(8,'Jean ','jean','Jean','jean1'),(9,'Ayra Napay','lynayranapay@gmail.com','ayra','ayra'),(10,'kim celeste','kimraphael.krc@gmai.com','kimm','1234');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'books_db'
--

--
-- Dumping routines for database 'books_db'
--
/*!50003 DROP FUNCTION IF EXISTS `CalculateTotalPriceByCategory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `CalculateTotalPriceByCategory`(
    category_name VARCHAR(100)
) RETURNS decimal(10,2)
    READS SQL DATA
BEGIN
    DECLARE total_price DECIMAL(10, 2);
    SELECT SUM(price) INTO total_price
    FROM books b
    JOIN categories c ON b.category_id = c.category_id
    WHERE c.category_name = category_name;
    
    RETURN total_price;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GetTotalBooksByAuthor` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetTotalBooksByAuthor`(
    IN author_name VARCHAR(100)
)
BEGIN
    DECLARE total_books INT;
    SELECT COUNT(*) INTO total_books
    FROM books b
    JOIN authors a ON b.author_id = a.author_id
    WHERE a.author_name = author_name;
    
    SELECT CONCAT('Total books by ', author_name, ': ', total_books) AS Result;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `book_authors`
--

/*!50001 DROP VIEW IF EXISTS `book_authors`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `book_authors` AS select `b`.`book_id` AS `book_id`,`b`.`title` AS `book_title`,`a`.`author_name` AS `author_name` from (`books` `b` join `authors` `a` on((`b`.`author_id` = `a`.`author_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `book_categories`
--

/*!50001 DROP VIEW IF EXISTS `book_categories`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `book_categories` AS select `b`.`book_id` AS `book_id`,`b`.`title` AS `book_title`,`c`.`category_name` AS `category_name` from (`books` `b` join `categories` `c` on((`b`.`category_id` = `c`.`category_id`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `most_borrowed_books`
--

/*!50001 DROP VIEW IF EXISTS `most_borrowed_books`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `most_borrowed_books` AS select `b`.`book_id` AS `book_id`,`b`.`title` AS `book_title`,count(`c`.`customer_id`) AS `borrowed_count` from (`books` `b` left join `customers` `c` on((`b`.`book_id` = `c`.`borrowed_books`))) group by `b`.`book_id`,`b`.`title` order by `borrowed_count` desc */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-04-30 18:41:01
