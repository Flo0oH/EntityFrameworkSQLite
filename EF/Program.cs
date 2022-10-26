using System;

namespace EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database CSV Converter!");
            //Neuen Temperaturwert anlegen
            Console.WriteLine("Inserting in TempSensorData");
            using(var database = new PersonContext())
            {
                database.Add(new TempSensor() { Name = "Sensor1", Temperature = 31, Temperaturedate = DateTime.Now.ToString(), Sensornr = 1 , SensorsId="1"});
                database.SaveChanges();


            }
            //Neuen Sensor registrieren
            Console.WriteLine("Inserting in Sensors");
            using (var database = new PersonContext())
            {
                database.Add(new Sensors() { Name = "Sensor1", Room="Wohnzimmer", RoomNr=1});
                database.SaveChanges();


            }
            Console.WriteLine("Finished in DBNull");

        }
    }
}
