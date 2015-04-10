
namespace B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe
{
    using APLICACAO.Operacao;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Sistema.ViewModel;
    using DOMINIO.Model.Global;
    using Map;
    using System;
    using System.Collections.Generic;
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    
    public static class UsuarioExecute
    {
        static Execute Executar = new Execute();

        public static List<UsuarioView> ListarTodosOsUsuarios()
        {
            List<UsuarioView> usuarios = Executar.Sistema.Usuario.ListarUsuarios().DeDominParaView();
            return usuarios;
        }

        public static List<UsuarioView> BuscarUsuarios(string filtro)
        {
            List<UsuarioView> usuarios = Executar.Sistema.Usuario.BuscarUsuarios(filtro).DeDominParaView();
            return usuarios;
        }

        public static UsuarioView CarregarUsuario(Guid UsuarioId)
        {
            UsuarioView usuario = Executar.Sistema.Usuario.CarregarUsuario(UsuarioId).DeDominParaView();
            return usuario;
        }

        public static UsuarioView CarregarUsuario(string LoginWindows)
        {
            UsuarioView usuario = Executar.Sistema.Usuario.CarregarUsuario(LoginWindows).DeDominParaView();
            return usuario;
        }

        public static UsuarioView CriarNovoUsuario(UsuarioView usuario, string CriadoPor, DateTime CriadoEm)
        {
            Usuario objdomin = usuario.DeViewParaDomin();
            objdomin.CriadoPor = CriadoPor;
            objdomin.CriadoEm = CriadoEm;

            usuario = Executar.Sistema.Usuario.CriarNovoUsuario(objdomin).DeDominParaView();
            return usuario;
        }

        public static UsuarioView EditarUsuario(UsuarioView usuario, string AlteradoPor, DateTime AlteradoEm)
        {
            Usuario objdomin = usuario.DeViewParaDomin();
            objdomin.AlteradoPor = AlteradoPor;
            objdomin.AlteradoEm = AlteradoEm;

            usuario = Executar.Sistema.Usuario.AtualizarUsuario(objdomin).DeDominParaView();
            return usuario;
        }

        public static bool ExcluirUsuario(UsuarioView usuario, string AlteradoPor, DateTime AlteradoEm)
        {
            Usuario objdomin = usuario.DeViewParaDomin();
            objdomin.CriadoPor = AlteradoPor;
            objdomin.AlteradoEm = AlteradoEm;

            bool ret = Executar.Sistema.Usuario.ExcluirUsuario(objdomin);
            return ret;
        }

        public static bool SolicitarAtivacao(UsuarioView usuario, string AlteradoPor, DateTime AlteradoEm)
        {
            Usuario objdomin = usuario.DeViewParaDomin();
            objdomin.CriadoPor = AlteradoPor;
            objdomin.AlteradoEm = AlteradoEm;

            bool ret = Executar.Sistema.Usuario.SolicitarAtivacao(objdomin);
            return ret;
        }

    }
}
