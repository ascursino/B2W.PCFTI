
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.EXTERNO.SharePoint.Data
{
    using DOMINIO.Model.Global;
    using TRANSVERSAL.Repositories;
    using TRANSVERSAL.Services;

    public class FornecedorService : Service<Fornecedor>, IFornecedorService
    {
        public FornecedorService(IRepositoryAsync<Fornecedor> repository)
            : base(repository)
        {
        }
    }
}
