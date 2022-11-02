using System.Collections.Generic;

namespace EF
{
    abstract class AbstractImport
    {
        public abstract string DBName { get; }

        public enum Table
        {
            Logins,
            Sensors,
            TempSensors
        }
        public abstract void Import(Table mytable, int loginid);
        public abstract List<int> ReadingIndex(Table mytable);
    }
}