namespace COMP1640.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string? Quality { get; set; }
        public DateTime LastDateComment { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public int StudentId { get; set; }
        public User User { get; set; }
        public List<FileReport> FileReports { get; set; }
        public List<PublishedReport> PublishedReports { get; set; }
        public List<ReportComment> ReportComments { get; set; }
    }
}
