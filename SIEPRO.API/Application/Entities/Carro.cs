namespace SIEPRO.API.Application.Entities
{
    public class Carro
    {
        public string Id { get; private set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public DateTime Cadastro { get; private set; }

        public Carro(string nome, string marca)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Marca = marca;
            Cadastro = DateTime.Now;
        }
    }
}
