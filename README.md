# Import Data from a Templogger CSV File into an SQLite DB with C# Entity Framework. 

CREATE VIEW MyTempLogs AS select login.LoginName, sensor.Name, sensor.Room
      from Logins login join TempSensors sensor on sensor.SensorsId = login.Identifier;
CREATE VIEW MyTempSensor AS select sensors.Name, sensor.Temperature
   	  from Sensors sensors join TempSensors sensor on sensors.SensorsId = sensor.SensorsId;
      
      
