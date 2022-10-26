using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class TempSensor2
    {
        public DbSet<TempSensor2> TempSensors { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }    
        public string Temperaturedate { get; set; }    
        public float Temperature { get; set; }  
        public int  sensornr { get; set; }

    }
}