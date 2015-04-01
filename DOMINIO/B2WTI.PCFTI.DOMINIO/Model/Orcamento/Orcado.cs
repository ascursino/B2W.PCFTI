
namespace B2WTI.PCFTI.DOMINIO.Model.Orcamento
{
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Base;
    using System;

    public class Orcado : Entity
    {
        public Guid LancamentoId { get; set; }
        public int PeriodoMes { get; set; }
        public double Valor { get; set; }
        public bool Ativo { get; set; }
        public virtual Lancamento Lancamento { get; set; }
    }
}
