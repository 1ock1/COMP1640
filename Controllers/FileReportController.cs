using COMP1640.DTOs;
using COMP1640.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileReportController : ControllerBase
    {
        private readonly IFileReportRepository fileReportRepository;
        public FileReportController(IFileReportRepository fileReportRepository)
        {
            this.fileReportRepository = fileReportRepository;
        }
        [HttpPost("GetDocumentId")]
        public async Task<ActionResult> GetDocumentId(int reportId)
        {
            var result = this.fileReportRepository.GetDocumentId(reportId);
            return StatusCode(200, result);
        }
        [HttpPost("GetDocumentImages")]
        public async Task<ActionResult> GetDocumentImages(ReportImagesDTO dto)
        {
            var result = await this.fileReportRepository.GetDocumentImages(dto);
            return StatusCode(200, result);
        }
        [HttpPost("GetAllFileOfOneReport")]
        public  ActionResult GetAllFileOfOneReport(int reportId)
        {
            var result = this.fileReportRepository.GetAllFileOfOneReport(reportId);
            return StatusCode(200, result);
        }
    }
}
