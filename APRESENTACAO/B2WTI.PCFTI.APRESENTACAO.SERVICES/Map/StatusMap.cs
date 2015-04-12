
namespace B2WTI.PCFTI.APRESENTACAO.SERVICES.Map
{
    using B2WTI.PCFTI.APLICACAO.Operacao;
    using DOMINIO.Model.Global;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class StatusMap
    {

        public static List<Status> DeViewParaDomin(this List<StatusView> source)
        {
            List<Status> listStatus = new List<Status>();

            Parallel.ForEach<StatusView>(source, status =>
            {
                listStatus.Add(new Status()
                {
                    StatusId = status.StatusId,
                    Descricao = status.Descricao,
                    Ativo = status.Ativo
                });
            });
            return listStatus;
        }

        public static Status DeViewParaDomin(this StatusView source)
        {
            Status status = new Status()
            {
                StatusId = source.StatusId,
                Descricao = source.Descricao,
                Ativo = source.Ativo
            };
            return status;
        }

        public static List<StatusView> DeDominParaView(this List<Status> source)
        {
            List<StatusView> statusList = new List<StatusView>();

            Parallel.ForEach<Status>(source, status =>
            {
                statusList.Add(new StatusView()
                {
                    StatusId = status.StatusId,
                    Descricao = status.Descricao,
                    Ativo = status.Ativo
                });
            });

            return statusList;
        }

        public static StatusView DeDominParaView(this Status source)
        {
            StatusView status = new StatusView()
            {
                StatusId = source.StatusId,
                Descricao = source.Descricao,
                Ativo = source.Ativo
            };

            return status;
        }

    }
}
