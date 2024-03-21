using COMP1640.Models;

namespace COMP1640.Repositories.IRepositories
{
    public interface IAdminRepository
    {
        public IEnumerable<User> GetAllUsers();
    }

    public interface FacultyManagementAPI
    {
        public IEnumerable<Faculty> GetAllFaculties();

        public IEnumerable<Faculty> GetFacultyByID(int id);


    }
}
