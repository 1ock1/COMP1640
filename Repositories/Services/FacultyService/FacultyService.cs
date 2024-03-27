using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.DTOs;
using System;
using System.Collections.Generic;

namespace COMP1640.Services {
            public class FacultyService
            {
                private readonly IFacultyRepository _facultyRepository;

                public FacultyService(IFacultyRepository facultyRepository)
                {
                    _facultyRepository = facultyRepository;
                }

                public IEnumerable<Falcuty> GetAllFaculties()
                {
                    return _facultyRepository.GetAllFaculties();
                }

                public Falcuty GetFacultyById(int id)
                {
                    return _facultyRepository.GetFacultyById(id);
                }

                public void CreateFaculty(CreateFacultyDto facultyDto)
                {
                    var faculty = new Falcuty
                    {
                        Name = facultyDto.Name,
                        Status = facultyDto.Status,
                    };
                    _facultyRepository.CreateFaculty(faculty);
                }

                public void UpdateFaculty(int id, EditFacultyDto facultyDto)
                {
                    // You can add business logic/validation here before updating faculty
                    var existingFaculty = _facultyRepository.GetFacultyById(id);
                    if (existingFaculty == null)
                    {
                        throw new ArgumentException("Faculty not found");
                    }

                    existingFaculty.Name = facultyDto.Name;
                    existingFaculty.Status = facultyDto.Status;
                    // Map other properties as needed

                    _facultyRepository.UpdateFaculty(id, existingFaculty);
                }

                public void DeleteFaculty(int id)
                {
                    // You can add business logic/validation here before deleting faculty
                    _facultyRepository.DeleteFaculty(id);
                }
            }
}
