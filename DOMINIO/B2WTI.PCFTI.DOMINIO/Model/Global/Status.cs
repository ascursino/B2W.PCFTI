
namespace B2WTI.PCFTI.DOMINIO.Model.Global
{
    using DOMINIO.Model.Sistema;
    using INFRAESTRUTURA.TRANSVERSAL.Base;
    using System;

    public class Status : CadastroBase
    {

        public Guid StatusId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

    }
}
