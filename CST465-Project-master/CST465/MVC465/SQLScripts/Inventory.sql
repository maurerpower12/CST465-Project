﻿CREATE TABLE Category
(
	ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	CategoryName VARCHAR(200) NOT NULL
)
CREATE TABLE Product
(
	ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	ProductCode VARCHAR(100) NOT NULL,
	ProductName VARCHAR(200) NOT NULL,
	CategoryID INT NOT NULL REFERENCES Category(ID), 
	ProductDescription VARCHAR(MAX) NULL,
	ProductImage VARBINARY(MAX),
	Price MONEY NOT NULL,
	Quantity INT NOT NULL 
)

