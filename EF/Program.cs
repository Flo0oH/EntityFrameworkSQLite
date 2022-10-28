using System;

namespace EF
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Database CSV Converter Importer V_0.1");
            //Login registrieren
            TableInsert mytableinsert = new TableInsert();
            mytableinsert.DoImport(AbstractImport.Table.Logins);
            mytableinsert.DoImport(AbstractImport.Table.Sensors);
            mytableinsert.DoImport(AbstractImport.Table.TempSensors);

            MyNewClass myclass = new MyNewClass();
        }

    }
}
