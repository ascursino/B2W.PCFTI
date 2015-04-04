
namespace B2WTI.PCFTI.APLICACAO.Operacao
{
    using B2WTI.PCFTI.APLICACAO.Operacao.Build;
    using System;

    public class Orcamento
    {

        public Orcamento()
        {
            Lancamento = new LancamentoBuild();
        }

        public LancamentoBuild Lancamento { get; set; }

    }
}
