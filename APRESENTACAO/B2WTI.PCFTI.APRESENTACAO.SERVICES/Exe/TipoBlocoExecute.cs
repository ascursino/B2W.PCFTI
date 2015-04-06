
namespace B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe
{
    using B2WTI.PCFTI.APLICACAO.Operacao;
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
            List<TipoBlocoView> TipoBlocos = Executar.Cadastro.TipoBloco.BuscarTiposBlocos(filtro).DeDominParaView();
            return TipoBlocos;
        }

        public static TipoBlocoView CarregarTipoBloco(Guid TipoBlocoId)
        {
            TipoBlocoView TipoBloco = Executar.Cadastro.TipoBloco.CarregarTipoBloco(TipoBlocoId).DeDominParaView();
            return TipoBloco;
        }

        public static TipoBlocoView CriarNovoTipoBloco(TipoBlocoView TipoBloco)
        {
            TipoBloco = Executar.Cadastro.TipoBloco.CriarNovoTipoBloco(TipoBloco.DeViewParaDomin()).DeDominParaView();
            return TipoBloco;
        }

        public static TipoBlocoView EditarTipoBloco(TipoBlocoView TipoBloco)
        {
            TipoBloco = Executar.Cadastro.TipoBloco.AtualizarTipoBloco(TipoBloco.DeViewParaDomin()).DeDominParaView();
            return TipoBloco;
        }

        public static bool ExcluirTipoBloco(TipoBlocoView TipoBloco)
        {
            bool ret = Executar.Cadastro.TipoBloco.ExcluirTipoBloco(TipoBloco.DeViewParaDomin());
            return ret;
        }

    }
}
