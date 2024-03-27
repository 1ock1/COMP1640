using COMP1640.Models;

namespace COMP1640.DTOs
{
    public class ReportCommentDTO
    {
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool? IsEdited { get; set; }
        public int? PublishedReportId { get; set; }
        public int? ReportId { get; set; }
        public int? ResponseForUserId { get; set; }
    }
    public class ReportCommentRequestDTO
    {
        public int? PublishedReportId { get; set; }
        public int? ReportId { get; set; }
        public int? ResponseForUserId { get; set; }
    }

    public class ReportCommentResponseDTO
    {
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
