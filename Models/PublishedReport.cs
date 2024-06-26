﻿using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("ReportId")]
        public Report Report { get; set; }
        public virtual List<ReportComment> ReportComments { get; set; }
    }
}
