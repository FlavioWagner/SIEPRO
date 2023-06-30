namespace SIEPRO.API.Application.Entities
{
    public class Cidade
    {
        public Cidade(string nome, string uf)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Uf = uf;
            Cadastro = DateTime.Now;
        }

        public string Id { get; private set; }
        public string Nome  { get; set; }
        public string Uf { get; set; }
        public DateTime Cadastro { get; private set; }
    }
}
