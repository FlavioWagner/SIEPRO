using Microsoft.AspNetCore.Mvc;
using SIEPRO.API.Infrastructure.Data.Repositories;

namespace SIEPRO.API.UI.Controllers.Interfaces
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BasicController<T> : ControllerBase where T : class
    {
        public IRepository<T> _repository;

        public BasicController(IRepository<T> repository)
        {
            _repository = repository;
        }

        // GET: api/<PessoaController>
        [HttpGet]
        public IEnumerable<T> Get()
        {
            return _repository.GetAll();
        }

        // GET api/<PessoaController>/5
        [HttpGet("{id}")]
        public T Get(string id)
        {
            return _repository.Get(id);
        }

        // POST api/<PessoaController>
        [HttpPost]
        public void Post([FromBody] T value)
        {
            _repository.Add(value);
        }

        // PUT api/<PessoaController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] T value)
        {
            _repository.Update(id, value);
        }

        // DELETE api/<PessoaController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _repository.Remove(id);
        }
    }
}
