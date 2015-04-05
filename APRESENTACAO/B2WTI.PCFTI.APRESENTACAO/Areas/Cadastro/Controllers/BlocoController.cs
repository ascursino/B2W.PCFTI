
namespace B2WTI.PCFTI.APRESENTACAO.Areas.Cadastro.Controllers
{
    using B2WTI.PCFTI.APLICACAO.Operacao;
    using B2WTI.PCFTI.APRESENTACAO.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class BlocoController : Controller
    {
        Execute Executar = new Execute();

        // GET: Cadastro/Bloco
        public ActionResult Index()
        {
            
            return View(new List<BlocoView>());
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
            return View("Novo", bloco);
        }
    }
}