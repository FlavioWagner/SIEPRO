namespace SIEPRO.Data.src.Domain.Entities
{
    public partial class Pessoa
    {
        public long Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Registro { get; set; } = null!;
        public DateTime? DataCadastro { get; set; }

        public virtual PessoaFisica? PessoaFisica { get; set; }
        public virtual PessoaJuridica? PessoaJuridica { get; set; }
    }
}
