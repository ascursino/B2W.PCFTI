
namespace B2WTI.PCFTI.APRESENTACAO.ORCAMENTO.Controllers
{
    using INFRAESTRUTURA.HORIZONTAL;
    using APLICACAO.Modulo.Cadastro;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.DOMINIO.Model.Global;

    public class LancamentoController : Controller
    {

        private PCFTIDataContext Data = new PCFTIDataContext();

        // GET: Lancamento
        public ActionResult Index()
        {
            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Fornecedor> fornecedorRepository = new Repository<Fornecedor>(context, unitOfWork);
                IFornecedorService fornecedorService = new FornecedorService(fornecedorRepository);

                var fornecedores = fornecedorService.ListarTodosOsFornecedores();

            }
            return View();
        }
    }
}