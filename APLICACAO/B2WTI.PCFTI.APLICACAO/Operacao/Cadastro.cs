
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
            Responsavel = new ResponsavelBuild();
            Status = new StatusBuild();
            TipoDePagamento = new TipoDePagamentoBuild();
            TipoServico = new TipoServicoBuild();
        }

        public FornecedorBuild Fornecedor { get; set; }
        public BlocoBuild Bloco { get; set; }
        public TipoBlocoBuild TipoBloco { get; set; }
        public PropriedadeBuild Propriedade { get; set; }
        public ResponsavelBuild Responsavel { get; set; }
        public StatusBuild Status { get; set; }
        public TipoDePagamentoBuild TipoDePagamento { get; set; }
        public TipoServicoBuild TipoServico { get; set; }
    }
}
