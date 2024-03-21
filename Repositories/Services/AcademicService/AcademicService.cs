using COMP1640.Models;
using COMP1640.Repositories.IRepositories;
using COMP1640.Utils;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640.Repositories.Services.AcademicService
{
    public class AcademicService: IAcademicRepository
    {
        private readonly DataContext _datacontex;
        public AcademicService(DataContext datacontex)
        {
            this._datacontex = datacontex;
        }

        public IActionResult CreateAcademic(Academic academic)
        {
            _datacontex.Academics.Add(academic);
            _datacontex.SaveChanges();
            return new OkResult();
        }

        public IActionResult DeleteAcademic(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Academic> GetAllAcademics()
        {
            return _datacontex.Academics.ToList();
        }

        public Academic GetAcademicById(int id)
        {
            return _datacontex.Academics.Find(id);
        }

        public IActionResult UpdateAcademic(int id, Academic academic)
        {
            _datacontex.Academics.Update(academic);
            _datacontex.SaveChanges();
            return new OkResult();
        }

    }
}
