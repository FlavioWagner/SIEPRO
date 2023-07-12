namespace SIEPRO.API.Application.Entities
{
    public class Professor
    {
        public string Id{ get; private set; }
        public string Nome { get; set; }
        public string Materia { get; set; }
        public DateTime Cadastro { get; private set; }

        public Professor(string nome, string materia)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Materia = materia;
            Cadastro = DateTime.Now;
        }
    }
}
