using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIEPRO.API.Application.Entities;
using SIEPRO.API.Infrastructure.Data.Repositories;
using SIEPRO.API.UI.Controllers.Interfaces;

namespace SIEPRO.API.UI.Controllers
{
    [ApiController]
    public class UsuarioController : BasicCrudController<Usuario>
    {
        public UsuarioController(IRepository<Usuario> repository) : base(repository)
        {
        }

        [HttpGet("buscar")]
        public IEnumerable<Usuario> GetUsuarios()
        {
            return _repository.GetAll();
        }
    }
}
