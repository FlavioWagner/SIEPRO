using System;
using System.Collections.Generic;

namespace SIEPRO.Data.src.Application.Entities
{
    public partial class PessoaFisica
    {
        public long Id { get; set; }
        public DateOnly? DataNascimento { get; set; }
        public string? Rg { get; set; }
        public string? RgExpedidor { get; set; }
        public DateOnly? RgExpedicao { get; set; }
        public string? Titulo { get; set; }
        public string? TituloZona { get; set; }
        public string? TituloSecao { get; set; }
        public string? NomeMae { get; set; }
        public string? NomePai { get; set; }

        public virtual Pessoa IdNavigation { get; set; } = null!;
    }
}
