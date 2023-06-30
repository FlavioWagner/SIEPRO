using Microsoft.AspNetCore.Mvc;
using SIEPRO.API.Infrastructure.Data.Repositories;

namespace SIEPRO.API.UI.Controllers.Interfaces
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BasicCrudController<T> : ControllerBase where T : class
    {
        public IRepository<T> _repository;

        public BasicCrudController(IRepository<T> repository)
        {
            _repository = repository;
        }

        // GET: api/<PessoaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            return Ok( _repository.GetAll() );
        }

        // GET api/<PessoaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(string id)
        {
            return Ok(_repository.Get(id));
        }

        // POST api/<PessoaController>
        [HttpPost]
        public async Task<ActionResult<T>> Post([FromBody] T value)
        {
            return _repository.Add(value);
        }

        // PUT api/<PessoaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Put(string id, [FromBody] T value)
        {
            return Ok( _repository.Update(id, value) );
        }

        // DELETE api/<PessoaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            return Ok(_repository.Remove(id));
        }
    }
}
