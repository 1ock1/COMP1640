using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.Utils;


namespace COMP1640.Services
{
    public class FacultyService : IFacultyRepository
    {
        private readonly DataContext _dataContext;
        public FacultyService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public string CreateFaculty(Falcuty faculty)
        {
            _dataContext.Falcuties.Add(faculty);
            _dataContext.SaveChanges();
            return "Faculty created successfully";
        }

        public string DeleteFaculty(int id)
        {
            _dataContext.Falcuties.Remove(_dataContext.Falcuties.Find(id));
            _dataContext.SaveChanges();
            return "Faculty deleted successfully";
        }

        public IEnumerable<Falcuty> GetAllFaculties()
        {
            return _dataContext.Falcuties.ToList();
        }

        public Falcuty GetFacultyById(int id)
        {
            return _dataContext.Falcuties.Find(id);
        }

        public string UpdateFaculty(int id, Falcuty faculty)
        {
            _dataContext.Falcuties.Update(faculty);
            _dataContext.SaveChanges();
            return "Faculty updated successfully";
        }



    }
}
