
namespace B2WTI.PCFTI.DOMINIO.Model.Global
{
    using DOMINIO.Model.Sistema;
    using INFRAESTRUTURA.TRANSVERSAL.Base;
    using System;

    public class AnoCalendario : CadastroBase
    {

        public int Ano { get; set; }
        public bool Ativo { get; set; }

    }
}
