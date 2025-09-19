namespace CareFlowX.Api.Models
{
    // Represents a referral in the healthcare system.
    public class Referral
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string Provider { get; set; }
        public string Status { get; set; }
        public string? Notes { get; set; }
        public DateTime DateCreated { get; set; }
    }
}