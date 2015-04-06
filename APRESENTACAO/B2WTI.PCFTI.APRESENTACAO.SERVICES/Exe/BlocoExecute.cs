
namespace B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe
{
    using B2WTI.PCFTI.APLICACAO.Operacao;
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;
    using Map;
    using System;
    using System.Collections.Generic;

    public static class BlocoExecute
    {
        static Execute Executar = new Execute();

        public static List<BlocoView> ListarTodosOsBlocos()
        {
            List<BlocoView> blocos = Executar.Cadastro.Bloco.ListarBlocos().DeDominParaView();
            return blocos;
        }

        public static List<BlocoView> BuscarBlocos(string filtro)
        {
            List<BlocoView> blocos = Executar.Cadastro.Bloco.BuscarBlocos(filtro).DeDominParaView();
            return blocos;
        }

        public static BlocoView CarregarBloco(Guid BlocoId)
        {
            BlocoView bloco = Executar.Cadastro.Bloco.CarregarBloco(BlocoId).DeDominParaView();
            return bloco;
        }

        public static BlocoView CriarNovoBloco(BlocoView bloco, string CriadoPor, DateTime CriadoEm)
        {
            Bloco objdomin = bloco.DeViewParaDomin();
            objdomin.CriadoPor = CriadoPor;
            objdomin.CriadoEm = CriadoEm;

            bloco = Executar.Cadastro.Bloco.CriarNovoBloco(objdomin).DeDominParaView();
            return bloco;
        }

        public static BlocoView EditarBloco(BlocoView bloco)
        {
            bloco = Executar.Cadastro.Bloco.AtualizarBloco(bloco.DeViewParaDomin()).DeDominParaView();
            return bloco;
        }

        public static bool ExcluirBloco(BlocoView bloco)
        {
            bool ret = Executar.Cadastro.Bloco.ExcluirBloco(bloco.DeViewParaDomin());
            return ret;
        }

    }
}
