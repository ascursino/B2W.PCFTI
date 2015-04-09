
namespace B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe
{
    using APLICACAO.Operacao;
    using DOMINIO.Model.Sistema;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Sistema.ViewModel;
    using Map;
    using System;
    using System.Collections.Generic;

    public static class RegraExecute
    {
        static Execute Executar = new Execute();

        public static List<RegraView> ListarTodosAsRegras()
        {
            List<RegraView> regras = Executar.Sistema.Regra.ListarRegras().DeDominParaView();
            return regras;
        }

        public static List<RegraView> BuscarRegras(string filtro)
        {
            List<RegraView> regras = Executar.Sistema.Regra.BuscarRegras(filtro).DeDominParaView();
            return regras;
        }

        public static RegraView CarregarRegra(Guid RegraId)
        {
            RegraView regra = Executar.Sistema.Regra.CarregarRegra(RegraId).DeDominParaView();
            return regra;
        }

        public static RegraView CriarNovaRegra(RegraView regra, string CriadoPor, DateTime CriadoEm)
        {
            Regra objdomin = regra.DeViewParaDomin();
            objdomin.CriadoPor = CriadoPor;
            objdomin.CriadoEm = CriadoEm;

            regra = Executar.Sistema.Regra.CriarNovaRegra(objdomin).DeDominParaView();
            return regra;
        }

        public static RegraView EditarRegra(RegraView regra, string AlteradoPor, DateTime AlteradoEm)
        {
            Regra objdomin = regra.DeViewParaDomin();
            objdomin.AlteradoPor = AlteradoPor;
            objdomin.AlteradoEm = AlteradoEm;

            regra = Executar.Sistema.Regra.AtualizarRegra(objdomin).DeDominParaView();
            return regra;
        }

        public static bool ExcluirRegra(RegraView regra, string AlteradoPor, DateTime AlteradoEm)
        {
            Regra objdomin = regra.DeViewParaDomin();
            objdomin.AlteradoPor = AlteradoPor;
            objdomin.AlteradoEm = AlteradoEm;

            bool ret = Executar.Sistema.Regra.ExcluirRegra(objdomin);
            return ret;
        }

    }
}
