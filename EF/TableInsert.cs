using System;

namespace EF
{
    internal class TableInsert : AbstractImport
    {
        public override string DBName => throw new System.NotImplementedException();

        public override void DoImport(Table mytable)
        {
            TableInsert mytableinsert = new TableInsert();
            Console.WriteLine("Inserting in " + mytable.ToString());
            var loginNow = "AutomaticImportV_0.1_" + DateTime.Now.ToString();
            using (var database = new PersonContext())
            {
                switch (mytable)
                {
                    case Table.Logins:
                        {
                            Console.WriteLine("Inserting in Logins");
                            database.Add(new Logins() { LoginName = loginNow, Password = "**********" });
                            database.SaveChanges();
                            Console.WriteLine("Done");
                        }
                        break;
                    case Table.Sensors:
                        {
                            Console.WriteLine("Inserting in TempSensorData");
                            database.Add(new TempSensor() { Name = "Sensor1", Temperature = 31, Temperaturedate = DateTime.Now.ToString(), Sensornr = 1, SensorsId = "1" });
                            database.SaveChanges();
                            Console.WriteLine("Done");
                        }
                        break;
                    case Table.TempSensors:
                        {
                            Console.WriteLine("Inserting in Sensors");
                            database.Add(new Sensors() { Name = "Sensor1", Room = "Wohnzimmer", RoomNr = 1 });
                            database.SaveChanges();
                            Console.WriteLine("Done");
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}