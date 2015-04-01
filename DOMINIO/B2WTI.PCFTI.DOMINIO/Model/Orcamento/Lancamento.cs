
namespace B2WTI.PCFTI.DOMINIO.Model.Orcamento
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Base;
    using System;
    using System.Collections.Generic;
    
    public partial class Lancamento : Entity
    {

        public Fornecedor Fornecedor { get; set; }
        public Responsavel Responsavel { get; set; }
        public Propriedade Propriedade { get; set; }
        public TipoServico TipoServico { get; set; }
        public TipoBloco TipoBloco { get; set; }
        public Bloco Bloco { get; set; }
        public Status Status { get; set; }
        public TipoDePagamento TipoDePagamento { get; set; }
        public IEnumerable<Orcado> Orcados { get; set; }
        public IEnumerable<Backlog> Backlogs { get; set; }
        public IEnumerable<Caixa> Caixas { get; set; }
        public IEnumerable<Real> Reais { get; set; }
        public IEnumerable<Acumulado> Acumulados { get; set; }

    }
}
