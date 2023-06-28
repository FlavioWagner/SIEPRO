namespace SIEPRO.API.Application.Entities
{
    public class Pessoa
    {
        public string Id { get; private set; }
        public string Nome { get; set; }
        public string Registro { get; set; }
        public DateTime Cadastro { get; private set; }

        public Pessoa(string nome, String registro)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Registro = registro;
            Cadastro = DateTime.Now;
        }
    }
}
