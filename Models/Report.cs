using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("StudentId")]
        public User User { get; set; }
        public virtual List<FileReport> FileReports { get; set; }
        public virtual List<PublishedReport> PublishedReports { get; set; }
        public virtual List<ReportComment> ReportComments { get; set; }
    }
}
