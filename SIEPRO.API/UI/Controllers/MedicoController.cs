using Microsoft.AspNetCore.Mvc;
using SIEPRO.API.Application.Entities;
using SIEPRO.API.Infrastructure.Data.Repositories;
using SIEPRO.API.UI.Controllers.Interfaces;

namespace SIEPRO.API.UI.Controllers
{
    [ApiController]
    public class MedicoController : BasicCrudController<Medico>
    {
        public MedicoController(IRepository<Medico> repository) : base(repository)
        {
        }

        [HttpGet("medico/{crm}")]
        public Medico GetMedico(int crm)
        {
            var medico = from m in _repository.GetAll()
                         where m.Crm.Equals(crm)
                         select m;

            return medico.FirstOrDefault();
        }
    }
}
