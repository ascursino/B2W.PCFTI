using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe;
using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;

namespace B2WTI.PCFTI.APRESENTACAO.Areas.Cadastro.Controllers
{
    public class ResponsavelController : Controller
    {
        // GET: Cadastro/Responsavel
        public ActionResult Index()
        {
            List<ResponsavelView> lista = ResponsavelExecute.ListarTodosOsResponsaveis();
            return View(lista);
        }

        [HttpPost]
        // POST: Cadastro/Responsavel/Novo
        public ActionResult Index(string filtro)
        {
            ViewData["filtro"] = filtro;
            List<ResponsavelView> lista = ResponsavelExecute.BuscarResponsaveis(filtro);
            return View("Index", lista);
        }

        [HttpGet]
        // GET: Cadastro/Responsavel/Novo
        public ActionResult Novo()
        {
            return View("Novo", new ResponsavelView());
        }

        [HttpPost]
        // POST: Cadastro/Responsavel/Novo
        public ActionResult Novo(ResponsavelView responsavel)
        {
            responsavel = ResponsavelExecute.CriarNovoResponsavel(responsavel,
                User.Identity.Name.ToString(), DateTime.Now);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // GET: Cadastro/Responsavel/Editar
        public ActionResult Editar(Guid Id)
        {
            ResponsavelView item = ResponsavelExecute.CarregarResponsavel(Id);
            return View("Editar", item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Cadastro/Responsavel/Editar
        public ActionResult Editar(ResponsavelView responsavel)
        {
            responsavel = ResponsavelExecute.EditarResponsavel(responsavel,
                User.Identity.Name.ToString(), DateTime.Now);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // GET: Cadastro/Responsavel/Excluir
        public ActionResult Excluir(Guid Id)
        {
            ResponsavelView item = ResponsavelExecute.CarregarResponsavel(Id);
            return View("Excluir", item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Cadastro/Responsavel/Excluir
        public ActionResult Excluir(ResponsavelView responsavel)
        {
            bool result = ResponsavelExecute.ExcluirResponsavel(responsavel, User.Identity.Name.ToString(), DateTime.Now);
            return RedirectToAction("Index");
        }
    }
}