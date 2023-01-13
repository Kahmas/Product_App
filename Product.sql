create database Product_DB
go

use Product_DB

CREATE TABLE Product (
	Uid INT NOT NULL IDENTITY (1, 1),
	Name VARCHAR(50) NOT NULL,
	Status TINYINT NOT NULL DEFAULT 1,
	PRIMARY KEY (uid)
)

INSERT INTO Product VALUES ('XYZ Sarden Extra Pedas 35gr','1')
INSERT INTO Product VALUES ('XYZ Makarel Extra Pedas 150gr','1')
INSERT INTO Product VALUES ('XYZ Kecap Manis 125ml','1')
INSERT INTO Product VALUES ('XYZ Sirup Karamel 250ml','1')
INSERT INTO Product VALUES ('XYZ Batrai AA (Pack isi 4)','1')

select * from Product