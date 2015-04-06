
namespace B2WTI.PCFTI.TESTE.Massa
{
    using B2WTI.PCFTI.APLICACAO.Operacao;
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.DOMINIO.Model.Orcamento;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class OrcamentoFake
    {

        #region Lancamento

        public static Lancamento NovoLancamentoFake()
        {
            Execute Executar = new Execute();

            Fornecedor fornecedor = CadastroFake.NovoFornecedorFake();
            Executar.Cadastro.Fornecedor.CriarNovoFornecedor(fornecedor);

            Bloco bloco = CadastroFake.NovoBlocoFake();
            Executar.Cadastro.Bloco.CriarNovoBloco(bloco);

            TipoBloco tipobloco = CadastroFake.NovoTipoBlocoFake();
            Executar.Cadastro.TipoBloco.CriarNovoTipoBloco(tipobloco);

            AnoCalendario anocalendario = CadastroFake.NovoAnoCalendarioFake();
            Executar.Cadastro.AnoCalendario.CriarNovoAnoCalendario(anocalendario);

            Responsavel responsavel = CadastroFake.NovoResponsavelFake();
            Executar.Cadastro.Responsavel.CriarNovoResponsavel(responsavel);

            Status status = CadastroFake.NovoStatusFake();
            Executar.Cadastro.Status.CriarNovoStatus(status);

            TipoServico tiposervico = CadastroFake.NovoTipoServicoFake();
            Executar.Cadastro.TipoServico.CriarNovoTipoServico(tiposervico);

            TipoDePagamento tipodepagamento = CadastroFake.NovoTipoDePagamentoFake();
            Executar.Cadastro.TipoDePagamento.CriarNovoTipoDePagamento(tipodepagamento);

            Lancamento lancamento = new Lancamento()
            {
                LancamentoId = Guid.NewGuid(),
                ResponsavelId = responsavel.ResponsavelId,
                FornecedorId = fornecedor.FornecedorId,
                Ano = anocalendario.Ano,
                StatusId = status.StatusId,
                BlocoId = bloco.BlocoId,
                TipoBlocoId = tipobloco.TipoBlocoId,
                TipoServicoId = tiposervico.TipoServicoId,
                TipoDePagamentoId = tipodepagamento.TipoDePagamentoId
            };

            return lancamento;
        }

        public static List<Lancamento> NovosBlocosFake()
        {
            List<Lancamento> lancamentos = new List<Lancamento>();

            Parallel.For(0, 9, i =>
            {
                Lancamento objetoFor = NovoLancamentoFake();
                lancamentos.Add(objetoFor);
            });

            return lancamentos;
        }

        #endregion

    }
}
