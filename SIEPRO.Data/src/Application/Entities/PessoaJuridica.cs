using System;
using System.Collections.Generic;

namespace SIEPRO.Data.src.Application.Entities
{
    public partial class PessoaJuridica
    {
        public PessoaJuridica()
        {
            RamoJuridica = new HashSet<RamoJuridica>();
        }

        public long Id { get; set; }
        public string? NomeFantasia { get; set; }

        public virtual Pessoa IdNavigation { get; set; } = null!;
        public virtual ICollection<RamoJuridica> RamoJuridica { get; set; }
    }
}
