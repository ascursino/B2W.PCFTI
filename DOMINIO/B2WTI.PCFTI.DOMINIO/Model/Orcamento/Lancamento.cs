
namespace B2WTI.PCFTI.DOMINIO.Model.Orcamento
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Base;
    using System;
    using System.Collections.Generic;
    
    public partial class Lancamento : Entity
    {

        public Guid LancamentoId { get; set; }


        public virtual ICollection<Backlog> Backlogs { get; set; }


    }
}
