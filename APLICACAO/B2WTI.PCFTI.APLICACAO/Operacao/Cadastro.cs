
namespace B2WTI.PCFTI.APLICACAO.Operacao
{
    using System;
    using B2WTI.PCFTI.APLICACAO.Operacao.Build;

    public class Cadastro
    {
        public Cadastro()
        {
            Fornecedor = new FornecedorBuild();
        }

        public FornecedorBuild Fornecedor { get; set; }

    }
}
