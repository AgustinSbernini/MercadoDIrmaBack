namespace mercado_dirma_backend.Models
{
    public class Appointment
    {
        public int IdAppointment { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
