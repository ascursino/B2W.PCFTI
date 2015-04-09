
namespace B2WTI.PCFTI.APRESENTACAO.Areas.Sistema.Controllers
{
    using APRESENTACAO.SERVICES.Exe;
    using B2WTI.PCFTI.APRESENTACAO.Areas.Sistema.Models;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Sistema.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Net.Http;
    using System.Net.Http;

    public class UsuarioController : Controller
    {
        // GET: Sistema/Usuario
        public ActionResult Index()
        {
            List<UsuarioView> lista = UsuarioExecute.ListarTodosOsUsuarios();
            return View(lista);
        }

        [HttpPost]
        // POST: Sistema/Usuario/Novo
        public ActionResult Index(string filtro)
        {
            ViewData["filtro"] = filtro;
            List<UsuarioView> lista = UsuarioExecute.BuscarUsuarios(filtro);
            return View("Index", lista);
        }

        [HttpGet]
        // GET: Sistema/Usuario/Novo
        public ActionResult Novo()
        {
            return View("Novo", new UsuarioView());
        }

        [HttpPost]
        // POST: Sistema/Usuario/Novo
        public ActionResult Novo(UsuarioView bloco)
        {
            bloco = UsuarioExecute.CriarNovoUsuario(bloco, User.Identity.Name.ToString(), DateTime.Now);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // GET: Sistema/Usuario/Editar
        public ActionResult Editar(Guid Id)
        {
            UsuarioView item = UsuarioExecute.CarregarUsuario(Id);
            return View("Editar", item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Sistema/Usuario/Editar
        public ActionResult Editar(UsuarioView usuario)
        {
            usuario = UsuarioExecute.EditarUsuario(usuario, User.Identity.Name.ToString(), DateTime.Now);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // GET: Sistema/Usuario/Excluir
        public ActionResult Excluir(Guid Id)
        {
            UsuarioView item = UsuarioExecute.CarregarUsuario(Id);
            return View("Excluir", item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Sistema/Usuario/Excluir
        public ActionResult Excluir(UsuarioView bloco)
        {
            bool result = UsuarioExecute.ExcluirUsuario(bloco, User.Identity.Name.ToString(), DateTime.Now);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // GET: Sistema/Usuario/Privilegios
        public ActionResult Privilegios(Guid Id)
        {
            UsuarioView usuario = UsuarioExecute.CarregarUsuario(Id);
            List<RegraView> regras = RegraExecute.ListarTodosAsRegras();
            List<UsuarioRegraView> usuarioregra = UsuarioRegraExecute.ListarTodosOsUsuarioRegras();

            GestaoPrivilegio gestao = new GestaoPrivilegio() { Usuario = usuario, Regras = regras, UsuarioRegras = usuarioregra };

            return View("Privilegios", gestao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Sistema/Usuario/Privilegios
        public ActionResult Privilegios(UsuarioView Usuario, string[] regras)
        {
            if (regras == null)
            {
                UsuarioRegraExecute.RemoverTodosOsPrivilegios(Usuario.UsuarioId, User.Identity.Name.ToString(), DateTime.Now);
            }
            else
            {
                List<Guid> Regras = new List<Guid>();
                for (int i = 0; i < regras.Length; i++)
                    Regras.Add(Guid.Parse(regras[i].ToString()));

                UsuarioRegraExecute.GerenciarPrivilegios(Usuario.UsuarioId, Regras.ToArray(), User.Identity.Name.ToString(), DateTime.Now);
            }
            return RedirectToAction("Index");
        }

    }
}