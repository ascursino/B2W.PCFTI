
namespace B2WTI.PCFTI.APRESENTACAO.SERVICES.Exe
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.APLICACAO.Operacao;
    using INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel;
    using Map;
    using System;
    using System.Collections.Generic;

    public static class ResponsavelExecute
    {
        static Execute Executar = new Execute();

        public static List<ResponsavelView> ListarTodosOsResponsaveis()
        {
            List<ResponsavelView> responsaveis = Executar.Cadastro.Responsavel.ListarResponsavel().DeDominParaView();
            return responsaveis;
        }

        public static List<ResponsavelView> BuscarResponsaveis(string filtro)
        {
            List<ResponsavelView> responsaveis = Executar.Cadastro.Responsavel.BuscarResponsaveis(filtro).DeDominParaView();
            return responsaveis;
        }

        public static ResponsavelView CarregarResponsavel(Guid ResponsavelId)
        {
            ResponsavelView responsavel = Executar.Cadastro.Responsavel.CarregarResponsavel(ResponsavelId).DeDominParaView();
            return responsavel;
        }

        public static ResponsavelView CriarNovoResponsavel(ResponsavelView responsavel, string CriadoPor, DateTime CriadoEm)
        {

            Responsavel objdomain = responsavel.DeViewParaDomin();
            objdomain.CriadoPor = CriadoPor;
            objdomain.CriadoEm = CriadoEm;

            responsavel = Executar.Cadastro.Responsavel.CriarNovoResponsavel(responsavel.DeViewParaDomin()).DeDominParaView();
            return responsavel;
        }

        public static ResponsavelView EditarResponsavel(ResponsavelView responsavel, string AlteradoPor, DateTime AlteradoEm)
        {
            Responsavel objdomain = responsavel.DeViewParaDomin();
            objdomain.CriadoPor = AlteradoPor;
            objdomain.CriadoEm = AlteradoEm;

            responsavel = Executar.Cadastro.Responsavel.AtualizarResponsavel(responsavel.DeViewParaDomin()).DeDominParaView();
            return responsavel;
        }

        public static bool ExcluirResponsavel(ResponsavelView responsavel, string AlteradoPor, DateTime AlteradoEm)
        {
            Responsavel objdomain = responsavel.DeViewParaDomin();
            objdomain.CriadoPor = AlteradoPor;
            objdomain.CriadoEm = AlteradoEm;

            bool ret = Executar.Cadastro.Responsavel.ExcluirResponsavel(responsavel.DeViewParaDomin());
            return ret;
        }

    }
}
