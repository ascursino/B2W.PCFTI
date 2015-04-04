
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
            TipoBloco = new TipoBlocoBuild();
            Propriedade = new PropriedadeBuild();
        }

        public FornecedorBuild Fornecedor { get; set; }
        public BlocoBuild Bloco { get; set; }
        public TipoBlocoBuild TipoBloco { get; set; }
        public PropriedadeBuild Propriedade { get; set; }
    }
}
