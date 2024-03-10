using Microsoft.Identity.Client;

namespace COMP1640.Models
{
    public class PublishedReport
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public int ViewedNumber { get; set; }
        public int ReportId { get; set; }
        public Report Report { get; set; }
        public List<ReportComment> ReportComments { get; set; }
    }
}
