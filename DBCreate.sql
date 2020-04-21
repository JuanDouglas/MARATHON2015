USE master;
GO
 CREATE DATABASE MarathonSkills ON(
 NAME = Marathon_Skills,
 FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MarathonSkills.mdf',
 SIZE = 50mb,
 MAXSIZE = 300MB,
 FILEGROWTH = 15mb
 )
 LOG ON (
 NAME = Marathon_SkillsLOG,
 FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MarathonSkillsLog.ldf',
 SIZE = 5mb,
 MAXSIZE = 50mb,
 FILEGROWTH = 1mb
 );
USE MarathonSkills;
GO 
CREATE TABLE Charity(
CharityId INTEGER IDENTITY PRIMARY KEY,
CharityName VARCHAR(100) NOT NULL,
CharityDescription VARCHAR(200),
CharityLogo VARCHAR(50)
);

CREATE TABLE Country(
CountryCode CHAR(3) PRIMARY KEY,
CountryName VARCHAR(100) NOT NULL,
CountryFlag VARCHAR(100) NOT NULL);

CREATE TABLE Marathon(
MarathonId INTEGER  PRIMARY KEY,
MarathonName VARCHAR(80) NOT NULL,
CityName VARCHAR(80),
CountryCode CHAR(3) NOT NULL,
YearHeld SMALLINT,
FOREIGN KEY (CountryCode) REFERENCES Country(CountryCode)
);

CREATE TABLE _EventType (
EventTypeId INTEGER IDENTITY PRIMARY KEY,
EventTypeName VARCHAR(50) NOT NULL
);

CREATE TABLE _Event (
EventId INTEGER IDENTITY PRIMARY KEY,
EventName VARCHAR(50) NOT NULL,
EventTypeId INTEGER,
MarathonId INTEGER,
StartDateTime DATETIME,
Cost DECIMAL(10,2),
MaxParticipants SMALLINT,
FOREIGN KEY (EventTypeId) REFERENCES _EventType(EventTypeId),
FOREIGN KEY (MarathonId) REFERENCES Marathon(MarathonId)
);

CREATE TABLE Gender(
Gender VARCHAR(10) PRIMARY KEY NOT NULL
);

CREATE TABLE RaceKitOption(
RaceKitOptionId CHAR(1) NOT NULL PRIMARY KEY,
RaceKitOption VARCHAR(80) NOT NULL,
RaceKitCoast DECIMAL(10,2) NOT NULL
);
CREATE TABLE Runner(
RunnerId INT IDENTITY PRIMARY KEY,
Email  VARCHAR(100) NOT NULL,
Gender VARCHAR(100) NOT NULL,
DateOfBirth DATETIME,
CountryCode CHAR(3)
);
CREATE TABLE RegistrationStatus (
RegistrationStatusId TINYINT NOT NULL IDENTITY PRIMARY KEY,
RegistrationStatus VARCHAR(80) NOT NULL
);

CREATE TABLE Registration(
RegistrationId INTEGER IDENTITY PRIMARY KEY,
RunnerId INT NOT NULL,
RegistrationDateTime DATETIME NOT NULL,
RaceKitOptionId CHAR(1) NOT NULL,
RegistrationStatusId TINYINT NOT NULL,
Cost DECIMAL(10,2) NOT NULL,
CharityId INT NOT NULL,
SponsorshipTarget DECIMAL(10,2) NOT NULL,
FOREIGN KEY (RunnerId) REFERENCES Runner(RunnerId),
FOREIGN KEY (RaceKitOptionId) REFERENCES RaceKitOption(RaceKitOptionId),
FOREIGN KEY (RegistrationStatusId) REFERENCES RegistrationStatus(RegistrationStatusId),
FOREIGN KEY (CharityId) REFERENCES Charity(CharityId)
);

CREATE TABLE RegistrationEvent(
RegistrationEventId INT NOT NULL IDENTITY PRIMARY KEY,
RegistrationId INTEGER NOT NULL,
EventId INTEGER, 
BibNumber SMALLINT, 
RaceTime INT,
FOREIGN KEY (RegistrationId) REFERENCES Registration(RegistrationId),
FOREIGN KEY (EventId) REFERENCES _Event(EventId)
);
CREATE TABLE _Role(
RoleId INTEGER PRIMARY KEY IDENTITY, 
RoleName VARCHAR(50)
);
CREATE TABLE Sponsorship(
SponsorshipId INT PRIMARY KEY IDENTITY,
SponsorName VARCHAR(150) NOT NULL,
RegistrationId INTEGER NOT NULL,
Amount DECIMAL(10,2),
FOREIGN KEY (RegistrationId) REFERENCES Registration(RegistrationId)
);

CREATE TABLE _User (
Email VARCHAR(100) NOT NULL PRIMARY KEY,
_Password VARCHAR(100) NOT NULL,
FirstName VARCHAR(80),
LastName VARCHAR(80),
RoleId INTEGER NOT NULL,
FOREIGN KEY (RoleId) REFERENCES _Role(RoleId)
);

CREATE TABLE Volunteer (
VolunterId INT IDENTITY PRIMARY KEY,
FisrtName VARCHAR(80),
LastName VARCHAR(80),
CountryCode CHAR(3) NOT NULL,
Gender VARCHAR(10) NOT NULL,
FOREIGN KEY (CountryCode) REFERENCES Country(CountryCode)
);

CREATE TABLE Position(
PositionId SMALLINT IDENTITY PRIMARY KEY ,
PosintionName VARCHAR(50) NOT NULL,
PositionDescription VARCHAR(1000),
Payrate DECIMAL(10,2) NOT NULL
);

CREATE TABLE  Staff(
StaffId INT IDENTITY PRIMARY KEY ,
FirstName VARCHAR(80) NOT NULL,
LastName VARCHAR(80) NOT NULL,
DateOfBirth DATETIME NOT NULL,
Gender VARCHAR(10) NOT NULL,
PositionId SMALLINT NOT NULL,
Comments VARCHAR(2000),
FOREIGN KEY (PositionId) REFERENCES Position(PositionId) 
);

CREATE TABLE Timesheet(
TimesheetId INT IDENTITY PRIMARY KEY ,
StaffId INT NOT NULL,
StartDateTime DATETIME, 
EndDateTime DATETIME,
PayAmount DECIMAL(10,2)
FOREIGN KEY (StaffId) REFERENCES Staff(StaffId)
);