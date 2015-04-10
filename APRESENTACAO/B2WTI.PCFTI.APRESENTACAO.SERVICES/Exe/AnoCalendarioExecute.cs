
namespace B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe
{
    using APLICACAO.Operacao;
    using DOMINIO.Model.Global;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;
    using Map;
    using System;
    using System.Collections.Generic;

    public static class AnoCalendarioExecute
    {
        static Execute Executar = new Execute();

        public static List<AnoCalendarioView> ListarTodosOsAnoCalendarios()
        {
            List<AnoCalendarioView> AnoCalendarios = Executar.Cadastro.AnoCalendario.ListarAnoCalendarios().DeDominParaView();
            return AnoCalendarios;
        }

        public static List<AnoCalendarioView> BuscarAnoCalendarios(int filtro)
        {
            List<AnoCalendarioView> anoCalendario = Executar.Cadastro.AnoCalendario.BuscarAnoCalendarios(filtro).DeDominParaView();
            return anoCalendario;
        }

        public static AnoCalendarioView CarregarAnoCalendario(int Ano)
        {
            AnoCalendarioView AnoCalendario = Executar.Cadastro.AnoCalendario.CarregarAnoCalendario(Ano).DeDominParaView();
            return AnoCalendario;
        }

        public static AnoCalendarioView CriarNovoAnoCalendario(AnoCalendarioView AnoCalendario, string CriadoPor, DateTime CriadoEm)
        {
            AnoCalendario objdomin = AnoCalendario.DeViewParaDomin();
            objdomin.CriadoPor = CriadoPor;
            objdomin.CriadoEm = CriadoEm;

            AnoCalendario = Executar.Cadastro.AnoCalendario.CriarNovoAnoCalendario(objdomin).DeDominParaView();
            return AnoCalendario;
        }

        public static AnoCalendarioView EditarAnoCalendario(AnoCalendarioView AnoCalendario, string AlteradoPor, DateTime AlteradoEm)
        {
            AnoCalendario objdomin = AnoCalendario.DeViewParaDomin();
            objdomin.AlteradoPor = AlteradoPor;
            objdomin.AlteradoEm = AlteradoEm;

            AnoCalendario = Executar.Cadastro.AnoCalendario.AtualizarAnoCalendario(objdomin).DeDominParaView();
            return AnoCalendario;
        }

        public static bool ExcluirAnoCalendario(AnoCalendarioView AnoCalendario, string AlteradoPor, DateTime AlteradoEm)
        {
            AnoCalendario objdomin = AnoCalendario.DeViewParaDomin();
            objdomin.AlteradoPor = AlteradoPor;
            objdomin.AlteradoEm = AlteradoEm;

            bool ret = Executar.Cadastro.AnoCalendario.ExcluirAnoCalendario(objdomin);
            return ret;
        }

    }
}
