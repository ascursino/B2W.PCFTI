
namespace B2WTI.PCFTI.DOMINIO.Model.Global
{
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Base;
    using System;

    public class Status : Entity
    {
        public Guid StatusId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}
