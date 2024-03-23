using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.DTOs;

namespace COMP1640.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultyController(IFacultyRepository facultyRepository)
        {
            this._facultyRepository = facultyRepository;
        }

        [HttpGet]
        public IEnumerable<Falcuty> GetAllFaculties()
        {
            IEnumerable<Falcuty> faculties = _facultyRepository.GetAllFaculties();
            return faculties;
        }

        [HttpGet("{id}")]
        public IActionResult GetFacultyById(int id)
        {
            Falcuty faculty = _facultyRepository.GetFacultyById(id);
            if (faculty == null)
            {
                return NotFound();
            }
            return Ok(faculty);
        }

        [HttpPost]
        public Falcuty CreateFaculty(CreateFacultyDto faculty)
        {
            Falcuty newFaculty = new Falcuty();
            newFaculty.Name = faculty.Name;
            newFaculty.Status = faculty.Status;
            _facultyRepository.CreateFaculty(newFaculty);
            return newFaculty;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFaculty(int id, EditFacultyDto faculty)
        {
            Falcuty existingFaculty = _facultyRepository.GetFacultyById(id);
            if (existingFaculty == null)
            {
                return NotFound();
            }

            existingFaculty.Name = faculty.Name;
            existingFaculty.Status = faculty.Status;
                      

            // Update other properties as needed

            _facultyRepository.UpdateFaculty(id, existingFaculty);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFaculty(int id)
        {
            Falcuty faculty = _facultyRepository.GetFacultyById(id);
            if (faculty == null)
            {
                return NotFound();
            }

            _facultyRepository.DeleteFaculty(id);
            return NoContent();
        }
    }
}
