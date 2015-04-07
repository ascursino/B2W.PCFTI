
namespace B2WTI.PCFTI.DOMINIO.Model.Sistema
{
    using INFRAESTRUTURA.TRANSVERSAL.Base;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class CadastroBase : Entity
    {

        public string CriadoPor { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime? CriadoEm { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public bool Descartado { get; set; }

    }
}
