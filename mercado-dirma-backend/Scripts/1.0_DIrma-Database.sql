CREATE DATABASE Mercado_DIrma
COLLATE SQL_Latin1_General_CP1_CI_AS
GO

USE Mercado_DIrma
GO

CREATE TABLE [User]
(
    IdUser INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Email VARCHAR(250) NOT NULL,
	FullName VARCHAR(250) NOT NULL,
    Dni INT NOT NULL,
    BirthDate DATE NULL,
	PhoneNumber BIGINT NULL,
	[Address] VARCHAR(250) NULL,
	CreationDate DATETIME NOT NULL,
    DeletionDate DATETIME NULL,
    UpdateDate DATETIME NULL,
	Active BIT NOT NULL,
);
GO

CREATE TABLE AppointmentStatus
(
    IdAppointmentStatus INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Description] VARCHAR(250) NOT NULL,
);
GO

CREATE TABLE Appointment
(
    IdAppointment INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdAppointmentStatus INT NOT NULL,
	IdUser INT NOT NULL,
	[Description] VARCHAR(500) NULL,
	AppointmentDate DATETIME NOT NULL,
	FOREIGN KEY (IdAppointmentStatus) REFERENCES AppointmentStatus (IdAppointmentStatus),
	FOREIGN KEY (IdUser) REFERENCES [User] (IdUser),
);
GO

CREATE TABLE [Role]
(
    IdRole INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	RoleName VARCHAR(100) NOT NULL,
);
GO

CREATE TABLE User_Role
(
    IdUser_Role INT IDENTITY(1,1) PRIMARY KEY NONCLUSTERED NOT NULL,
	IdUser INT NOT NULL,
	IdRole INT NOT NULL,
	FOREIGN KEY (IdRole) REFERENCES [Role] (IdRole),
	FOREIGN KEY (IdUser) REFERENCES [User] (IdUser),
    INDEX UserRole_IdUser_IdRole UNIQUE CLUSTERED (IdUser, IdRole)
);
GO

CREATE TABLE AvailableDays
(
    IdAvailableDays INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Description] VARCHAR(50) NOT NULL,
);
GO

CREATE TABLE [Availability]
(
    IdAvailability INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdAvailableDays INT NOT NULL,
	StartHour TIME(0) NOT NULL,
	EndHour TIME(0) NOT NULL,
	Active BIT NOT NULL,
	FOREIGN KEY (IdAvailableDays) REFERENCES AvailableDays (IdAvailableDays),
);
GO

CREATE TABLE Sale
(
    IdSale INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdUser INT NOT NULL,
	DetailsAmount MONEY NOT NULL,
	FinalAmount MONEY NOT NULL,
	[Date] DATETIME NOT NULL,
	[Description] VARCHAR(500) NOT NULL,
	CreationDate DATETIME NOT NULL,
    DeletionDate DATETIME NULL,
    UpdateDate DATETIME NULL,
	Active BIT NOT NULL,
	FOREIGN KEY (IdUser) REFERENCES [User] (IdUser),
);
GO

CREATE TABLE ProductBrand
(
    IdProductBrand INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	Active BIT NOT NULL,
);
GO

CREATE TABLE ProductStatus
(
    IdProductStatus INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	Active BIT NOT NULL,
);
GO

CREATE TABLE ProductType
(
    IdProductType INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	Active BIT NOT NULL,
);
GO

CREATE TABLE Product
(
    IdProduct INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	ProductName VARCHAR(250)  NOT NULL,
	IdProductBrand INT NOT NULL,
	IdProductStatus INT NOT NULL,
	IdProductType INT NOT NULL,
	IdUserOwner INT NOT NULL,
	Price MONEY NOT NULL,
	Size INT NOT NULL,
	[Description] VARCHAR(750) NULL,
	CreationDate DATETIME NOT NULL,
    DeletionDate DATETIME NULL,
    UpdateDate DATETIME NULL,
	Active BIT NOT NULL,
	FOREIGN KEY (IdProductBrand) REFERENCES ProductBrand (IdProductBrand),
	FOREIGN KEY (IdProductStatus) REFERENCES ProductStatus (IdProductStatus),
	FOREIGN KEY (IdProductType) REFERENCES ProductType (IdProductType),
	FOREIGN KEY (IdUserOwner) REFERENCES [User] (IdUser),
);
GO

CREATE TABLE SaleDetails
(
    IdSaleDetails INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdSale INT NOT NULL,
	IdProduct INT NOT NULL,
	Quantity INT NOT NULL,
	FOREIGN KEY (IdSale) REFERENCES Sale (IdSale),
	FOREIGN KEY (IdProduct) REFERENCES Product (IdProduct),
);
GO

CREATE TABLE TransactionType
(
    IdTransactionType INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Description] VARCHAR(100) NOT NULL,
);
GO

CREATE TABLE [Transaction]
(
    IdTransaction INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdTransactionType INT NOT NULL,
	IdUserFrom INT NOT NULL,
	IdUserTo INT NOT NULL,
	Amount MONEY NOT NULL,
	[Date] DATETIME NOT NULL,
	Active BIT NOT NULL,
	FOREIGN KEY (IdTransactionType) REFERENCES TransactionType (IdTransactionType),
	FOREIGN KEY (IdUserFrom) REFERENCES [User] (IdUser),
	FOREIGN KEY (IdUserTo) REFERENCES [User] (IdUser),
);
GO

CREATE TABLE ClientAccount
(
    IdClientAccount INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdUserClient INT NOT NULL,
	IdTransaction INT NOT NULL,
	Amount MONEY NOT NULL,
	Balance MONEY NOT NULL,
	[Date] DATETIME NOT NULL,
	Active BIT NOT NULL,
	FOREIGN KEY (IdUserClient) REFERENCES [User] (IdUser),
	FOREIGN KEY (IdTransaction) REFERENCES [Transaction] (IdTransaction),
);
GO