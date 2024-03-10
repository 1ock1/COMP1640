namespace COMP1640.Models
{
    public class FileReport
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int ReportId { get; set; }
        public Report Report { get; set; }
    }
}
