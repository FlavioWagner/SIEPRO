using Microsoft.AspNetCore.Mvc;
using SIEPRO.API.Application.Entities;
using SIEPRO.API.Infrastructure.Data.Repositories;
using SIEPRO.API.UI.Controllers.Interfaces;

namespace SIEPRO.API.UI.Controllers
{
    [ApiController]
    public class PessoaController : BasicCrudController<Pessoa>
    {
        public PessoaController(IRepository<Pessoa> repository) : base(repository)
        {

        }

        [HttpGet("teste")]
        public IEnumerable<Pessoa> GetPessoas()
        {
            return _repository.GetAll();
        }
    }
}
