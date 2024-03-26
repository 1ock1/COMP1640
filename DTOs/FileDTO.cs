namespace COMP1640.DTOs
{
    public class FileDTO
    {
        public string Type { get; set; }
        public int TopicId { get; set; }
        public int StudentId { get; set; }
        public IFormFile File { get; set; }
    }

    public class SaveFileDTO
    {
        public IFormCollection data { get; set; }
        public string Name { get; set; }
    }

    public class UploadImagesDTO
    {
        public List<IFormFile> Files { get; set; }
        public int ReportId { get; set; }
    }
}
