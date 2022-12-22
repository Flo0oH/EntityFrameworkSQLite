using System;
using System.Linq;

namespace EF
{
    internal class Program
    {
        public static string paths { get; private set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Database CSV Converter Importer V_0.1");
            //Login registrieren
            TableInsert mytablereading = new TableInsert();
            var loginids = mytablereading.ReadingIndex(AbstractImport.Table.Logins);
            var loginid = loginids.Count()+1;
            CsvConverter myconvert = new CsvConverter(paths);
            var mycsvdata = myconvert.readCsvToStringList(paths);
            for (int i = 0; i < 3; i++)
            {
                TableInsert mytableinsert = new TableInsert();
                mytableinsert.Import(AbstractImport.Table.Logins, loginid);
                mytableinsert.Import(AbstractImport.Table.Sensors, loginid);
                mytableinsert.Import(AbstractImport.Table.TempSensors, loginid);
                loginid++;
            }
            CsvReader myclass = new CsvReader();
        }
    }
}
