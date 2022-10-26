using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF
{
    public class PersonContext:DbContext
    {
        public DbSet<TempSensor> TempSensors { get; set; }
        public DbSet<Sensors> Sensors { get; set; }
        public DbSet<Logins> Logins { get; set; }
        public DbSet<FluentApiTable> FluentApiTable { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite("Data Source=DBLud.db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FluentApiTable>().HasKey(a => a.Identifier);
            modelBuilder.Entity<FluentApiTable>().Property(a => a.Name).IsRequired().HasColumnName("MyName");
            
            //ModelBuilder um das System zu ändern 
            //modelBuilder.Entity<TempSensor>().ToTable("PapasTempSensor");
            var mySensors = modelBuilder.Entity<Sensors>();
            //mySensors.ToTable("olderSensors");

            //ID
            //var mySensorIDs = mySensors.HasKey(b => b.SensorsId);
            //var nonames = mySensors.Ignore(b => b.Name);
            
            //Setze die maximale column Char Anzahl auf max 30 Stellen
            mySensors.Property(b => b.SensorsId).HasMaxLength(30);
            mySensors.Property(b => b.Name).HasMaxLength(30);
            //var SuchenachSensors2 = mySensors.HasOne(b => b.Name).GetType().Name.CompareTo("Sensor2");


            modelBuilder.Entity<Logins>().Property(a => a.Identifier).HasColumnType("Int");
        }


    }

    public class FluentApiTable
    {
        public int Identifier { get; set; }
        public string Name { get; set; }
    }


    public class TempSensor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Temperaturedate { get; set; }
        public float Temperature { get; set; }
        public int Sensornr { get; set; }

        [Required]
        public string SensorsId { get; set; }   

    }

    public class Sensors
    {
        
        public int SensorsId { get; set; }   
        public string Name { get; set; }
        public string Room { get; set; }
        public int RoomNr { get; set; }


    }

    public class Logins
    {
        [Key]
        public int Identifier { get; set; }
        public string LoginName { get; set; }

        public string Password { get; set; }

    }

}
