using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe;
using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;

namespace B2WTI.PCFTI.APRESENTACAO.Areas.Cadastro.Controllers
{
    public class StatusController : Controller
    {
        // GET: Cadastro/Status
        public ActionResult Index()
        {
            List<StatusView> lista = StatusExecute.ListarTodosOsStatus();
            return View(lista);
        }

        [HttpPost]
        // POST: Cadastro/Status/Novo
        public ActionResult Index(string filtro)
        {
            ViewData["filtro"] = filtro;
            List<StatusView> lista = StatusExecute.BuscarStatus(filtro);
            return View("Index", lista);
        }

        [HttpGet]
        // GET: Cadastro/Status/Novo
        public ActionResult Novo()
        {
            return View("Novo", new StatusView());
        }

        [HttpPost]
        // POST: Cadastro/Status/Novo
        public ActionResult Novo(StatusView status)
        {
            status.Ativo = true;
            status = StatusExecute.CriarNovoStatus(status, User.Identity.Name.ToString(), DateTime.Now);

            return RedirectToAction("Index");
        }

        [HttpGet]
        // GET: Cadastro/Status/Editar
        public ActionResult Editar(Guid Id)
        {
            StatusView item = StatusExecute.CarregarStatus(Id);
            return View("Editar", item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Cadastro/Status/Editar
        public ActionResult Editar(StatusView status)
        {
            status = StatusExecute.EditarStatus(status, User.Identity.Name.ToString(), DateTime.Now);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // GET: Cadastro/Status/Excluir
        public ActionResult Excluir(Guid Id)
        {
            StatusView item = StatusExecute.CarregarStatus(Id);
            return View("Excluir", item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Cadastro/Status/Excluir
        public ActionResult Excluir(StatusView status)
        {
            bool result = StatusExecute.ExcluirStatus(status, User.Identity.Name.ToString(), DateTime.Now);
            return RedirectToAction("Index");
        }
    }
}