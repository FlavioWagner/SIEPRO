namespace SIEPRO.API.Application.Entities
{
    public class Medico
    {
        public string Id { get; private set; }
        public string Nome { get; set; }
        public int Crm { get; set; }
        public DateTime Criacao { get; private set;}
        public Medico(string nome, int crm)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Crm = crm;
            Criacao = DateTime.Now; 
        }
    }
}
