
namespace B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe
{
    using APLICACAO.Operacao;
    using DOMINIO.Model.Global;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;
    using Map;
    using System;
    using System.Collections.Generic;

    public static class StatusExecute
    {
        static Execute Executar = new Execute();

        public static List<StatusView> ListarTodosOsStatus()
        {
            List<StatusView> status = Executar.Cadastro.Status.ListarStatus().DeDominParaView();
            return status;
        }

        public static List<StatusView> BuscarStatus(string filtro)
        {
            List<StatusView> status = Executar.Cadastro.Status.BuscarStatus(filtro).DeDominParaView();
            return status;
        }

        public static StatusView CarregarStatus(Guid StatusId)
        {
            StatusView status = Executar.Cadastro.Status.CarregarStatus(StatusId).DeDominParaView();
            return status;
        }

        public static StatusView CriarNovoStatus(StatusView status, string CriadoPor, DateTime CriadoEm)
        {
            Status objdomin = status.DeViewParaDomin();
            objdomin.CriadoPor = CriadoPor;
            objdomin.CriadoEm = CriadoEm;

            status = Executar.Cadastro.Status.CriarNovoStatus(objdomin).DeDominParaView();
            return status;
        }

        public static StatusView EditarStatus(StatusView status, string AlteradoPor, DateTime AlteradoEm)
        {
            Status objdomin = status.DeViewParaDomin();
            objdomin.AlteradoPor = AlteradoPor;
            objdomin.AlteradoEm = AlteradoEm;

            status = Executar.Cadastro.Status.AtualizarStatus(objdomin).DeDominParaView();
            return status;
        }

        public static bool ExcluirStatus(StatusView status, string AlteradoPor, DateTime AlteradoEm)
        {
            Status objdomin = status.DeViewParaDomin();
            objdomin.AlteradoPor = AlteradoPor;
            objdomin.AlteradoEm = AlteradoEm;

            bool ret = Executar.Cadastro.Status.ExcluirStatus(objdomin);
            return ret;
        }

    }
}
