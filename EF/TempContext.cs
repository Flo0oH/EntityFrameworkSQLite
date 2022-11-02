using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF
{
    public class TempContext:DbContext
    {
        public DbSet<TempSensor> TempSensors { get; set; }
        public DbSet<Sensors> Sensors { get; set; }
        public DbSet<Logins> Logins { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=DBLud_Temp_7.db");
        }
        /// <summary>
        /// Commands for new DB Build Process:
        /// Add-Migration MigrationNameV1.0.x -Project entiframe
        /// Update-Database -Project entiframe
        /// 
        /// DROP VIEW if exists MyTempSensor;
        ///  GO;

        /// DROP VIEW if exists MyTempLogs;
        /// CREATE VIEW MyTempLogs AS select login.LoginName, sensor.Name, sensor.Room
        /// from Logins login join TempSensors sensor on sensor.SensorsId = login.Identifier;
        /// CREATE VIEW MyTempSensor AS select sensors.Name, sensor.Temperature
        /// from Sensors sensors join TempSensors sensor on sensors.SensorsId = sensor.SensorsId;
        /// 
        /// DELETE FROM [Logins];
        /// DELETE FROM[Sensors];
        /// DELETE FROM[TempSensors];
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

        }

    }

    public class Logins
    {
        [Key]
        public int Identifier { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }

    }
    public class Sensors
    {
        public int SensorsId { get; set; }
        public string Name { get; set; }
        public string Room { get; set; }
        public int RoomNr { get; set; }
        public int? LoginId { get; set; }

        [ForeignKey("LoginsForeignKeys")]
        public virtual Logins Logins { get; set; }
    }
    public class TempSensor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Temperaturedate { get; set; }
        public float Temperature { get; set; }
        public int Sensornr { get; set; }
        public int? SensorsId { get; set; }

        [ForeignKey("SensorsForeignKey")]
        public virtual Sensors Sensors { get; set; }    

    }
}
