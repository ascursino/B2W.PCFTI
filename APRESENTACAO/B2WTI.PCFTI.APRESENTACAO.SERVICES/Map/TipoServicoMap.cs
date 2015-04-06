
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

    public static class TipoServicoMap
    {

        public static List<TipoServico> DeViewParaDomin(this List<TipoServicoView> source)
        {
            List<TipoServico> tiposervicos = new List<TipoServico>();

            Parallel.ForEach<TipoServicoView>(source, item =>
            {
                tiposervicos.Add(new TipoServico()
                {
                    TipoServicoId = item.TipoServicoId,
                    Descricao = item.Descricao,
                    Ativo = item.Ativo
                });
            });
            return tiposervicos;
        }

        public static TipoServico DeViewParaDomin(this TipoServicoView source)
        {
            TipoServico tiposervico = new TipoServico()
            {
                TipoServicoId = source.TipoServicoId,
                Descricao = source.Descricao,
                Ativo = source.Ativo
            };
            return tiposervico;
        }

        public static List<TipoServicoView> DeDominParaView(this List<TipoServico> source)
        {
            List<TipoServicoView> TipoServicos = new List<TipoServicoView>();

            Parallel.ForEach<TipoServico>(source, item =>
            {
                TipoServicos.Add(new TipoServicoView()
                {
                    TipoServicoId = item.TipoServicoId,
                    Descricao = item.Descricao,
                    Ativo = item.Ativo
                });
            });

            return TipoServicos;
        }

        public static TipoServicoView DeDominParaView(this TipoServico source)
        {
            TipoServicoView tiposervico = new TipoServicoView()
            {
                TipoServicoId = source.TipoServicoId,
                Descricao = source.Descricao,
                Ativo = source.Ativo
            };

            return tiposervico;
        }

    }
}
