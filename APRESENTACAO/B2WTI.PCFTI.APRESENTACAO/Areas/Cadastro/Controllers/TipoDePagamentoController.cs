using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe;
using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;

namespace B2WTI.PCFTI.APRESENTACAO.Areas.Cadastro.Controllers
{
    public class TipoDePagamentoController : Controller
    {
        // GET: Cadastro/TipoDePagamento
        public ActionResult Index()
        {
            List<TipoDePagamentoView> lista = TipoDePagamentoExecute.ListarTodosOsTiposDePagamentos();
            return View(lista);
        }

        [HttpPost]
        // POST: Cadastro/TipoDePagamento/Novo
        public ActionResult Index(string filtro)
        {
            ViewData["filtro"] = filtro;
            List<TipoDePagamentoView> lista = TipoDePagamentoExecute.BuscarTiposDePagamentos(filtro);
            return View("Index", lista);
        }

        [HttpGet]
        // GET: Cadastro/TipoDePagamento/Novo
        public ActionResult Novo()
        {
            return View("Novo", new TipoDePagamentoView());
        }

        [HttpPost]
        // POST: Cadastro/TipoDePagamento/Novo
        public ActionResult Novo(TipoDePagamentoView tipoDePagamento)
        {
            tipoDePagamento = TipoDePagamentoExecute.CriarNovoTipoDePagamento(tipoDePagamento,
                User.Identity.Name.ToString(), DateTime.Now);
            return RedirectToAction("Index");
        }

    }
}