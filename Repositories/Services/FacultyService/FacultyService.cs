using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.Utils;
using System;
using System.Collections.Generic;

namespace COMP1640.Services
{
    public class FacultyService : IFacultyRepository
    {
        private readonly DataContext _dataContext;

        public FacultyService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public IEnumerable<Faculty> GetAllFaculty()
        {
            return _dataContext.Faculty;
        }

        public Faculty GetFacultyById(int id)
        {
            return _dataContext.Faculty.Find(id);
        }

        public Faculty CreateFaculty(Faculty faculty)
        {
            if (faculty == null)
                throw new ArgumentNullException(nameof(faculty));

            _dataContext.Faculty.Add(faculty);
            _dataContext.SaveChanges();

            return faculty;
        }

        public Faculty UpdateFaculty(int id, Faculty faculty)
        {
            if (faculty == null)
                throw new ArgumentNullException(nameof(faculty));

            var existingFaculty = _dataContext.Faculty.Find(id);
            if (existingFaculty == null)
                throw new KeyNotFoundException("Faculty not found");

            // Update faculty properties
            existingFaculty.Name = faculty.Name;
            // Update other properties as needed

            _dataContext.SaveChanges();

            return existingFaculty;
        }

        public bool DeleteFaculty(int id)
        {
            var faculty = _dataContext.Faculty.Find(id);
            if (faculty == null)
                return false;

            _dataContext.Faculty.Remove(faculty);
            _dataContext.SaveChanges();

            return true;
        }
    }
}
