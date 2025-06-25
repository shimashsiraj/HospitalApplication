namespace HospitalApplication.Models
{
    public class HomeViewModel
    {
        public List<Appointment> UpcomingAppointments { get; set; } = new();
        public int TotalAppointmentsToday { get; set; }
        public int PendingAppointments { get; set; }
    }
}
