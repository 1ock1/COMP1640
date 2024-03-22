﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using COMP1640.Models;
using COMP1640.Repositories.IRepositories;

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
        public IEnumerable<Faculty> GetAllFaculties()
        {
            IEnumerable<Faculty> faculties = _facultyRepository.GetAllFaculties();
            return faculties;
        }

        [HttpGet("{id}")]
        public IActionResult GetFacultyById(int id)
        {
            Faculty faculty = _facultyRepository.GetFacultyById(id);
            if (faculty == null)
            {
                return NotFound();
            }
            return Ok(faculty);
        }

        [HttpPost]
        public IActionResult CreateFaculty(Faculty faculty)
        {
            _facultyRepository.CreateFaculty(faculty);
            return CreatedAtAction(nameof(GetFacultyById), new { id = faculty.Id }, faculty);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFaculty(int id, Faculty faculty)
        {
            Faculty existingFaculty = _facultyRepository.GetFacultyById(id);
            if (existingFaculty == null)
            {
                return NotFound();
            }

            existingFaculty.Name = faculty.Name;
            existingFaculty.Status = faculty.Status;
            existingFaculty.Id = faculty.Id;

            // Update other properties as needed

            _facultyRepository.UpdateFaculty(id, existingFaculty);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFaculty(int id)
        {
            Faculty faculty = _facultyRepository.GetFacultyById(id);
            if (faculty == null)
            {
                return NotFound();
            }

            _facultyRepository.DeleteFaculty(id);
            return NoContent();
        }
    }
}
