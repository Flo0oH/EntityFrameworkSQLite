using System;
using System.Collections.Generic;

namespace EF
{
    internal class TableInsert : AbstractImport
    {
        public override string DBName => throw new System.NotImplementedException();

        public override void Import(Table mytable, int loginid)
        {
            TableInsert mytableinsert = new TableInsert();
            Console.WriteLine("Inserting in " + mytable.ToString());
            var loginNow = "AutomaticImportV_0.1_" + DateTime.Now.ToString();
            using (var database = new TempContext())
            {
                switch (mytable)
                {
                    case Table.Logins:
                        {
                            Console.WriteLine("Inserting in Logins");
                            database.Add(new Logins() { LoginName = loginNow, Password="myludpw", Identifier=loginid });
                            database.SaveChanges();
                            Console.WriteLine("Done");
                        }
                        break;
                    case Table.TempSensors:
                        {
                            Console.WriteLine("Inserting in Sensors");
                            database.Add(new Sensors() { Name = "Sensor_" + loginid.ToString(), Room = "Wohnzimmer", RoomNr = 1, LoginId=loginid});
                            database.SaveChanges();
                            Console.WriteLine("Done");
                        }
                        break;
                    case Table.Sensors:
                        {
                            Console.WriteLine("Inserting in TempSensorData");
                            database.Add(new TempSensor() { Name = "Sensor_" + loginid.ToString(), Temperature = DateTime.Now.Second, Temperaturedate = DateTime.Now.ToString(), Sensornr = 1, Id = loginid, SensorsId=loginid } );
                            database.SaveChanges();
                            Console.WriteLine("Done");
                        }
                        break;

                    default:
                        break;
                }
            }
        }
        public override List<int> ReadingIndex(Table mytable)
        {
            TableInsert mytableinsert = new TableInsert();
            Console.WriteLine("Inserting in " + mytable.ToString());
            var loginNow = "AutomaticImportV_0.1_" + DateTime.Now.ToString();
            using (var database = new TempContext())
            {
                var logins = new List<int>();
                switch (mytable)
                {
                    case Table.Logins:
                        {
                            Console.WriteLine("Inserting in Logins");
                            foreach (var Logins in database.Logins)
                            {
                                logins.Add(Logins.Identifier);
                            }
                            Console.WriteLine("Done");
                            
                        }
                        return logins;
                    case Table.TempSensors:
                        {
                            Console.WriteLine("Inserting in Sensors");
                 
                            Console.WriteLine("Done");
                        }
                        return null;
                    case Table.Sensors:
                        {
                            Console.WriteLine("Inserting in TempSensorData");
                  
                            Console.WriteLine("Done");
                        }
                        return null;

                    default:
                        return null;
                }
            }
        }
    }
}