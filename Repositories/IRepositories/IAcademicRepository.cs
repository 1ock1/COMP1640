﻿using COMP1640.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640.Repositories.IRepositories
{
    public interface IAcademicRepository
    {
        public IEnumerable<Academic> GetAllAcademics();
        public Academic GetAcademicById(int id);
        public string CreateAcademic(Academic academic);
        public string UpdateAcademic(int id, Academic academic);
        public IActionResult DeleteAcademic(int id);

    }
}
