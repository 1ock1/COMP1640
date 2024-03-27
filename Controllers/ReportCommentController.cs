using COMP1640.DTOs;
using COMP1640.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportCommentController : ControllerBase
    {
        private readonly IReportCommentRepository _repository;
        public ReportCommentController(IReportCommentRepository repository)
        {
            _repository = repository;
        }
        [HttpPost("CreateComment")]
        public async Task<ActionResult> CreateComment(ReportCommentDTO dto)
        {
            var result = await this._repository.CreateComment(dto);
            return StatusCode(200, result);
        }
        [HttpPost("GetCommentReport")]
        public async Task<ActionResult> GetCommentReport(ReportCommentRequestDTO dto)
        {
            var result = await this._repository.GetComments(dto);
            return StatusCode(200, result);
        }
        [HttpPost("GetCommentPublishedReport")]
        public async Task<ActionResult> GetCommentPublishedReport(ReportCommentRequestDTO dto)
        {
            var result = await this._repository.GetComments(dto);
            return StatusCode(200, result);
        }
    }
}
