namespace HealthCare_app.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int HealthcareProviderId { get; set; }
        public virtual HealthcareProvider HealthcareProvider { get; set; } 
        public string Purpose { get; set; }
        public string GMapsHospitalUrl { get; set; }
    }
}
