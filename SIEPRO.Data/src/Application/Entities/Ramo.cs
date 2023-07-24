using System;
using System.Collections.Generic;

namespace SIEPRO.Data.src.Application.Entities
{
    public partial class Ramo
    {
        public Ramo()
        {
            RamoJuridica = new HashSet<RamoJuridica>();
        }

        public long Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<RamoJuridica> RamoJuridica { get; set; }
    }
}
