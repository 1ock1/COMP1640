namespace COMP1640.DTOs
{
    public class FileReportDTO
    {
        public string Id { get; set; }
        public IFormFile File { get; set; }
    }

    public class DocumentImagesDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class ReportImagesDTO
    {
        public int ReportId { get; set; }
        public string Type { get; set; }
    }

    public class FileReportResponseDTO
    {
        public string Id { get; set; }
        public string Type { get; set; }
    }

    public class ResourceDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
