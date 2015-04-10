
namespace B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe
{
    using APLICACAO.Operacao;
    using DOMINIO.Model.Global;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;
    using Map;
    using System;
    using System.Collections.Generic;

    public static class TipoDePagamentoExecute
    {
        static Execute Executar = new Execute();

        public static List<TipoDePagamentoView> ListarTodosOsTiposDePagamentos()
        {
            List<TipoDePagamentoView> ret = Executar.Cadastro.TipoDePagamento.ListarTiposDePagamento().DeDominParaView();
            return ret;
        }

        public static List<TipoDePagamentoView> BuscarTiposDePagamentos(string filtro)
        {
            List<TipoDePagamentoView> ret = Executar.Cadastro.TipoDePagamento.BuscarTiposDePagamento(filtro).DeDominParaView();
            return ret;
        }

        public static TipoDePagamentoView CarregarTipoDePagamento(Guid TipoDePagamentoId)
        {
            TipoDePagamentoView tipodepagamento = Executar.Cadastro.TipoDePagamento.CarregarTipoDePagamento(TipoDePagamentoId).DeDominParaView();
            return tipodepagamento;
        }

        public static TipoDePagamentoView CriarNovoTipoDePagamento(TipoDePagamentoView tipodepagamento, string CriadoPor,DateTime CriadoEm)
        {
            TipoDePagamento objdomain = tipodepagamento.DeViewParaDomin();
            objdomain.CriadoPor = CriadoPor;
            objdomain.CriadoEm = CriadoEm;
            
            tipodepagamento = Executar.Cadastro.TipoDePagamento.CriarNovoTipoDePagamento(tipodepagamento.DeViewParaDomin()).DeDominParaView();
            return tipodepagamento;
        }

        public static TipoDePagamentoView EditarTipoDePagamento(TipoDePagamentoView tipodepagamento)
        {
            tipodepagamento = Executar.Cadastro.TipoDePagamento.AtualizarTipoDePagamento(tipodepagamento.DeViewParaDomin()).DeDominParaView();
            return tipodepagamento;
        }

        public static bool ExcluirTipoDePagamento(TipoDePagamentoView tipodepagamento)
        {
            bool ret = Executar.Cadastro.TipoDePagamento.ExcluirTipoDePagamento(tipodepagamento.DeViewParaDomin());
            return ret;
        }

    }
}
