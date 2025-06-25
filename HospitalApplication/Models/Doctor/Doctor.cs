namespace HospitalApplication.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public TimeSpan AvailableFrom { get; set; }
        public TimeSpan AvailableTo { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
