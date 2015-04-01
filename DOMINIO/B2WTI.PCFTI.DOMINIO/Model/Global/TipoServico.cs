
namespace B2WTI.PCFTI.DOMINIO.Model.Global
{
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Base;
    using System;

    public class TipoServico : Entity
    {
        public Guid TipoServicoId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}
