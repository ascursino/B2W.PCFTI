
namespace B2WTI.PCFTI.DOMINIO.Model.Global
{
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Base;
    using System;

    public class TipoDePagamento : Entity
    {
        public Guid TipoDePagamentoId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

    }
}
