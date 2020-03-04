USE master;
GO
 CREATE DATABASE MarathonSkills ON(
 NAME = Marathon_Skills,
 FILENAME = 'C:\MarathonSkills2015\MarathonSkills.mdf',
 SIZE = 50mb,
 MAXSIZE = 300MB,
 FILEGROWTH = 15mb
 )
 LOG ON (
 NAME = Marathon_SkillsLOG,
 FILENAME = 'C:\MarathonSkills2015\MarathonSkillsLog.ldf',
 SIZE = 5mb,
 MAXSIZE = 50mb,
 FILEGROWTH = 1mb
 );
USE MarathonSkills;
GO 
CREATE TABLE Charity(
CharityId INTEGER NOT NULL IDENTITY PRIMARY KEY,
CharityName VARCHAR(100) NOT NULL,
CharityDescription VARCHAR(200),
CharityLogo VARCHAR(50)
);

CREATE TABLE Country(
CountryCode CHAR(3) NOT NULL PRIMARY KEY,
CountryName VARCHAR(100) NOT NULL,
CountryFlag VARCHAR(100) NOT NULL);

CREATE TABLE _EventType (
EventTypeId CHAR(2) NOT NULL PRIMARY KEY,
EventTypeName VARCHAR(50) NOT NULL
);

CREATE TABLE _Event (
EventId CHAR(6) NOT NULL PRIMARY KEY,
EventName VARCHAR(50) NOT NULL,
EventTypeId CHAR(2)  NOT NULL,
MarathonId TINYINT NOT NULL,
StartDateTime DATETIME,
Cost DECIMAL(10,2),
MaxParticipants SMALLINT,
);

CREATE TABLE Gender(
Gender VARCHAR(10) PRIMARY KEY NOT NULL
);


USE MarathonSkills;
GO
CREATE TABLE Marathon(
MarathonId TINYINT NOT NULL PRIMARY KEY,
MarathonName VARCHAR(80) NOT NULL,
CityName VARCHAR(80),
CountryCode CHAR(3) NOT NULL,
YearHeld SMALLINT
);

CREATE TABLE RaceKitOption(
RaceKitOptionId CHAR(1) NOT NULL PRIMARY KEY,
RaceKitOption VARCHAR(80) NOT NULL,
RaceKitCoast DECIMAL(10,2) NOT NULL
);
CREATE TABLE Registration(
RegistrationId INT NOT NULL IDENTITY PRIMARY KEY,
RunnerId INT NOT NULL,
RegistrationDateTime DATETIME NOT NULL,
RaceKitOptionId CHAR(1) NOT NULL,
RegistrationStatusId TINYINT NOT NULL,
Cost DECIMAL(10,2) NOT NULL,
CharityId INT NOT NULL,
SponsorshipTarget DECIMAL(10,2) NOT NULL
);

CREATE TABLE RegistrationEvent(
RegistrationEventId INT NOT NULL IDENTITY PRIMARY KEY,
RegistrationId INT NOT NULL,
EventId CHAR(6), 
BibNumber SMALLINT, 
RaceTime INT
);

CREATE TABLE RegistrationStatus (
RegistrationStatusId TINYINT NOT NULL IDENTITY PRIMARY KEY,
RegistrationStatus VARCHAR(80) NOT NULL
);

CREATE TABLE _Role(
RoleId CHAR(1) NOT NULL PRIMARY KEY, 
RoleName VARCHAR(50)
);

CREATE TABLE Runner(
RunnerId INT NOT NULL PRIMARY KEY,
Email  VARCHAR(100) NOT NULL,
Gender VARCHAR(100) NOT NULL,
DateOfBirth DATETIME,
CountryCode CHAR(3)
);

CREATE TABLE Sponsorship(
SponsorshipId INT NOT NULL IDENTITY,
SponsorName VARCHAR(150) NOT NULL,
RegistrationId INT NOT NULL,
Amount DECIMAL(10,2)
);

CREATE TABLE _User (
Email VARCHAR(100) NOT NULL PRIMARY KEY,
_Password VARCHAR(100) NOT NULL,
FirstName VARCHAR(80),
LastName VARCHAR(80),
RoleId CHAR(1) NOT NULL
);

CREATE TABLE Volunteer (
VolunterId INT NOT NULL IDENTITY PRIMARY KEY,
FisrtName VARCHAR(80),
LastName VARCHAR(80),
CountryCode CHAR(3) NOT NULL,
Gender VARCHAR(10) NOT NULL,
);

CREATE TABLE Position(
PositionId SMALLINT NOT NULL PRIMARY KEY IDENTITY,
PosintionName VARCHAR(50) NOT NULL,
PositionDescription VARCHAR(1000),
Payrate DECIMAL(10,2) NOT NULL
);

CREATE TABLE  Staff(
StaffId INT NOT NULL PRIMARY KEY IDENTITY,
FirstName VARCHAR(80) NOT NULL,
LastName VARCHAR(80) NOT NULL,
DateOfBirth DATETIME NOT NULL,
Gender VARCHAR(10) NOT NULL,
PositionId SMALLINT NOT NULL,
Comments VARCHAR(2000)
);

CREATE TABLE Timesheet(
TimesheetId INT NOT NULL PRIMARY KEY IDENTITY,
StaffId INT NOT NULL,
StartDateTime DATETIME, 
EndDateTime DATETIME,
PayAmount DECIMAL(10,2)
);