
namespace B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe
{
    using APLICACAO.Operacao;
    using DOMINIO.Model.Sistema;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Sistema.ViewModel;
    using Map;
    using System;
    using System.Collections.Generic;

    public static class UsuarioRegraExecute
    {
        static Execute Executar = new Execute();

        public static List<UsuarioRegraView> ListarTodosOsUsuarioRegras()
        {
            List<UsuarioRegraView> usuarioregras = Executar.Sistema.UsuarioRegra.ListarUsuarioRegras().DeDominParaView();
            return usuarioregras;
        }

        public static List<UsuarioRegraView> BuscarUsuarioRegras(string filtro)
        {
            List<UsuarioRegraView> usuarioregras = Executar.Sistema.UsuarioRegra.BuscarUsuarioRegras(filtro).DeDominParaView();
            return usuarioregras;
        }

        public static UsuarioRegraView CarregarUsuarioRegra(Guid UsuarioId, Guid RegraId)
        {
            UsuarioRegraView usuarioregra = Executar.Sistema.UsuarioRegra.CarregarUsuarioRegra(UsuarioId, RegraId).DeDominParaView();
            return usuarioregra;
        }

        public static UsuarioRegraView CriarNovoUsuarioRegra(UsuarioRegraView usuarioregra, string CriadoPor, DateTime CriadoEm)
        {
            UsuarioRegra objdomin = usuarioregra.DeViewParaDomin();
            objdomin.CriadoPor = CriadoPor;
            objdomin.CriadoEm = CriadoEm;

            usuarioregra = Executar.Sistema.UsuarioRegra.CriarNovoUsuarioRegra(objdomin).DeDominParaView();
            return usuarioregra;
        }

        public static UsuarioRegraView EditarUsuarioRegra(UsuarioRegraView usuarioregra, string CriadoPor, DateTime CriadoEm)
        {
            UsuarioRegra objdomin = usuarioregra.DeViewParaDomin();
            objdomin.CriadoPor = CriadoPor;
            objdomin.CriadoEm = CriadoEm;

            usuarioregra = Executar.Sistema.UsuarioRegra.AtualizarUsuarioRegra(usuarioregra.DeViewParaDomin()).DeDominParaView();
            return usuarioregra;
        }

        public static bool ExcluirUsuarioRegra(UsuarioRegraView usuarioregra, string CriadoPor, DateTime CriadoEm)
        {
            UsuarioRegra objdomin = usuarioregra.DeViewParaDomin();
            objdomin.CriadoPor = CriadoPor;
            objdomin.CriadoEm = CriadoEm;

            bool ret = Executar.Sistema.UsuarioRegra.ExcluirUsuarioRegra(usuarioregra.DeViewParaDomin());
            return ret;
        }

    }
}
