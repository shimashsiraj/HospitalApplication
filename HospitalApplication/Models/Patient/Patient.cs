namespace HospitalApplication.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? PasswordHash { get; set; } // If not using Identity
        public ICollection<Appointment> Appointments { get; set; }
    }
}
