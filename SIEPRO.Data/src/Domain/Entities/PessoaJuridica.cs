using System;
using System.Collections.Generic;

namespace SIEPRO.Data.src.Domain.Entities
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
