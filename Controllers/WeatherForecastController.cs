using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost("CreateShareFile")]
        public async Task<ActionResult> CreateShareFile(string containerName)
        {
            var result = await _userRepository.CreateContainer(containerName);
            return Ok(result);
        }
        [HttpPost("UploadFile")]
        public async Task<ActionResult> UploadFile(IFormFile file)
        {
            var result = await _userRepository.UploadFile(file);
            return StatusCode(200, result);
        }
        [HttpDelete("DeleteFile")]
        public async Task<ActionResult> DeleteFile(string file)
        {
            var result = await _userRepository.DeleteFile(file);
            return StatusCode(200, result);
        }
        [HttpGet("RetrieveContentBlob")]
        public async Task<ActionResult> RetrieveContentBlob(string file)
        {
            var result = await _userRepository.RetrieveContentBlob(file);
            return StatusCode(200, result);
        }
        [HttpGet("RetrieveDocument")]
        public async Task<ActionResult> RetrieveDocument()
        {
            var result = await _userRepository.RetrieveDocument();
            return StatusCode(200, result);
        }
        [HttpGet("RetrieveDocumentCC2")]
        public async Task<ActionResult> RetrieveDocumentCC2()
        {
            var result = await _userRepository.RetrieveDocumentCC2();
            return StatusCode(200, result);
        }
    }
}
