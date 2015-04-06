
namespace B2WTI.PCFTI.APRESENTACAO.Areas.Cadastro.Controllers
{
    using B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class TipoBlocoController : Controller
    {

        // GET: Cadastro/TipoBloco
        public ActionResult Index()
        {
            List<TipoBlocoView> lista = TipoBlocoExecute.ListarTodosOsTipoBlocos();
            return View(lista);
        }

        [HttpPost]
        // POST: Cadastro/TipoBloco/Novo
        public ActionResult Index(string filtro)
        {
            ViewData["filtro"] = filtro;
            List<TipoBlocoView> lista = TipoBlocoExecute.BuscarTipoBlocos(filtro);
            return View("Index", lista);
        }

        [HttpGet]
        // GET: Cadastro/TipoBloco/Novo
        public ActionResult Novo()
        {
            return View("Novo", new TipoBlocoView());
        }

        [HttpPost]
        // POST: Cadastro/TipoBloco/Novo
        public ActionResult Novo(TipoBlocoView TipoBloco)
        {
            TipoBloco.Ativo = true;
            TipoBloco = TipoBlocoExecute.CriarNovoTipoBloco(TipoBloco);

            return RedirectToAction("Index");
        }

        [HttpGet]
        // GET: Cadastro/TipoBloco/Editar
        public ActionResult Editar(Guid Id)
        {
            TipoBlocoView item = TipoBlocoExecute.CarregarTipoBloco(Id);
            return View("Editar", item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Cadastro/TipoBloco/Editar
        public ActionResult Editar(TipoBlocoView TipoBloco)
        {
            TipoBloco = TipoBlocoExecute.EditarTipoBloco(TipoBloco);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // GET: Cadastro/TipoBloco/Excluir
        public ActionResult Excluir(Guid Id)
        {
            TipoBlocoView item = TipoBlocoExecute.CarregarTipoBloco(Id);
            return View("Excluir", item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Cadastro/TipoBloco/Excluir
        public ActionResult Excluir(TipoBlocoView TipoBloco)
        {
            bool result = TipoBlocoExecute.ExcluirTipoBloco(TipoBloco);
            return RedirectToAction("Index");
        }

    }
}