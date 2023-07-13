using Microsoft.AspNetCore.Mvc;
using SIEPRO.API.Application.Entities;
using SIEPRO.API.Infrastructure.Data.Repositories;
using SIEPRO.API.UI.Controllers.Interfaces;

namespace SIEPRO.API.UI.Controllers
{
    public class ProfessorController : BasicCrudController<Professor>
    {
        public ProfessorController(IRepository<Professor> repository) : base(repository)
        {
        }

        [HttpGet("nome")]
        public IEnumerable<Professor> GetProfessors()
        {
            return _repository.GetAll();
        }
    }
}
