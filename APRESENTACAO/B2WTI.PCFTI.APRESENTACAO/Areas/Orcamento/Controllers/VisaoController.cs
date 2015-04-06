using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2WTI.PCFTI.APRESENTACAO.Areas.Orcamento.Controllers
{
    public class VisaoController : Controller
    {
        // GET: Orcamento/Visao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Anual()
        {
            return View();
        }

        public ActionResult Semestral()
        {
            return View();
        }
    }
}