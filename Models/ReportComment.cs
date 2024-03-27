using System.ComponentModel.DataAnnotations.Schema;

namespace COMP1640.Models
{
    public class ReportComment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date {  get; set; }
        public bool? IsEdited { get; set; }
        public int? PublishedReportId { get; set; }
        [ForeignKey("PublishedReportId")]
        public PublishedReport? PublishedReport { get; set; }
        public int? ReportId { get; set; }
        [ForeignKey("ReportId")]
        public Report? Report { get; set; }
        public int? ResponseForUserId { get; set; }
        [ForeignKey("ResponseForUserId")]
        public User? User { get; set; }
    }
}
