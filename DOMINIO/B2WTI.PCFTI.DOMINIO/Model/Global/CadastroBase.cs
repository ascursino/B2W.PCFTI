using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2WTI.PCFTI.DOMINIO.Model.Global
{
    public abstract class CadastroBase : Entity
    {
        public string CriadoPor { get; set; }
        public string AlteradoPor { get; set; }
        public DateTime? CriadoEm { get; set; }
        public DateTime? AlteradoEm { get; set; }
    }
}
