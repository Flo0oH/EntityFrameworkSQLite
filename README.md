# EF
Import Data from a Templogger CSV File into an SQLite DB with C# Entity Framework. 

-- Script Date: 28.10.2022 14:21  - ErikEJ.SqlCeScripting version 3.5.2.94
-- Database information:
-- Database: C:\Users\flori\source\repos\EF\EF\DBLud.db
-- ServerVersion: 3.38.5.1
-- DatabaseSize: 32 KB
-- Created: 26.10.2022 19:10

-- User Table information:
-- Number of tables: 5
-- __EFMigrationsHistory: -1 row(s)
-- FluentApiTable: -1 row(s)
-- Logins: -1 row(s)
-- Sensors: -1 row(s)
-- TempSensors: -1 row(s)

SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [TempSensors] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Name] text NULL
, [Temperaturedate] text NULL
, [Temperature] real NOT NULL
, [Sensornr] bigint NOT NULL
, [SensorsId] text DEFAULT ('') NOT NULL
);
CREATE TABLE [Sensors] (
  [SensorsId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Name] text NULL
, [Room] text NULL
, [RoomNr] bigint NOT NULL
);
CREATE TABLE [Logins] (
  [Identifier] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [LoginName] text NULL
, [Password] text NULL
);
CREATE TABLE [FluentApiTable] (
  [Identifier] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Name] text NOT NULL
);
CREATE TABLE [__EFMigrationsHistory] (
  [MigrationId] text NOT NULL
, [ProductVersion] text NOT NULL
, CONSTRAINT [sqlite_autoindex___EFMigrationsHistory_1] PRIMARY KEY ([MigrationId])
);
COMMIT;
