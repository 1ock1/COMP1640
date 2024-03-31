namespace COMP1640.DTOs
{
    public class ReportDTO
    {
        public int StudentId { get; set; }
        public int TopicId { get; set; }
    }

    public class ReportRequestDTO
    {
        public int TopicId { get; set; }
        public string Status { get; set; }
    }

    public class ReportResponseDTO
    {
        public string ReportId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Quality { get; set; }
        public string LastDateComment { get; set; }
    }
    public class UpdateReportStatusDTO
    {
        public int ReportId { get; set; }
        public string Status { get; set; }
        public string? Quality { get; set; }
        public string Role { get; set; }
    }

    public class UploadNewReportDTO
    {
        public string GUID { get; set; }
        public int ReportID { get; set; }
    }
}
