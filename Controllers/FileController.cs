using COMP1640.DTOs;
using COMP1640.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace COMP1640.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileRepository _fileReporitory;
        private readonly IReportRepository _reportReporitory;
        private readonly IFileReportRepository _fileReportRepository;
        public FileController(IFileRepository fileReporitory, IReportRepository reportRepository, IFileReportRepository fileReportRepository)
        {
            this._fileReporitory = fileReporitory;
            this._reportReporitory = reportRepository;
            _fileReportRepository = fileReportRepository;
        }
        [HttpPost("CreateShareFile")]
        public async Task<ActionResult> CreateShareFile(string containerName)
        {
            var result = await _fileReporitory.CreateContainer(containerName);
            return Ok(result);
        }
        [HttpPost("UploadFile")]
        public async Task<ActionResult> UploadFile([FromForm] FileDTO form)
        {
            StringBuilder sb = new StringBuilder();
            string guid = await this._reportReporitory.CreateReportFirstTime(form.TopicId, form.StudentId, form.File.FileName, form.Type);
            sb.Append(guid);
            sb.Append(".docx");
            Console.WriteLine(guid);
            var result = await _fileReporitory.UploadFile(form.File, sb.ToString());
            Console.WriteLine(result);
            return StatusCode(200, guid);
        }
        [HttpDelete("{file}")]
        public async Task<ActionResult> DeleteFile(string file)
        {
            var result = await _fileReporitory.DeleteFile(file);
            return StatusCode(200, result);
        }
        [HttpGet("RetrieveContentBlob")]
        public async Task<ActionResult> RetrieveContentBlob(string file)
        {
            var result = await _fileReporitory.RetrieveContentBlob(file);
            return StatusCode(200, result);
        }
        [HttpGet("{file}")]
        public async Task<ActionResult> RetrieveDocument(string file)
        {
            var result = await _fileReporitory.RetrieveDocument(file);
            return StatusCode(200, result);
        }
        [HttpPost("SaveDocument")]
        [Microsoft.AspNetCore.Cors.EnableCors("hehe")]
        public async Task<ActionResult> SaveDocument([FromForm] SaveFileDTO dto)
        {
            Console.WriteLine(dto.Name);
            _fileReporitory.SaveDocument(dto);
            return StatusCode(200, "Success");
        }
        [HttpPost("UploadImages")]
        public async Task<ActionResult> UploadImages([FromForm] UploadImagesDTO dto)
        {
            Console.WriteLine(dto.Files.Count);
            Console.WriteLine(dto.ReportId);
            var listReports = await this._fileReportRepository.UploadImagesInDatabase(dto);
            var result = await this._fileReporitory.UploadMultipleImages(listReports);
            return StatusCode(200, result);
        }

        [HttpPost("IsReportSubmitted")]
        public async Task<ActionResult> IsReportSubmmited(ReportDTO dto)
        {
            var result = await this._reportReporitory.IsReportExistWithTopicId(dto);
            return StatusCode(200, result);
        }
    }
}
