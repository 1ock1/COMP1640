namespace COMP1640.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string? Avatar { get; set; }
        public int? FalcutyId { get; set; }
        public Falcuty? Falcuty { get; set; }
        public string Status { get; set; }
        public List<Report> Reports { get; set; }
        public List<ReportComment> ReportComments { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
