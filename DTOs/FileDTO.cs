namespace COMP1640.DTOs
{
    public class FileDTO
    {
        public string Type { get; set; }
        public int TopicId { get; set; }
        public int StudentId { get; set; }
        public IFormFile File { get; set; }
    }
}
