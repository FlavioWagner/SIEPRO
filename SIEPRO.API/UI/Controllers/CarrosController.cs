using SIEPRO.API.Application.Entities;
using SIEPRO.API.Infrastructure.Data.Repositories;
using SIEPRO.API.UI.Controllers.Interfaces;

namespace SIEPRO.API.UI.Controllers
{
    public class CarrosController : BasicCrudController<Carro>
    {
        public CarrosController(IRepository<Carro> repository) : base(repository)
        {
        }
    }
}
