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
        public Academic CreateAcademic(CreateAcademic academic)
        {
            Academic newAcademic = new Academic();

            newAcademic.StartDate = academic.StartDate;
            newAcademic.EndDate = academic.EndDate;

            _academicRepository.CreateAcademic(newAcademic);
            return newAcademic ;
        }

        [HttpPut("UpdateAcademic")]
        public Academic UpdateAcademic(int id, UpdateAcademic academic)
        {
            Academic academicInformation = _academicRepository.GetAcademicById(id);
            academicInformation.StartDate = academic.StartDate;
            academicInformation.EndDate = academic.EndDate;

            _academicRepository.UpdateAcademic(id, academicInformation);
            return academicInformation;
        }

        [HttpDelete("DeleteAcademic")]
        public string DeleteAcademic(int id)
        {
           
            _academicRepository.DeleteAcademic(id);
            return "Deleted successfully";
        }
    }
}
