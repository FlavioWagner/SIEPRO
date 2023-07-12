namespace SIEPRO.API.Application.Entities
{
    public class Cidade
    {
        public Cidade(string nome, string uF)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            UF = uF;
            Cadastro = DateTime.Now;
        }

        public string Id { get; private set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public DateTime Cadastro { get; private set;}
    }
}
