
namespace B2WTI.PCFTI.APRESENTACAO.SERVICES.Map
{
    using DOMINIO.Model.Sistema;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Sistema.ViewModel;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class RegraMap
    {

        public static List<Regra> DeViewParaDomin(this List<RegraView> source)
        {
            List<Regra> regras = new List<Regra>();

            Parallel.ForEach<RegraView>(source, regra =>
            {
                regras.Add(new Regra()
                {
                    RegraId = regra.RegraId,
                    Nome = regra.Nome
                });
            });
            return regras;
        }

        public static Regra DeViewParaDomin(this RegraView source)
        {
            Regra regra = new Regra()
            {
                RegraId = source.RegraId,
                Nome = source.Nome
            };
            return regra;
        }

        public static List<RegraView> DeDominParaView(this List<Regra> source)
        {
            List<RegraView> regras = new List<RegraView>();

            Parallel.ForEach<Regra>(source, regra =>
            {
                regras.Add(new RegraView()
                {
                    RegraId = regra.RegraId,
                    Nome = regra.Nome
                });
            });

            return regras;
        }

        public static RegraView DeDominParaView(this Regra source)
        {
            RegraView regra = new RegraView()
            {
                RegraId = source.RegraId,
                Nome = source.Nome
            };

            return regra;
        }


        public static List<RegraView> DeDominParaView(this ICollection<Regra> source)
        {
            List<RegraView> regrasview = new List<RegraView>();
            Parallel.ForEach<Regra>(source, item =>
            {
                regrasview.Add(new RegraView() { RegraId = item.RegraId, Nome = item.Nome });
            });
            return regrasview;
        }

    }
}
