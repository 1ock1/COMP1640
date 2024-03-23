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
        public FileController(IFileRepository fileReporitory, IReportRepository reportRepository)
        {
            this._fileReporitory = fileReporitory;
            this._reportReporitory= reportRepository;
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
            return StatusCode(200, result);
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
        public async Task<ActionResult> SaveDocument(IFormCollection data)
        {
            _fileReporitory.SaveDocument(data);
            return StatusCode(200, "Success");
        }
        [HttpPost("UploadImages")]
        public async Task<ActionResult> UploadImages(List<IFormFile> files)
        {
            Console.WriteLine(files.Count);
            var result = await this._fileReporitory.UploadMultipleImages(files);
            return StatusCode(200, result);
        }
    }
}
