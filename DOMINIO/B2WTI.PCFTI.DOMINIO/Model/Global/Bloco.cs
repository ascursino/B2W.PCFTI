
namespace B2WTI.PCFTI.DOMINIO.Model.Global
{
    using DOMINIO.Model.Sistema;
    using INFRAESTRUTURA.TRANSVERSAL.Base;
    using System;

    public class Bloco : CadastroBase
    {

        public Guid BlocoId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

    }
}
