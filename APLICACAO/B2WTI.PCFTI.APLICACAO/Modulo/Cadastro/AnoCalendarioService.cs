
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

    public interface IAnoCalendarioService : IService<AnoCalendario>
    {
        AnoCalendario NovoAnoCalendario(AnoCalendario Propriedade);
        IEnumerable<AnoCalendario> ListarTodasOsAnosCalendario();
    }

    public class AnoCalendarioService : Service<AnoCalendario>, IAnoCalendarioService
    {
        private readonly IRepositoryAsync<AnoCalendario> _repository;

        public AnoCalendarioService(IRepositoryAsync<AnoCalendario> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public AnoCalendario NovoAnoCalendario(AnoCalendario Propriedade)
        {
            return _repository.NovaPropriedade(Propriedade);
        }

        public IEnumerable<AnoCalendario> ListarTodasOsAnosCalendario()
        {
            return from item in _repository.Queryable()
                   where item.Ativo.Equals(true)
                   select item;
        }
    }
}
