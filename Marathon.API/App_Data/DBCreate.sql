-- Charity Table --

CREATE TABLE Charity(
CharityId INTEGER IDENTITY PRIMARY KEY NOT NULL,
CharityName VARCHAR(100) NOT NULL,
CharityDescription VARCHAR(2000),
CharityLogo VARCHAR(50));

-- Country Table --

CREATE TABLE Country(
CountryCode CHAR(3) PRIMARY KEY NOT NULL,
CountryName VARCHAR(100) NOT NULL,
CountryFlag VARCHAR(100) NOT NULL);

-- EventType Table --

CREATE TABLE EventType (
EventTypeId CHAR(2) PRIMARY KEY NOT NULL,
EventTypeName VARCHAR(50) NOT NULL);

-- Gender Table --

CREATE TABLE Gender(
Gender VARCHAR(10) PRIMARY KEY NOT NULL);

-- RaceKitOption Table --

CREATE TABLE RaceKitOption(
RaceKitOptionId CHAR(1) NOT NULL PRIMARY KEY,
RaceKitOption VARCHAR(80) NOT NULL,
RaceKitCost DECIMAL(10,2) NOT NULL);

-- RegistrationStatus Table --

CREATE TABLE RegistrationStatus (
RegistrationStatusId TINYINT IDENTITY PRIMARY KEY,
RegistrationStatus VARCHAR(80) NOT NULL);

-- Role Table --

CREATE TABLE [Role](
RoleId CHAR(3) PRIMARY KEY, 
RoleName VARCHAR(50));

-- Position Table --

CREATE TABLE Position(
PositionId SMALLINT IDENTITY PRIMARY KEY NOT NULL,
PosintionName VARCHAR(50) NOT NULL,
PositionDescription VARCHAR(1000),
Payrate DECIMAL(10,2) NOT NULL);

-- Marathon Table --

CREATE TABLE Marathon(
MarathonId TINYINT IDENTITY PRIMARY KEY NOT NULL,
MarathonName VARCHAR(80) NOT NULL,
CityName VARCHAR(80),
CountryCode CHAR(3) NOT NULL,
YearHeld SMALLINT,
FOREIGN KEY (CountryCode) REFERENCES Country(CountryCode));

-- Event Table --

CREATE TABLE [Event] (
EventId CHAR(6) PRIMARY KEY NOT NULL,
EventName VARCHAR(50) NOT NULL,
EventTypeId CHAR(2) NOT NULL,
MarathonId TINYINT NOT NULL,
StartDateTime DATETIME,
Cost DECIMAL(10,2),
MaxParticipants SMALLINT,
FOREIGN KEY (EventTypeId) REFERENCES EventType(EventTypeId),
FOREIGN KEY (MarathonId) REFERENCES Marathon(MarathonId));

-- User Table --

CREATE TABLE [User] (
Email VARCHAR(100) PRIMARY KEY NOT NULL,
[Password] VARCHAR(100) NOT NULL,
FirstName VARCHAR(80),
LastName VARCHAR(80),
RoleId CHAR(3) NOT NULL,
FOREIGN KEY (RoleId) REFERENCES [Role](RoleId));

-- Runner Table --

CREATE TABLE Runner(
RunnerId INT IDENTITY PRIMARY KEY NOT NULL,
Email  VARCHAR(100) NOT NULL,
Gender VARCHAR(100) NOT NULL,
DateOfBirth DATETIME,
CountryCode CHAR(3) NOT NULL,
FOREIGN KEY (Email) REFERENCES [User](Email));

-- Registration Table --

CREATE TABLE Registration(
RegistrationId INT IDENTITY PRIMARY KEY NOT NULL,
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
FOREIGN KEY (CharityId) REFERENCES Charity(CharityId));

-- RegistrationEvent Table --

CREATE TABLE RegistrationEvent(
RegistrationEventId INT IDENTITY PRIMARY KEY NOT NULL,
RegistrationId INTEGER NOT NULL,
EventId CHAR(6), 
BibNumber SMALLINT, 
RaceTime INT,
FOREIGN KEY (RegistrationId) REFERENCES Registration(RegistrationId),
FOREIGN KEY (EventId) REFERENCES [Event](EventId));

-- Sponsorship Table --

CREATE TABLE Sponsorship(
SponsorshipId INT PRIMARY KEY IDENTITY NOT NULL,
SponsorName VARCHAR(150) NOT NULL,
RegistrationId INTEGER NOT NULL,
Amount DECIMAL(10,2),
FOREIGN KEY (RegistrationId) REFERENCES Registration(RegistrationId));

-- Vounteer Table --

CREATE TABLE Volunteer (
VolunterId INT IDENTITY PRIMARY KEY NOT NULL,
FisrtName VARCHAR(80),
LastName VARCHAR(80),
CountryCode CHAR(3) NOT NULL,
Gender VARCHAR(10) NOT NULL,
FOREIGN KEY (CountryCode) REFERENCES Country(CountryCode),
FOREIGN KEY (Gender) REFERENCES Gender(Gender));

-- Staff Table --

CREATE TABLE  Staff (
StaffId INT IDENTITY PRIMARY KEY NOT NULL ,
FirstName VARCHAR(80) NOT NULL,
LastName VARCHAR(80) NOT NULL,
DateOfBirth DATETIME NOT NULL,
Gender VARCHAR(10) NOT NULL,
PositionId SMALLINT NOT NULL,
Comments VARCHAR(2000),
FOREIGN KEY (PositionId) REFERENCES Position(PositionId));

-- Timesheet Table --

CREATE TABLE Timesheet(
TimesheetId INT IDENTITY PRIMARY KEY NOT NULL,
StaffId INT NOT NULL,
StartDateTime DATETIME, 
EndDateTime DATETIME,
PayAmount DECIMAL(10,2)
FOREIGN KEY (StaffId) REFERENCES Staff(StaffId));