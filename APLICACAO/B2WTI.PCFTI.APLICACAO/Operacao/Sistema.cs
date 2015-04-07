
namespace B2WTI.PCFTI.APLICACAO.Operacao
{
    using B2WTI.PCFTI.APLICACAO.Operacao.Build;
    using System;

    public class Sistema
    {

        public Sistema()
        {
            Versao = new VersaoBuild();
        }

        public VersaoBuild Versao { get; set; }

    }
}
