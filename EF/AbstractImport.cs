using System.Collections.Generic;

namespace EF
{
    abstract class AbstractImport
    {
       
        /// <summary>
        /// Abstracte Klasse um die Grundfunktionen der Tabellen die möglicherweise gelesen und geschrieben werden zu bestimmen.
        /// Bitte immer nachpflegen wenn das Datenbankmodell geändert wird.
        /// </summary>
        public enum Table
        {
            Logins,
            Sensors,
            TempSensors
        }
        public abstract void Import(Table mytable, int loginid, IEnumerable<string[]> data);
        public abstract List<int> ReadingIndex(Table mytable);
    }
}