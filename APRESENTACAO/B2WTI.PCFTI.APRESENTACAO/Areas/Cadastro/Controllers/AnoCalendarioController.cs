
using B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe;

namespace B2WTI.PCFTI.APRESENTACAO.Areas.Cadastro.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;
    public class AnoCalendarioController : Controller
    {
        // GET: Cadastro/AnoCalendario
        public ActionResult Index()
        {
            List<AnoCalendarioView> lista = AnoCalendarioExecute.ListarTodosOsAnoCalendarios();
            return View(lista);
        }

        [HttpPost]
        // POST: Cadastro/Bloco/Novo
        public ActionResult Index(int filtro)
        {
            ViewData["filtro"] = filtro;
            List<AnoCalendarioView> lista = AnoCalendarioExecute.BuscarAnoCalendarios(filtro);
            return View("Index", lista);
        }

        [HttpGet]
        // GET: Cadastro/AnoCalendario/Novo
        public ActionResult Novo()
        {
            return View("Novo", new AnoCalendarioView());
        }

        [HttpPost]
        // POST: Cadastro/AnoCalendario/Novo
        public ActionResult Novo(AnoCalendarioView anoCalendario)
        {
            anoCalendario = AnoCalendarioExecute.CriarNovoAnoCalendario(anoCalendario,
                User.Identity.Name.ToString(), DateTime.Now);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // GET: Cadastro/AnoCalendario/Excluir
        public ActionResult Excluir(int Ano)
        {
            AnoCalendarioView item = AnoCalendarioExecute.CarregarAnoCalendario(Ano);
            return View("Excluir", item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Cadastro/AnoCalendario/Excluir
        public ActionResult Excluir(AnoCalendarioView anoCalendario)
        {
            bool result = AnoCalendarioExecute.ExcluirAnoCalendario(anoCalendario, User.Identity.Name.ToString(), DateTime.Now);
            return RedirectToAction("Index");
        }
    }
}