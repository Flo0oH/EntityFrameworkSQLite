using System;
using System.Collections.Generic;

namespace EF
{
    internal class TableInsert : AbstractImport
    {
        /// <summary>
        /// Methode zum schreiben in eine Datenbank für speziel die Tabelen die im Enum mytable übergeben werden. Bitte entsprechend nachpfelchen
        /// Kein Rückgabetyp notwendig -> Consolenausgabe wenn es geklappt hat.
        /// </summary>
        /// <param name="mytable"></param>
        /// <param name="loginid"></param>
        public override void Import(Table mytable, int loginid, IEnumerable<string[]> importdata)
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
                            foreach (var datablock in importdata)
                            {
                                database.Add(new TempSensor() { Name = "Sensor_1_test", Temperature = float.Parse(datablock[1]), Temperaturedate = datablock[0].ToString(), Sensornr = 1, Id = loginid, SensorsId = 1 });
                                database.SaveChanges();
                                Console.WriteLine("Sensor_" + loginid.ToString());
                                loginid++;
                            }
                   
                           Console.WriteLine("Done");
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Methode zum lesen von Daten in einer Datenbank Tabelle die durch das Enum festgelegt wird. 
        /// Rückgabetype ist eine List<Int>()</Int>
        /// </summary>
        /// <param name="mytable"></param>
        /// <returns></returns>
        public override List<int> ReadingIndex(Table mytable)
        {
            TableInsert mytableinsert = new TableInsert();
            Console.WriteLine("Inserting in " + mytable.ToString());
            var loginNow = "AutomaticImportV_0.1_" + DateTime.Now.ToString();
            using (var database = new TempContext())
            {
                var logins = new List<int>();
                var sensors = new List<int>();
                var tempSensors = new List<int>();
                switch (mytable)
                {
                    case Table.Logins:
                        {
                            Console.WriteLine("Reading index in Logins");
                            foreach (var Logins in database.Logins)
                            {
                                logins.Add(Logins.Identifier);
                            }
                            Console.WriteLine("Done");
                            
                        }
                        return logins;
                    case Table.TempSensors:
                        {
                            Console.WriteLine("Reading index in Sensors");
                            foreach (var sensor in database.Sensors)
                            {
                                sensors.Add(sensor.SensorsId);
                            }
                            Console.WriteLine("Done");
                        }
                        return null;
                    case Table.Sensors:
                        {
                            Console.WriteLine("Reading index in TempSensorData");
                            foreach (var tempsensor in database.TempSensors)
                            {
                                tempSensors.Add(tempsensor.Id);
                            }
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