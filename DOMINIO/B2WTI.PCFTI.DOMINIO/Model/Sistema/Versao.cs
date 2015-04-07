
namespace B2WTI.PCFTI.DOMINIO.Model.Sistema
{
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Base;
    using System;

    public class Versao : Entity
    {

        public Guid VersaoId { get; set; }
        public DateTime Momento { get; set; }
        public string Promotor { get; set; }
        public string Entidade { get; set; }
        public string EnitdadeId { get; set; }
        public string Operacao { get; set; }
        public string Dados { get; set; }

    }
}
