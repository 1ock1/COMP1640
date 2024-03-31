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
    }
}
