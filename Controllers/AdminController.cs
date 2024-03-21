using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            this._adminRepository = adminRepository;
        }


        [HttpGet("GetAllUser")]
        public IEnumerable<User> GetAllUsers()
        {
            // Call the service to get all users
            IEnumerable<User> users = _adminRepository.GetAllUsers();
            return users;
        }

        private readonly FacultyManagementAPI _facultyManagementAPI;

        public AdminController(FacultyManagementAPI facultyManagementAPI)
        {
            _facultyManagementAPI = facultyManagementAPI;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Faculty>> GetAllFaculties()
        {
            return _facultyManagementAPI.GetAllFaculties().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Faculty> GetFacultyById(int id)
        {
            var faculty = _facultyManagementAPI.GetFacultyById(id);
            if (faculty == null)
            {
                return NotFound();
            }
            return faculty;
        }

        [HttpPost]
        public IActionResult CreateFaculty([FromBody] Faculty faculty)
        {
            _facultyManagementAPI.CreateFaculty(faculty.Name, faculty.Department);
            return CreatedAtAction(nameof(GetFacultyById), new { id = faculty.Id }, faculty);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFaculty(int id, [FromBody] Faculty faculty)
        {
            try
            {
                _facultyManagementAPI.UpdateFaculty(id, faculty.Name, faculty.Department);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFaculty(int id)
        {
            try
            {
                _facultyManagementAPI.DeleteFaculty(id);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
