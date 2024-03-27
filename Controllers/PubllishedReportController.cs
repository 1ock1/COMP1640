using COMP1640.DTOs;
using COMP1640.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PubllishedReportController : ControllerBase
    {
        private readonly IPublishedReportRepository _publishedReportRepository;
        public PubllishedReportController(IPublishedReportRepository publishedReportRepository)
        {
            _publishedReportRepository = publishedReportRepository;
        }
        [HttpPost("CreatePublishedReport")]
        public async Task<ActionResult> CreatePublishedReport(PublishedReportDTO dto)
        {
            var result = await this._publishedReportRepository.CreatePublishedReport(dto);
            return StatusCode(200, result);
        }
        [HttpGet("GetAllPublishedReport")]
        public async Task<ActionResult> GetAllPublishedReport()
        {
            var result = await this._publishedReportRepository.GetPublishedReport();
            return StatusCode(200, result);
        }
    }
}
