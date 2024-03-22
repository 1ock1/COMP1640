using System.Collections.Generic;
using COMP1640.Models;

namespace COMP1640.Repositories.IRepositories
{
    public interface IFacultyRepository
    {
        IEnumerable<Faculty> GetAllFaculties();
        Faculty GetFacultyById(int id);
        void CreateFaculty(Faculty faculty);
        void UpdateFaculty(int id, Faculty faculty);
        void DeleteFaculty(int id);
    }
}
