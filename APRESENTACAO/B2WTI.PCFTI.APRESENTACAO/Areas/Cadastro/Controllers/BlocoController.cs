
namespace B2WTI.PCFTI.APRESENTACAO.Areas.Cadastro.Controllers
{
    using B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class BlocoController : Controller
    {
       
        // GET: Cadastro/Bloco
        public ActionResult Index()
        {
            List<BlocoView> lista = BlocoExecute.ListarTodosOsBlocos();
            return View(lista);
        }

        [HttpPost]
        // POST: Cadastro/Bloco/Novo
        public ActionResult Index(string filtro)
        {
            ViewData["filtro"] = filtro;
            List<BlocoView> lista = BlocoExecute.BuscarBlocos(filtro);
            return View("Index", lista);
        }

        [HttpGet]
        // GET: Cadastro/Bloco/Novo
        public ActionResult Novo()
        {
            return View("Novo", new BlocoView());
        }

        [HttpPost]
        // POST: Cadastro/Bloco/Novo
        public ActionResult Novo(BlocoView bloco)
        {
            bloco = BlocoExecute.CriarNovoBloco(bloco);

            return RedirectToAction("Index");
        }

        [HttpGet]
        // GET: Cadastro/Bloco/Editar
        public ActionResult Editar(Guid Id)
        {
            BlocoView item = BlocoExecute.CarregarBloco(Id);
            return View("Editar", item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Cadastro/Bloco/Editar
        public ActionResult Editar(BlocoView bloco)
        {
            bloco = BlocoExecute.EditarBloco(bloco);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // GET: Cadastro/Bloco/Excluir
        public ActionResult Excluir(Guid Id)
        {
            BlocoView item = BlocoExecute.CarregarBloco(Id);
            return View("Excluir", item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Cadastro/Bloco/Excluir
        public ActionResult Excluir(BlocoView bloco)
        {
            bool result = BlocoExecute.ExcluirBloco(bloco);
            return RedirectToAction("Index");
        }

    }
}