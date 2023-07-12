using Microsoft.AspNetCore.Mvc;
using SIEPRO.API.Application.Entities;
using SIEPRO.API.Infrastructure.Data.Repositories;
using SIEPRO.API.UI.Controllers.Interfaces;

namespace SIEPRO.API.UI.Controllers
{
    [ApiController]
    public class CidadeController : BasicController<Cidade>
    {
        public CidadeController(IRepository<Cidade> repository) : base(repository)
        {
        }
    }
}
