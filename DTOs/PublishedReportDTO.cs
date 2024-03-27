using COMP1640.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP1640.DTOs
{
    public class PublishedReportDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public int ViewedNumber { get; set; }
        public int ReportId { get; set; }
    }
}
