USE master
GO

DROP DATABASE IF EXISTS FootballDB
GO

CREATE DATABASE FootballDB
GO

USE FootballDB
GO

CREATE TABLE Owners(
	OwnerID INT NOT NULL PRIMARY KEY IDENTITY,
	OwnerName VARCHAR(50) NULL,
	ClubOwned VARCHAR(50) NULL,
	ClubPercOwned INT NULL,
	NetWorthMill INT NULL
);

CREATE TABLE Agents(
	AgentID INT NOT NULL PRIMARY KEY IDENTITY,
	AgentName VARCHAR(50) NULL,
	AgentFeeMill INT NULL,
	PlayerPercOwned INT NULL
);

CREATE TABLE Players(
	PlayerID INT NOT NULL PRIMARY KEY IDENTITY,
	PlayerName VARCHAR(50) NULL,
	PlayerAge INT NULL,
	OwnerID INT FOREIGN KEY REFERENCES Owners(OwnerID),
	AgentID INT FOREIGN KEY REFERENCES Agents(AgentID),
	Salary INT NULL,
	ContractLength INT NULL
);

CREATE TABLE Scouts(
	ScoutID INT NOT NULL PRIMARY KEY IDENTITY,
	ScoutName VARCHAR(50) NULL,
	PlayerID INT FOREIGN KEY REFERENCES Players(PlayerID),
	CountryBased VARCHAR(50)
);

CREATE TABLE HeadStaffs(
	HeadStaffID INT NOT NULL PRIMARY KEY IDENTITY,
	StaffName VARCHAR(50) NULL,
	OwnerID INT FOREIGN KEY REFERENCES Owners(OwnerID),
	StaffRole VARCHAR(50) NULL,
	ScoutID INT FOREIGN KEY REFERENCES Scouts(ScoutID)
);

INSERT INTO Owners (OwnerName, ClubOwned, ClubPercOwned, NetWorthMill) VALUES
('Sheikh Mansour', 'Manchester City', 100, 17000),
('Stan Kroenke', 'Arsenal', 100, 10000)
GO

INSERT INTO Agents (AgentName, AgentFeeMill, PlayerPercOwned) VALUES
('Mino Raiola', 30, 0),
('Jorge Mendes', 15, 5)
GO

INSERT INTO Players (PlayerName, PlayerAge, OwnerID, AgentID, Salary, ContractLength) VALUES 
('Paul Pogba', 27, 1, 1, 250000, 3),
('Ederson', 26, 1, 2, 160000, 5)
GO

INSERT INTO Scouts (ScoutName, PlayerID, CountryBased) VALUES
('John Smith', 1, 'Portugal')
GO

INSERT INTO HeadStaffs (StaffName, OwnerID, StaffRole, ScoutID) VALUES
('Edu', 2, 'Technical Director', 1)
GO