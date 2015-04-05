
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

    public static class BlocoMap
    {

        public static List<Bloco> DeViewParaDomin(this List<BlocoView> source)
        {
            List<Bloco> blocos = new List<Bloco>();

            Parallel.ForEach<BlocoView>(source, bloco =>
            {
                blocos.Add(new Bloco()
                {
                    BlocoId = bloco.BlocoId,
                    Descricao = bloco.Descricao,
                    Ativo = bloco.Ativo
                });
            });
            return blocos;
        }

        public static Bloco DeViewParaDomin(this BlocoView source)
        {
            Bloco bloco = new Bloco()
            {
                BlocoId = source.BlocoId,
                Descricao = source.Descricao,
                Ativo = source.Ativo
            };
            return bloco;
        }

        public static List<BlocoView> DeDominParaView(this List<Bloco> source)
        {
            List<BlocoView> blocos = new List<BlocoView>();

            Parallel.ForEach<Bloco>(source, bloco =>
            {
                blocos.Add(new BlocoView()
                {
                    BlocoId = bloco.BlocoId,
                    Descricao = bloco.Descricao,
                    Ativo = bloco.Ativo
                });
            });

            return blocos;
        }

        public static BlocoView DeDominParaView(this Bloco source)
        {
            BlocoView bloco = new BlocoView()
            {
                BlocoId = source.BlocoId,
                Descricao = source.Descricao,
                Ativo = source.Ativo
            };

            return bloco;
        }

    }
}
