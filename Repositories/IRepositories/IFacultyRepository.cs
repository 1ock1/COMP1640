using System.Collections.Generic;
using COMP1640.Models;


namespace COMP1640.Repositories.IRepositories
{
    public interface IFacultyRepository
    {
        public IEnumerable<Falcuty> GetAllFaculties();
        public Falcuty GetFacultyById(int id);
        public string CreateFaculty(Falcuty faculty);
        public string UpdateFaculty(int id, Falcuty faculty);
        public string DeleteFaculty(int id);
    }
}
