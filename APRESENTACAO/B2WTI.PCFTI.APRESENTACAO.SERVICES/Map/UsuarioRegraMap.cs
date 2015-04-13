
namespace B2WTI.PCFTI.APRESENTACAO.SERVICES.Map
{
    using B2WTI.PCFTI.APLICACAO.Operacao;
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Sistema.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class UsuarioRegraMap
    {

        public static List<UsuarioRegra> DeViewParaDomin(this List<UsuarioRegraView> source)
        {
            List<UsuarioRegra> usuarioregras = new List<UsuarioRegra>();

            Parallel.ForEach<UsuarioRegraView>(source, usuarioregra =>
            {
                usuarioregras.Add(new UsuarioRegra()
                {
                    UsuarioId = usuarioregra.UsuarioId,
                    RegraId = usuarioregra.RegraId
                });
            });
            return usuarioregras;
        }

        public static UsuarioRegra DeViewParaDomin(this UsuarioRegraView source)
        {
            UsuarioRegra usuarioregra = new UsuarioRegra()
            {
                UsuarioId = source.UsuarioId,
                RegraId = source.RegraId
            };
            return usuarioregra;
        }

        public static List<UsuarioRegraView> DeDominParaView(this List<UsuarioRegra> source)
        {
            List<UsuarioRegraView> usuarioregras = new List<UsuarioRegraView>();

            Parallel.ForEach<UsuarioRegra>(source, usuarioregra =>
            {
                usuarioregras.Add(new UsuarioRegraView()
                {
                    UsuarioId = usuarioregra.UsuarioId,
                    RegraId = usuarioregra.RegraId,
                    Regra = (usuarioregra.Regra != null) ? usuarioregra.Regra.DeDominParaView() : null

                });
            });

            return usuarioregras;
        }

        public static UsuarioRegraView DeDominParaView(this UsuarioRegra source)
        {
            UsuarioRegraView usuarioregra = new UsuarioRegraView()
            {
                UsuarioId = source.UsuarioId,
                RegraId = source.RegraId
            };

            return usuarioregra;
        }

    }
}
