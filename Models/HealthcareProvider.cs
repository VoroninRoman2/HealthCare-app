﻿namespace HealthCare_app.Models
{
    public class HealthcareProvider
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
