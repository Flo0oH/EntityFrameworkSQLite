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
        public abstract void DoImport(Table mytable);
    }
}