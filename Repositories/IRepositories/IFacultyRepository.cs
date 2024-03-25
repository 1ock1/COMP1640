using COMP1640.Models;
using System.Collections.Generic;

namespace COMP1640.Repositories.IRepositories
{
    public interface IFacultyRepository
    {
        IEnumerable<Faculty> GetAllFaculty();
        Faculty GetFacultyById(int id);
        Faculty CreateFaculty(Faculty faculty);
        Faculty UpdateFaculty(int id, Faculty faculty);
        bool DeleteFaculty(int id);
    }
}

