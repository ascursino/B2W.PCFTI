
namespace B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe
{
    using B2WTI.PCFTI.APLICACAO.Operacao;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;
    using Map;
    using System;
    using System.Collections.Generic;

    public static class TipoServicoExecute
    {
        static Execute Executar = new Execute();

        public static List<TipoServicoView> ListarTodosOsTipoServicos()
        {
            List<TipoServicoView> TipoServicos = Executar.Cadastro.TipoServico.ListarTiposServicos().DeDominParaView();
            return TipoServicos;
        }

        public static List<TipoServicoView> BuscarTipoServicos(string filtro)
        {
            List<TipoServicoView> TipoServicos = Executar.Cadastro.TipoServico.BuscarTiposServicos(filtro).DeDominParaView();
            return TipoServicos;
        }

        public static TipoServicoView CarregarTipoServico(Guid TipoServicoId)
        {
            TipoServicoView TipoServico = Executar.Cadastro.TipoServico.CarregarTipoServico(TipoServicoId).DeDominParaView();
            return TipoServico;
        }

        public static TipoServicoView CriarNovoTipoServico(TipoServicoView TipoServico)
        {
            TipoServico = Executar.Cadastro.TipoServico.CriarNovoTipoServico(TipoServico.DeViewParaDomin()).DeDominParaView();
            return TipoServico;
        }

        public static TipoServicoView EditarTipoServico(TipoServicoView TipoServico)
        {
            TipoServico = Executar.Cadastro.TipoServico.AtualizarTipoServico(TipoServico.DeViewParaDomin()).DeDominParaView();
            return TipoServico;
        }

        public static bool ExcluirTipoServico(TipoServicoView TipoServico)
        {
            bool ret = Executar.Cadastro.TipoServico.ExcluirTipoServico(TipoServico.DeViewParaDomin());
            return ret;
        }

    }
}
