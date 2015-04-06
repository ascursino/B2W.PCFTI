
namespace B2WTI.PCFTI.APRESENTACAO.Areas.Cadastro.Controllers
{
    using B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class TipoServicoController : Controller
    {

        // GET: Cadastro/TipoServico
        public ActionResult Index()
        {
            List<TipoServicoView> lista = TipoServicoExecute.ListarTodosOsTipoServicos();
            return View(lista);
        }

        [HttpPost]
        // POST: Cadastro/TipoServico/Novo
        public ActionResult Index(string filtro)
        {
            ViewData["filtro"] = filtro;
            List<TipoServicoView> lista = TipoServicoExecute.BuscarTipoServicos(filtro);
            return View("Index", lista);
        }

        [HttpGet]
        // GET: Cadastro/TipoServico/Novo
        public ActionResult Novo()
        {
            return View("Novo", new TipoServicoView());
        }

        [HttpPost]
        // POST: Cadastro/TipoServico/Novo
        public ActionResult Novo(TipoServicoView TipoServico)
        {
            TipoServico.Ativo = true;
            TipoServico = TipoServicoExecute.CriarNovoTipoServico(TipoServico);

            return RedirectToAction("Index");
        }

        [HttpGet]
        // GET: Cadastro/TipoServico/Editar
        public ActionResult Editar(Guid Id)
        {
            TipoServicoView item = TipoServicoExecute.CarregarTipoServico(Id);
            return View("Editar", item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Cadastro/TipoServico/Editar
        public ActionResult Editar(TipoServicoView TipoServico)
        {
            TipoServico = TipoServicoExecute.EditarTipoServico(TipoServico);
            return RedirectToAction("Index");
        }

        [HttpGet]
        // GET: Cadastro/TipoServico/Excluir
        public ActionResult Excluir(Guid Id)
        {
            TipoServicoView item = TipoServicoExecute.CarregarTipoServico(Id);
            return View("Excluir", item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: Cadastro/TipoServico/Excluir
        public ActionResult Excluir(TipoServicoView TipoServico)
        {
            bool result = TipoServicoExecute.ExcluirTipoServico(TipoServico);
            return RedirectToAction("Index");
        }

    }
}