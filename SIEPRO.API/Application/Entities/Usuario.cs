namespace SIEPRO.API.Application.Entities
{
    public class Usuario
    {
        public String Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime Cadastro { get; private set; }

        public Usuario(String nome) 
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Cadastro = DateTime.Now;
        }
    }
}
