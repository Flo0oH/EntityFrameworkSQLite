# Import Data from a Templogger CSV File into an SQLite DB with C# Entity Framework. 
## Create SQLite TB with Tables
      SELECT 1;
      PRAGMA foreign_keys=on;
      BEGIN TRANSACTION;
      CREATE TABLE [Logins] (
        [Identifier] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
      , [LoginName] text NULL
      , [Password] text NULL
      );
      CREATE TABLE [Sensors] (
        [SensorsId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
      , [Name] text NULL
      , [Room] text NULL
      , [RoomNr] bigint NOT NULL
      , [LoginId] bigint NULL
      , [LoginsForeignKeys] bigint NULL
      , CONSTRAINT [FK_Sensors_0_0] FOREIGN KEY ([LoginsForeignKeys]) REFERENCES [Logins] ([Identifier]) ON DELETE RESTRICT ON UPDATE NO ACTION
      );
      CREATE TABLE [TempSensors] (
        [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
      , [Name] text NULL
      , [Temperaturedate] text NULL
      , [Temperature] real NOT NULL
      , [Sensornr] bigint NOT NULL
      , [SensorsId] bigint NULL
      , [SensorsForeignKey] bigint NULL
      , CONSTRAINT [FK_TempSensors_0_0] FOREIGN KEY ([SensorsForeignKey]) REFERENCES [Sensors] ([SensorsId]) ON DELETE RESTRICT ON UPDATE NO ACTION
      );
      CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] text NOT NULL
      , [ProductVersion] text NOT NULL
      , CONSTRAINT [sqlite_autoindex___EFMigrationsHistory_1] PRIMARY KEY ([MigrationId])
      );
      CREATE INDEX [Sensors_IX_Sensors_LoginsForeignKeys] ON [Sensors] ([LoginsForeignKeys] ASC);
      CREATE INDEX [TempSensors_IX_TempSensors_SensorsForeignKey] ON [TempSensors] ([SensorsForeignKey] ASC);
      CREATE TRIGGER [fki_Sensors_LoginsForeignKeys_Logins_Identifier] BEFORE Insert ON [Sensors] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table Sensors    violates foreign key constraint FK_Sensors_0_0') WHERE NEW.LoginsForeignKeys IS NOT NULL AND(SELECT Identifier FROM Logins WHERE  Identifier = NEW.LoginsForeignKeys) IS NULL; END;
      CREATE TRIGGER [fku_Sensors_LoginsForeignKeys_Logins_Identifier] BEFORE Update ON [Sensors] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table Sensors violates foreign key constraint FK_Sensors_0_0') WHERE NEW.LoginsForeignKeys IS NOT NULL AND(SELECT Identifier FROM Logins WHERE  Identifier = NEW.LoginsForeignKeys) IS NULL; END;
      CREATE TRIGGER [fki_TempSensors_SensorsForeignKey_Sensors_SensorsId] BEFORE Insert ON [TempSensors] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table TempSensors violates foreign key constraint FK_TempSensors_0_0') WHERE NEW.SensorsForeignKey IS NOT NULL AND(SELECT SensorsId FROM Sensors WHERE  SensorsId = NEW.SensorsForeignKey) IS NULL; END;
      CREATE TRIGGER [fku_TempSensors_SensorsForeignKey_Sensors_SensorsId] BEFORE Update ON [TempSensors] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table TempSensors violates foreign key constraint FK_TempSensors_0_0') WHERE NEW.SensorsForeignKey IS NOT NULL AND(SELECT SensorsId FROM Sensors WHERE  SensorsId = NEW.SensorsForeignKey) IS NULL; END;
      CREATE VIEW MyTempLogs AS select login.LoginName, sensor.Name, sensor.Room 
            from Logins login join TempSensors sensor on sensor.SensorsId = login.Identifier;
      CREATE VIEW MyTempSensor AS select sensors.Name, sensor.Temperature 
              from Sensors sensors join TempSensors sensor on sensors.SensorsId = sensor.SensorsId;
      COMMIT;

## CREATE VIEW MyTempLogs
      CREATE VIEW MyTempLogs AS select login.LoginName, sensor.Name, sensor.Room
      from Logins login join TempSensors sensor on sensor.SensorsId = login.Identifier;
## CREATE VIEW MyTempSensor 
      CREATE VIEW MyTempSensorAS select sensors.Name, sensor.Temperature
   	from Sensors sensors join TempSensors sensor on sensors.SensorsId = sensor.SensorsId;
      
      
