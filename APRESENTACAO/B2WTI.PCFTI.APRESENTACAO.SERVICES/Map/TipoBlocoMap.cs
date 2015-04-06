
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

    public static class TipoBlocoMap
    {

        public static List<TipoBloco> DeViewParaDomin(this List<TipoBlocoView> source)
        {
            List<TipoBloco> TipoBlocos = new List<TipoBloco>();

            Parallel.ForEach<TipoBlocoView>(source, item =>
            {
                TipoBlocos.Add(new TipoBloco()
                {
                    TipoBlocoId = item.TipoBlocoId,
                    Descricao = item.Descricao,
                    Ativo = item.Ativo
                });
            });
            return TipoBlocos;
        }

        public static TipoBloco DeViewParaDomin(this TipoBlocoView source)
        {
            TipoBloco TipoBloco = new TipoBloco()
            {
                TipoBlocoId = source.TipoBlocoId,
                Descricao = source.Descricao,
                Ativo = source.Ativo
            };
            return TipoBloco;
        }

        public static List<TipoBlocoView> DeDominParaView(this List<TipoBloco> source)
        {
            List<TipoBlocoView> TipoBlocos = new List<TipoBlocoView>();

            Parallel.ForEach<TipoBloco>(source, item =>
            {
                TipoBlocos.Add(new TipoBlocoView()
                {
                    TipoBlocoId = item.TipoBlocoId,
                    Descricao = item.Descricao,
                    Ativo = item.Ativo
                });
            });

            return TipoBlocos;
        }

        public static TipoBlocoView DeDominParaView(this TipoBloco source)
        {
            TipoBlocoView TipoBloco = new TipoBlocoView()
            {
                TipoBlocoId = source.TipoBlocoId,
                Descricao = source.Descricao,
                Ativo = source.Ativo
            };

            return TipoBloco;
        }

    }
}
