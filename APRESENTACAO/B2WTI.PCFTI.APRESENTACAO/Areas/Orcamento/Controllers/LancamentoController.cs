
using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Orcamento;

namespace B2WTI.PCFTI.APRESENTACAO.Areas.Orcamento.Controllers
{
    using B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class LancamentoController : Controller
    {
        // GET: Orcamento/Lancamento
        public ActionResult Index()
        {
            return View();
        }
    }
}