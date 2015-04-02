
namespace B2WTI.PCFTI.APLICACAO.Modulo.Cadastro
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Services;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPropriedadeService : IService<Propriedade>
    {
        Propriedade NovaPropriedade(Propriedade Propriedade);
        IEnumerable<Propriedade> ListarTodasAsPropriedades();
    }

    public class PropriedadeService : Service<Propriedade>, IPropriedadeService
    {
        private readonly IRepositoryAsync<Propriedade> _repository;

        public PropriedadeService(IRepositoryAsync<Propriedade> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Propriedade NovaPropriedade(Propriedade Propriedade)
        {
            return _repository.NovaPropriedade(Propriedade);
        }

        public IEnumerable<Propriedade> ListarTodasAsPropriedades()
        {
            return from item in _repository.Queryable()
                   where item.Ativo.Equals(true)
                   select item;
        }
    }
}
