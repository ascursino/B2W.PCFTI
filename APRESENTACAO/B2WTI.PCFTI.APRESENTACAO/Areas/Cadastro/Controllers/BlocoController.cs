
namespace B2WTI.PCFTI.APRESENTACAO.Areas.Cadastro.Controllers
{
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using SERVICES;
    using B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe;

    public class BlocoController : Controller
    {
       
        // GET: Cadastro/Bloco
        public ActionResult Index()
        {    
            return View(BlocoExecute.ListarTodosOsBlocos());
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