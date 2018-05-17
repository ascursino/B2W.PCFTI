
namespace B2WTI.PCFTI.APRESENTACAO.Models
{
    using APRESENTACAO.SERVICES.Exe;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Sistema.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.SessionState;

    public class Aplicacao
    {
        
        public Aplicacao()
        {
            const string sessionUsuarioView = "UsuarioView";
            UsuarioView usuario = null;

            if (HttpContext.Current.Session[sessionUsuarioView] != null)
                usuario = (UsuarioView)HttpContext.Current.Session[sessionUsuarioView];
            else if (HttpContext.Current.User.Identity.IsAuthenticated)
                usuario = UsuarioExecute.CarregarUsuario(HttpContext.Current.User.Identity.Name);
            
            if (usuario != null)
                AccountChange(usuario);
        }

        public static Aplicacao Iniciar()
        {
            return new Aplicacao(); 
        }

        public Conta Usuario { get; set; }

        public bool Permitido(string[] arrRegra)
        {
            bool ret = false;
            
            if (arrRegra != null)
                if (arrRegra.Length > 0)
                    ret = Permitido(arrRegra.ToList());
                    
            return ret;
        }

        public bool Permitido(List<string> lstRegra)
        {
            foreach (string item in lstRegra)
                if (Permitido(item.ToString())) 
                    return true;
            
            return false;
        }

        public bool Permitido(string regra)
        {
            bool ret = false;

            if (regra == string.Empty)
                return ret;

            if (regra.Contains(","))
                ret = Permitido(regra.Split(new Char[] { ',' }));
            else if (Usuario != null)
                ret = Usuario.Regras.Where(p => p.ToUpper().Trim().Equals(regra.ToUpper().Trim())).Count() > 0;
            else
                ret = false;

            return ret;
        }

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