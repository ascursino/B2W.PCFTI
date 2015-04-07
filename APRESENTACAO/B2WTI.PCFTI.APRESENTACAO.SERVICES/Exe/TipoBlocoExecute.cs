
namespace B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe
{
    using B2WTI.PCFTI.APLICACAO.Operacao;
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;
    using Map;
    using System;
    using System.Collections.Generic;

    public static class TipoBlocoExecute
    {
        static Execute Executar = new Execute();

        public static List<TipoBlocoView> ListarTodosOsTipoBlocos()
        {
            List<TipoBlocoView> TipoBlocos = Executar.Cadastro.TipoBloco.ListarTiposBlocos().DeDominParaView();
            return TipoBlocos;
        }

        public static List<TipoBlocoView> BuscarTipoBlocos(string filtro)
        {
            List<TipoBlocoView> tipoblocos = Executar.Cadastro.TipoBloco.BuscarTiposBlocos(filtro).DeDominParaView();
            return tipoblocos;
        }

        public static TipoBlocoView CarregarTipoBloco(Guid TipoBlocoId)
        {
            TipoBlocoView tipobloco = Executar.Cadastro.TipoBloco.CarregarTipoBloco(TipoBlocoId).DeDominParaView();
            return tipobloco;
        }

        public static TipoBlocoView CriarNovoTipoBloco(TipoBlocoView tipobloco, string CriadoPor, DateTime CriadoEm)
        {
            TipoBloco objdomin = tipobloco.DeViewParaDomin();
            objdomin.CriadoPor = CriadoPor;
            objdomin.CriadoEm = CriadoEm;

            tipobloco = Executar.Cadastro.TipoBloco.CriarNovoTipoBloco(objdomin).DeDominParaView();
            return tipobloco;
        }

        public static TipoBlocoView EditarTipoBloco(TipoBlocoView tipobloco, string CriadoPor, DateTime CriadoEm)
        {
            TipoBloco objdomin = tipobloco.DeViewParaDomin();
            objdomin.CriadoPor = CriadoPor;
            objdomin.CriadoEm = CriadoEm;

            tipobloco = Executar.Cadastro.TipoBloco.AtualizarTipoBloco(objdomin).DeDominParaView();
            return tipobloco;
        }

        public static bool ExcluirTipoBloco(TipoBlocoView tipobloco, string CriadoPor, DateTime CriadoEm)
        {
            TipoBloco objdomin = tipobloco.DeViewParaDomin();
            objdomin.CriadoPor = CriadoPor;
            objdomin.CriadoEm = CriadoEm;

            bool ret = Executar.Cadastro.TipoBloco.ExcluirTipoBloco(objdomin);
            return ret;
        }

    }
}
