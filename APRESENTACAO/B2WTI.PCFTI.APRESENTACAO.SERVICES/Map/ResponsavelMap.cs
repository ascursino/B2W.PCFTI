
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

    public static class ResponsavelMap
    {

        public static List<Responsavel> DeViewParaDomin(this List<ResponsavelView> source)
        {
            List<Responsavel> responsaveis = new List<Responsavel>();

            Parallel.ForEach<ResponsavelView>(source, item =>
            {
                responsaveis.Add(new Responsavel()
                {
                    ResponsavelId = item.ResponsavelId,
                    UsuarioId = item.UsuarioId,
                    Ativo = item.Ativo
                });
            });
            return responsaveis;
        }

        public static Responsavel DeViewParaDomin(this ResponsavelView source)
        {
            Responsavel responsavel = new Responsavel()
            {
                ResponsavelId = source.ResponsavelId,
                UsuarioId = source.UsuarioId,
                Ativo = source.Ativo
            };
            return responsavel;
        }

        public static List<ResponsavelView> DeDominParaView(this List<Responsavel> source)
        {
            List<ResponsavelView> Responsavels = new List<ResponsavelView>();

            Parallel.ForEach<Responsavel>(source, item =>
            {
                Responsavels.Add(new ResponsavelView()
                {
                    ResponsavelId = item.ResponsavelId,
                    UsuarioId = item.UsuarioId,
                    Ativo = item.Ativo
                });
            });

            return Responsavels;
        }

        public static ResponsavelView DeDominParaView(this Responsavel source)
        {
            ResponsavelView responsavel = new ResponsavelView()
            {
                ResponsavelId = source.ResponsavelId,
                UsuarioId = source.UsuarioId,
                Ativo = source.Ativo
            };

            return responsavel;
        }

    }
}
