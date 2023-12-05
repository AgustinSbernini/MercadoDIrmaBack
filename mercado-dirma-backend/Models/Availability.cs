namespace mercado_dirma_backend.Models
{
    public class Availability
    {
        public int IdAvailability { get; set; }
        public Day IdAvailableDay { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
        public bool Active { get; set; }
        
    }
}
