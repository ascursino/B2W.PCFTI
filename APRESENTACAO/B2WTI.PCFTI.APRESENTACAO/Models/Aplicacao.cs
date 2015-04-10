
namespace B2WTI.PCFTI.APRESENTACAO.Models
{
    using B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Sistema.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Aplicacao
    {

        public Aplicacao()
        {
            UsuarioView usuario = null;
            if (HttpContext.Current.User.Identity.IsAuthenticated)
                usuario = UsuarioExecute.CarregarUsuario(HttpContext.Current.User.Identity.Name);
            
            if (usuario != null)
                AccountChange(usuario);
        }

        public static Aplicacao Iniciar()
        {
            return new Aplicacao(); 
        }

        public Conta Usuario { get; set; }

        private void AccountChange(UsuarioView usuario)
        {
            Usuario = new Conta() 
            {
                UsuarioId = usuario.UsuarioId,
                Nome = usuario.Nome,
                ContaWindows = usuario.LoginWindows,
                Regras = new List<string>()
            };

            if (usuario.Regras != null)
                if (usuario.Regras.Count() > 0)
                    foreach (RegraView regra in usuario.Regras)
                        Usuario.Regras.Add(regra.Nome);

        }

    }
}