
namespace B2WTI.PCFTI.APLICACAO.Operacao
{
    using System;
    using B2WTI.PCFTI.APLICACAO.Operacao.Build;

    public class Cadastro
    {
        public Cadastro()
        {
            Fornecedor = new FornecedorBuild();
            Bloco = new BlocoBuild();
        }

        public FornecedorBuild Fornecedor { get; set; }
        public BlocoBuild Bloco { get; set; }
    }
}
