using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static COMP1640.DTOs.AcademicDTOs;

namespace COMP1640.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicController : ControllerBase
    {
        private readonly IAcademicRepository _academicRepository;

        public AcademicController(IAcademicRepository academicRepository)
        {
            this._academicRepository = academicRepository;
        }

        [HttpGet("GetAllAcademic")]
        public IEnumerable<Academic> GetAllAcademics()
        {
            // Call the service to get all academics
            IEnumerable<Academic> academics = _academicRepository.GetAllAcademics();
            return academics;
        }

        [HttpGet("GetAcademicById")]
        public Academic GetAcademicById(int id)
        {
            // Call the service to get academic by id
            Academic academic = _academicRepository.GetAcademicById(id);
            return academic;
        }

        [HttpPost("CreateAcademic")]
        public IActionResult CreateAcademic(CreateAcademic academic)
        {
            Academic newAcademic = new Academic();

            newAcademic.StartDate = academic.StartDate;
            newAcademic.EndDate = academic.EndDate;


            return _academicRepository.CreateAcademic(newAcademic);
        }

        [HttpPut("UpdateAcademic")]
        public IActionResult UpdateAcademic(int id, UpdateAcademic academic)
        {
            Academic academicInformation = _academicRepository.GetAcademicById(id);
            academicInformation.StartDate = academic.StartDate;
            academicInformation.EndDate = academic.EndDate;

            return _academicRepository.UpdateAcademic(id, academicInformation);
        }
    }
}
