using COMP1640.DTOs;
using COMP1640.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository reportRepository;
        public ReportController(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }
        [HttpPost("GetReportBaseStatus")]
        public ActionResult GetReportBaseStatus(ReportRequestDTO reportRequestDTO)
        {
            var result = this.reportRepository.GetListReportBaseStatus(reportRequestDTO);
            return StatusCode(200, result);
        }
        [HttpPost("GetReportInformation")]
        public ActionResult GetReportInformation(int reportId)
        {
            var result = this.reportRepository.GetReportInformation(reportId);
            return StatusCode(200, result);
        }
        [HttpPut("UpdateReportStatus")]
        public ActionResult GetReportInformation(UpdateReportStatusDTO dto)
        {
            var result = this.reportRepository.UpdateReportStatus(dto);
            return StatusCode(200, result);
        }
        [HttpPost("TotalContribution")]
        public ActionResult TotalContribution(DashboardManagerRequestDTO dto)
        {
            var result = this.reportRepository.TotalContributionOfFacultyPerAcademic(dto);
            return StatusCode(200, result);
        }
        [HttpPost("PercentageSubmission")]
        public ActionResult PercentageSubmission(DashboardManagerRequestDTO dto)
        {
            var result = this.reportRepository.SubmissionPercentageOfFacultyPerAcademic(dto);
            return StatusCode(200, result);
        }
        [HttpGet("CommentStatusOfTopic/{topicId}")]
        public ActionResult CheckCommentStatus(int topicId)
        {
            var result = this.reportRepository.CheckReportComment(topicId);
            return StatusCode(200, result);
        }
        [HttpPost("TopicStatus")]
        public ActionResult ListTopicsStatusOfFacultyOnAcademic(DashboardManagerRequestDTO dto)
        {
            var result = this.reportRepository.ListTopicsStatusOfFacultyPerAcademic(dto);
            return StatusCode(200, result);
        }
        [HttpPost("TotalReportOnTopicBaseStatus")]
        public ActionResult TotalReportOnTopicBaseStatus(OneStatusOfTopicDTO dto)
        {
            var result = this.reportRepository.TotalOfOneStatusOnTopic(dto);
            return StatusCode(200, result);
        }
        [HttpPost("PercentagePublishedReport")]
        public ActionResult PercentagePublishedReport(DashboardManagerRequestDTO dto)
        {
            var result = this.reportRepository.PublishedReportRating(dto);
            return StatusCode(200, result);
        }
        [HttpPost("TotalContributor")]
        public ActionResult TotalContributor(DashboardManagerRequestDTO dto)
        {
            var result = this.reportRepository.TotalContributorOnAcademicAndFaculty(dto);
            return StatusCode(200, result);
        }
    }
}
