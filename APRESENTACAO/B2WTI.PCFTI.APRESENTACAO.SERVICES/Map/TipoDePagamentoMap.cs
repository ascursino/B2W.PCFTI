
namespace B2WTI.PCFTI.APRESENTACAO.SERVICES.Map
{
    using B2WTI.PCFTI.APLICACAO.Operacao;
    using DOMINIO.Model.Global;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class TipoDePagamentoMap
    {

        public static List<TipoDePagamento> DeViewParaDomin(this List<TipoDePagamentoView> source)
        {
            List<TipoDePagamento> tipodepagamentos = new List<TipoDePagamento>();

            Parallel.ForEach<TipoDePagamentoView>(source, item =>
            {
                tipodepagamentos.Add(new TipoDePagamento()
                {
                    TipoDePagamentoId = item.TipoDePagamentoId,
                    Descricao = item.Descricao,
                    Ativo = item.Ativo
                });
            });
            return tipodepagamentos;
        }

        public static TipoDePagamento DeViewParaDomin(this TipoDePagamentoView source)
        {
            TipoDePagamento tipodepagamento = new TipoDePagamento()
            {
                TipoDePagamentoId = source.TipoDePagamentoId,
                Descricao = source.Descricao,
                Ativo = source.Ativo
            };
            return tipodepagamento;
        }

        public static List<TipoDePagamentoView> DeDominParaView(this List<TipoDePagamento> source)
        {
            List<TipoDePagamentoView> TipoDePagamentos = new List<TipoDePagamentoView>();

            Parallel.ForEach<TipoDePagamento>(source, item =>
            {
                TipoDePagamentos.Add(new TipoDePagamentoView()
                {
                    TipoDePagamentoId = item.TipoDePagamentoId,
                    Descricao = item.Descricao,
                    Ativo = item.Ativo
                });
            });

            return TipoDePagamentos;
        }

        public static TipoDePagamentoView DeDominParaView(this TipoDePagamento source)
        {
            TipoDePagamentoView tipodepagamento = new TipoDePagamentoView()
            {
                TipoDePagamentoId = source.TipoDePagamentoId,
                Descricao = source.Descricao,
                Ativo = source.Ativo
            };

            return tipodepagamento;
        }

    }
}
