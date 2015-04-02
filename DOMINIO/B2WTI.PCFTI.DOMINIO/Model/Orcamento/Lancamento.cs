
namespace B2WTI.PCFTI.DOMINIO.Model.Orcamento
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Base;
    using System;
    using System.Collections.Generic;
    
    public partial class Lancamento : Entity
    {
        public Guid LancamentoId { get; set; }

        public Guid FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        public Guid ResponsavelId { get; set; }
        public virtual Responsavel Responsavel { get; set; }

        public int Ano { get; set; }
        public virtual Propriedade Propriedade { get; set; }

        public Guid? TipoServicoId { get; set; }
        public virtual TipoServico TipoServico { get; set; }

        public Guid? TipoBlocoId { get; set; }
        public virtual TipoBloco TipoBloco { get; set; }

        public Guid? BlocoId { get; set; }
        public virtual Bloco Bloco { get; set; }

        public Guid? StatusId { get; set; }
        public virtual Status Status { get; set; }

        public Guid? TipoDePagamentoId { get; set; }
        public virtual TipoDePagamento TipoDePagamento { get; set; }

        public virtual ICollection<Orcado> Orcados { get; set; }
        public virtual ICollection<Backlog> Backlogs { get; set; }
        public virtual ICollection<Caixa> Caixas { get; set; }
        public virtual ICollection<Real> Reais { get; set; }
        public virtual ICollection<Acumulado> Acumulados { get; set; }
    }
}
