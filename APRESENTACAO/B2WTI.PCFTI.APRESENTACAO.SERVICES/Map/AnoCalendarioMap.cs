
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

    public static class AnoCalendarioMap
    {

        public static List<AnoCalendario> DeViewParaDomin(this List<AnoCalendarioView> source)
        {
            List<AnoCalendario> anoCalendarios = new List<AnoCalendario>();

            Parallel.ForEach<AnoCalendarioView>(source, anoCalendario =>
            {
                anoCalendarios.Add(new AnoCalendario()
                {
                    Ano = anoCalendario.Ano,
                    Ativo = anoCalendario.Ativo
                });
            });
            return anoCalendarios;
        }

        public static AnoCalendario DeViewParaDomin(this AnoCalendarioView source)
        {
            AnoCalendario anoCalendario = new AnoCalendario()
            {
                Ano = source.Ano,
                Ativo = source.Ativo
            };
            return anoCalendario;
        }

        public static List<AnoCalendarioView> DeDominParaView(this List<AnoCalendario> source)
        {
            List<AnoCalendarioView> anoCalendarios = new List<AnoCalendarioView>();

            Parallel.ForEach<AnoCalendario>(source, anoCalendario =>
            {
                anoCalendarios.Add(new AnoCalendarioView()
                {
                    Ano = anoCalendario.Ano,
                    Ativo = anoCalendario.Ativo
                });
            });

            return anoCalendarios;
        }

        public static AnoCalendarioView DeDominParaView(this AnoCalendario source)
        {
            AnoCalendarioView anoCalendario = new AnoCalendarioView()
            {
                Ano = source.Ano,
                Ativo = source.Ativo
            };

            return anoCalendario;
        }

    }
}
